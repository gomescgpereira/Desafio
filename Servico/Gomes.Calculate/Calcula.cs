using System;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Gomes.Calculate.Models;
using System.Text.RegularExpressions;

namespace Gomes.Calculate
{
    public class Calcula
    {

        public  List<Cliente> Clientes;

        public Calcula()
        {
            Clientes = new List<Cliente>();
        }

        public async Task Calcular()
        {
            Clientes = await GetClientesAsync();  
            foreach (var item in Clientes)
            {
                var billing = Calculando(item);
                await Registra(billing);
            }
        }  

        public Billing Calculando(Cliente item)
        {
            string CPFapenasNumeros = Regex.Replace(item.Cpf, "[^0-9]", "");
            string Valor = CPFapenasNumeros.Substring(0, 2);
            Valor = Valor + CPFapenasNumeros.Substring(9, 2);

            var obj = new Billing();
            obj.Cpf = CPFapenasNumeros;
            obj.Valor = Math.Round(Convert.ToDecimal(Valor), 2);
            obj.Vencimento = DateTime.Now;
            return obj;

        }

        //Api de Clientes
        private async Task Registra(Billing billing)
        {
            HttpClient client = new HttpClient();
            try
            {
                string url = "http://localhost:5000/api/billing";
                var uri = new Uri(string.Format(url));
                var data = JsonConvert.SerializeObject(billing);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao incluir produto");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Cliente>> GetClientesAsync()
        {
            HttpClient client = new HttpClient();
            try
            {
                string url = "http://localhost:5001/api/clients";
                var response = await client.GetStringAsync(url);
                var listaclientes = JsonConvert.DeserializeObject<List<Cliente>>(response);
                return listaclientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }


   
}
