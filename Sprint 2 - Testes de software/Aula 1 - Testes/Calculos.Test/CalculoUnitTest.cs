namespace Calculos.Test
{
    public class CalculoUnitTest
    {
        // Princípio AAA: Act, Arrange e Assert
        // Princípio AAA: Agir, Organizar e Provar
        [Fact]
        public void SomarDoisNumeros()
        {
            // Organizar (Arrange)
            double n1 = 3.3;
            double n2 = 2.2;
            double valorEsperado = 5.5;

            // Agir (Act)
            double resultadoSoma = Calculo.Somar(n1, n2); // Execulta a função de soma e retorna o resultado da operação

            // Provar (Assert)
            Assert.Equal(valorEsperado, resultadoSoma); // Verifica se os valores dos parâmetros são iguais
        }

        [Fact]
        public void SubtrairDoisNumeros()
        {
            double n1 = 4.2;
            double n2 = 2.1;
            double valorEsperado = 2.1;

            // Execulta a função de soma e retorna o resultado da operação
            var x = Calculo.Subtrair(n1, n2);

            // Verifica se os valores dos parâmetros são iguais
            Assert.Equal(valorEsperado, x);
        }

        [Fact]
        public void MultilpicarDoisNumeros()
        {
            double n1 = 2.0;
            double n2 = 2.0;
            double valorEsperado = 4.0;

            // Execulta a função de soma e retorna o resultado da operação
            double resultadoSoma = Calculo.Multilpicar(n1, n2);

            // Verifica se os valores dos parâmetros são iguais
            Assert.Equal(valorEsperado, resultadoSoma);
        }

        [Fact]
        public void DividirDoisNumeros()
        {
            double n1 = 6.0;
            double n2 = 3.0;
            double valorEsperado = 2.0;

            // Execulta a função de soma e retorna o resultado da operação
            double resultadoSoma = Calculo.Dividir(n1, n2);

            // Verifica se os valores dos parâmetros são iguais
            Assert.Equal(valorEsperado, resultadoSoma);
        }
    }
}