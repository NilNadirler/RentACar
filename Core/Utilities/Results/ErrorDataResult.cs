using Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {
     

        public ErrorDataResult(T data, string messege) : base(data, false, messege)
        {

        }
        public ErrorDataResult(T data):base(data,false)
        {

        }
        public ErrorDataResult(string message, T dafault) :base(dafault,false,message)
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
