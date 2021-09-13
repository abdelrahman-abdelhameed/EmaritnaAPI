using Emaritna.DAL.BaseEntity;
using Emaritna.DAL.Entity.Clinic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Emaritna.DAL.Entity.Lookups
{
    public class Cities : BaseEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int ID { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }



        //related entities
        public ICollection<Accounts> Accounts { get; set; }
    }
}
