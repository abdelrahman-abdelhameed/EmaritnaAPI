using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Emaritna.DAL.BaseEntity
{
    public class BaseEntity<T>
    {

        [Key]
        public virtual T ID { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}
