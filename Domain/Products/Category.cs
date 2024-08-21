using Flunt.Validations;

namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public bool IsActive { get; set; }

    public Category(string name, string createdBy, string editedBy)
    {
        var contract = new Contract<Category>()
            .IsNotNullOrEmpty(name, "Name")
            .IsNotNullOrEmpty(createdBy, "createdBy")
            .IsNotNullOrEmpty(editedBy, "editedBy");

        AddNotifications(contract);

        Name = name;
        IsActive = true;
        CreatedBy = createdBy;
        EditedBy = editedBy;
        CreatedOn = DateTime.Now;
        editedBy = "Test";
        EditedOn = DateTime.Now;
    }
}
