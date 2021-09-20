using System;
using System.Threading.Tasks;
using Emaritna.Bll.IServices;
using Emaritna.Bll.ViewModels.Announcement;
using Emaritna.DAL.IUnitOfWork;
using System.Linq;
using System.Collections.Generic;

namespace Emaritna.Bll.Services
{
    public class AnnouncementServices : IAnnouncementServices
    {
        private readonly IUnitOfWork unitOfWork;

        public AnnouncementServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

 
        // get list of announcements by type listed as paging

        public async Task<List<AnnouncementViewModel>> GetAnnouncementListPagingByType(byte Type, int currentPage, int pageSize)
        {
            var _data = (await unitOfWork.AnnouncementsRepository.GetWith(a => a.IsActive == true && a.AnnouncmentType == Type
              && (!a.ExpirationDate.HasValue || a.ExpirationDate >= DateTime.Now)))
                 .OrderByDescending(a => a.ID).Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => new
                  AnnouncementViewModel
                 {
                     Announcement = a.Announcement,
                     AnnouncmentType = a.AnnouncmentType,
                     CreateAt = a.CreateAt,
                     ExpirationDate = a.ExpirationDate,
                     ID = a.ID,
                     IsActive = a.IsActive,
                     IsPoster = a.IsPoster,
                     ShowDays = a.ShowDays,
                     Title = a.Title

                 }).ToList();

            return _data;
        }



    }
}