using System.Collections;
using System;
using UsageCollections;

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
            Console.Write("Votre choix : ");
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
            if (string.IsNullOrWhiteSpace(nom))
            {
                Console.WriteLine(" Veuillez entrer un nom.");
            }
        } while (string.IsNullOrWhiteSpace(nom));

        Console.Write("Note de Contrôle Continu (sur 20) : ");
        double noteCC = LireNote();

        Console.Write("Note de Devoir (sur 20) : ");
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
        Console.Write("Entrez le nom de l'étudiant à rechercher : ");
        string nom = Console.ReadLine();

        if (lstEtudiants.Contains(nom))
        {
            Etudiant etudiant = (Etudiant)lstEtudiants[nom];
            Console.WriteLine(etudiant.ToString());
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
        foreach (DictionaryEntry entry in lstEtudiants)
        {
            Etudiant etudiant = (Etudiant)entry.Value;
            Console.WriteLine(etudiant.ToString());
        }
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
