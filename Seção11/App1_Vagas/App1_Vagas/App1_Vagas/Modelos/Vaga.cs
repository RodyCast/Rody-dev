using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1_Vagas.Modelos
{
	[Table("Vaga")]
	public class Vaga
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string nomeVaga { get; set; }
		public short quantidade { get; set; }
		public string cidade { get; set; }
		public string empresa { get; set; }
		public double salario { get; set; }
		public string descricao { get; set; }
		public string tipoContratacao {get;  set;}
		public string telefone { get; set; }
		public string email { get; set; }
    }
}
