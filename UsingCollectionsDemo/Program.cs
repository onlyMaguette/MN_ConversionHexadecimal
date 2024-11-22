using System.Collections;
using System;
using UsageCollections;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        SortedList lstEtudiants = new SortedList();

        while (true)
        {
            Console.WriteLine("\nMenu :");
            Console.WriteLine("1. Ajouter un étudiant");
            Console.WriteLine("2. Afficher les détails d'un étudiant");
            Console.WriteLine("3. Afficher tous les étudiants");
            Console.WriteLine("4. Quitter le programme");
            Console.Write("Veuillez sélectionner une option : ");
            string choix = Console.ReadLine().ToLower();

            if (choix == "q" || choix == "quitter")
            {
                Console.WriteLine("Programme terminé.");
                return;
            }

            switch (choix)
            {
                case "1":
                    AjouterEtudiant(lstEtudiants);
                    break;
                case "2":
                    AfficherUnEtudiant(lstEtudiants);
                    break;
                case "3":
                    AfficherTousLesEtudiants(lstEtudiants);
                    break;
                case "4":
                    Console.WriteLine("Programme terminé.");
                    return;
                default:
                    Console.WriteLine("Choix invalide. Veuillez réessayer.");
                    break;
            }
        }
    }

    /// <summary>
    /// Ajoute un étudiant à la collection
    /// </summary>
    /// <param name="lstEtudiants">Liste des étudiants</param>
    static void AjouterEtudiant(SortedList lstEtudiants)
    {
        string nom;

        do
        {
            Console.Write("Nom de l'étudiant : ");
            nom = Console.ReadLine();

            // Vérification que le nom ne contient que des lettres
            if (string.IsNullOrWhiteSpace(nom) || !Regex.IsMatch(nom, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine("\nLe nom ne doit contenir que des lettres. Veuillez réessayer.");
            }
        } while (string.IsNullOrWhiteSpace(nom) || !Regex.IsMatch(nom, @"^[a-zA-Z]+$"));

        Console.Write("Note de Contrôle Continu : ");
        double noteCC = LireNote();

        Console.Write("Note de Devoir : ");
        double noteDevoir = LireNote();

        Etudiant etudiant = new Etudiant
        {
            Nom = nom,
            NoteCC = noteCC,
            NoteDevoir = noteDevoir
        };

        lstEtudiants.Add(nom, etudiant);
        Console.WriteLine("Étudiant ajouté avec succès !");
    }

    /// <summary>
    /// Affiche les détails d'un étudiant spécifique
    /// </summary>
    /// <param name="lstEtudiants">Liste des étudiants</param>
    static void AfficherUnEtudiant(SortedList lstEtudiants)
    {
        string nom;

        do
        {
            Console.Write("Entrez le nom de l'étudiant à rechercher : ");
            nom = Console.ReadLine();

            // Vérification que le nom ne contient que des lettres
            if (string.IsNullOrWhiteSpace(nom) || !Regex.IsMatch(nom, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine("\nLe nom ne doit contenir que des lettres. Veuillez réessayer.");
            }
        } while (string.IsNullOrWhiteSpace(nom) || !Regex.IsMatch(nom, @"^[a-zA-Z]+$"));

        if (lstEtudiants.Contains(nom))
        {
            Etudiant etudiant = (Etudiant)lstEtudiants[nom];
            Console.WriteLine("\nDétails de l'étudiant :");
            Console.WriteLine(new string('-', 30)); // Affichage d'une ligne horizontale
            Console.WriteLine($"{"Nom",-15}: {etudiant.Nom}");
            Console.WriteLine($"{"Note CC",-15}: {etudiant.NoteCC:F2}");
            Console.WriteLine($"{"Note Devoir",-15}: {etudiant.NoteDevoir:F2}");
            Console.WriteLine($"{"Moyenne",-15}: {etudiant.CalculerMoyenne():F2}");
            Console.WriteLine(new string('-', 30)); // Affichage d'une ligne horizontale
        }
        else
        {
            Console.WriteLine("Aucun étudiant trouvé avec ce nom.");
        }
    }


    /// <summary>
    /// Affiche les détails de tous les étudiants
    /// </summary>
    /// <param name="lstEtudiants">Liste des étudiants</param>
    static void AfficherTousLesEtudiants(SortedList lstEtudiants)
    {
        if (lstEtudiants.Count == 0)
        {
            Console.WriteLine("Aucun étudiant dans la liste.");
            return;
        }

        Console.WriteLine("\nListe des étudiants :");
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine("{0,-20} {1,-10} {2,-15} {3,-10}", "Nom", "Note CC", "Note Devoir", "Moyenne");
        Console.WriteLine("------------------------------------------------------------");

        foreach (DictionaryEntry entry in lstEtudiants)
        {
            Etudiant etudiant = (Etudiant)entry.Value;
            Console.WriteLine("{0,-20} {1,-10:F2} {2,-15:F2} {3,-10:F2}",
                etudiant.Nom, etudiant.NoteCC, etudiant.NoteDevoir, etudiant.CalculerMoyenne());
        }
        Console.WriteLine("------------------------------------------------------------");
    }

    /// <summary>
    /// Lecture sécurisée d'une note avec validation
    /// </summary>
    /// <returns>Note valide entre 0 et 20</returns>
    static double LireNote()
    {
        while (true)
        {
            if (double.TryParse(Console.ReadLine(), out double note) && note >= 0 && note <= 20)
            {
                return note;
            }
            else
            {
                Console.Write("Veuillez entrer une note valide (entre 0 et 20) : ");
            }
        }
    }
}
