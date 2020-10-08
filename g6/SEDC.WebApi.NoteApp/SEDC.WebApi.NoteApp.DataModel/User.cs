using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEDC.WebApi.NoteApp.DataModel
{
    [Dapper.Contrib.Extensions.Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // 0
        public string Username { get; set; } //1
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Computed]
        public IEnumerable<Note> Notes { get; set; }
    }
}