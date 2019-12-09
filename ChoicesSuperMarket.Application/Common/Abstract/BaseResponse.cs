using System;

namespace ChoicesSuperMarket.Application.Common.Abstract
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}