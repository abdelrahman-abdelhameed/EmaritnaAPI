using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Emaritna.Bll.ViewModels.Announcement;

namespace Emaritna.Bll.IServices
{
    public interface IAnnouncementServices
    {
        Task<List<AnnouncementViewModel>> GetAnnouncementListPagingByType(byte type, int currentPage, int pageSize = 10);

        Task AddNewAnnouncement(AnnouncementViewModel dataObj);

        Task EditAnnouncement(AnnouncementViewModel dataObj);

        Task DeleteAnnouncement(long id);

    }
}