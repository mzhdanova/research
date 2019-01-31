namespace HsmmErrorSources.Models.Models
{
    public interface IHsmModelHolder
    {
        IHsmModel Model { get; set; }
        string Name { get; set; }
    }
}
