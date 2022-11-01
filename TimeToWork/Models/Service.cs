using System.ComponentModel.DataAnnotations;

namespace TimeToWork.Models
{
    public class Service
    {
        public int ServiceId { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string ServiceName { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<ServiceProvider>? ServiceProviders { get; set; }
    }
}
