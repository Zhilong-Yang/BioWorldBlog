using System;
using System.Collections.Generic;
using System.Text;

namespace BioWorld.Application.Response
{
    public class SuccessResponse<T> : Response<T>
    {
        public SuccessResponse()
        {
            IsSuccess = true;
        }

        public SuccessResponse(T item = default(T)) : base(item)
        {
            IsSuccess = true;
        }
    }

    public class SuccessResponse : Response
    {
        public SuccessResponse()
        {
            IsSuccess = true;
        }
    }
}
