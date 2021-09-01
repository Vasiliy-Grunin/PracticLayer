

namespace DAL.Entitys.Interfaces
{
    /// <summary>
    /// Requared field for a people
    /// </summary>
    public interface IPeople
    {
        string Name { get; set; }
        string LastName { get; set; }
        string MidleName { get; set; }
    }
}
