using ApiSample.Utility.Hooks.Audit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ApiSample.DA.Tables
{    
    public partial class Category : EntityBase
    {        
        public int Id { get; set; }

        public int? ParentId { get; set; }
     
        public string Name { get; set; }
        
        public ICollection<Category> Categories { get; set; }        

        public ICollection<Product> Products { get; set; }        
    }

    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category
    {
    }
     
    public class CategoryMetadata
	{
        [Key]
        public int Id { get; set; }

        public int? ParentId { get; set; }

        [StringLength(100)]
        [Required]
        [RequireAudit]
        public string Name { get; set; }

        [ForeignKey("ParentId")]
        public ICollection<Category> Categories { get; set; }

        public ICollection<Product> Products { get; set; }
	}
}
