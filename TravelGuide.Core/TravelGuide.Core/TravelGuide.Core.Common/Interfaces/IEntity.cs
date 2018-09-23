namespace TravelGuide.Core.Common.Interfaces
{
    internal interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}