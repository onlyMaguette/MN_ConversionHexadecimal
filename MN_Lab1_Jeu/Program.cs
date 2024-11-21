using System;
using System.Collections.Generic;

namespace MN_Lab1_Jeu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans le jeu 'Trouver le nombre' !");
            bool rejouer = true;

            while (rejouer)
            {
                // Étape 3 : Personnalisation des bornes
                Console.WriteLine("\nVeuillez définir les bornes de l'intervalle.");
                int borneMin = LireBorne("Borne minimale : ");
                int borneMax = LireBorne("Borne maximale : ", borneMin);

                // Génération du nombre aléatoire à trouver
                Random random = new Random();
                int nombreATrouver = random.Next(borneMin, borneMax + 1);

                List<int> choixJoueur = new List<int>();
                int tentatives = 0;
                bool gagne = false;

                Console.WriteLine($"\nTrouvez le nombre mystère entre {borneMin} et {borneMax} !");

                // Étape 2 : Gestion des exceptions et boucle
                while (!gagne)
                {
                    try
                    {
                        Console.Write("\nEntrez votre choix : ");
                        int choix = LireNombre(borneMin, borneMax);

                        tentatives++;
                        choixJoueur.Add(choix);

                        if (choix == nombreATrouver)
                        {
                            gagne = true;
                            Console.WriteLine("\n🎉 Félicitations, vous avez trouvé le nombre mystère !");
                        }
                        else
                        {
                            Console.WriteLine("❌ Mauvais choix, essayez encore !");
                        }

                        Console.WriteLine($"Vos choix précédents : {string.Join(", ", choixJoueur)}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Erreur : {e.Message}");
                    }
                }

                // Calcul de la note
                double note = Math.Round((double)(borneMax - borneMin + 1) / tentatives, 2);
                Console.WriteLine($"\nVotre note est : {note}");

                // Rejouer ?
                Console.Write("\nVoulez-vous rejouer ? (oui/non) : ");
                string reponse = Console.ReadLine().ToLower();
                rejouer = reponse == "oui" || reponse == "o";
            }

            Console.WriteLine("Merci d'avoir joué ! À bientôt !");
        }

        /// <summary>
        /// Lecture sécurisée d'un nombre entier dans une plage donnée.
        /// </summary>
        static int LireNombre(int min, int max)
        {
            if (!int.TryParse(Console.ReadLine(), out int nombre) || nombre < min || nombre > max)
            {
                throw new ArgumentException($"Saisissez un nombre compris entre [{min}, {max}].");
            }

            return nombre;
        }

        /// <summary>
        /// Lecture sécurisée d'une borne pour définir l'intervalle.
        /// </summary>
        static int LireBorne(string message, int min = int.MinValue)
        {
            while (true)
            {
                Console.Write(message);
                try
                {
                    int borne = int.Parse(Console.ReadLine());
                    if (borne <= min)
                    {
                        Console.WriteLine($"Veuillez entrer une valeur supérieure à {min}.");
                    }
                    else
                    {
                        return borne;
                    }
                }
                catch
                {
                    Console.WriteLine("Veuillez entrer un nombre entier valide.");
                }
            }
        }
    }
}
