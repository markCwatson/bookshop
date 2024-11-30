﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage="Display Order must be between 1 and 100")]
        public int DisplayOrder { get; set; }
    }
}
