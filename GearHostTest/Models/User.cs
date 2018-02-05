using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHostTest.Models
{
    class User
    {
        public int ID { get; set; }
        public string Pass { get; set; }
        public string Name { get; set; }

        public ICollection<Message> Message { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", ID.ToString(), Name);
        }
    }
}
