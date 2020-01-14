﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App2_Tarefa.Modelos;

namespace App2_Tarefa.Telas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cadastro : ContentPage
	{
		private byte Prioridade { get; set; }
		public Cadastro()
		{
			InitializeComponent();
		}

		private void PrioridadeSelectAction(object sender, EventArgs args)
		{
			var Stacks = SLPrioridades.Children;

			foreach (var Linha in Stacks)
			{
				Label lblPrioridade = ((StackLayout)Linha).Children[1] as Label;
				lblPrioridade.TextColor = Color.Gray;
			}

			((Label)((StackLayout)sender).Children[1]).TextColor = Color.Black;
			FileImageSource Source = ((Image)((StackLayout)sender).Children[0]).Source as FileImageSource;

			String Prioridade = Source.File.ToString().Replace("Resource/", "").Replace(".png", "").Replace("p", "");
			this.Prioridade = byte.Parse(Prioridade);
		}

		public void SalvarAction(object sender, EventArgs args)
		{
			bool erroExiste = false;
			if (txtNome.Text == null || txtNome.Text.Trim().Length <= 0)
			{
				erroExiste = true;
				DisplayAlert("Erro", "Tarefa não digitada", "OK");
			}

			if (Prioridade <= 0)
			{
				erroExiste = true;
				DisplayAlert("Erro", "Prioridade não escolhida", "OK");
			}
			if (erroExiste == false)
			{
				Tarefa tarefa = new Tarefa();
				tarefa.nome = txtNome.Text.Trim();
				tarefa.Prioridade = this.Prioridade;

				new GerenciadorTarefa().Salvar(tarefa);

				App.Current.MainPage = new NavigationPage(new Inicio());

			}
		}
	}
}