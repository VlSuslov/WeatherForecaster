using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;
using WeatherForecaster.Models.Domen_Models;
using WeatherForecaster.Models.View_Models;

namespace WeatherForecaster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CurrentWeather CurrentWeather { get; set; }
        DayWeather DayWeather { get; set; }
        WeekWeather WeekWeather { get; set; }
        IForecaster Forecaster { get; set; }
        const string CurrentWeatherUrl = "weather";
        const string DayWeatherUrl = "forecast";
        const string WeekWeatherUrl = @"forecast/daily";

        public MainWindow()
        {
            InitializeComponent();
            Forecaster = new Forecaster();
            CurrentWeather = new CurrentWeather();
            DayWeather = new DayWeather();
            WeekWeather = new WeekWeather();
            this.CurrentPage.DataContext = CurrentWeather;
            this.WeekForecastPage.DataContext = DayWeather;
            CreateDayForecast();
            this.WeekForecastPage.DataContext = WeekWeather;
            CreateWeekForecast();
            FillWeatherPages("London");
            PlaceBox.Items.Add(new TextBlock() { Text="London" });
        }

        /// <summary>
        /// Creating view for day forecast and binding it with day weather forecast view-model
        /// </summary>
        private void CreateDayForecast()
        {
            for (int i = 0; i < 8; i++)
            {
                Rectangle rect = new Rectangle()
                {
                    Height = 100,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Width = 435,
                    Margin = new Thickness(10, i * 110 + 10, 10, 0),
                    StrokeThickness = 1,
                    Stroke = new SolidColorBrush(Colors.Gray),
                    Fill = new SolidColorBrush(Colors.LightGray)
                };
                DayForecastPage.Children.Add(rect);
                Image icon = new Image()
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Height = 50,
                    Width = 50,
                    Margin = new Thickness(15, i * 110 + 20, 0, 0)
                };
                Binding binding = new Binding();
                binding.Source = DayWeather.Parts[i];
                binding.Path = new PropertyPath("Icon");
                icon.SetBinding(Image.SourceProperty, binding);
                DayForecastPage.Children.Add(icon);

                DayForecastPage.Children.Add(CreateLabel(76, new Thickness(70, i * 110 + 20, 0, 0),"Weather",null));
                DayForecastPage.Children.Add(CreateLabel(76, new Thickness(70, i * 110 +50, 0, 0), "Humidity", null));
                DayForecastPage.Children.Add(CreateLabel(76, new Thickness(70, i * 110 + 80, 0, 0), "Wind", null));
                DayForecastPage.Children.Add(CreateLabel(76, new Thickness(250, i * 110 + 20, 0, 0), "Temperature", null));
                DayForecastPage.Children.Add(CreateLabel(76, new Thickness(250, i * 110 + 50, 0, 0), "Pressure", null));
                DayForecastPage.Children.Add(CreateLabel(76, new Thickness(250, i * 110 + 80, 0, 0), "Clouds", null));
                DayForecastPage.Children.Add(CreateLabel(100, new Thickness(150, i * 110 + 20, 0, 0), null,
                    CreateBinding(DayWeather.Parts[i],"Weather")));
                DayForecastPage.Children.Add(CreateLabel(100, new Thickness(150, i * 110 + 50, 0, 0), null,
                   CreateBinding(DayWeather.Parts[i], "Humidity")));
                DayForecastPage.Children.Add(CreateLabel(100, new Thickness(150, i * 110 + 80, 0, 0), null,
                   CreateBinding(DayWeather.Parts[i], "Wind")));
                DayForecastPage.Children.Add(CreateLabel(100, new Thickness(330, i * 110 + 20, 0, 0), null,
                   CreateBinding(DayWeather.Parts[i], "Temperature")));
                DayForecastPage.Children.Add(CreateLabel(100, new Thickness(330, i * 110 + 50, 0, 0), null,
                   CreateBinding(DayWeather.Parts[i], "Pressure")));
                DayForecastPage.Children.Add(CreateLabel(100, new Thickness(330, i * 110 + 80, 0, 0), null,
                   CreateBinding(DayWeather.Parts[i], "Clouds")));
                DayForecastPage.Children.Add(CreateLabel(100, new Thickness(15, i * 110 + 55, 0, 0), null,
                   CreateBinding(DayWeather.Parts[i], "Time")));              
            }
        }

        /// <summary>
        /// Creating view for week forecast and binding it with week weather forecast view-model
        /// </summary>
        private void CreateWeekForecast()
        {
            for (int i = 0; i < 7; i++)
            {
                Rectangle rect = new Rectangle()
                {
                    Height = 135,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Width = 435,
                    Margin = new Thickness(10, i * 145 + 10, 10, 0),
                    StrokeThickness = 1,
                    Stroke = new SolidColorBrush(Colors.Gray),
                    Fill = new SolidColorBrush(Colors.LightGray)
                };
                WeekForecastPage.Children.Add(rect);

                Image icon = new Image()
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Height = 50,
                    Width = 50,
                    Margin = new Thickness(75, i * 145 + 20, 0, 0)
                };
                Binding binding = new Binding();
                binding.Source = WeekWeather.Days[i];
                binding.Path = new PropertyPath("Icon");
                icon.SetBinding(Image.SourceProperty, binding);
                WeekForecastPage.Children.Add(icon);

                Label label = CreateLabel(70, new Thickness(10, i * 145 + 20, 0, 0), null, CreateBinding(WeekWeather.Days[i], "Date"));
                label.Height = 50;
                WeekForecastPage.Children.Add(label);
                WeekForecastPage.Children.Add(CreateLabel(90, new Thickness(10, i * 145 + 75, 0, 0), null,
                    CreateBinding(WeekWeather.Days[i], "Weather")));
                WeekForecastPage.Children.Add(CreateLabel(60, new Thickness(125, i * 145 + 20, 0, 0), "Morning",null));
                WeekForecastPage.Children.Add(CreateLabel(60, new Thickness(125, i * 145 + 50, 0, 0), "Evening", null));
                WeekForecastPage.Children.Add(CreateLabel(60, new Thickness(125, i * 145 + 80, 0, 0), "Clouds", null));
                WeekForecastPage.Children.Add(CreateLabel(60, new Thickness(125, i * 145 + 110, 0, 0), "Pressure", null));
                WeekForecastPage.Children.Add(CreateLabel(60, new Thickness(290, i * 145 + 20, 0, 0), "Day", null));
                WeekForecastPage.Children.Add(CreateLabel(60, new Thickness(290, i * 145 + 50, 0, 0), "Night", null));
                WeekForecastPage.Children.Add(CreateLabel(60, new Thickness(290, i * 145 + 80, 0, 0), "Wind", null));
                WeekForecastPage.Children.Add(CreateLabel(60, new Thickness(290, i * 145 + 110, 0, 0), "Humidity", null));
                WeekForecastPage.Children.Add(CreateLabel(60, new Thickness(190, i * 145 + 20, 0, 0), null,
                     CreateBinding(WeekWeather.Days[i], "MorningTemp")));
                WeekForecastPage.Children.Add(CreateLabel(60, new Thickness(190, i * 145 + 50, 0, 0), null,
                    CreateBinding(WeekWeather.Days[i], "EveningTemp")));
                WeekForecastPage.Children.Add(CreateLabel(95, new Thickness(190, i * 145 + 80, 0, 0), null,
                    CreateBinding(WeekWeather.Days[i], "Clouds")));
                WeekForecastPage.Children.Add(CreateLabel(95, new Thickness(190, i * 145 + 110, 0, 0), null,
                    CreateBinding(WeekWeather.Days[i], "Pressure")));
                WeekForecastPage.Children.Add(CreateLabel(60, new Thickness(350, i * 145 + 20, 0, 0), null,
                  CreateBinding(WeekWeather.Days[i], "DayTemp")));
                WeekForecastPage.Children.Add(CreateLabel(60, new Thickness(350, i * 145 + 50, 0, 0), null,
                  CreateBinding(WeekWeather.Days[i], "NightTemp")));
                WeekForecastPage.Children.Add(CreateLabel(95, new Thickness(350, i * 145 + 80, 0, 0), null,
                  CreateBinding(WeekWeather.Days[i], "Wind")));
                WeekForecastPage.Children.Add(CreateLabel(95, new Thickness(350, i * 145 + 110, 0, 0), null,
                  CreateBinding(WeekWeather.Days[i], "Humidity")));
            }
        }

        /// <summary>
        /// Creating view for week forecast and binding it with week weather forecast view-model
        /// </summary>
        void Find_Click(object sender, RoutedEventArgs e)
        {
            FillWeatherPages(PlaceBox.Text);
        }

        /// <summary>
        /// Fill all weather view with the weather data
        /// </summary>
        /// /// <param name="place">Place for which is forecast</param>
        public async void FillWeatherPages(string place)
        {
            try
            {
                await FillCurrentWeather(place);
                await FillDayWeather(place);
                await FillWeekWeather(place);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("An error occurred while processing the data of the external service\n" + ex.Message,"Error");
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Error executing query\n" + ex.Message, "Error");
            }
        }

        /// <summary>
        /// Fill current weather view with the weather data
        /// </summary>
        /// /// <param name="place">Place for which is forecast</param>
         async Task FillCurrentWeather(string place)
        {          
            XmlSerializer serializer = new XmlSerializer(typeof(Current));
            string xml;
            try
            {
                xml = await GetWeather(CurrentWeatherUrl, place, 7);
            }
            catch (HttpRequestException)
            {
                throw;
            }
            if (xml != null)
            {
                try
                {
                        TextReader reader = new StringReader(xml);
                        Current forecast = (Current)serializer.Deserialize(reader);
                        PlaceName.Content = forecast.City.Name + "," + forecast.City.Country;
                        CurrentWeather.Update(forecast);
                        reader.Dispose();
                }
                catch (InvalidOperationException)
                {
                    throw;
                }          
            }
        }

        /// <summary>
        /// Fill day weather view with the weather data
        /// </summary>
        /// /// <param name="place">Place for which is forecast</param>
        async Task FillDayWeather(string place)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(WeatherData));
            string xml;
            try
            {
                xml = await GetWeather(DayWeatherUrl, place, 9);
            }
            catch (HttpRequestException)
            {
                throw;
            }
            if (xml != null)
            {
                try
                {
                    TextReader reader = new StringReader(xml);
                    WeatherData forecast = (WeatherData)serializer.Deserialize(reader);
                    DayWeather.Update(forecast);
                    reader.Dispose();
                }
                catch (InvalidOperationException)
                {
                    throw;
                }            
            }
        }

        /// <summary>
        /// Fill week weather view with the weather data
        /// </summary>
        /// /// <param name="place">Place for which is forecast</param>
        async Task FillWeekWeather(string place)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(WeatherData));
            string xml;
            try
            {
               xml = await GetWeather(WeekWeatherUrl, place, 8);
            }
            catch (HttpRequestException)
            {
                throw;
            }
                if (xml != null)
             {
                try
                {
                        TextReader reader = new StringReader(xml);                   
                        WeatherData forecast = (WeatherData)serializer.Deserialize(reader);
                        WeekWeather.Update(forecast);
                        reader.Dispose();
                    }
                    catch (InvalidOperationException)
                    {
                        throw;
                    }               
            }      
        }

        /// <summary>
        /// Get weather data from the forecaster
        /// </summary>
        /// <param name="type">Type of weather forecast</param>
        /// <param name="place">Place for which is forecast</param>
        /// <param name="place">Number of forecast parts</param>
        /// <returns> weather data in xml format
        async Task<string> GetWeather(string type,string place,int count)
        {
            string result = null;
                try
                {
                    result = await Forecaster.GetForecast(type, place, count);
                }
                catch (HttpRequestException)
                {
                     throw;
                }
                    return result;
        }

        /// <summary>
        /// Creating label object with configured settings
        /// </summary>
        /// <param name="width">Width of label in pixels</param>
        /// <param name=" margin">Margin for label in  Thickness struct</param>
        /// <param name="content">Content of label</param>
        /// <param name="content">Binding for content property of label</param>
        /// <returns> Created label object
        Label CreateLabel(int width, Thickness margin,string content,Binding binding)
        {
            Label label = new Label()
            {
                Width = width,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = margin,
                Content = content
            };
            if (binding != null)
            {
                label.SetBinding(ContentProperty, binding);
            }
            return label;
        }

        /// <summary>
        /// Creating binding for object
        /// </summary>
        /// <param name="source">The source object for binding</param>
        /// <param name="path">Path property of source object the binding</param>
        /// <returns> Created binding object
        Binding CreateBinding(object source,string path)
        {
            Binding binding = new Binding();
            binding.Source = source;
            binding.Path = new PropertyPath(path);
            return binding;  
        }

        private void AddPlace_Click(object sender, RoutedEventArgs e)
        {
            PlaceBox.Items.Add(new TextBlock() { Text = PlaceBox.Text });
        }

        private void RemovePlace_Click(object sender, RoutedEventArgs e)
        {
            PlaceBox.Items.Remove(PlaceBox.SelectedItem);
        }
    }
}
