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
            = new HttpClient() { BaseAddress = new Uri("http://localhost:5000/api/") };

        public ObservableCollection<Car> CarList = new ObservableCollection<Car>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadCars(null, null);
        }

        private async Task<Car[]> loadCars(int year, int month, int day)
        {
            HttpResponseMessage carBookingResponse;
            if (year != 0 && month != 0 && day != 0)
            {
                carBookingResponse = await HttpClient.GetAsync("cars?year=" + year + "&month=" + month + "&day=" + day);
            }
            else
            {
                carBookingResponse = await HttpClient.GetAsync("cars");
            }
            carBookingResponse.EnsureSuccessStatusCode();
            var responseBody = await carBookingResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Car[]>(responseBody);
        }

        private async void LoadCarsFiltered(object sender, RoutedEventArgs e)
        {
            if (DateFilter.DisplayDate != null)
            {
                _UpdateCars(await loadCars(DateFilter.DisplayDate.Year, DateFilter.DisplayDate.Month, DateFilter.DisplayDate.Day));
            }
        }

        private async void LoadCars(object sender, RoutedEventArgs e)
        {
            _UpdateCars(await loadCars(0, 0, 0));
        }

        private void _UpdateCars(Car[] carArray)
        {
            CarList = new ObservableCollection<Car>();
            foreach (Car car in carArray)
            {
                CarList.Add(car);
            }
        }
    }
}
