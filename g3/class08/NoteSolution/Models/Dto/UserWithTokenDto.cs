using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Dto
{
    public class UserWithTokenDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Token { get; set; }
    }
}
