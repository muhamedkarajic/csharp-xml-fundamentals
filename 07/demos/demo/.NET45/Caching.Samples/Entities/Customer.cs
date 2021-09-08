using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caching.Samples
{
  [Table("Customer", Schema = "SalesLT")]
  public class Customer
  {
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomerID { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    [Required]
    public string LastName { get; set; }

    public string CompanyName { get; set; }

    public string SalesPerson { get; set; }

    [EmailAddress]
    public string EmailAddress { get; set; }

    [Phone]
    public string Phone { get; set; }

    // Extra properties needed for insert/update
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public Guid rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }
  }
}
