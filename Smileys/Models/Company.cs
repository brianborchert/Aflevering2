using System.ComponentModel.DataAnnotations;

namespace Smileys.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CVR { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Smileys { get; set; }
    }
}