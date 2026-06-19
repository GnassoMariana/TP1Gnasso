using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Entities;

namespace TP1Gnasso.WForms.Classes
{
    public static class SystemUsers
    {
        public static List<User> Users { get; } =
        [
            new User
            {
                UserName = "admin",
                Password = "1234"
            },
            new User
            {
                UserName = "empleado",
                Password = "1234"

            }

        ];
    }
}
