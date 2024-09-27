namespace ZurichAPI.Model.Entity
{
    public class UserAndRole
    {
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }

    }
}
