using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;
using Xamarin.Forms;

namespace TestXamarinApp
{
    public partial class MainPage : ContentPage
    {
        readonly FirebaseClient _firebase = new FirebaseClient("https://team8-160d5.firebaseio.com/");

        public MainPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            _firebase
                .Child("chats")
                .Child("r_1")
                .AsObservable<object>()
                .Subscribe(p =>
                {
                    Debug.WriteLine($"===>>> event = {p.EventType}, key = {p.Key}, object = {p.Object}");
                });
        }
    }
}
