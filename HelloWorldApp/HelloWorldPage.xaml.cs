using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace HelloWorldApp
{
    public partial class HelloWorldPage : ContentPage
    {
        HttpClient client;

        public HelloWorldPage()
        {
            InitializeComponent();
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            logo.Source = ImageSource.FromResource("HelloWorldApp.file.logo.png");
        }


        protected async void LoginButton_OnClicked(object sender, EventArgs e)
        {
            //await DisplayAlert("I tuoi dati", Username.Text+"-"+Password.Text, "OK");
           
            try
            {
                /*
                var client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(new { username = "1", password = "1" }));
                var result = await client.PostAsync("http://www.donkeylab.com/webservice.php", content).ConfigureAwait(false);
                if (result.IsSuccessStatusCode)
                {
                    var tokenJson = await result.Content.ReadAsStringAsync();
                    //await DisplayAlert("Chiamata", tokenJson, "OK");
                }
                */


                //var data = JsonConvert.SerializeObject(new { username = Username.Text, password = Password.Text });
                //var content = new StringContent(data, Encoding.UTF8, "application/json");

                //var response = client.PostAsync("http://www.donkeylab.com/webservice.php", content).Result;
                //var tokenJson = await response.Content.ReadAsStringAsync();
                //await DisplayAlert("Chiamata", tokenJson, "OK");

                int resultLogin =  await POSTreq(Username.Text, Password.Text);

                string temp = "";
                if (resultLogin == 0)
                {
                    temp = "Credenziali di accesso non corrette";
                    await DisplayAlert("Chiamata", temp, "OK");
                }
                else
                {
                    App.Current.MainPage = new HelloListPage();

                }




            }
            catch (Exception ex)
            {
                await DisplayAlert("Errore", ex.Message, "OK");
            }
        }

        public async Task<int> POSTreq(string Username, string Password)  
        {  
            Uri requestUri = new Uri("http://www.donkeylab.com/webservice.php"); //replace your Url  
            dynamic dynamicJson = new ExpandoObject();  
            dynamicJson.username = Username;  
            dynamicJson.password = Password;  
            string json = "";  
            json = Newtonsoft.Json.JsonConvert.SerializeObject(dynamicJson);  
            var objClint = new System.Net.Http.HttpClient();  
            System.Net.Http.HttpResponseMessage respon = await objClint.PostAsync(requestUri, new StringContent(json, System.Text.Encoding.UTF8, "application/json"));  
            string res = await respon.Content.ReadAsStringAsync();
            JObject jsonRes = JObject.Parse(res);

            return (int)jsonRes["result"];

        }  




        ///// <summary>
        ///// Login.
        ///// </summary>
        ///// <returns>true or false</returns>
        ///// <param name="username">username</param>
        ///// <param name="password">password</param>
        ///// 
        //public async Task<int> LoginAsync(string Username, string Password)
        //{
            
        //    var data = JsonConvert.SerializeObject(new { username = Username, password = Password });
        //    var content = new StringContent(data, Encoding.UTF8, "application/json");
        //    //var response = await client.PostAsync("http://www.donkeylab.com/webservice.php", content);


        //    var response = client.PostAsync("http://www.donkeylab.com/webservice.php", content).Result;
        //    var result = JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);
        //    return result;



        //}



    }
}
