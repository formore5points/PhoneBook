using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBoo
{
    public class Contact : Person
    {
        public String Company { get; set; }

        public Information info { get; set; }

        public Contact(int ID,string Name,string Surname,string Company,Information info)
        {
            this.ID = ID;
            this.Name = Name;
            this.Surname = Surname;
            this.Company = Company;
            this.info = info;
           
        }

        public override string ToString()
        {
            return "ID: "+ID+ "\r\n" + "Name: "+Name+ "\r\n"+"Surname: "+Surname+ "\r\n"+"Company: "+Company+"\r\n"+"InfoType: "+info.InfoType+ "\r\n"+"Info: "+info.Info;
        }

    }
}
