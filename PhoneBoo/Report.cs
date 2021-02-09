using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PhoneBoo
{
    public class Report
    {
        public List<Contact> Contacts { get; set; }// = new List<Contact>();

        public Report(List<Contact> Contacts)
        {
            this.Contacts = Contacts;
        }

        public int getRegisteredPhoneNumberCount()
        {
            int count = 0;

            foreach (Contact c in Contacts)
            {
                if(c.info.InfoType == "Phone")
                {
                    count++;
                }

            }
            return count;
        }
        
        public int getRegisteredPersonCount()
        {
            return Contacts.Count;
        }

        public string getReportasString()
        {
            Dictionary<string,int> Locations = new Dictionary<string,int>();

            foreach (Contact c in Contacts)
            {
                if (c.info.InfoType == "Location")
                {
                    if (Locations.ContainsKey(c.info.Info))
                    {
                        int value = Locations[c.info.Info];
                        value++;
                        Locations.Remove(c.info.Info);
                        Locations.Add(c.info.Info, value);
                    }
                    else
                    {
                        Locations.Add(c.info.Info, 1);
                    }
                }
            }

            

            Dictionary<string, int> sortedLocations = new Dictionary<string, int>();

            int max = -1;
            string max_key = "";

            for(int i = 0;i<Locations.Count;i++)
            {
                for (int j = 0; j < Locations.Count; j++)
                {
                    if (Locations.ElementAt(j).Value > max)
                    {
                        max = Locations.ElementAt(j).Value;
                        max_key = Locations.ElementAt(j).Key;
                    }

                }

                sortedLocations.Add(max_key, max);
              
                Locations[max_key] = -2;
                max = -1;

            }
            string final_String = "";
            foreach (KeyValuePair<string, int> entry in sortedLocations)
            {
                final_String = final_String + "Location : "+entry.Key+" --> "+"Count: "+entry.Value+"\r\n";
            }

            final_String = final_String + "\r\nRegistered Person Count: " + getRegisteredPersonCount()+"\r\n"+ "Registered Phone Number Count: "+getRegisteredPhoneNumberCount();

            return final_String;
        }
    }
}
