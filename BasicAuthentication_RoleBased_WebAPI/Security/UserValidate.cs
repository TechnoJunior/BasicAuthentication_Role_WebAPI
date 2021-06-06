using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BasicAuthentication_RoleBased_WebAPI.Security
{
    public class UserValidate
    {
        public static bool login(String username, String password)
        {
            using(OfficeEntities obj = new OfficeEntities())
            {
                return obj.Users.Any(user => user.U_Name.Equals(username, StringComparison.OrdinalIgnoreCase) && user.U_Pass == password);
            }
        }

        public static User userDetails(String username, String password)
        {
            using(OfficeEntities obj1 = new OfficeEntities())
            {
                return obj1.Users.FirstOrDefault(user => user.U_Name.Equals(username, StringComparison.OrdinalIgnoreCase) && user.U_Pass == password);
            }
        }
    }
}