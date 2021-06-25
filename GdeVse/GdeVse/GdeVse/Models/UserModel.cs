using System;
using System.Collections.Generic;
using System.Text;

namespace GdeVse.Models
{
    class UserModel
    {
        public int UserId { get; set; }

        public int UserName { get; set; }

        public string Gmail { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public bool Resolution { get; set; }
    }
}
