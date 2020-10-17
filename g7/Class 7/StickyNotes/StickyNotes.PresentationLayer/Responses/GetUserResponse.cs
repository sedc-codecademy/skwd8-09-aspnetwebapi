using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;

namespace StickyNotes.PresentationLayer.Responses
{
    public class GetUserResponse
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public SecurityToken Token { get; set; }

        public virtual ICollection<GetNoteResponse> Notes { get; set; }
    }
}
