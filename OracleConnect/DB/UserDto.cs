using FluentValidation;

namespace OracleConnect.DB
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
    public class ValidationUserDto: AbstractValidator<UserDto>
    {
        public ValidationUserDto() 
        {
            RuleFor(r => r.Email).EmailAddress().NotEmpty().NotNull();
        }
    }
}
