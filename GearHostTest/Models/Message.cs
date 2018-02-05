using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHostTest.Models
{
    class Message
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public User User { get; set; }

        public int UserID { get; set; }

        public string GetName {
            get
            {
                return string.Format("{0} {1}", User.ToString(), Text);
            }
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", User.ToString(), Text);
        }
    }
}
