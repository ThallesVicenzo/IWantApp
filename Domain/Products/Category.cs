﻿using Flunt.Validations;

namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public bool IsActive { get; private set; }
    public new string Name { get; private set; }

    public Category(string name, string createdBy, string editedBy)
    {
        Name = name;
        IsActive = true;
        CreatedBy = createdBy;
        EditedBy = editedBy;
        CreatedOn = DateTime.Now;
        EditedOn = DateTime.Now;

        Validate();
    }

    private void Validate()
    {
        var contract = new Contract<Category>()
                    .IsNotNullOrEmpty(Name, "Name")
                    .IsGreaterOrEqualsThan(Name, 3, "Name")
                    .IsNotNullOrEmpty(CreatedBy, "CreatedBy")
                    .IsNotNullOrEmpty(EditedBy, "EditedBy");

        AddNotifications(contract);
    }

    public void EditInfo(string name, bool active, string editedBy)
    {
        IsActive = active;
        Name = name;
        EditedBy = editedBy;
        EditedOn = DateTime.Now;

        Validate();
    }
}
