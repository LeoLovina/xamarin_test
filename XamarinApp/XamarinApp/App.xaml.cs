using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Data;

namespace XamarinApp
{
    public partial class App : Application
    {
        public static string FolderPath { get; set; }
        static NoteDatabase database;

        public static NoteDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }

                return database;
            }
        }


        public App()
        {
            // load and parse the associated XAML.
            InitializeComponent();

            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            MainPage = new NavigationPage(new NotesPage());
        }

        protected override void OnStart()
        {
            Console.WriteLine("App OnStart");
        }

        protected override void OnSleep()
        {
            Console.WriteLine("App OnSleep");
        }

        protected override void OnResume()
        {
            Console.WriteLine("App OnResume");
        }
    }
}
