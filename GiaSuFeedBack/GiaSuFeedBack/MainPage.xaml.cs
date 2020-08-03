using Newtonsoft.Json;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GiaSuFeedBack
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly string FeedbackUrl = "https://giasuapi2.azurewebsites.net/api/FeedbackControllers/Feedbacks";
        private readonly HttpClient httpClient = new HttpClient();
        private ObservableCollection<FeedBack> FeedBack = new ObservableCollection<FeedBack>();


        public MainPage()
        {
            InitializeComponent();

        }
        protected async override void OnAppearing()
        {
            await GetFeedBackList();
        }
        private async Task GetFeedBackList()
        {
            var response = await httpClient.GetAsync(FeedbackUrl);
            var result = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine(result);
            FeedBack = JsonConvert.DeserializeObject<ObservableCollection<FeedBack>>(result);
            FeedbackList.ItemsSource = FeedBack;
        }

        private void FeedbackList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var TappedFeedback = e.Item as GiaSuFeedBack.FeedBack;
            FeedbackList.SelectedItem = null;
        }

        float start = 400;
        float end = 0;

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            start = (float)e.NewValue;
            end = (float)e.NewValue;
            TopBigFrame.TranslationY = e.NewValue;
            FeedbackList.TranslationY = e.NewValue;
            Header.TranslationY = e.NewValue;
            ActiveButton.TranslationY = e.NewValue;
        }

        private async void ActiveButton_Clicked(object sender, EventArgs e)
        {
            uint timeout = 500;
            var ActiveButton = sender as ImageButton;
            await ActiveButton.TranslateTo(-100, 0, timeout, Easing.SpringIn);
            await ActiveButton.RelRotateTo(360);
            await ActiveButton.TranslateTo(0, 0, timeout, Easing.SpringOut);
        }


    }
}

