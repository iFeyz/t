using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace t
{
    public partial class generationPlateau : Form
    {
        public int ligne { get; set; }
        public int colonne {  get; set; }   
        public generationPlateau()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string texteLigne = textBox1.Text;
            string texteColonne = textBox2.Text;

            if (int.TryParse(texteLigne, out int nombreDeLignes) && int.TryParse(texteColonne, out int nombreDeColonnes))
            {
                ligne = nombreDeLignes;
                colonne = nombreDeColonnes;
                DialogResult = DialogResult.OK;
            }
            else
            {
                // Gérer le cas où le texte n'est pas un nombre valide
                MessageBox.Show("Veuillez entrer des nombres valides pour le nombre de lignes et de colonnes.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }
    }
}
