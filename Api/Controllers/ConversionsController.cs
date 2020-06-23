using Application.Services;
using System.Web.Http;

namespace Api.Controllers
{
    public class ConversionsController : ApiController
    {
        IConversionService _conversionService;

        public ConversionsController(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        public IHttpActionResult Get()
        {
            return Ok(_conversionService.GetAll());
        }
    }
}