using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
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

        public ObservableCollection<Car> CarList { get; set; } = new ObservableCollection<Car>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadCars(null, null);
        }

        private async Task<List<Car>> loadCars(int year, int month, int day)
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
            return JsonSerializer.Deserialize<List<Car>>(responseBody);
        }

        private async void LoadCarsFiltered(object sender, RoutedEventArgs e)
        {
            MessageBox.Text = "";
            if (DateFilter.DisplayDate != default)
            {
                _UpdateCars(await loadCars(DateFilter.DisplayDate.Year, DateFilter.DisplayDate.Month, DateFilter.DisplayDate.Day));
            }
        }

        private async void LoadCars(object sender, RoutedEventArgs e)
        {
            MessageBox.Text = "";
            _UpdateCars(await loadCars(0, 0, 0));
        }

        private void _UpdateCars(IEnumerable<Car> carArray)
        {
            CarList.Clear();
            foreach (Car car in carArray)
            {
                CarList.Add(car);
            }
        }

        private async void BookCar(object sender, RoutedEventArgs e)
        {
            if (DateFilter.DisplayDate != default)
            {
                Booking booking = new Booking()
                {
                    CarID = Int32.Parse(SelectCarID.Text),
                    CustomerID = Int32.Parse(SelectCustomerID.Text),
                    Date = DateFilter.DisplayDate
                };

                try
                {
                    var content = new StringContent(JsonSerializer.Serialize(booking), Encoding.UTF8, "application/json");
                    var carBookingResponse = await HttpClient.PostAsync("bookings", content);
                    carBookingResponse.EnsureSuccessStatusCode();
                    MessageBox.Text = "Car booked";
                }
                catch (Exception ex)
                {
                    MessageBox.Text = "Car not available at this day!";
                }

            }
            else
            {
                MessageBox.Text = "Please provide a booking date!";
            }
        }
    }
}
