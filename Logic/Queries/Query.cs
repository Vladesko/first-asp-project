using Module20.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module20.Logic.Queries
{
    public static class Query
    {
        public static List<User> GetUsersToList()
        {
            UserDb db = new UserDb();
            return db.Users.ToList();
        }
    }
}
