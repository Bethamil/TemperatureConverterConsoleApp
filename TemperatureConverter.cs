namespace testApp
{
    internal class TemperatureConverter
    {
        public void Run()
        {
            Console.WriteLine("Welcome to the temperature Converter");
            Boolean again = true;

            while (again)
            {
                Console.Write("To convert to Fahrenheit, choose 1. To convert to Celsius, choose 2: ");
                string choice = Console.ReadLine()!;

                try
                {
                    again = ConvertTemp(choice);
                }
                catch
                {
                    Console.WriteLine("Please enter a 1 or a 2");
                };
            }

        }

        private Boolean ConvertTemp(string choice)
        {
            int celOrFahr = Convert.ToInt16(choice);
            switch (celOrFahr)
            {
                case 1:
                    Console.WriteLine($"The temperature in Fahrenheit is {Math.Round((TempToDouble(AskTemperature()) * 1.8) + 32, 2)}");
                    return TryAgain();
                case 2:
                    Console.WriteLine($"The temperature in Celsius is {Math.Round((TempToDouble(AskTemperature()) - 32) * 0.5556, 2)}");
                    return TryAgain();
                default:
                    Console.Write("Please enter a 1 or a 2: ");
                    choice = Console.ReadLine()!;
                    return ConvertTemp(choice);
            }
        }

        private static string AskTemperature()
        {
            Console.Write("What's the temperature: ");
            return Console.ReadLine()!;
        }


        private double TempToDouble(string tempStr)
        {
            try
            {
                return Convert.ToDouble(tempStr);
            }
            catch
            {
                Console.Write("Please enter a valid number: ");
                tempStr = Console.ReadLine()!;
                return TempToDouble(tempStr);
            }
        }

        private Boolean TryAgain()
        {
            Console.Write("Try again? Y or N: ");
            string answer = Console.ReadLine()!.ToUpper();
            return answer switch
            {
                "Y" => true,
                "N" => false,
                _ => TryAgain(),
            };
        }
    }
}
