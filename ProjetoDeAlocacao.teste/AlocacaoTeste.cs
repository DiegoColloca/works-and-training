using System;
using Xunit;

namespace ProjetoDeAlocacao.teste
{
    public class AlocacaoTeste
    {
        [Fact(DisplayName = "Deve retornar o Numero total de dias úteis")]
        public void RetorneONumeroTotalDeDiasUteis()
        {
            var projeto = new Projetos();
            var funcionario = new Funcionarios();
            var alocacao = new Alocacao(funcionario, projeto);
            alocacao.DataDeInicio = new DateTime(2019, 02, 11);
            alocacao.DataDeTermino = new DateTime(2019, 02, 18);




            var valorEsperado = 6;
            var valorAtual = alocacao.ContadorDeDiasUteis();


            Assert.Equal(valorEsperado, valorAtual);

        }

        [Fact(DisplayName = "Deve calcular o custo de alocação")]
        public void DeveCalcularOCustoDaAlocacao()
        {
            //Arrange
            var projeto = new Projetos();
            var funcionario = new Funcionarios();
            var alocacao = new Alocacao(funcionario, projeto);
            alocacao.DataDeInicio = new DateTime(2019, 02, 11);
            alocacao.DataDeTermino = new DateTime(2019, 02, 18);
            alocacao.CargaHoraria = 8;
            funcionario.CustoDoFuncionarioPorHora = 200;

            //Act
            var valorEsperado = 9600;
            var valorAtual = alocacao.CalcularCustoDaAlocacao();

            //Assert
            Assert.Equal(valorEsperado, valorAtual);  
        }

        [Fact(DisplayName ="Deve calcular o custo de todas as alocações")]
        public void DeveCalcularOCustoDeTodasAsAlocacoes()
        {
            //Funcionario 1
            var projeto = new Projetos();
            var funcionario = new Funcionarios();
            funcionario.CustoDoFuncionarioPorHora = 200;
            var alocacao = new Alocacao(funcionario, projeto);
            alocacao.CargaHoraria = 8;
            alocacao.DataDeInicio = new DateTime(2019, 02, 11);
            alocacao.DataDeTermino = new DateTime(2019, 02, 18);

            //Funcionario 2
            var funcionario2 = new Funcionarios();
            funcionario2.CustoDoFuncionarioPorHora = 300;
            var alocacao2 = new Alocacao(funcionario2, projeto);
            alocacao2.CargaHoraria = 6;
            alocacao2.DataDeInicio = new DateTime(2019, 02, 11);
            alocacao2.DataDeTermino = new DateTime(2019, 02, 17);



            var valorEsperado = 18600;
            var valorAtual = alocacao.CalcularOCustoDeTodasAsAlocacoes();

            Assert.Equal(valorEsperado, valorAtual);
            
            
            
            


        }





        
    }
}
