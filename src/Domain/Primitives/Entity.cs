namespace Domain.Primitives;

public abstract class Entity
{
    public DateTime AddedTime { get; set; }
    public DateTime LastModified { get; set; }
}