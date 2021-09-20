using Emaritna.DAL.BaseEntity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emaritna.DAL.Entity.Users
{
    public class UserApartments : BaseEntity<int>
    {
        [MaxLength(10)]
        public string ApartmentNumber { get; set; }

        public Nullable<byte> TowerSection { get; set; }

        public Nullable<int> FloorNumber { get; set; }

        public string UserId { get; set; }
        

       [ForeignKey(nameof(UserId))]
        public ApplicationUser UserData { get; set; }
        
        
        

       
    }
}