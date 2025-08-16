using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSTeam.Models.Internal;

[Table("users_information")]
public class UsersInformation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid UserId { get; set; }
    
    [Required]
    [StringLength(50)]
    public string? FirstName { get; set; }
    
    [Required]
    [StringLength(50)]
    public string? MiddleName { get; set; }
    
    [Required]
    [StringLength(50)]
    public string? LastName { get; set; }
    
    [Required]
    public UserLevel Level { get; set; }
    
    [Required]
    public Status Status { get; set; }
    
    public DateTime Created { get; set; }
    public DateTime UpdatedDate { get; set; }
}

//outside UsersInformation 

public enum UserLevel
{
    [Display(Name = "Admin")] 
    ADMIN,

    [Display(Name = "User")] 
    USER,
}

public enum Status
{
    [Display(Name = "ACTIVE")] 
    ACTIVE,

    [Display(Name = "INACTIVE")] 
    INACTIVE  
}   