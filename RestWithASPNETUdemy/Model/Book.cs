using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model;

[Table("books")]
public class Book : Base
{
    [Required]
    [StringLength(100)]
    [Column("author")]
    public string Author { get; set; } = "author";
    [Required]
    [Column("launch_date")]
    public DateTime Launch { get; set; }
    [Required]
    [Column("price")]
    public decimal Price { get; set; }
    [Required]
    [StringLength(100)]
    [Column("title")]
    public string Title { get; set; } = "title";
}