using System.ComponentModel.DataAnnotations;

namespace Economiq.Shared.DTO
{
    public class RecipientDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Recipient Name Required")]
#pragma warning disable CS8618 // Non-nullable property 'Name' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Name { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Name' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

        [Required(ErrorMessage = "Recipient City Required")]
#pragma warning disable CS8618 // Non-nullable property 'City' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string City { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'City' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

#pragma warning disable CS8618 // Non-nullable property 'Street' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Street { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Street' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Zipcode' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Zipcode { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Zipcode' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}