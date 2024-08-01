using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidadorEmailConsole;

namespace ValidadorEmail.Test
{
    public class ValidadorEmailTest
    {
        // Princípio AAA: Act, Arrange e Assert
        // Princípio AAA: Agir, Organizar e Provar
        [Theory]
        [InlineData("cois@gmail.com")]
        [InlineData("coisgmail.com")]
        [InlineData("cois@gmail")]
        [InlineData("cois@gmail.com.br")]
        [InlineData("c@oisgmail.com.br")]
        [InlineData("c@.com.br")]
        public void ValidarDominioDeEmail(string email)
        {
            // Agir (Act)
            bool emailValido = Email.ValidarEmail(email);

            // Provar (Assert)
            Assert.True(emailValido);
        }
    }
}
