using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MasterDance.Application.UseCases.Dashboard.Models;
using MasterDance.Application.UseCases.Dashboard.Queries;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace MasterDance.WebUI.Controllers
{
    public class DashboardController : BaseController
    {
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, typeof(DashboardViewModel))]
        public async Task<ActionResult> GetDashboard()
        {
            var result = await Mediator.Send(new GetDashboardViewModelQuery.Request());
            return Ok(result);
        }

        [HttpGet("[action]")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(ICollection<NotificationModel>))]
        public async Task<ActionResult> GetNotifications()
        {
            var result = await Mediator.Send(new GetNotificationsQuery.Request());
            return Ok(result);
        }
    }
}