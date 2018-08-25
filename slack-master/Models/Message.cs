using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlackClone.Models
{
    [Table("Message")]
    public class Message
    {
        public int Id { get; set; }
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public string Content { get; set; }
        public string DateTime { get; set; }
    }
}
