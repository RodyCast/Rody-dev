using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_TipoPaginaXF.TipoPagina.Master
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : MasterDetailPage
	{
		public Master()
		{
			InitializeComponent();
		}
		private void MudarPagina1(object sender, EventArgs args)
		{
			Detail = new NavigationPage(new Navegation.Pagina1());
			//Faz com que o menu volte a esconder depois de clicar
			IsPresented = false;
		}
		private void MudarPagina2(object sender, EventArgs args)
		{
			Detail = new Navegation.Pagina2();
			IsPresented = false;
		}
		private void MudarPagina3(object sender, EventArgs args)
		{
			Detail = new Conteudo();
			IsPresented = false;
		}
	}
}