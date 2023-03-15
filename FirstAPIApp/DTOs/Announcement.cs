using System.ComponentModel.DataAnnotations;

namespace FirstAPIApp.DTOs
{
    public class Announcement
    {
        [Key]
        public Guid IdAnnouncement { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public DateTime ValidFrom { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public DateTime ValidTo { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(250, ErrorMessage = "Campul Title poate sa contina maxim 250 caractere.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(250, ErrorMessage = "Campul Text poate sa contina maxim 250 caractere.")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(1000, ErrorMessage = "Campul Tags poate sa contina maxim 1000 caractere.")]
        public string Tags { get; set; }
    }
}
