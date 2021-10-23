using System;
using MediatR;

namespace Emaritna.Bll.UserApartment.Edit
{
    public class Command : IRequest
    {
        public int  ID { get; set; }
        
        public string ApartmentNumber { get;  }

        public byte? TowerSection { get;  }

        public int? FloorNumber { get;  }

        public Command(int id , string apartmentNumber , byte? towerSection , int? floorNumber )
        {
            this.ID = id;
            this.ApartmentNumber = apartmentNumber;
            this.TowerSection = towerSection;
            this.FloorNumber = floorNumber;
          
        }
    }
}