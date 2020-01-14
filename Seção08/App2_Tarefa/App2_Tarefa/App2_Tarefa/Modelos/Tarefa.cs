using System;
using System.Collections.Generic;
using System.Text;

namespace App2_Tarefa.Modelos
{
    public class Tarefa
    {
		public string nome { get; set; }
		//public Nullable<DateTime> dataFinalizacao { get; set; } tanto o anterior quanto o proximo fazem a var aceitar null
		public DateTime? dataFinalizacao { get; set; }
		public byte Prioridade { get; set; }
    }
}
