using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data) : base(true, data)
        {
        }

        public SuccessDataResult(string message,T data) : base(message, true, data)
        {
        }
        public SuccessDataResult(string message) : base(message, false, default)
        {

        }
        public SuccessDataResult() : base(false, default)
        {

        }
    }
}
