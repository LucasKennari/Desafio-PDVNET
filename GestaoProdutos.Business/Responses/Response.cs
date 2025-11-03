using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutos.Business.Model
{
    public class Response : IResponse
    {
        public Response()
        {

        }
        HandlerResult IResponse.Ok(bool result, string message)
        {
            return new HandlerResult()
            {
                Success = result,
                Message = message,
            };
        }
        HandlerResult IResponse.Invalid(bool result, string message, Exception exception)
        {
            return new HandlerResult()
            {
                Success = result,
                Message = message,
                Ex = exception

            };
        }
    }
}
