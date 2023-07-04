using Module20.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module20.Logic.Commands
{
    public static class Commands
    {
        /// <summary>
        /// Add new user in data base
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task AddAsync(User user)
        {
            UserDb db = new UserDb();
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
        }/// <summary>
        /// Update a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task UpdateUserAsync(User user)
        {
            UserDb db = new UserDb();
            foreach (var item in db.Users) //Busting people and find person by id from static class and update this
            {
                if (item.Id == DataStaticClass.Value)
                {
                    item.FirstName = user.FirstName;
                    item.LastName = user.LastName;
                    item.NumberPhone = user.NumberPhone;
                    item.Patronymic = user.Patronymic;
                    item.Adress = user.Adress;
                    item.Description = user.Description;
                    break;
                }
            }
            await db.SaveChangesAsync();
        }
        /// <summary>
        /// Remove user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task RemoveUserAsync(User user)
        {
            UserDb db = new UserDb();
            db.Users.Remove(user);
            await db.SaveChangesAsync();
        }

    }
}
