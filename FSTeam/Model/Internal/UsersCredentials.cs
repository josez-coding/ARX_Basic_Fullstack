using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSTeam.Models.Internal;

[Table("users_credentials")]
public class UsersCredentials
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(50)]
    [Column(TypeName = "varchar(50)")]
    public string UserName { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(255)")]
    public string Password { get; set; }
    
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string Username { get; set; }
}