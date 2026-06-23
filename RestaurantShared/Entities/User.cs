using RestaurantShared.Entities;
using System;
using System.Collections.Generic;

namespace RestaurantDataAccess.Entities;

public partial class User
{
    public int UserId { get; set; }

    public int PersonId { get; set; }

    public string Username { get; set; } = null!;

    public string HashPassword { get; set; } = null!;

    public bool IsActive { get; set; }
    
    public virtual Employee? Employee { get; set; } 

    public virtual Person Person { get; set; } = null!;
    public virtual ICollection<RefreshToken> RefreshToken{ get; set; } = new List<RefreshToken>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
