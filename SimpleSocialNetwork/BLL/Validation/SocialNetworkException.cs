using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Validation
{
    public class SocialNetworkException:Exception
    {
        public string Property { get; set; }          
        public SocialNetworkException(string message):base(message)
        {
                
        }

        public SocialNetworkException(string message, string property): base(message)
        {
            Property = property;
        }
    }
}
