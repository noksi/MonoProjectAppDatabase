using ASPNETMVCCRUD.Models.Domain;
using System.Collections;

namespace ASPNETMVCCRUD.Repository
{
    public interface IUserRepository
    {
        IEnumerable GetUsers();
        Vehicle GetUserByID(int userId);
        void InsertUser(Vehicle user);
        void DeleteUser(int userId);
        void UpdateUser(Vehicle user);
        void Save();
    }
}
