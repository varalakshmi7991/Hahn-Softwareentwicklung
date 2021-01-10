using System;

namespace Hahn.ApplicatonProcess.December2020.Web.Exception
{
    public class HttpResponseException : SystemException
    {
        public int Status { get; set; } = 500;

        public object Value { get; set; }
    }
}
