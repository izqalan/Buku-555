using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;

namespace NewBuku555.Droid
{
    [Activity(Label = "NewBuku555", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            string filename = "Hutang_db.sqlite";
            string fileLoc = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string path = Path.Combine(fileLoc, filename);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(path));
        }
    }
}

