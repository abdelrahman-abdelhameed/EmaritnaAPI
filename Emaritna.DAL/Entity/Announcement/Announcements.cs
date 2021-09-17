using Emaritna.DAL.BaseEntity;
using System;

namespace Emaritna.DAL.Entity.Announcement
{
    public class Announcements : BaseEntity<long>
    {
       
       public string Announcement { get; set; }
     
       public string Title { get; set; }
       
       public byte AnnouncmentType { get; set; }

       public bool IsPoster { get; set; }
       
       public Nullable<int> ShowDays { get; set; }

       public Nullable<DateTime> ExpirationDate { get; set; }
       
              
    }
}