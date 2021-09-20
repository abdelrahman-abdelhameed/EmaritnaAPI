using Emaritna.DAL.BaseEntity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Emaritna.DAL.Entity.Announcement
{
    public class Announcements : BaseEntity<long>
    {
       
       public string Announcement { get; set; }
    
       [MaxLength(100)]
       public string Title { get; set; }
       
       public byte AnnouncmentType { get; set; }

       public bool IsPoster { get; set; }
       
       public Nullable<int> ShowDays { get; set; }

       public Nullable<DateTime> ExpirationDate { get; set; }
       
              
    }
}