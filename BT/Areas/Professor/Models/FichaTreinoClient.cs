using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using BusinessLibrary.Entity;
using System.Net.Http.Headers;

namespace BT.Areas.Professor.Models
{
    public class FichaTreinoClient
    {
     private string Base_URL = "https://bttraining.azurewebsites.net/api/";
        private string Base_API_Module = "FichaTreinos";

        public IEnumerable<BusinessLibrary.Entity.FichaTreino> findAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(Base_API_Module).Result;

                if (response.IsSuccessStatusCode)
                    return   response.Content.ReadAsAsync<IEnumerable<BusinessLibrary.Entity.FichaTreino>>().Result;
               
                return null;
            }
            catch
            {
                return null;
            }
        }
        public BusinessLibrary.Entity.FichaTreino find(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(Base_API_Module + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<BusinessLibrary.Entity.FichaTreino>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public bool Create(BusinessLibrary.Entity.FichaTreino exercicio)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync(Base_API_Module, exercicio).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(BusinessLibrary.Entity.FichaTreino exercicio)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync(Base_API_Module + "/" + exercicio.Exer_id, exercicio).Result;
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
                HttpResponseMessage response = client.DeleteAsync(Base_API_Module + "/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }

}
