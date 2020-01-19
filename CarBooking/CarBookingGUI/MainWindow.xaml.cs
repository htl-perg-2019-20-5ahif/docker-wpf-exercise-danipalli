using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace CarBookingGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static HttpClient HttpClient
            = new HttpClient() { BaseAddress = new Uri("http://localhost:5000/api") };

        public ObservableCollection<Car> CarList = new ObservableCollection<Car>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private async Task<Car[]> loadCars()
        {
            var carBookingResponse = await HttpClient.GetAsync("Cars");
            carBookingResponse.EnsureSuccessStatusCode();
            var responseBody = await carBookingResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Car[]>(responseBody);
        }
    }
}
