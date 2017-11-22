using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopCourses.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required(ErrorMessage = "Wprowadź imie")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Wprowadź nazwisko")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Wprowadź ulice")]
        [StringLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Wprowadź miasto")]
        [StringLength(100)]
        public string City { get; set; }

        [Required(ErrorMessage = "Wprowadź kod pocztowy")]
        [StringLength(6)]
        public string PostCode { get; set; }

        [Required(ErrorMessage ="Musisz wprowadzić numer telefonu")]
        [StringLength(20)]
        [RegularExpression(@"(\+\d{2})*[\d\s-]+",ErrorMessage ="Błędny format numeru telefonu")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="Wprowadź swój adres e-mail")]
        [EmailAddress(ErrorMessage ="Błędny format adresu e-mail")]
        public string Email { get; set; }

        public string Comment { get; set; }

        public DateTime DateAdded { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public decimal OrderValue { get; set; }

        public List<OrderItem> OrderItem { get; set; }
    }

    public enum OrderStatus
    {
        Nowe,
        Zrealizowane
    }
}