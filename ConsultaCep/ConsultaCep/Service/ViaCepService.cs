using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using ConsultaCep.Service.Model;
using Newtonsoft.Json;

namespace ConsultaCep.Service
{
    class ViaCepService
    {
        private static string addressUrl = "https://viacep.com.br/ws/{0}/json/";

        public static Address SearchAddressViaCep(string cep)
        {
            string newAddressUrl = string.Format(addressUrl, cep);
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(newAddressUrl);

            Address end = JsonConvert.DeserializeObject<Address>(conteudo);
            if (end.cep == null) return null;
            return end;
        }
    }
}
