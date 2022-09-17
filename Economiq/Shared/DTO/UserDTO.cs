namespace Economiq.Shared.DTO
{
    public class UserDTO
    {
#pragma warning disable CS8618 // Non-nullable property 'Lname' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Lname { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Lname' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Fname' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Fname { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Fname' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Username' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Username { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Username' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'email' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string email { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'email' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'password' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string password { get; set; } //This way of authing should in no way shape or form be allowed to persist to release.
#pragma warning restore CS8618 // Non-nullable property 'password' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Gender' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Gender { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Gender' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'City' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string City { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'City' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}