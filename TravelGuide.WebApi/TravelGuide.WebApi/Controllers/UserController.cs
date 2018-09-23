using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelGuide.Core.Common.Entities;
using TravelGuide.Core.Common.Interfaces;

namespace TravelGuide.WebApiNew.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _uow;

        public UserController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]User user)
        {
            try
            {
                var result = _uow.Users.Get(x => x.Email.Equals(user.Email) && x.SocialId.Equals(user.SocialId)).FirstOrDefault();

                if (result == null)
                {
                    result = _uow.Users.Add(user);
                }
                else
                {
                    _uow.Users.Update(user);
                }
                await _uow.SaveChangesAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}