using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.Auth
{
    public class AuthResponseModel
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}
