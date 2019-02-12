using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoDeAlocacao
{
    public class Alocacao
    {
        public bool EhOLider { get; set; }

        public DateTime DataDeInicio { get; set; }

        public DateTime DataDeTermino { get; set; }

        public double CargaHoraria { get; set; }

        public Funcionarios Funcionario { get; set; }

        public Projetos Projeto { get; set; }

        public Alocacao(Funcionarios funcionario, Projetos projeto)
        {
            this.Funcionario = funcionario;
            this.Projeto = projeto;

            projeto.Alocacoes.Add(this);
        }

        public int ContadorDeDiasUteis()
        {

            var contador = 0;

            for (DateTime i = DataDeInicio.Date; i <= DataDeTermino.Date; i = i.AddDays(1))
            {
                if (i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday)
                    contador++;
            }

            return contador;
        }
        public decimal  CalcularCustoDaAlocacao()
        {
            return (decimal)CargaHoraria * ContadorDeDiasUteis() * Funcionario.CustoDoFuncionarioPorHora;
        }

        public decimal CalcularOCustoDeTodasAsAlocacoes()
        {
            CalcularCustoDaAlocacao();

            decimal contador = 0;

            foreach (Alocacao item in this.Projeto.Alocacoes)
            {
                contador += item.CalcularCustoDaAlocacao();   
            }
            return contador;
        }
    }
}
