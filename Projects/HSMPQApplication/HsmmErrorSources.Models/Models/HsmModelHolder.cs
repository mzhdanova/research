namespace HsmmErrorSources.Models.Models
{
    public class HsmModelHolder : IHsmModelHolder
    {
        public HsmModelHolder(string name, IHsmModel model) {
            this.Name = name;
            this.Model = model;
        }
        public IHsmModel Model { get; set; }
        public string Name { get; set; }
    }
}
