namespace  ApiRoutingDrills.Services
{
    public class ConverterService
    {
        public decimal ConvertCelsiusToFahrenheit(decimal celsius)
        {
            decimal fahrenheit = (celsius * 9 / 5) + 32;
            return fahrenheit ;
        }
    }
}