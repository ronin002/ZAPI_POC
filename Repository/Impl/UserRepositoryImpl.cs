using ZurichAPI.Data;
using ZurichAPI.Model.Entity;

namespace ZurichAPI.Repository.Impl
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepositoryImpl(DataContext context)
        {
            _context = context;
        }
        public UserModel GetById(Guid id)
        {
            var user = new UserModel();
            user = _context.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }




        public UserModel GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public List<UserAndRole> GetAllUsers()
        {
            var users = _context.Users.ToList();
            var roleUsers = _context.RoleUsers.ToList();
            var roles = _context.Roles.ToList();
            /*
            var query = (from c in users
                         join ua in roles on c.Id equals ua.User.Id
                         select new { c.Id, c.Name, c.LastName ,c.Email}).Distinct().ToList<object>();
            */

            var UsersComRoles = (from c in users
                                 join ru in roleUsers on c.Id equals ru.User.Id
                                 select new { c.Id, c.Name, c.Last_Name, c.Email, ru.RoleId }).Distinct().ToList();


            var UsersERoles = (from r in roles
                               join q in UsersComRoles on r.Id equals q.RoleId
                               select new UserAndRole
                               {
                                   UserId = q.Id,
                                   UserName = q.Name,
                                   LastName = q.Last_Name,
                                   Email = q.Email,
                                   RoleId = r.Id,
                                   RoleName = r.Name,

                               }).Distinct().ToList<UserAndRole>();

            //a => !db.Producao.Any(b => b.Chapa == a.Chapa && b.Data == new DateTime(2014, 09, 02)) && a.Codsubord == "CB02010100");

            var UsersSemRoles = users
                .Where(u => !UsersComRoles.Any(ur => ur.Id == u.Id))
                .Select(o =>
                    new UserAndRole
                    {
                        UserId = o.Id,
                        UserName = o.Name,
                        LastName = o.Last_Name,
                        Email = o.Email,
                        RoleId = Guid.Empty,
                        RoleName = "",

                    }).ToList();

            var result = UsersERoles.Concat(UsersSemRoles).OrderBy(x => x.UserName).ToList();
            //Executing the LINQ query
            // var result = query.ToList();
            return result;
        }
        public UserModel Login(string email, string password)
        {
            return _context.Users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && x.Password == password);
        }

        public bool Save(UserModel user)
        {

            var userExists = _context.Users.Where(x => x.Email == user.Email).FirstOrDefault();
            if (userExists != null)
            {
                return false;
            }
            user.Creation_Date = DateTime.UtcNow;
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;

        }

        public bool Update(UserModel user)
        {

            var userExists = _context.Users.Any(x => x.Email == user.Email);
            if (!userExists)
            {
                return false;
            }
            _context.Users.Update(user);
            _context.SaveChanges();
            return true;

        }
    }
}
