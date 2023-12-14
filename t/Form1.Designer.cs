namespace t
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            button4 = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            button5 = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(37, 12);
            button1.Name = "button1";
            button1.Size = new Size(111, 35);
            button1.TabIndex = 0;
            button1.Text = "Jouer";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Cursor = Cursors.No;
            dataGridView1.Enabled = false;
            dataGridView1.Location = new Point(210, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(538, 375);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button2
            // 
            button2.Location = new Point(37, 53);
            button2.Name = "button2";
            button2.Size = new Size(111, 39);
            button2.TabIndex = 2;
            button2.Text = "Sauvegarder";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(37, 98);
            button3.Name = "button3";
            button3.Size = new Size(111, 38);
            button3.TabIndex = 3;
            button3.Text = "Choisir Sauvegarde";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 386);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nom Joueur";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 4;
            // 
            // button4
            // 
            button4.Location = new Point(24, 415);
            button4.Name = "button4";
            button4.Size = new Size(75, 27);
            button4.TabIndex = 5;
            button4.Text = "Ok";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 386);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 6;
            label1.Text = "label1";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 415);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 7;
            label2.Text = "label2";
            label2.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(243, 393);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Sasir mot...";
            textBox2.Size = new Size(207, 23);
            textBox2.TabIndex = 8;
            textBox2.Visible = false;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button5
            // 
            button5.Location = new Point(456, 393);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 9;
            button5.Text = "Valider";
            button5.UseVisualStyleBackColor = true;
            button5.Visible = false;
            button5.Click += button5_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(74, 175);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 10;
            label3.Text = "00:00";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 149);
            label4.Name = "label4";
            label4.Size = new Size(111, 15);
            label4.TabIndex = 11;
            label4.Text = "Temps de la partie : ";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(46, 205);
            label5.Name = "label5";
            label5.Size = new Size(92, 15);
            label5.TabIndex = 12;
            label5.Text = "Temps du tour : ";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(74, 233);
            label6.Name = "label6";
            label6.Size = new Size(34, 15);
            label6.TabIndex = 13;
            label6.Text = "00:00";
            label6.Click += label6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(795, 457);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button5);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button3;
        private TextBox textBox1;
        private Button button4;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Button button5;
        private System.Windows.Forms.Label labelTempsRestant;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
