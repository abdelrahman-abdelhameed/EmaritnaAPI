using Emaritna.DAL.BaseEntity;
using Emaritna.DAL.Entity.Lookups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Emaritna.DAL.Entity.Clinic
{
    public class Accounts : BaseEntity<long>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long ID { get; set; }
         
        public Guid Serial { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string PhoneNumber1 { get; set; }

        [MaxLength(50)]
        public string PhoneNumber2 { get; set; }

        [MaxLength(50)]
        public string Mobile1 { get; set; }

        [MaxLength(50)]
        public string Mobile2 { get; set; }

 

        public Nullable<int> PlanID { get; set; } // will add to parent clinic only 

        public bool Islocked { get; set; } // if account temporary locked

        // related entities
        [ForeignKey("CityID")]
        public Cities City { get; set; }

        [ForeignKey("PlanID")]
        public PaymentPlans Plan { get; set; }



        // selef join 
        [ForeignKey("ParentID")]
        public Accounts Parent { get; set; }

    }
}
