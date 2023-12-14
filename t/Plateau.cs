using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Diagnostics.Eventing.Reader;

namespace t
{
    internal class Plateau
    {
        public int colonne;
        public int ligne;


        private static Random randInt = new Random();

        public static string[,] generationPlateau(int lignes, int colonnes)
        {
            // indiquer le chemin du fichier
            string filePath = "../../../utils/Lettre.csv";

            // Liste pour stocker les lignes 
            List<string[]> lignesCSV = new List<string[]>();

            // Lecture du fichier
            using (TextFieldParser lecteurCSV = new TextFieldParser(filePath))
            {
                lecteurCSV.TextFieldType = FieldType.Delimited;
                lecteurCSV.SetDelimiters(",");

                // Lecture des lignes
                while (!lecteurCSV.EndOfData)
                {
                    string[] champs = lecteurCSV.ReadFields();
                    lignesCSV.Add(champs);
                }
            }

            // Création du plateau

            string[,] plateau = new string[lignes, colonnes];
            for (int i = 0; i < plateau.GetLength(0); i++)
            {
                for (int j = 0; j < plateau.GetLength(1); j++)
                {
                    string addLetter = getLetter(lignesCSV);
                    plateau[i, j] = addLetter;
                }
            }

            return plateau;
        }

        private  static string getLetter(List<string[]> lignesCSV)
        {
            int nb = randInt.Next(0, 26);
            int intRemainLetter = int.Parse(lignesCSV[nb][1]);
            intRemainLetter--;

            if (intRemainLetter != 0)
            {
                string stringRemainLetter = intRemainLetter.ToString();
                lignesCSV[nb][1] = stringRemainLetter;
                return lignesCSV[nb][0];
            }
            else
            {
                return getLetter(lignesCSV); // Ajout de la récursivité manquante
            }
        }

        public  void toFile(string[,] plateau)
        {
            int nbSave = Directory.GetFiles("../../../save/").Length;
            string pathFile = "../../../save/" + nbSave + 1.ToString();
            using (StreamWriter redacteur = new StreamWriter(pathFile))
            {
                for (int i = 0; i < plateau.GetLength(0); i++)
                {
                    for (int j = 0; j < plateau.GetLength(1); j++)
                    {
                        if (j != plateau.GetLength(1) - 1)
                        {
                            redacteur.Write(plateau[i, j] + ",");
                        }
                        else
                        {
                            redacteur.Write(plateau[i, j]);
                        }
                    }
                    redacteur.Write("\n");
                }
            }

        }

        public string[,] toRead(string fileName)
        {
            List<string[]> lignesCSV = new List<string[]>();
            using (TextFieldParser lecteurCSV = new TextFieldParser(fileName))
            {
                lecteurCSV.TextFieldType = FieldType.Delimited;
                lecteurCSV.SetDelimiters(",");

                while (!lecteurCSV.EndOfData)
                {
                    string[] champs = lecteurCSV.ReadFields();
                    lignesCSV.Add(champs);
                }
            }

            int ligne = lignesCSV.Count;
            int colonne = lignesCSV[0].Length;
            string[,] plateau = new string[ligne, colonne];
            for (int i = 0; i < ligne; i++)
            {
                for (int j = 0; j < colonne; j++)
                {
                    string addLetter = lignesCSV[i][j];
                    plateau[i, j] = addLetter;
                }
            }

            return plateau;

        }

