namespace NetflixClone.Foundation.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
