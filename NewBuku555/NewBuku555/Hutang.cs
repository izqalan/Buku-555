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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }

    }
}
