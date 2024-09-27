using ZurichAPI.Model.Entity;

namespace ZurichAPI.Repository
{
    public interface IUserRepository
    {
        public bool Save(UserModel user);
        public bool Update(UserModel user);
        
        public List<UserAndRole> GetAllUsers();
        public UserModel GetById(Guid id);
        public UserModel GetByEmail(string email);
        public UserModel Login(string email, string password);
    }
}
