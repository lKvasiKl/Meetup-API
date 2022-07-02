using Data.Entities;

namespace Business.Models
{
    public class LoginSuccessModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public RoleModel Role { get; set; }
        public string Jwt { get; set; }

        public LoginSuccessModel(User user, string jwt)
        {
            Id = user.Id;
            Email = user.Email;
            Role = new RoleModel
            {
                Id = user.Role.Id,
                Name = user.Role.Name
            };
            Jwt = jwt;
        }
    }
}
