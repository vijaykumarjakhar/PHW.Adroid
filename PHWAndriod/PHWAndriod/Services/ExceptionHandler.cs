using System;

namespace PHWAndriod.Services
{
    public static class ExceptionHandler
    {
        public static async void HandleException(Exception ex, string source)
        {
            // Add your global exception handling logic here
            Console.WriteLine($"Global Exception Handler: {ex.Message} source: {source}");
            await App.Current.MainPage.DisplayAlert("PHW", "Something went wrong. Please try again later.", "Ok");
        }

    }
}
