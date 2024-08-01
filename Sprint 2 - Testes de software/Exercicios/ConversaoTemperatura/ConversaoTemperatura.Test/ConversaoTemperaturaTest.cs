using Xunit;

namespace ConversaoTemperaturaConsole
{
    public class ConversaoTemperaturaTest
    {
        [Theory]
        [InlineData(10.5f)]
        [InlineData(5.0f)]
        [InlineData(25.8f)]
        [InlineData(30.0f)]
        public void ConverterGrausCelsiusParaFahrenheit(float temperaturaEmCelsius)
        {
            float temperaturaEmFahrenheit = Temperatura.ConverterCelsiusParaFahrenheit(temperaturaEmCelsius);
            float temperaturaConvertidaEmCelsius = Temperatura.ConverterFahrenheitParaCelsius(temperaturaEmFahrenheit);

            Assert.Equal(temperaturaEmCelsius, temperaturaConvertidaEmCelsius);
        }
        
        [Theory]
        [InlineData(5.0f)]
        [InlineData(25.5f)]
        [InlineData(10.2f)]
        public void ConverterGrausFahrenheitParaCelsius(float temperaturaEmFahrenheit)
        {
            float temperaturaEmCelsius = Temperatura.ConverterFahrenheitParaCelsius(temperaturaEmFahrenheit);
            float temperaturaConvertidaEmFahrenheit = Temperatura.ConverterCelsiusParaFahrenheit(temperaturaEmCelsius);

            Assert.Equal(temperaturaEmFahrenheit, temperaturaConvertidaEmFahrenheit);
        }
    }
}
