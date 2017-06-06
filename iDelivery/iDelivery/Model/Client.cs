using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDelivery.Model
{
    public class Client
    {
        public static Client Current { set; get; }

        public int Id { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string SecretKey { set; get; }
    }
}
