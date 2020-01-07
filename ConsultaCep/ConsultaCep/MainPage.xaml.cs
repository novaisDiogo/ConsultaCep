using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ConsultaCep.Service;
using ConsultaCep.Service.Model;

namespace ConsultaCep
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnBuscar.Clicked += BuscarCep;
        }

        private void BuscarCep(object sender, EventArgs args)
        {
            string cep = txtName.Text.Trim();
            if (isValidCep(cep))
            {
                try
                {
                    Address end = ViaCepService.SearchAddressViaCep(cep);
                    if (end != null)
                    {
                        lbResultado.Text = string.Format("Endereço: {0}, {1}, {2}-{3}", end.logradouro, end.bairro, end.localidade, end.uf);
                    }
                    else
                    {
                        DisplayAlert("Erro", "O Endereço não foi encontrado para o cep encontrado: " + cep, "OK");
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("Erro Critico", e.Message, "OK");
                }
            }
        }
        private bool isValidCep(string cep)
        {
            bool valido = true;
            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "Cep Invalido! O cep deve conter 8 caracteres.", "OK");
                valido = false;
            }
            int novoCep = 0;
            if (!int.TryParse(cep, out novoCep))
            {
                DisplayAlert("ERRO", "Cep Invalido! O cep deve ser composto somente por numeros.", "OK");
                valido = false;
            }
            return valido;
        }
    }
}
