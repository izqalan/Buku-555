using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewBuku555
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPage : ContentPage
	{
		public AddPage ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Hutang h = new Hutang()
            {
                Name = nameEntry.Text,
                Amount = amountEntry.Text
            };

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Hutang>();
                var numberOfRows = conn.Insert(h);

                if (numberOfRows > 0)
                {
                    DisplayAlert("Success", "Data has been stored", "OK");
                    clear(); // clear form
                }
                else
                    DisplayAlert("Error", "Duplicate ID founded!", "OK");

            }




        }

        public void clear()
        {
            nameEntry.Text = "";
            amountEntry.Text = "";
        }
	}
}