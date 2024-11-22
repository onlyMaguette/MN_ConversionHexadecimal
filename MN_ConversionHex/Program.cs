namespace MN_ConversionHex
{
    class Program
    {
        static void Main(string[] args)
        {
            // Liste pour stocker les conversions effectuées
            List<string> conversions = new List<string>();

            while (true)
            {
                Console.WriteLine("Entrez un entier à convertir en hexadécimal (ou 'q' pour quitter) :");
                string input = Console.ReadLine();

                // Permet de quitter le programme
                if (input.Equals("q", StringComparison.OrdinalIgnoreCase) ||
                    input.Equals("quitter", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                // Validation de l'entrée
                if (int.TryParse(input, out int number))
                {
                    string hexValue = ConvertToHexadecimal(number);
                    conversions.Add($"{number} => {hexValue}");
                    Console.WriteLine($"L'entier {number} en hexadécimal est : {hexValue}");
                }
                else
                {
                    Console.WriteLine("Veuillez entrer un entier valide.");
                }
            }

            // Afficher les conversions effectuées
            if (conversions.Count > 0)
            {
                Console.WriteLine("\nListe des conversions effectuées :");
                Console.WriteLine(new string('-', 30)); // Ligne de séparation pour l'esthétique
                foreach (string conversion in conversions)
                {
                    Console.WriteLine($"{conversion}");  // Utilisation d'un tiret pour marquer chaque conversion
                }
                Console.WriteLine(new string('-', 30)); // Ligne de séparation à la fin
            }
            else
            {
                Console.WriteLine("\nAucune conversion n'a été effectuée.");
            }

        }

        /// <summary>
        /// Convertit un entier en une chaîne hexadécimale
        /// </summary>
        /// <param name="number">Entier à convertir</param>
        /// <returns>Chaîne hexadécimale</returns>
        static string ConvertToHexadecimal(int number)
        {
            if (number == 0) return "0";

            string hexChars = "0123456789ABCDEF";
            string hexResult = "";

            // Conversion en hexadécimal
            while (number > 0)
            {
                int remainder = number % 16;
                hexResult = hexChars[remainder] + hexResult;
                number /= 16;
            }

            return hexResult;
        }
    }
}
