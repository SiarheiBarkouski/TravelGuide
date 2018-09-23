using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelGuide.Core.Common.Entities;
using TravelGuide.Core.Common.Interfaces;
using TravelGuide.Core.Common.Interfaces.Repositories;
using TravelGuide.Core.Repositories;

namespace TravelGuide.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly ICityRepository _cityRepository;
        private readonly ICoordinateRepository _coordinateRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IRouteImageRepository _routeImageRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly IUserRepository _userRepository;

        public UnitOfWork
        (
            RepositoryContext repositoryContext,
            ICityRepository cityRepository,
            ICoordinateRepository coordinateRepository,
            ICountryRepository countryRepository,
            IRouteImageRepository routeImageRepository,
            ILocationRepository locationRepository,
            IRouteRepository routeRepository,
            IUserRepository userRepository
        )
        {
            _repositoryContext = repositoryContext;
            _cityRepository = cityRepository;
            _coordinateRepository = coordinateRepository;
            _countryRepository = countryRepository;
            _routeImageRepository = routeImageRepository;
            _locationRepository = locationRepository;
            _routeRepository = routeRepository;
            _userRepository = userRepository;
        }

        public ICityRepository Cities => _cityRepository;
        public ICoordinateRepository Coordinates => _coordinateRepository;
        public ICountryRepository Countries => _countryRepository;
        public IRouteImageRepository RouteImages => _routeImageRepository;
        public ILocationRepository Locations => _locationRepository;
        public IRouteRepository Routes => _routeRepository;
        public IUserRepository Users => _userRepository;

        public Task<int> SaveChangesAsync()
        {
            return _repositoryContext.SaveChangesAsync();
        }

        public async Task InitializeDatabase()
        {
            await _repositoryContext.Database.MigrateAsync();

            var country = new Country { Name = "Belarus" };
            var cities = new List<City>
            {
                new City {Country = country, Name = "Minsk"},
                new City {Country = country, Name = "Vitebsk"},
                new City {Country = country, Name = "Mogilev"},
                new City {Country = country, Name = "Gomel"},
                new City {Country = country, Name = "Brest"},
                new City {Country = country, Name = "Grodno"},
                new City {Country = country, Name = "Orsha"}
            };

            if (!Countries.Get().Any())
                Countries.Add(country);

            if (!Cities.Get().Any())
                Cities.Add(cities);

            await SaveChangesAsync();
        }
    }
}