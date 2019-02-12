using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoDeAlocacao
{
    public class Projetos
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime DataDeInicio { get; set; }

        public DateTime DataDeTermino { get; set; }

        public Clientes Cliente { get; set; }

        public List<Alocacao> Alocacoes { get; set; }

        public Projetos()
        {
            this.Alocacoes = new List<Alocacao>();

        }


    }
}
