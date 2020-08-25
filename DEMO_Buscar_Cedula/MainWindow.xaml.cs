using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Windows;
//using System.Text.Json;
using System.Windows.Controls;
using System.Windows.Documents;

namespace DEMO_Buscar_Cedula
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Properties
        private static readonly HttpClient client = new HttpClient();   
        #endregion
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnConvert_ClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = txtUrl.Text;
                string responseString = string.Empty;
                responseString = await client.GetStringAsync(url);

                var response = JsonConvert.DeserializeObject<SepProfessionalLicense>(responseString);
                //dgJson.ItemsSource = Tabulate(responseString);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public class SepProfessionalLicense
        {
            [JsonProperty("response")]
            public List<Person> response { get; set; }
        }
        public class Person
        {
            //[JsonPropertyName("nombre")]
            public string nombre { get; set; }
            //[JsonPropertyName("id")]
            public string id { get; set; }
            //[JsonPropertyName("numCedula")]
            public string numCedula { get; set; }
            //[JsonPropertyName("titulo")]
            public string titulo { get; set; }
            //[JsonPropertyName("genero")]
            public int genero { get; set; }
            //[JsonPropertyName("institucion")]
            public string institucion { get; set; }
            //[JsonPropertyName("materno")]
            public string materno { get; set; }
            //[JsonPropertyName("anioRegistro")]
            public int anioRegistro { get; set; }
            //[JsonPropertyName("tipo")]
            public string tipo { get; set; }
            //[JsonPropertyName("paterno")]
            public string paterno { get; set; }
            //[JsonPropertyName("timestamp")]
            public DateTime timestamp { get; set; }
            //[JsonPropertyName("score")]
            public double score { get; set; }
        }

        #region Test Methods
        //public static List<Person> Tabulate(string jsonContent)
        //{
        //    var jsonLinq = JObject.Parse(jsonContent);
        //    // Find the first array using Linq
        //    var srcArray = jsonLinq.Descendants().Where(d => d is JArray).First();
        //    var trgArray = new JArray();
        //    foreach (JObject row in srcArray.Children<JObject>())
        //    {
        //        var cleanRow = new JObject();
        //        foreach (JProperty column in row.Properties())
        //        {
        //            // Only include JValue types
        //            if (column.Value is JValue)
        //            {
        //                cleanRow.Add(column.Name, column.Value);
        //            }
        //        }

        //        trgArray.Add(cleanRow);
        //    }

        //    return JsonConvert.DeserializeObject<MyJsonPerson>(trgArray.ToString()).Persons;
        //}
        #endregion
    }
}
