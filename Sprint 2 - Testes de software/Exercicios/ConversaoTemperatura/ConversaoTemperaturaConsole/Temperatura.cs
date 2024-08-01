using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConversaoTemperaturaConsole
{
    public class Temperatura
    {
        public static float ConverterCelsiusParaFahrenheit(float temperaturaEmCelsius)
        {
            string calcResult = $"{((temperaturaEmCelsius * 1.8f) + 32f):F2}".ToString();
            return float.Parse(calcResult);
        }

        public static float ConverterFahrenheitParaCelsius(float temperaturaEmFahrenheit)
        {
            string calcResult = $"{(temperaturaEmFahrenheit - 32f) / 1.8f:F2}".ToString();
            return float.Parse(calcResult);
        }
    }
}
