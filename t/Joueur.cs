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

            using (TextFieldParser lecteurCSV = new TextFieldParser("C:\\Users\\Arthur\\source\\repos\\t\\t\\utils\\JoueurDB.csv"))
            {
                lecteurCSV.TextFieldType = FieldType.Delimited;
                lecteurCSV.SetDelimiters(",");

                while (!lecteurCSV.EndOfData)
                {
                    string[] champs = lecteurCSV.ReadFields();
                    lignesCSV.Add(champs);
                }
                if (lignesCSV.Count == 0)
                {
                    ajoutJoueur();
                }

                for (int i = 0; i < lignesCSV.Count; i++) 
                {
                    if (lignesCSV[i][0] == nomJoueur)
                    {
                        this.scoreJoueur = lignesCSV[i][1];
                        break;
                    }
                    else
                    {
                        this.scoreJoueur = "0";
                        ajoutJoueur();
                        break;
                    }
                }
            }


        }

        public  void ajoutJoueur()
        {
            using (StreamWriter redacteur = new StreamWriter("C:\\Users\\Arthur\\source\\repos\\t\\t\\utils\\JoueurDB.csv",true))
            {
                redacteur.WriteLine(this.nomJoueur+",0") ;
            }
        }
    }
}
