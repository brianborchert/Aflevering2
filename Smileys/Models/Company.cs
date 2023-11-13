using System.ComponentModel.DataAnnotations;

namespace Smileys.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Display(Name = "Navn")]
        public string Name { get; set; }

        [Display(Name = "CVR-nr.")]
        public int CVR { get; set; }

        [Display(Name = "Vejnavn")]
        public string Street { get; set; }

        [Display(Name = "Husnr.")]
        public string HouseNumber { get; set; }

        [Display(Name = "Postnr.")]
        public int ZipCode { get; set; }

        [Display(Name = "By")]
        public string City { get; set; }

        [Display(Name = "Smiley'er")]
        public string Smileys { get; set; }
    }
}