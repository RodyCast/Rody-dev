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
	public partial class MinhasVagasCadastradas : ContentPage
	{
		List<Vaga> Lista { get; set; }
		public MinhasVagasCadastradas()
		{
			InitializeComponent();

			ConsultarVagas();
		}

		private void ConsultarVagas()
		{
			DataBase dataBase = new DataBase();
			Lista = dataBase.Consultar();
			ListaVagas.ItemsSource = Lista;

			lblCount.Text = Lista.Count.ToString();
		}

		public void EditarAction(object sender, EventArgs args)
		{
			Label lblEditar = (Label)sender;
			TapGestureRecognizer tapGest = (TapGestureRecognizer)lblEditar.GestureRecognizers[0];
			Vaga vaga = tapGest.CommandParameter as Vaga;
			Navigation.PushAsync(new EditarVaga(vaga));

		}
		public void ExcluirAction(object sender, EventArgs args)
		{
			Label lblExcluir = (Label)sender;
			TapGestureRecognizer tapGest = (TapGestureRecognizer)lblExcluir.GestureRecognizers[0];
			Vaga vaga = tapGest.CommandParameter as Vaga;

			DataBase dataBase = new DataBase();
			dataBase.Exclusao(vaga);

			ConsultarVagas();
		}
		public void PesquisarAction(object sender, TextChangedEventArgs args)
		{
			ListaVagas.ItemsSource = Lista.Where(a => a.nomeVaga.Contains(args.NewTextValue)).ToList();
		}
	}
}