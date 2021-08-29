using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
//use newtonsoft to convert json to c# objects.
using Newtonsoft.Json.Linq;
using System.Net.Http;
using custodies.Models;

namespace custodies
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        async void login()
        {
            string container = string.Empty;
            //Define your baseUrl
            string baseUrl = "https://testing3.alyaseenagri.com/AuthAPI/login";
            //Have your using statements within a try/catch block
            try
            {
                //We will now define your HttpClient with your first using statement which will use a IDisposable.
                using (HttpClient client = new HttpClient())
                {
                    //In the next using statement you will initiate the Get Request, use the await keyword so it will execute the using statement in order.
                    using (HttpResponseMessage res = await client.PostAsync(baseUrl))
                    {
                        //Then get the content from the response in the next using statement, then within it you will get the data, and convert it to a c# object.
                        using (var ctx = new User())
                        {
                            ctx = new User() { userName = "", password = "" };

                            ctx.SaveChanges();
                        }

                        MessageBox.Show("OK");
                    }
                }
            }
            catch (Exception exception)
            {
                container += "Exception Hit------------ \n";
                container += exception;
            }

            MessageBox.Show(container);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            members();
        }
    }
}
