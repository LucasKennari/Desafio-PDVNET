using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutos.Business.Model
{
    public interface IHandlerResult : IEquatable<IHandlerResult>
    {
        bool Result();
        string Message();
    }
}
