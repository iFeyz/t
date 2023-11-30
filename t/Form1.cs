using System.Drawing.Drawing2D;
using System.Diagnostics;
using static System.Windows.Forms.LinkLabel;

namespace t
{
    public partial class Form1 : Form
    {
        Plateau plateau = new Plateau();
        Joueur joueur;
        string[,] plateauContent;
        public Form1()
        {
            InitializeComponent();
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
                MessageBox.Show("Le champ de texte doit contenir des caractères.", "Erreur");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                Dictionnaire dico = new Dictionnaire();
                if (dico.RechercheMot(textBox2.Text.ToUpper()) == true)
                {
                    MessageBox.Show("Valide.", "Erreur");
                }
                if (dico.RechercheMot(textBox2.Text.ToUpper()) == false)
                {
                    MessageBox.Show("Pas valide.", "Erreur");
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (plateau.RechercheMot(textBox3.Text.ToUpper(),plateauContent).motPresent == true)
            {
                MessageBox.Show("Le mot est présent");
            }
            else if (plateau.RechercheMot(textBox3.Text.ToUpper(), plateauContent).motPresent == false)
            {
                MessageBox.Show("Le mot n'est pas present");
            }
        }
    }
}
