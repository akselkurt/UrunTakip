using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrunTakipFormu.Models
{
    public class LoginControl
    {
        private LoginControl() { }

        public static LoginControl obj;

        private static readonly object mylockobject = new object();
        public static LoginControl GetInstance()
        {
            lock (mylockobject)
            {
                if (obj == null)
                {
                    obj = new LoginControl();
                }
            }
            return obj;
        }
        public bool IsLogin { get; set; }

        public bool IsAdmin { get; set; }

        public object UserID { get; set; }
        public object FullName { get; set; }
    }
}