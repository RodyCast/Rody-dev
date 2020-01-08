using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SwichPage : ContentPage
	{
		public SwichPage ()
		{
			InitializeComponent ();
		}

		private void ActionTrocou(object sender, ToggledEventArgs args)
		{
			lblResult.Text = DateTime.Now.ToString("HH:mm") + " - " + args.Value;
		}
	}
}