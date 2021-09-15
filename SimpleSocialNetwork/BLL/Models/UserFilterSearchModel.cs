using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class UserAccountFilterSearchModel
    {
        public string City { get; set; }
        public int AgeFrom { get; set; } = 14;
        public int AgeTo { get; set; }
        public bool IsMale { get; set; }

        public bool WithPhoto { get; set; }

    }
}
