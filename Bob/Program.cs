using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using OpenAI.API;

class Program
{
    static async Task Main(string[] args)
    {
        bool continueExecution = true;
        var openaiApiKey = "VOTRE CLE API OPEN AI";
        var openAICorrect = new Corriger(openaiApiKey);
        var translator = new Traduire(openaiApiKey);

        while (continueExecution)
        {
            Console.WriteLine("Veuillez entrer une commande (--c pour corriger, --t pour traduire) :");
            string input = Console.ReadLine();

            if (input == "--c")
            {
                Console.WriteLine("Veuillez entrer le texte à corriger :");
                string textToCorrect = Console.ReadLine();
                string correctedText = await openAICorrect.CorrectTextAsync(textToCorrect);
                Console.WriteLine(correctedText);


            }
            else if (input == "--t")
            {
                Console.WriteLine("Veuillez entrer une phrase à traduire en anglais :");
                string textToTranslate = Console.ReadLine();
                string translatedText = await translator.TranslateTextToEnglishAsync(textToTranslate);
                Console.WriteLine("Traduction en anglais :");
                Console.WriteLine(translatedText);
            }
            else if (input == "create")
            {
                Console.WriteLine("Création de l'application React et installation des dépendances...");
            }
            else
            {
                Console.WriteLine("Commande non reconnue. Veuillez réessayer.");
            }

            Console.Write("Voulez-vous exécuter une autre commande ? (yes/y, no/n) : ");
            string response = Console.ReadLine();

            if (response.ToLower() == "no" || response.ToLower() == "n")
            {
                continueExecution = false;
            }
        }

        Console.WriteLine("Fin de l'application.");
    }




}
