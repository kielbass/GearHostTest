using GearHostTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHostTest.Classes
{
    internal class Query
    {
        public UserContext Db { get; private set; }

        public Query()
        {
            Db = new UserContext();
        }
        internal bool Authorization(User u)
        {
            if (string.IsNullOrEmpty(u.Name))
            {
                User[] temp = Db.Users.Select(x => x).Where(x => x.ID == u.ID).ToArray();
                if (temp.Count() > 0 && temp != null)
                {
                    if (PassCheck(temp[0], u))
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else
            {
                User[] temp = Db.Users.Select(x => x).Where(x => x.Name == u.Name).ToArray();
                if (temp.Count() > 0)
                {
                    if (PassCheck(temp[0], u))
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }

        }
        private bool PassCheck(User a, User b)
        {
            if (a.Pass.Equals(b.Pass))
            {
                return true;
            }
            else return false;
            
        }
        internal User GetUser(int i)
        {
            User[] temp = Db.Users.Select(x => x).Where(x => x.ID == i).ToArray();
            if(temp.Count() > 0)
            {
                return temp[0];
            }
            else
            {
                return null;
            }
        }
        internal void AddMessage(Message m)
        {
            Db.Messages.Add(m);
            Db.SaveChangesAsync();
        }
        internal void Close()
        {
            Db.Dispose();
        }
    }
}
