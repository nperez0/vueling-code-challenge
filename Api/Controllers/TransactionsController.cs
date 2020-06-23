using Application.Services;
using System.Web.Http;

namespace Api.Controllers
{
    public class TransactionsController : ApiController
    {
        ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public IHttpActionResult Get()
        {
            return Ok(_transactionService.GetAll());
        }

        public IHttpActionResult Get(string id)
        {
            return Ok(_transactionService.GetProductReport(id));
        }
    }
}