        public static void afficherPlateau(string[,] plateau)
        {

            for (int i = 0; i < plateau.GetLength(0); i++)
            {
                for (int j = 0; j < plateau.GetLength(1); j++)
                {
                    Console.Write(plateau[i, j] + "\t");
                }
                Console.WriteLine(); // Passer à la ligne suivante après chaque ligne de la matrice
            }

        }
        public static string[,] majPlateau(string[,] plateauContent,RecherchePlateau recherchePlateau)
        {
            for(int i = 0; i<recherchePlateau.indexMotTrouver.Count()-1;i++)
            {
                plateauContent[recherchePlateau.indexMotTrouver[i][0]-1, recherchePlateau.indexMotTrouver[i][1]] = "";
            }
            for (int colonne = 0; colonne < plateauContent.GetLength(1); colonne++)
            {
                for (int ligne = plateauContent.GetLength(0) - 1; ligne >= 0; ligne--)
                {
                    if (plateauContent[ligne, colonne] == "")
                    {
                        // Chercher la première lettre non vide au-dessus
                        int nouvelleLigne = ligne - 1;
                        while (nouvelleLigne >= 0 && plateauContent[nouvelleLigne, colonne] == "")
                        {
                            nouvelleLigne--;
                        }

                        if (nouvelleLigne >= 0)
                        {
                            // Déplacer la lettre vers le bas
                            plateauContent[ligne, colonne] = plateauContent[nouvelleLigne, colonne];
                            plateauContent[nouvelleLigne, colonne] = "";
                        }
                    }
                }
            }

            return plateauContent;
        }

        public class RecherchePlateau
        {

            public int indexMot;
            public List<int[]> indexMotTrouver = new List<int[]>();
            public bool? motPresent;
            public bool? isPresentGauche;
            public bool? isPresentDroite;
            public bool? isPresentHaut;

        }

