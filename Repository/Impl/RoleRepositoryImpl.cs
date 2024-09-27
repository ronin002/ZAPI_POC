using ZurichAPI.Data;
using ZurichAPI.Model.Entity;

namespace ZurichAPI.Repository.Impl
{
    public class RoleRepositoryImpl : IRoleRepository
    {
        private readonly DataContext _context;

        public RoleRepositoryImpl(DataContext context)
        {
            _context = context;
        }

        public List<Role> GetRoleUser(Guid userId)
        {
            
            List<Role> roles = new List<Role>();
            return roles;
        }

        private bool UserHasRole(List<UserModel> users, Guid userId)
        {
            users.Where(u => u.Id == userId).ToList();
            return true;
        }

        public List<UserModel> GetUsersWithThisRole(Role role)
        {
            var rolesId = _context.RoleUsers.Where(ru => ru.RoleId == role.Id);
            var allUsers = _context.Users.Where(u => rolesId.Any(ru => ru.UserId == u.Id)).ToList();
            return allUsers;
            //var users = _context.Users.Where(x => x.Roles.Any(r => r.Id == role.Id)).ToList();
        }

        public Role GetRoleById(Guid idRole)
        {
            var role = _context.Roles.Where(u => u.Id == idRole).FirstOrDefault();

            if (role != null)
                return role;
            return null;
        }

        public bool AddRoleToUser(Role role, UserModel user)
        {
            var roleExists = _context.Roles.Any(x=> x.Id == role.Id);

            var userExists = _context.Users.Any(x => x.Id == user.Id);

            if (!roleExists || !userExists) //|| role.CompanyId != user.CompanyId)
            {
                return false;
            }

            return true;
        }

        public bool Save(Role role)
        {
            var roleExists = _context.Roles.Where(x => x.Name == role.Name).FirstOrDefault();
            if (roleExists != null)
            {
                return false;
            }

            _context.Roles.Add(role);
            _context.SaveChanges();
            return true;
        }

        public bool RemoveRoleToUser(Guid roleId, Guid userId)
        {
            var roleExists = _context.RoleUsers.Where(x =>  x.UserId == userId).FirstOrDefault();
            if (roleExists == null)
            {
                return false;
            }
            _context.RoleUsers.Remove(roleExists);
            _context.SaveChanges();
            return true;
        }

        public bool Remove(Role role)
        {
            var roleHasUsers = _context.RoleUsers.Any(x => x.RoleId == role.Id);
            if (roleHasUsers)
                return false;

            _context.Roles.Remove(role);
            _context.SaveChanges();
            return true;
        }



        public List<Role> ObjetctRoles(Guid idUser)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetRolesCompany(Guid idCompany)
        {
            throw new NotImplementedException();
        }
    }
}
