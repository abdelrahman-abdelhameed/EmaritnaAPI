using System;
using System.Collections.Generic;
using System.Text;

namespace UsersManagement.Bll.DTO
{
    public class ResponseData<T>
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public T ReturnData { get; set; }

        public int ResponseCode { get; set; }
    }
}
