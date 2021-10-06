using Emaritna.Bll.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Emaritna.Bll.Announcements.List;
using Emaritna.Bll.ViewModels.Announcement;
using create = Emaritna.Bll.Announcement.Create;
using MediatR;

namespace Emaritna.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IMediator _mediator;


        public AnnouncementController(IMediator mediator)
        {
            _mediator = mediator;
        }


        #region get all Announcement

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAllAnnouncementPaging(int currentPage = 1, int pageSize = 10)
        {
            var query = new Query(1, currentPage, pageSize);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        #endregion


        #region Add New Announcement

        [HttpPost]
        [Route("creat")]
        public async Task<IActionResult> Create([FromBody] AnnouncementViewModel dataObj)
        {
            var command = new create.Command(dataObj.Announcement, dataObj.Title,
                dataObj.AnnouncmentType, dataObj.IsPoster, dataObj.ShowDays, dataObj.ExpirationDate);
            await _mediator.Send(command);
            return Ok();
        }

        #endregion
    }
}