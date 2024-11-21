using System;
using System.Collections;

namespace UsageCollections
{
    public class Etudiant
    {
        public string Nom { get; set; }
        public double NoteCC { get; set; } // Note de Contrôle Continu
        public double NoteDevoir { get; set; } // Note de Devoir

        /// <summary>
        /// Calcul de la moyenne pondérée (33% pour NoteCC et 67% pour NoteDevoir)
        /// </summary>
        /// <returns>Moyenne pondérée</returns>
        public double CalculerMoyenne()
        {
            return (NoteCC * 0.33) + (NoteDevoir * 0.67);
        }

        public override string ToString()
        {
            return $"Nom: {Nom}, Note CC: {NoteCC}, Note Devoir: {NoteDevoir}, Moyenne: {CalculerMoyenne():F2}";
        }
    }
}