using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using BusinessLibrary.Entity;
using System.Net.Http.Headers;

namespace BT.Areas.Professor.Models
{
    public class ClienteClient
    {
        private string Base_URL = "https://bttraining.azurewebsites.net/api/";
        private string Base_API_Module = "Clientes";

        public IEnumerable<BusinessLibrary.Entity.Cliente> findAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(Base_API_Module).Result;

                if (response.IsSuccessStatusCode)
                    return   response.Content.ReadAsAsync<IEnumerable<BusinessLibrary.Entity.Cliente>>().Result;
               
                return null;
            }
            catch
            {
                return null;
            }
        }
        public BusinessLibrary.Entity.Cliente find(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(Base_API_Module + "/"  + id).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<BusinessLibrary.Entity.Cliente>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public bool Create(BusinessLibrary.Entity.Cliente cliente)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync(Base_API_Module, cliente).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(BusinessLibrary.Entity.Cliente cliente)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync(Base_API_Module + "/"  + cliente.clie_id, cliente).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync(Base_API_Module + "/"  + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }

}
