using  System;

namespace Emaritna.Bll.ViewModels.UserApartment
{
    public class UserApartmentViewModel
    {

        public int ID { get; set; }
        
        public string ApartmentNumber { get; set; }

        public byte? TowerSection { get; set; }

        public int? FloorNumber { get; set; }

        public string UserId { get; set; }
    }
}