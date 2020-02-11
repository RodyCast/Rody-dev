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
	public partial class CadastroVagas : ContentPage
	{
		public CadastroVagas ()
		{
			InitializeComponent ();
		}
		public void SalvarAction(object sender, EventArgs args)
		{
			Vaga vaga = new Vaga();
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
			dataBase.Cadastro(vaga);

			App.Current.MainPage = new NavigationPage(new ConsultaVagas());
		}
	}
}