        public RecherchePlateau RechercheMot(string mot , string[,] plateau) // void a changer
        {
            for(int i=0; i < plateau.GetLength(1); i++)
            {
                RecherchePlateau recherchePlateau = new RecherchePlateau();
                recherchePlateau.indexMotTrouver.Add(new int[] { plateau.GetLength(0),i });
                if(RechercheMotRecursif(recherchePlateau).motPresent == true)
                {
                    return recherchePlateau;
                }
            }
            RecherchePlateau falsePlateau = new RecherchePlateau();
            falsePlateau.motPresent = false;
            return falsePlateau;

            RecherchePlateau RechercheMotRecursif(RecherchePlateau recherchePlateau)
            {


                RecherchePlateau RecherheMotRecursifGauche(RecherchePlateau recherchePlateau)
                {
                    int lignetoCheck = recherchePlateau.indexMotTrouver[recherchePlateau.indexMot][0] - 1;
                    int colonnetoCheck = recherchePlateau.indexMotTrouver[recherchePlateau.indexMot][1];
                    if ( (colonnetoCheck > plateau.GetLength(1) - 1 && colonnetoCheck >0) || (lignetoCheck > plateau.GetLength(0) - 1 && lignetoCheck >0))
                    {
                        recherchePlateau.isPresentGauche = false;
                        return (RechercheMotRecursif(recherchePlateau));
                    }
                    if (plateau[lignetoCheck, colonnetoCheck] == mot[recherchePlateau.indexMot].ToString())
                    {
                        recherchePlateau.isPresentGauche = true;
                        recherchePlateau.indexMotTrouver.Add(new int[] { lignetoCheck, colonnetoCheck });
                        recherchePlateau.indexMot++;
                        recherchePlateau.isPresentHaut = null;
                        recherchePlateau.isPresentDroite = null;

                        if (recherchePlateau.indexMot == mot.Length)
                        {
                            recherchePlateau.motPresent = true;
                            return (RechercheMotRecursif(recherchePlateau));
                        }
                        return (RechercheMotRecursif(recherchePlateau));
                    } 
                    else
                    {
                        recherchePlateau.isPresentGauche = false;
                        return (RechercheMotRecursif(recherchePlateau));
                    }
                    
                }
                RecherchePlateau RecherheMotRecursifDroite(RecherchePlateau recherchePlateau)
                {
                   
                    int lignetoCheck = recherchePlateau.indexMotTrouver[recherchePlateau.indexMot][0]+1;
                    int colonnetoCheck = recherchePlateau.indexMotTrouver[recherchePlateau.indexMot][1];
                    if(colonnetoCheck > plateau.GetLength(1)-1 || lignetoCheck > plateau.GetLength(0)-1)
                    {
                        recherchePlateau.isPresentDroite = false;
                        return (RechercheMotRecursif(recherchePlateau));
                    }
                    if (plateau[lignetoCheck, colonnetoCheck] == mot[recherchePlateau.indexMot].ToString())
                    {
                        recherchePlateau.isPresentDroite = true;
                        recherchePlateau.indexMotTrouver.Add(new int[] { lignetoCheck, colonnetoCheck });
                        recherchePlateau.indexMot++;
                        recherchePlateau.isPresentHaut = null;
                        recherchePlateau.isPresentGauche = null;

                        if (recherchePlateau.indexMot == mot.Length)
                        {
                            recherchePlateau.motPresent = true;
                            return (RechercheMotRecursif(recherchePlateau));
                        }
                        return (RechercheMotRecursif(recherchePlateau));
                    }
                    else
                    {
                        recherchePlateau.isPresentDroite = false;
                        return (RechercheMotRecursif(recherchePlateau));
                    }

                }
                RecherchePlateau RecherheMotRecursifHaut(RecherchePlateau recherchePlateau)
                {
                    int lignetoCheck = recherchePlateau.indexMotTrouver[recherchePlateau.indexMot][0];
                    int colonnetoCheck = recherchePlateau.indexMotTrouver[recherchePlateau.indexMot][1]-1;
                    if (colonnetoCheck > plateau.GetLength(1) - 1 || lignetoCheck > plateau.GetLength(0) - 1 || colonnetoCheck<0)
                    {
                        recherchePlateau.isPresentHaut = false;
                        return (RechercheMotRecursif(recherchePlateau));
                    }
                    if (plateau[lignetoCheck, colonnetoCheck] == mot[recherchePlateau.indexMot].ToString())
                    {
                        recherchePlateau.isPresentHaut = true;
                        recherchePlateau.indexMotTrouver.Add(new int[] { lignetoCheck, colonnetoCheck });
                        recherchePlateau.indexMot++;
                        recherchePlateau.isPresentDroite = null;
                        recherchePlateau.isPresentGauche = null;

                        if (recherchePlateau.indexMot == mot.Length)
                        {
                            recherchePlateau.motPresent = true;
                            return (RechercheMotRecursif(recherchePlateau));
                        }
                        return (RechercheMotRecursif(recherchePlateau));
                    }
                    else
                    {
                        recherchePlateau.isPresentHaut = false;
                        return (RechercheMotRecursif(recherchePlateau));
                    }

                }

                if (recherchePlateau.motPresent == true)
                {
                    return (recherchePlateau);
                }
                if (recherchePlateau.indexMot == mot.Length && recherchePlateau.motPresent == null)
                {
                    recherchePlateau.motPresent = false;
                    return (recherchePlateau);
                }
                if(recherchePlateau.isPresentGauche == false && recherchePlateau.isPresentDroite == false && recherchePlateau.isPresentHaut == false)
                {
                    recherchePlateau.motPresent = false;
                    return (recherchePlateau);
                }

                if(recherchePlateau.isPresentGauche ==  false && recherchePlateau.isPresentDroite == null) 
                {
                    RecherheMotRecursifDroite(recherchePlateau);
                }
                if(recherchePlateau.isPresentDroite == false && recherchePlateau.isPresentGauche == false)
                {
                    RecherheMotRecursifHaut(recherchePlateau);
                }
                if(recherchePlateau.isPresentHaut == false && recherchePlateau.isPresentGauche == false && recherchePlateau.isPresentDroite == false)
                {
                    RecherheMotRecursifGauche(recherchePlateau);
                }
                RecherheMotRecursifGauche(recherchePlateau);
                return recherchePlateau;
            }
        }

    }
}

