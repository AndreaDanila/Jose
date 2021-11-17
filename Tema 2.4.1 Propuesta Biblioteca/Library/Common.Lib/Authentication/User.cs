using Common.Lib.Core;

namespace Common.Lib.Authentication
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Surname1 { get; set; }
        public string Surname2 { get; set; }        
    }
}
