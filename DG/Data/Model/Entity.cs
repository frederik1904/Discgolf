namespace DG.Data.Model;

public class Entity
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastChanged { get; set; }
    public int Version { get; set; }
}