using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NewBuku555
{
	public partial class MainPage : ContentPage
	{
        DBItemController dbcontroller = new DBItemController();
        Hutang hutang = new Hutang();
        private ObservableCollection<Hutang> items = new ObservableCollection<Hutang>();

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

                    //deleteDB();
                    await DisplayAlert("Alert", "Record removed.", "OK");
                    
                    break;

                case "Update":


                    break;
                
                default:
                    break;
            }
        }
        
        public void deleteDB(int id)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                
                hutang.Id = id; // need to get from somewhere HALP
                //hutang.Id = 1; // get ID from tap
                conn.Delete<Hutang>(hutang.Id);
                conn.CreateTable<Hutang>();
                var h = conn.Table<Hutang>().ToList();
         
                hutangListView.ItemsSource = h;
            }
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddPage()); // change page to add page
        }
	}
}
