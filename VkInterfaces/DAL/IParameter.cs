namespace Vk.Interfaces.DAL
{
    public interface IParameter
    {
        
        string Name { get; set; }

        string Value { get; set; }

        bool Required { get; set; }

        string Excludes { get; set; }
    }
}
