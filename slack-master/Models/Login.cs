
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SlackClone.Models
{
    [Table("Users")]
    public class Login
    {
        public int Id { get; set; }

        [Required]
      
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConnectionId { get; set; }
        public bool Status { get; set; }

    }
}
