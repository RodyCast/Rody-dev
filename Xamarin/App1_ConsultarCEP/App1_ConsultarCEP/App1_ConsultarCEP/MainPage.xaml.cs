using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1_ConsultarCEP.Servico.Modelo;
using App1_ConsultarCEP.Servico;

namespace App1_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			BOTAO.Clicked += BuscarCEP;

		}

		private void BuscarCEP(object sender, EventArgs args)
		{
			
			//ToDo - Validações

			string cep = CEP.Text.Trim();

			if (isValidCep(cep))
			{
				try
				{
					Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

					if (end != null)
					{
						RESULT.Text = string.Format("Endereço: {0}, bairro {1}, cidade de {2}, {3}", end.logradouro, end.bairro, end.localidade, end.uf);
					}
					else
					{
						DisplayAlert("Erro", "O endereço não foi encontrado para o CEP informado: " + cep, "OK");
					}
				}
				catch (Exception e)
				{
					DisplayAlert("ERRO CRÍTICO!", e.Message, "OK");
				}

			}
		}

		private bool isValidCep(string cep)
		{
			bool valid = true;

			if (cep.Length != 8)
			{
				//ERRO
				DisplayAlert("Erro", "CEP inválido! O CEP deve conter 8 caracteres.", "OK");
				valid = false;
			}
			int novoCep = 0;
			if (!int.TryParse(cep, out novoCep))
			{
				//ERRO
				DisplayAlert("Erro", "CEP inválido! O CEP deve ser composto apenas por números.", "OK");
				valid = false;
			}

			return valid;
		}


	}
}
