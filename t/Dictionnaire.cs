using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t
{
    internal class Dictionnaire
    {
        private string[] mots;

        public Dictionnaire()
        {
            // Lecture des mots depuis le fichier et séparation par espace
            mots = File.ReadAllText("../../../utils/Mots_Français.txt").Split(' ');

            // Tri des mots
            Array.Sort(mots);
        }

        public bool RechercheMot(string motARechercher)
        {
            // Recherche dichotomique
            return RechercheDichotomique(motARechercher);
        }

        private bool RechercheDichotomique(string element)
        {
            int debut = 0;
            int fin = mots.Length - 1;

            while (debut <= fin)
            {
                int milieu = (debut + fin) / 2;
                int comparaison = String.Compare(mots[milieu], element);

                if (comparaison == 0)
                {
                    // Le mot a été trouvé
                    return true;
                }
                else if (comparaison < 0)
                {
                    debut = milieu + 1;
                }
                else
                {
                    fin = milieu - 1;
                }
            }

            // Le mot n'a pas été trouvé
            return false;
        }
    }
}
