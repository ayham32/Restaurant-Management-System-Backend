using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantShared.DTOs.UserRolesDTOs
{
    public class ReadUserRolesDto
    {

        public int UserRolesId { get; set; }
        public int UserId {  get; set; }
        public int RoleId { get; set; } 
    }
}
