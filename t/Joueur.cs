using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace t
{
    internal class Joueur
    {
        public string nomJoueur;
        public string scoreJoueur;

        public Joueur(string nomJoueur)
        {
            this.nomJoueur = nomJoueur;

            List<string[]> lignesCSV = new List<string[]>();

            using (TextFieldParser lecteurCSV = new TextFieldParser("../../../utils/JoueurDB.csv"))
            {
                lecteurCSV.TextFieldType = FieldType.Delimited;
                lecteurCSV.SetDelimiters(",");

                while (!lecteurCSV.EndOfData)
                {
                    string[] champs = lecteurCSV.ReadFields();
                    lignesCSV.Add(champs);
                }
            bool joueurExiste = false;

            for (int i = 0; i < lignesCSV.Count; i++)
            {
                if (lignesCSV[i][0] == nomJoueur)
                {
                    this.scoreJoueur = lignesCSV[i][1];
                    joueurExiste = true;
                    break;
                }
            }

            if (!joueurExiste)
            {
                this.scoreJoueur = "0";
                ajoutJoueur();
            }
        }


        }


        public  void ajoutJoueur() // ajoute un joueur 
        {
            using (StreamWriter redacteur = new StreamWriter("../../../utils/JoueurDB.csv", true))
            {
                redacteur.WriteLine(this.nomJoueur+",0") ;
            }
        }
        public  void MettreAJourScore( string nomJoueur, int nouveauScore) // Met a jour dans le fchier le score
        {
            string[] lignes = File.ReadAllLines("../../../utils/JoueurDB.csv");
            for(int i = 0;i < lignes.Length; i++)
            {
                string[] elements = lignes[i].Split(",");
                if(elements.Length == 2 && elements[0].Trim() == nomJoueur) 
                {
                    lignes[i] = nomJoueur + "," + Convert.ToString(Convert.ToInt32(this.scoreJoueur)+nouveauScore);
                }
                File.WriteAllLines("../../../utils/JoueurDB.csv", lignes);
            }
           this.scoreJoueur = Convert.ToString(Convert.ToInt32(this.scoreJoueur) + 10);
        }



    }
}
