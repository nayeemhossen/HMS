using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Customize_Function
{
    public class AutoIdentity
    {
        private HospitalManagementSystemDBContex db = new HospitalManagementSystemDBContex();
        public string AutoIdGenerator(int usertype)
        {
            int lastid = db.Users.Where(x => x.Date == DateTime.Today && x.UserType == usertype).Select(x => x.CoreID).DefaultIfEmpty(0).Max() + 1;
            string incrementalid = "";
            if (lastid<=9)
            {
                incrementalid = "000" + lastid;
            }
            else if (lastid <= 99)
            {
                incrementalid = "00" + lastid;
            }
            else if (lastid <= 999)
            {
                incrementalid = "0" + lastid;
            }
            else 
            {
                incrementalid = lastid.ToString();
            }
            string autoGenId =DateTime.Now.ToString("yy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/" + incrementalid;    
            return autoGenId;
        }
        public int LastId(int usertype)
        {
            int lastid = db.Users.Where(x => x.Date == DateTime.Today && x.UserType == usertype).Select(x => x.CoreID).DefaultIfEmpty(0).Max() + 1;
            return lastid;
        }
        //public string Incrementalid(int usertype)
        //{
        //    var lastid = db.Users.Where(x => x.Date == DateTime.Today && x.UserType == usertype).Select(x => x.CoreID).DefaultIfEmpty(0).Max() + 1;
        //    string incrementalid = "";
        //    if (lastid <= 9)
        //    {
        //        incrementalid = "000" + lastid;
        //    }
        //    else if (lastid <= 99)
        //    {
        //        incrementalid = "00" + lastid;
        //    }
        //    else if (lastid <= 999)
        //    {
        //        incrementalid = "0" + lastid;
        //    }
        //    else
        //    {
        //        incrementalid = lastid.ToString();
        //    }
        //    return (incrementalid);
        //}

    }
   
}