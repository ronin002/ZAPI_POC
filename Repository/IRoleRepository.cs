using ZurichAPI.Model.Entity;

namespace ZurichAPI.Repository
{
    public interface IRoleRepository
    {
        public List<Role> GetRoleUser(Guid idUserm);
        public List<Role> GetRolesCompany(Guid idCompany);
        public Role GetRoleById(Guid id);
        public bool AddRoleToUser(Role role, UserModel user);
        public bool Save(Role role);
        public bool Remove(Role role);
    }
}
