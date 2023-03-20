using System.ComponentModel.DataAnnotations;

namespace FirstAPIApp.DTOs
{
    public class MembershipType
    {
        [Key]
        public Guid IdMembershipType { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(100, ErrorMessage = "Campul Name poate sa contina maxim 100 caractere.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(250, ErrorMessage = "Campul Description poate sa contina maxim 250 caractere.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public int SubscriptionLengthInMonths { get; set; }
    }
}
