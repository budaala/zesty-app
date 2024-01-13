using System.ComponentModel.DataAnnotations;

namespace zesty_api.Models
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

    }
}
