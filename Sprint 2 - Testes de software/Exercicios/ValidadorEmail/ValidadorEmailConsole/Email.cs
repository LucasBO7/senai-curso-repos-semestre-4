using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidadorEmailConsole
{
    public class Email
    {
        /// <summary>
        /// Valida um email
        /// </summary>
        /// <returns>true --> email válido, false --> email inválido</returns>
        public static bool ValidarEmail(string email)
        {
            // Verifica se há texto antes do @, depois do . e entre o @ e o .
            string pattern = @"^[^@]+@[^@]+\.[^@]+$";
            Match match = Regex.Match(email, pattern);

            // Se contém @ e terminar com ".com" ou ".com.br"
            if (match.Success && email.Contains('@') && email.EndsWith(".com") || email.EndsWith(".com.br"))
            {
                return true;
            }
            return false;
        }
    }
}
