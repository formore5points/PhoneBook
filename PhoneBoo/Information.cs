using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBoo
{
    public class Information
    {
 
        public String InfoType { get; set; }
        public String Info { get; set; }

        public Information(string InfoType, string Info)
        {
            this.InfoType = InfoType;
            this.Info = Info;
        }

        public override string ToString()
        {
            return "InfoType: " + InfoType + "\r\n" + "Info: " + Info;
        }

    }
}
