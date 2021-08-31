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
using System.Net.Http.Headers;
using custodies.Models;
using RestSharp;

namespace custodies
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        void Get()
        {
            //Source from:  https://youtu.be/KTr3zDDqSYg
            string url = "https://testing3.alyaseenagri.com/AuthAPI/login/";
            var client = new RestClient(url);
            var request = new RestRequest();
            request.AddParameter("id", "6");
            var respose = client.Get(request);
            MessageBox.Show(respose.Content.ToString());
        }

        void Post()
        {
            //Source from:  https://youtu.be/fVf6wNnUSPc
            string url = "https://jsonplaceholder.typicode.com/posts/";
            var client = new RestClient(url);
            var request = new RestRequest();
            var body = new post() { body = "This is the test body", title = "test post request", userId = 2 };
            request.AddJsonBody(body);
            var response = client.Post(request);

            MessageBox.Show(response.StatusCode.ToString() + "          " + response.Content.ToString());
        }

        //            xhr.send('username=AdminX&password=123456&duration=5&refresh-timeout=true')
        void PostLogin()
        {


            //Source from:  https://youtu.be/fVf6wNnUSPc
            string url = "https://testing3.alyaseenagri.com/AuthAPI/login/";
            var client = new RestClient(url);
            var request = new RestRequest();
            var body = new User() { username = "AdminX", password = "123456", duration = 5, service = "login" };


            Parameter p = (Parameter)body;
            
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            //request.AddParameter("username", "AdminX");
            //request.AddParameter("password", "123456");
            //request.AddParameter("duration", 10);
            request.AddParameter(body);
                var response = client.Post(request);

            MessageBox.Show(response.StatusCode.ToString() + "          " + response.Content.ToString());
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            //User user = new User();
            //user.userName = textBox1.Text;
            //user.password = textBox2.Text;
            PostLogin();
            //Get();
        }
    }
}
