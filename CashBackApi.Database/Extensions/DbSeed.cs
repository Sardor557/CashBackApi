using CashBackApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CashBackApi.Database.Extensions
{
    public static class DbSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            #region spUserTypes
            modelBuilder.Entity<spUserType>().HasData(new spUserType() { Id = 1, Name = "Admin", Status = 1, CreateUser = 1, CreateDate = DateTime.Now });
            modelBuilder.Entity<spUserType>().HasData(new spUserType() { Id = 2, Name = "Client", Status = 1, CreateUser = 1, CreateDate = DateTime.Now });
            #endregion

        }
    }
}