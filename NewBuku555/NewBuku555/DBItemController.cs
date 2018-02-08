using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NewBuku555
{
    public class DBItemController
    {
        private static object locker = new object();
        private SQLiteConnection database;

        public int DeleteDBItem(int id)
        {
            lock (locker)
            {
                return this.database.Delete<Hutang>(id);
            }
        }

    }
}
