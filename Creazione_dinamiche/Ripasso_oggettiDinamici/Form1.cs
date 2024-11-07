using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static Ripasso_oggettiDinamici.Form1;

namespace Ripasso_oggettiDinamici
{

    

    public partial class Form1 : Form
    {

        DataGridView dgv = new DataGridView();

        ////////public enum Scelgli
        ////////{
        ////////    pietro,
        ////////    matteo,
        ////////    alfonso
        ////////}

        ////////public struct SecondaParte
        ////////{
        ////////    public string ok;
        ////////}

        ////////public struct Prova
        ////////{
        ////////    public int x;
        ////////    public string line;
        ////////    public Scelgli persona;
        ////////    public SecondaParte cane;

        ////////    // Aggiunto un costruttore per facilitare l'inizializzazione
        ////////    public Prova(int x, string line, Scelgli persona)
        ////////    {
        ////////        this.x = x;
        ////////        this.line = line;
        ////////        this.persona = persona;
        ////////        this.cane = new SecondaParte(); // Inizializzazione del campo cane
        ////////    }
        ////////}

        ////////// Inizializzazione dell'oggetto
        ////////Prova strutturaProva = new Prova(1, "cahsj", Scelgli.pietro);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            creabtn();
            creaDgv();
            creabtnSalva();

            caricalista();
            //carricaStruttura();
           
        }

        private void caricalista()
        {
            List<string> list = new List<string>();
            int i = int.Parse(Interaction.InputBox("inserire numero di elementi"));
            //for (int j = 0; j<i;j++)
            //{
            //    list.Add(Interaction.InputBox(" numero "));
            //}
            //list.Sort();
            //for (int j = 0; j < i; j++)
            //{
            //    MessageBox.Show(list[j]);
            //}
        
            //MessageBox.Show(list.Find(n => n == "1"));


            //// lista classe
            List<listaTipo> listaTipo = new List<listaTipo>();
            for (int j = 0; j < i; j++)
            {
                listaTipo aus = new listaTipo();
                aus.Nome = Interaction.InputBox(" nome ");
                listaTipo.Add(aus);


            }

           

        }

        //private void carricaStruttura()
        //{
        //    for (int i = 0; i < 3; i++) {

        //        strutturaProva.= int.Parse(Interaction.InputBox("inserire numero "));

        //    }
        //}

        private void creabtnSalva()
        {
           Button salva = new Button();
            this.Controls.Add(salva);
            salva.Location = new Point(200, 100);
            salva.Text = "salva";
            salva.Click += fileSalva;

        }

        private void fileSalva(object sender, EventArgs e)
        {
            try {
                StreamWriter sw = new StreamWriter("dati.csv");
                int i = 0;
                while (i < dgv.RowCount)
                {
                    string line = dgv.Rows[i].Cells[0].Value.ToString() + ";";
                    line += dgv.Rows[i].Cells[1].Value.ToString() + ";";
                    line += dgv.Rows[i].Cells[2].Value.ToString();
                    i++;
                    sw.WriteLine(line);

                }
                sw.Close();
                MessageBox.Show("dati salvati con successo");
            }

            catch { MessageBox.Show("errore salvataggio dati"); }
            
          
        }

        private void caricaDgv(DataGridView dgv)
        {
            int i = 0;
         
                StreamReader sr = new StreamReader("dati.csv");
                string[] array = new string[3];
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    array = line.Split(';');
              
                            dgv.Rows[i].Cells[0].Value = array[0];
                            dgv.Rows[i].Cells[1].Value = array[1];
                            dgv.Rows[i].Cells[2].Value = array[2];
                            i++;
                }
                sr.Close();
            
           

           
        }

        private void creaDgv()
        {
            

            dgv.Location = new Point(100,200);
            dgv.CellContentClick += mostraContenuto;
            this.Controls.Add(dgv);
            settaDgv(dgv);
            caricaDgv(dgv);
        }

        private void mostraContenuto(object sender, DataGridViewCellEventArgs e)
        {

            dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "cioa";
        
        }

        private void settaDgv(DataGridView dgv)
        {
            // imposto num righe e colonne
            dgv.RowCount = 5;
            dgv.ColumnCount = 5;

            // imposto la griglia in sola lettura
            dgv.ReadOnly = true;

            // nascondo header di riga e di colonna
            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersVisible = true;

            // evitare ridimensionamento cella
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = false;

            // disabilito scrollbars


            // resize delle celle
            SizeDgv(dgv);
        }

        private void SizeDgv(DataGridView dgv)
        {
            
            dgv.Columns[0].HeaderText = $"nome";
            dgv.Columns[1].HeaderText = $"cognome";
            dgv.Columns[2].HeaderText = $"tel";


            for (int i = 0; i < 5; i++)
            {
                dgv.Rows[i].Height = dgv.Height / 5;
            }
            for (int i = 0; i < 5; i++)
            {
                dgv.Columns[i].Width = dgv.Width / 5;
            }
        }

        private void creabtn()
        {
            int k = 0;
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    Button btn = new Button();
                    btn.Width = 50;
                    btn.Height= 50;
                    btn.Location = new Point(50 * i, 50*j);
                    btn.Name = i + "-" + j;
                    btn.Click += Mostra;
                    this.Controls.Add(btn);
                }
            }
           
        }

        private void Mostra(object sender, EventArgs e)
        {
           Button btnCorrente = sender as Button;

            MessageBox.Show($"{btnCorrente.Name}");

        }
    }
}
