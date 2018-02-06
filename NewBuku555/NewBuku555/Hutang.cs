using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NewBuku555
{
    public class Hutang
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
    }
}
