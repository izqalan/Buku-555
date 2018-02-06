using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NewBuku555
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            Title = "Hutang";
            InitializeComponent();
            
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
       
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Hutang>();
                var h = conn.Table<Hutang>().ToList();

                hutangListView.ItemsSource = h;
            }
        }

        private async void OnTappedAsync(object sender, EventArgs e)
        {
            string x = await DisplayActionSheet("What todo", "Go back", null, "Remove", "Update");

            switch (x)
            {
                case "Remove":

                    //remove();
                    await DisplayAlert("Alert", "Record removed.", "OK");

                    break;

                case "Update":


                    break;
                
                default:
                    break;
            }
        }
        
        private void remove()
        {
            Hutang h = new Hutang();
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                
            }
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddPage()); // change page to add page
        }
	}
}
