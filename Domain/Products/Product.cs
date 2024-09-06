using Flunt.Validations;

namespace IWantApp.Domain.Products;

public class Product : Entity
{
    public Category? Category { get; private set; }
    public Guid? CategoryId { get; private set; }
    public string? Description { get; private set; }
    public new string? Name { get; private set; }
    public bool? HasStock { get; private set; }
    public bool? IsActive { get; private set; } = true;

    public Product() { }

    public Product(string name, Category category, string description, bool hasStock, string createdBy)
    {
        Name = name;
        Category = category;
        Description = description;
        HasStock = hasStock;

        CreatedBy = createdBy;
        EditedBy = createdBy;
        CreatedOn = DateTime.Now;
        EditedOn = DateTime.Now;

        Validate();
    }

    private void Validate()
    {
        var contract = new Contract<Product>()
            .IsNotNullOrEmpty(Name, "Name")
            .IsGreaterOrEqualsThan(Name, 3, "Name")
            .IsNotNull(Category, "Category", "Category not found!")
            .IsNotNullOrEmpty(Description, "Description", "Description should not be null!")
            .IsGreaterOrEqualsThan(Description, 3, "Description", "Description should not be less than 3")
            .IsNotNullOrEmpty(CreatedBy, "Createdy", "Created by not found!")
            .IsNotNullOrEmpty(EditedBy, "EditedBy", "Editedby by not found!");

        AddNotifications(contract);
    }
}
