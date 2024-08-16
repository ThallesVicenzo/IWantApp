namespace IWantApp.Domain;

public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public required string  Name { get; set; }
    public required string CreatedBy { get; set; }
    public required DateTime CreatedOn { get; set; }
    public required DateTime EditedOn { get; set; }
    public required string EditedBy { get; set; }
}
