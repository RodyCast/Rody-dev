using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1_Vagas.Modelos;
using App1_Vagas.Banco;

namespace App1_Vagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditarVaga : ContentPage
	{
		private Vaga vaga { get; set; }
		public EditarVaga (Vaga vaga)
		{
			InitializeComponent ();
			this.vaga = vaga;
			NomeVaga.Text = vaga.nomeVaga;
			Empresa.Text = vaga.empresa;
			Quantidade.Text = vaga.quantidade.ToString();
			Cidade.Text = vaga.cidade;
			Descricao.Text = vaga.descricao;
			TipoContratacao.IsToggled = (vaga.tipoContratacao == "CLT") ? false : true;
			Telefone.Text = vaga.telefone;
			Email.Text = vaga.email;
			Salario.Text = vaga.salario.ToString();
		}
		public void SalvarAction(object sender, EventArgs args)
		{
			vaga.nomeVaga = NomeVaga.Text;
			vaga.quantidade = short.Parse(Quantidade.Text);
			vaga.salario = double.Parse(Salario.Text);
			vaga.empresa = Empresa.Text;
			vaga.cidade = Cidade.Text;
			vaga.descricao = Descricao.Text;
			vaga.tipoContratacao = (TipoContratacao.IsToggled) ? "PF" : "CLT";
			vaga.telefone = Telefone.Text;
			vaga.email = Email.Text;

			DataBase dataBase = new DataBase();
			dataBase.Atualizacao(vaga);

			App.Current.MainPage = new NavigationPage(new MinhasVagasCadastradas());
		}
	}
}