using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module20.DataBase
{
    //@"Data Source=D:\Обучение\Программирование\С#\Skillbox\ДЗ\Module20\DataBase\UsersSQLite.db"
    public class UserDb : DbContext
    {       
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=D:\Обучение\Программирование\С#\Skillbox\ДЗ\Module20\DataBase\UsersSQLite.db");
        }
    }
}
