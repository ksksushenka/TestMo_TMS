using TestMo_TMS.Models.Enums;

namespace TestMo_TMS.Models
{
    public record User
    {
        public UserType UserType { get; set; }
        public string? Username { get; init; } = string.Empty;
        public string? Password { get; init; } = string.Empty;
        public string? Token { get; set; }
    }
}
