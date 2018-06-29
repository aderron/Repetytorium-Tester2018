using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;

namespace PracticalExam
{
    /*
     * Praktykant ze stanów zjednoczonych źle wyeksportował plik testwoy (AccountingData.json)
     * Daty w tym pliku są w złym formacie (amerykańskim a nie europejskim). Popraw plik
     */

    [TestFixture]
    public class Ex2Tests
    {
        [Test]
        public void ReadData()
        {
            var result = Ex2.ReadData();
        }
    }

    public class Ex2
    {
        public static List<Row> ReadData()
        {
            var data = File.ReadAllText("Ex2Data.json");
            var rows = JsonConvert.DeserializeObject<List<Row>>(data);
            return rows;
        }

        public class Row
        {
            public DateTime Date { get; set; }
            public DateTime AccountingDate { get; set; }
            public bool IsLogged {get; set; }
            public string Client { get; set; }
            public double Amount { get; set; }
        }
    }
}