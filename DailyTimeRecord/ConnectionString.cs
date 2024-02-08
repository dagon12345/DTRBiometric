using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DailyTimeRecord
{
    class ConnectionString
    {
        //public string DBcon = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\DailyTimeRecord_db.mdf;Integrated Security=True;User Instance=True";
        public string DBcon = @"Data Source =192.168.0.100,1433;initial Catalog=DailyTimeRecord_db.mdf;Trusted_Connection=true;Integrated Security=false;Connect Timeout=30;user ID=dtr_new ;password=server";
    }
}
