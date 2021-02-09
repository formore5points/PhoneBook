using NUnit.Framework;
using System.Collections.Generic;
using System.Data;

namespace Tests
{
    public class Tests
    {
        private List<PhoneBoo.Contact> People;// = new List<PhoneBoo.Contact>();

        [SetUp]
        public void Setup()
        {
            People = new List<PhoneBoo.Contact>();
            People.Add(new PhoneBoo.Contact(1, "Berkay", "Co�kuner", "A", new PhoneBoo.Information("Location", "�zmir")));
            People.Add(new PhoneBoo.Contact(2, "Ahmet", "Kabaday�", "B", new PhoneBoo.Information("Location", "Ankara")));
            People.Add(new PhoneBoo.Contact(3, "Mehmet", "�z", "C", new PhoneBoo.Information("Location", "�zmir")));
            People.Add(new PhoneBoo.Contact(4, "Zeynep", "�al��kan", "D", new PhoneBoo.Information("Phone", "5436789821")));
            People.Add(new PhoneBoo.Contact(5, "Cemre", "Kin", "E", new PhoneBoo.Information("Phone", "545667521")));
        }
        //Report Class Test Functions
        [Test]
        public void TestRegisteredPersonCount()
        {
            PhoneBoo.Report r = new PhoneBoo.Report(People);

            int result = r.getRegisteredPersonCount();

            Assert.AreEqual(5,result);
        }

        [Test]
        public void TestRegisteredPhoneNumberCount()
        {
            PhoneBoo.Report r = new PhoneBoo.Report(People);

            int result = r.getRegisteredPhoneNumberCount();

            Assert.AreEqual(2,result);
        }

        [Test]
        public void TestReportasString()
        {
            PhoneBoo.Report r = new PhoneBoo.Report(People);

            string expected = "Location : �zmir --> Count: 2" + "\r\nLocation : Ankara --> Count: 1\r\n\r\nRegistered Person Count: 5\r\nRegistered Phone Number Count: 2";

            string result = r.getReportasString();

            Assert.AreEqual(expected, result);

        }

        //Information Class Test Functions

        [Test]
        public void TestInformationtoString()
        {
            PhoneBoo.Information i = new PhoneBoo.Information("Location","�zmir");

            string result = i.ToString();

            Assert.AreEqual("InfoType: Location\r\nInfo: �zmir",result);
        }

        //Contact Class Test Functions

        [Test]
        public void TestContacttoString()
        {
            
            PhoneBoo.Information i = new PhoneBoo.Information("Location", "�zmir");
            PhoneBoo.Contact c = new PhoneBoo.Contact(1,"Berkay","Co�kuner","A",i);

            string result = c.ToString();

            Assert.AreEqual("ID: 1\r\nName: Berkay\r\nSurname: Co�kuner\r\nCompany: A\r\nInfoType: Location\r\nInfo: �zmir", result);
        }

        //Form1 Class Test Functions

        [Test]
        public void TestGetList()
        {

            PhoneBoo.Form1 f = new PhoneBoo.Form1();

            DataTable dt = f.GetList();

            DataRow row = dt.Rows[0];

            Assert.AreEqual("Ahmet", row["Name"]);
        }

        [Test]
        public void TestFindPersonByID()
        {

            PhoneBoo.Form1 f = new PhoneBoo.Form1();

            int result = f.findPersonByID(1,People).ID;


            Assert.AreEqual(1, result);
        }

    }
}