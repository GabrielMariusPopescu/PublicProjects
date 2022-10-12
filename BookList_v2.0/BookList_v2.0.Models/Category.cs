using System;
using System.ComponentModel.DataAnnotations;

namespace BookList_v2._0.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Category Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
