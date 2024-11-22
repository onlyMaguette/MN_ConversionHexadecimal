using System;
using System.Collections.Generic;

namespace MN_Lab1_Jeu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();  // Pour nettoyer la console avant d'afficher le message
            Console.ForegroundColor = ConsoleColor.Cyan; // Changer la couleur du texte

            Console.WriteLine("**********************************************");
            Console.WriteLine("*                                            *");
            Console.WriteLine("*        Bienvenue dans le jeu               *");
            Console.WriteLine("*        'Trouver le nombre' !                *");
            Console.WriteLine("*                                            *");
            Console.WriteLine("**********************************************");

            Console.ResetColor(); // Réinitialiser la couleur de texte par défaut

            // Petite pause pour l'effet
            Console.WriteLine("\nPréparez-vous à jouer...");
            Thread.Sleep(1000);  // Attendre 1 seconde pour ajouter un effet de suspense

            Console.WriteLine("\nLe but du jeu est simple :");
            Console.WriteLine("Devinez le nombre mystère entre les bornes.");
            Console.WriteLine("Bonne chance !");
            Console.WriteLine();  // Ajouter un espace entre les messages

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
                            Console.ForegroundColor = ConsoleColor.Green;  // Changer la couleur en vert pour la victoire
                            Console.WriteLine("\nFélicitations !");
                            Console.WriteLine("Vous avez trouvé le nombre mystère !");
                            Console.WriteLine($"Il était bien {nombreATrouver} !");
                            Console.ResetColor(); // Réinitialiser la couleur après l'affichage du message
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;  // Changer la couleur en rouge pour l'échec
                            Console.WriteLine("\nMauvais choix !");
                            Console.WriteLine("Dommage, essayez encore !");
                            Console.ResetColor(); // Réinitialiser la couleur après l'affichage du message
                        }

                        Console.WriteLine("\n--------------------");
                        Console.WriteLine($"Vos choix précédents : {string.Join(", ", choixJoueur)}");
                        Console.WriteLine("--------------------\n");

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{e.Message}");
                    }
                }

                // Calcul de la note
                double note = Math.Round((double)(borneMax - borneMin + 1) / tentatives, 2);
                Console.WriteLine($"\nVotre note est : {note}");

                // Rejouer ?
                string reponse;
                do
                {
                    Console.Write("\nVoulez-vous rejouer ? (oui/non) : ");
                    reponse = Console.ReadLine().Trim().ToLower();

                    // Vérifier les variantes acceptées
                    if (string.IsNullOrEmpty(reponse) || (reponse != "oui" && reponse != "o" && reponse != "non" && reponse != "n"))
                    {
                        Console.WriteLine("Entrée incorrecte. Veuillez réessayer.");
                    }
                }
                while (string.IsNullOrEmpty(reponse) || (reponse != "oui" && reponse != "o" && reponse != "non" && reponse != "n"));

                // Déterminer si on rejoue
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
