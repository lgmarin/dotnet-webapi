using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("account")]
public class Account
{
    public Guid AccountId {get; set;}

    [Required]
    public DateTime DateCreated {get; set;}

    [Required]
    public string AccuntType {get; set;}

    [ForeignKey(nameof(Owner))]
    public Guid OwnerId {get; set;}

    public Owner Owner {get; set;}
}