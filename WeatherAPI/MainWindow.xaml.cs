using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using Newtonsoft.Json;

namespace WeatherAPI
{
 
    public partial class MainWindow : Window
    {
        private const string ApiKey = "cdb07ee686e345a9b0aad2b5325cdf9c";
        private const string ApiUrl = "http://api.openweathermap.org/data/2.5/weather";

        public MainWindow()
        {
            InitializeComponent();
            CityTextBox.GotFocus += RemovePlaceholder;
            CityTextBox.LostFocus += RestorePlaceholder;
        }
        //Удобное очищение поля ввода

        private void RemovePlaceholder(object sender, RoutedEventArgs e)
        {
            if (CityTextBox.Text == "Введите название города")
            {
                CityTextBox.Text = "";
                CityTextBox.Foreground = Brushes.Black;
            }
        }

        private void RestorePlaceholder(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CityTextBox.Text))
            {
                CityTextBox.Text = "Введите название города";
                CityTextBox.Foreground = Brushes.Gray;
            }
        }
        //Вывод данных при нажатии на кнопку

        private async void GetWeatherButton_Click(object sender, RoutedEventArgs e)
        {
            string city = CityTextBox.Text;

            if (string.IsNullOrWhiteSpace(city))
            {
                MessageBox.Show("Please enter a city name.");
                return;
            }

            try
            {
                WeatherData weatherData = await GetWeatherData(city);

                TemperatureLabel.Content = $"Температура: {weatherData.Main.TemperatureInCelsius:F2}°C";
                DescriptionLabel.Content = $"Описание: {weatherData.Weather[0].Description}";
                WindLabel.Content = $"Скорость ветра: {weatherData.Wind.Speed} м/с";
            }
            catch 
            {
                MessageBox.Show($"Такого Города нет(");
            }
        }
        //Получение данных от АPI

        private async Task<WeatherData> GetWeatherData(string city)
        {
            using (HttpClient client = new HttpClient())
            {
                //Использование ключа API

                string apiUrl = $"{ApiUrl}?q={city}&appid={ApiKey}&units=metric&lang=ru";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(jsonResponse);
                    return weatherData;
                }
                else
                {
                    throw new Exception($"Не получилось загрузить данные погоды. Код Статуса: {response.StatusCode}");
                }
            }
        }
    }
}
