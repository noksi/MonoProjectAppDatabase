using System;
using ASPNETMVCCRUD.Models.Domain;
using System.Collections;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ASPNETMVCCRUD.Data;

namespace ASPNETMVCCRUD.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MVCDemoDbContext context;

        public UserRepository(MVCDemoDbContext context)
        {
            this.context = context;
        }

        public IEnumerable GetUsers()
        {
            return context.VehicleMake.ToList();
        }

        public Vehicle GetUserByID(int userId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return context.VehicleMake.Find(userId);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public void InsertUser(Vehicle user)
        {
            context.VehicleMake.Add(user);
        }

        public void DeleteUser(int userId)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Vehicle user = context.VehicleMake.Find(userId);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            _ = context.VehicleMake.Remove(user);
        }

        public void UpdateUser(Vehicle user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}