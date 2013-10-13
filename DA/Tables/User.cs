using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.DA.Tables
{
    public class User : EntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(300)]
        public string Email { get; set; }

        public string Token { get; set; }

        public string EncryptKey { get; set; }

        public string SaltKey { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}
