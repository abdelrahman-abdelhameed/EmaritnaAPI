using System;
using System.ComponentModel.DataAnnotations;
using Emaritna.Bll.ViewModels.Base;


namespace Emaritna.Bll.ViewModels.Announcement
{
    public class AnnouncementViewModel : BaseViewModel<long>
    {
        [Required]
        public string Announcement { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public byte AnnouncmentType { get; set; }

        public bool IsPoster { get; set; }

        public Nullable<int> ShowDays { get; set; }

        public Nullable<DateTime> ExpirationDate { get; set; }
    }
}