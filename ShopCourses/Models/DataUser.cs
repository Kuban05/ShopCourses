using System.ComponentModel.DataAnnotations;

namespace ShopCourses.Models
{
    public class DataUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }

        [RegularExpression(@"(\+\d{2})*[\d\s-]+",ErrorMessage ="Błędny format numeru telefonu")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage ="Błędny format adresu e-mail")]
        public string Email { get; set; }
    }
}