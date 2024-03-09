using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspmvc.Models.Contact
{
    public class ContactModel
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar")]
        [Required]
        [StringLength(50)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [DisplayName("Phone")]
        [StringLength(11)]
        public string Phone { get; set; }

        [Column(TypeName = "nvarchar")]
        [Required]
        [DisplayName("Message")]
        [StringLength(500)]
        public string Message { get; set; }
    }
}
