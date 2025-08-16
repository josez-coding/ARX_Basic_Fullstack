using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FSTeam.Models.Internal;

namespace FSTeam.Model.Internal;

[Table("users")]
public class Users
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    [ForeignKey("Credentials")]
    public Guid CredentialsId { get; set; }
    
    [Required]
    [ForeignKey("Information")]
    public Guid InformationId { get; set; }
    
    public virtual UsersCredentials Credentials { get; set; }
    public virtual UsersInformation Information { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}