using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MasterDance.Application.UseCases.Members.Models;
using MasterDance.Application.UseCases.Payments.Commands;
using MasterDance.Application.UseCases.Payments.Models;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace MasterDance.WebUI.Controllers
{
    public class PaymentsController : BaseController
    {
        [HttpPost("[action]")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(ICollection<MembershipModel>))]
        public async Task<ActionResult> MakePayment([FromBody] PaymentModel payment)
        {
            var result = await Mediator.Send(new AddPaymentCommand.Request(){Payment = payment, Creator = GetUserId()});
            return Ok(result);
        }
    }
}