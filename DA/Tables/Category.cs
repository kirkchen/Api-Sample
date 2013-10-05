using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ApiSample.DA.Tables
{
    public class Category : EntityBase
    {
        [Key]
        public int Id { get; set; }

        public int? ParentId { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [ForeignKey("ParentId")]
        public ICollection<Category> Categories { get; set; }        

        public ICollection<Product> Products { get; set; }
    }
}
