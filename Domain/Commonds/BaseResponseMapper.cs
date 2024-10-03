using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commonds
{
    public static class BaseResponseMapper
    {


        public static BaseResponse MapperBaseRespone(int status, string message)
        {
            return new BaseResponse()
            {
                statusCode = status,
                message = message
            };
        }


    }
}
