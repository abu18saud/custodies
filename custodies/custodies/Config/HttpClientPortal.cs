using custodies.Models;
using DevExpress.Utils.About;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HttpClientPortal
{
    //Install-Package Microsoft.AspNet.WebApi.Client





    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }

    class Program
    {
        //private XmlHttpRequest request;
        //private Uri requestUri;
        //private WebHeaderCollection headers;
        //private bool hasResponse;

        //public override string Method { get; set; }
        //public override string ContentType { get; set; }
        ///// <summary>
        ///// Gets or sets the value of the Connection HTTP header.
        ///// </summary>
        //public string Connection { get; set; }
        //public string UserAgent { get; set; }
        //public override Uri RequestUri { get { return requestUri; } }

        ///// <summary>
        ///// Gets the Uniform Resource Identifier (URI) of the Internet resource that actually responds to the request.
        ///// </summary>
        //public Uri Address { get; private set; }

        //AsyncResult<HttpWebResponse> resultGetResponse = null;
        //Stream requestStream;



        //public ClientHttpWebRequest_(Uri uri)
        //{
        //    this.requestUri = uri;
        //    this.request = new XmlHttpRequest();
        //    this.Method = "GET"; // Default method is GET            
        //    this.request.OnReadyStateChange = this.OnStateChanged;
        //}



        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new product
                Product product = new Product
                {
                    Name = "Gizmo",
                    Price = 100,
                    Category = "Widgets"
                };

                var url = await CreateProductAsync(product);
                Console.WriteLine($"Created at {url}");

                // Get the product
                product = await GetProductAsync(url.PathAndQuery);
                ShowProduct(product);

                // Update the product
                Console.WriteLine("Updating price...");
                product.Price = 80;
                await UpdateProductAsync(product);

                // Get the updated product
                product = await GetProductAsync(url.PathAndQuery);
                ShowProduct(product);

                // Delete the product
                var statusCode = await DeleteProductAsync(product.Id);
                Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        static HttpClient client = new HttpClient();

        static void ShowProduct(Product product)
        {
            Console.WriteLine($"Name: {product.Name}\tPrice: " +
                $"{product.Price}\tCategory: {product.Category}");
        }

        static async Task<Uri> CreateProductAsync(Product product)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/products", product);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }
        static public async Task<Uri> LoginWithPost(User user)
        {
            //var xhr = new XMLHttpRequest();
            /*
             xhr.onreadystatechange = function () {
                if (this.readyState = 4) {
                console.log(this.responseText);
                }
            }
            xhr.open('post','https://testing3.alyaseenagri.com/AuthAPI/login')
            xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
            xhr.send('username=AdminX&password=123456&duration=5&refresh-timeout=true')



            result:
            {
            "message":"تم تسجيل الدخول بنجاح.", 
            "type":"info", 
            "token":"7ac27faff564e3504d54d9b436d31bf3e3185be7eddb1132d2c889bd4ecea49d", 
            "user-id":"10158", 
            "token-type":"basic", 
            "expires-after":5, 
            "expires-on":"2021-08-30 15:45:11"
            }

             */


            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://testing3.alyaseenagri.com/AuthAPI/login", user);
            MessageBox.Show(response.EnsureSuccessStatusCode().ToString());

            // return URI of the created resource.
            return response.Headers.Location;
        }



        static async Task<Product> GetProductAsync(string path)
        {
            Product product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Product>();
            }
            return product;
        }

        static async Task<Product> UpdateProductAsync(Product product)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/products/{product.Id}", product);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            product = await response.Content.ReadAsAsync<Product>();
            return product;
        }

        static async Task<HttpStatusCode> DeleteProductAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/products/{id}");
            return response.StatusCode;
        }


        static async Task RunAsync_()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new product
                Product product = new Product
                {
                    Name = "Gizmo",
                    Price = 100,
                    Category = "Widgets"
                };

                var url = await CreateProductAsync(product);
                Console.WriteLine($"Created at {url}");

                // Get the product
                product = await GetProductAsync(url.PathAndQuery);
                ShowProduct(product);

                // Update the product
                Console.WriteLine("Updating price...");
                product.Price = 80;
                await UpdateProductAsync(product);

                // Get the updated product
                product = await GetProductAsync(url.PathAndQuery);
                ShowProduct(product);

                // Delete the product
                var statusCode = await DeleteProductAsync(product.Id);
                Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }


}