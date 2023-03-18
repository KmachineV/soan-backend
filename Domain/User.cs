using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace soan_backend.Domain

{
    public class User
    {
        [Key]
        public int Id { get; set; }              
        public string Email { get; set; }
        public string Name { get; set; }

        public string Password_Bash { get; set; }

        //Relations 
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }



    }
}
