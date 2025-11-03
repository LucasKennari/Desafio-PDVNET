using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutos.Business.Model
{
    public class HandlerResult 
    {
        internal bool Success { get; set; }
        internal string Message { get; set; }
        internal Exception Ex { get; set; }
    }
}
