using ApiSample.Utility.Hooks.UpdateSystemInfo;
using ApiSample.Utility.Hooks.ValidFlag;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.DA.Tables
{
    public class EntityBase : ISystemInfo, IIsValid
    {
        public EntityBase()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.IsValid = true;
        }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsValid { get; set; }
    }
}
