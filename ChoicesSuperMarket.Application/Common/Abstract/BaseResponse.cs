using System;
using System.Collections.Generic;
using System.Text;

namespace ChoicesSuperMarket.Application.Common.Abstract
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}
