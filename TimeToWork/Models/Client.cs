using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace TimeToWork.Models
{
    public class Client
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "Ім'я")]
        public string FirstMidName { get; set; }

        [Display(Name = "Повне ім'я")]
        public string FullName
        {
            get
            {
                return LastName + " " + FirstMidName;
            }
        }

        [Display(Name = "Номер телефону")]
        public long PhoneNumber { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
    }
}
