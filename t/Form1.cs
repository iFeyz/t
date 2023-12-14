using System.Drawing.Drawing2D;
using System.Diagnostics;
using static System.Windows.Forms.LinkLabel;
using System;

namespace t
{
    public partial class Form1 : Form
    {
        Plateau plateau = new Plateau();
        Joueur joueur;
        string[,] plateauContent;
        private System.Timers.Timer t;
        private System.Timers.Timer t2;
        int m, s;
        int m2, s2;
        private DateTime tempsDebut;
        private int tempsLimite = 20000;
        public Form1()
        {
            InitializeComponent();

            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;

            t2 = new System.Timers.Timer();
            t2.Interval = 1000;
            t2.Elapsed += OnTimeEvent2;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (joueur == null)
            {
                MessageBox.Show("Renseigner d'abord le nom du joueur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Debug.WriteLine("test");
                using (generationPlateau genPlateau = new generationPlateau())
                {
                    if (genPlateau.ShowDialog() == DialogResult.OK)
                    {
                        int ligne = genPlateau.ligne;
                        int colonne = genPlateau.colonne;
                        plateauContent = Plateau.generationPlateau(ligne, colonne);

                        afficherTableau(plateau);
                    }
                }
                button5.Visible = true;
                textBox2.Visible = true;
                t.Start();




            }

        }
        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                s += 1;
                if (s == 60)
                {
                    s = 0;
                    m += 1;

                }
                label3.Text = string.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
            }));
            if (m == 5)
            {
                t.Stop();
                MessageBox.Show("Le temps de jeux est �couler vous avez perdu.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }
        private void OnTimeEvent2(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                s2 += 1;
                if (s2 == 60)
                {
                    s2 = 0;
                    m2 += 1;

                }
                label6.Text = string.Format("{0}:{1}", m2.ToString().PadLeft(2, '0'), s2.ToString().PadLeft(2, '0'));
            }));
            if (m2 == 1)
            {
                t.Stop();
                MessageBox.Show("Le temps de jeux est �couler vous avez perdu.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        private void afficherTableau(Plateau plateau)
        {
            DataGridView dataGridView = Controls.OfType<DataGridView>().FirstOrDefault();
            dataGridView.Columns.Clear();
            // Ajoutez les colonnes
            for (int i = 0; i < plateauContent.GetLength(1); i++)
            {
                dataGridView.Columns.Add(i.ToString(), i.ToString());
            }

            // Ajoutez les lignes
            for (int i = 0; i < plateauContent.GetLength(0); i++)
            {
                dataGridView.Rows.Add();
                for (int j = 0; j < plateauContent.GetLength(1); j++)
                {
                    dataGridView.Rows[i].Cells[j].Value = plateauContent[i, j];
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                joueur = new Joueur(textBox1.Text);
                button4.Visible = false;
                textBox1.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label1.Text = "Nom :" + joueur.nomJoueur;
                label2.Text = "Score :" + joueur.scoreJoueur;
            }
            else
            {
                MessageBox.Show("Le champ de texte doit contenir des caract�res.", "Erreur");
            }
        }

        public void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                Dictionnaire dico = new Dictionnaire();

                //if (dico.RechercheMot(textBox2.Text.ToUpper()) == true && plateau.RechercheMot(textBox2.Text.ToUpper(), plateauContent).motPresent == true)
                 if (plateau.RechercheMot(textBox2.Text.ToUpper(), plateauContent).motPresent == true)
                {
                    MessageBox.Show("Mot Trouv�.", "Erreur");
                    //prendre la liste du plateau et actualiser le plateau 
                    plateauContent = Plateau.majPlateau(plateauContent, plateau.RechercheMot(textBox2.Text.ToUpper(), plateauContent));
                    afficherTableau(plateau);
                    joueur.MettreAJourScore(joueur.nomJoueur, 10); // changer le score
                    label2.Text = "Score :" + joueur.scoreJoueur;
                    t2.Start();

                }
                else if (dico.RechercheMot(textBox2.Text.ToUpper()) == false || plateau.RechercheMot(textBox2.Text.ToUpper(), plateauContent).motPresent == false)
                {
                    MessageBox.Show("Ce mot n'est pas dans le dictionnaire ou dans le tableau.", "Erreur");

                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            plateau.toFile(plateauContent);
            MessageBox.Show("Partie bien sauvegarder.", "Erreur");
            Environment.Exit(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (joueur == null)
            {
                MessageBox.Show("Renseigner d'abord le nom du joueur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Selectioner sauvegarde";
                openFileDialog1.InitialDirectory = "../../../save/";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != "")
                {
                    string nomSauvegarde = openFileDialog1.FileName;
                    plateauContent = plateau.toRead(nomSauvegarde);
                    afficherTableau(plateau);

                    button5.Visible = true;
                    textBox2.Visible = true;
                    t.Start();
                }
                else
                {
                    MessageBox.Show("Mauvais fichier.", "Erreur");
                }
            }

        }
    }
}
