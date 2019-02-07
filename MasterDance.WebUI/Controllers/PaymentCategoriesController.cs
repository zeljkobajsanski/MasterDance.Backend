using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MasterDance.Application.UseCases.PaymentCategories.Models;
using MasterDance.Application.UseCases.PaymentCategories.Queries;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace MasterDance.WebUI.Controllers
{
    public class PaymentCategoriesController : BaseController
    {
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, typeof(ICollection<PaymentCategoryModel>))]
        public async Task<ActionResult> GetPaymentCategories()
        {
            var result = await Mediator.Send(new GetPaymentGroupsQuery.Request());
            return Ok(result);
        }
    }
}