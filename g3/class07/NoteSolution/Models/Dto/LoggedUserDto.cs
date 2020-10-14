using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Dto
{
    public class LoggedUserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
