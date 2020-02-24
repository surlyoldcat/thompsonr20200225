using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriangleMan.API.Model
{
    public class ApiError
    {
        public string Message { get; set; }
        public string ErrorType { get; set; }

        public static ApiError FromException(Exception ex)
        {
            return new ApiError
            {
                Message = ex.Message,
                ErrorType = ex.GetType().ToString()
            };
        }
    }
}
