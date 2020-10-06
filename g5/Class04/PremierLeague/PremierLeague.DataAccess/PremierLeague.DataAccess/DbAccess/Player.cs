using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PremierLeague.DataAccess.PremierLeague.DataAccess.DbAccess
{
    [Table("Player")]
    public partial class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("FirstName")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [MaxLength(100)]
        public bool? IsActive { get; set; }
        public string City { get; set; }
        public int? Age { get; set; }
        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
