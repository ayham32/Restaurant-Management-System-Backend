using RestaurantShared.Enums;
using System;
using System.Collections.Generic;

namespace RestaurantDataAccess.Entities;

public partial class Person
{
    public int PersonId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string NationalNo { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public enGender Gender { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public virtual User? User { get; set; } 
}
