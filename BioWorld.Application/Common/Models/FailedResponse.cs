using System;

namespace BioWorld.Application.Common.Models
{
    public class FailedResponse<T> : Response<T>
    {
        public Exception Exception { get; set; }

        public FailedResponse(int responseCode)
        {
            ResponseCode = responseCode;
        }

        public FailedResponse(string message)
        {
            Message = message;
        }

        public FailedResponse(int responseCode, string message, Exception ex = null)
        {
            ResponseCode = responseCode;
            Message = message;
            Exception = ex;
        }
    }

    public class FailedResponse : Response
    {
        public Exception Exception { get; set; }

        public FailedResponse(int responseCode)
        {
            ResponseCode = responseCode;
        }

        public FailedResponse(string message)
        {
            Message = message;
        }

        public FailedResponse(int responseCode, string message, Exception ex = null)
        {
            ResponseCode = responseCode;
            Message = message;
            Exception = ex;
        }
    }
}