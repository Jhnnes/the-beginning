using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace weather_app_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                richTextBox1.Text = "Bitte gebe den Namen einer Stadt ein...";
            }
           
            else if (textBox1.Text != "")
            {
               
            


            string cityname = textBox1.Text;


                HttpClient httpClient = new HttpClient();
                string requestUrl = "https://api.openweathermap.org/data/2.5/weather?q=" + cityname + "&appid=98fddd6a43823c753014981b0c01911b&units=metric";
                HttpResponseMessage httpResponse = httpClient.GetAsync(requestUrl).Result;
                string response = httpResponse.Content.ReadAsStringAsync().Result;
                WeatherMapResponse weatherMapResponse = JsonConvert.DeserializeObject<WeatherMapResponse>(response);

                if (weatherMapResponse.main == null)
                {
                    richTextBox1.Text = "Diese Stadt ist uns leider nicht bekannt. Überprüfe bitte die Schreibweise!";
                }
                else
                {
                    richTextBox1.Text = (string)"In " + cityname + " hat es " + weatherMapResponse.main.temp + "°C";
                }

                

                
            }
        }



        class WeatherMapResponse
        {
            public Main main;
        }

        class Main
        {
            public float temp;
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}