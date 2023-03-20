using System.ComponentModel.DataAnnotations;

namespace soan_backend.Domain
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
}
