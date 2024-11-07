using Microsoft.VisualBasic;
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

namespace Preparazione_verifica_info
{
    public partial class Rubrica : Form
    {
        string nome;
        string tel;
        List<Contatto> Contatti = new List<Contatto>();
    

        public Rubrica()
        {
            InitializeComponent();
            Carica();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
 
            if((txtTel.Text!= "" || txtNome.Text != "") && !duplcati())
            {
                    aggiungiContatto();
                    CaricaListbox();
                    txtTel.Text = "";
                    txtNome.Text = "";
                     Salva();
            }
            else
            {
                if(duplcati())
                    MessageBox.Show("Campo già esistente");
                else
                    MessageBox.Show("devi riempire tutti i campi");
                txtTel.Text = "";
                txtNome.Text = "";
            }
        }

        private bool duplcati()
        {
            string ausN="";
            string ausTel="";
            nome = txtNome.Text;
            tel = txtTel.Text;
            for (int i = 0; i < listContatti.Items.Count; i++)
            {
                ausN= (listContatti.Items[i].ToString()).Split('-')[0];
                ausTel = (listContatti.Items[i].ToString()).Split('-')[1];

                if(ausN==nome && ausTel==tel)
                    return true;
            }
            return false;
        }
        private void aggiungiContatto()
        {
            
            Contatto persona = new Contatto(nome, tel);
            Contatti.Add(persona);
           
            
        }

        private void Carica()
        {

            string n;
            string tel;
            try
            {
                StreamReader sr = new StreamReader("rubrica.txt");
                while (!sr.EndOfStream)
                {
                    string[] v = sr.ReadLine().Split(';');
                    n=v[0];
                    tel = v[1];
                    Contatto ElementoAggiunto = new Contatto(n,tel);
                    Contatti.Add(ElementoAggiunto);
                    
                }
                sr.Close();
                CaricaListbox();
            }
            catch 
            {

                MessageBox.Show("Errore");
            
            }
        


        }

        private void CaricaListbox()
        {
            listContatti.Items.Clear(); 
            for (int i = 0; i < Contatti.Count; i++) {

                listContatti.Items.Add($"{Contatti[i].Nome}-{Contatti[i].Tel}");
            }
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            if(listContatti.SelectedItem!=null)
            {
                int selectedIndex = listContatti.SelectedIndex;
            
                    Contatti.RemoveAt(selectedIndex);
                    CaricaListbox();
                    Salva();


            }
            else
            {
                MessageBox.Show("selezionare un contatto da eliminare");
            }
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            if (listContatti.SelectedItem != null)
            {
                int selectedIndex = listContatti.SelectedIndex;

                Contatti.RemoveAt(selectedIndex);
                CaricaListbox();
                nome = Interaction.InputBox("inserire nuovo nome ");
                tel = Interaction.InputBox("inserire nuovo tel ");
                aggiungiContatto();
                CaricaListbox();
                Salva();


            }
            else
            {
                MessageBox.Show("selezionare un contatto da modificare");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Contatti.Clear();
            Salva();
            MessageBox.Show("tutti i contatti sono stati eliminati correttamente");
            listContatti.Items.Clear();
        }

        private void Salva()
        {
            StreamWriter sw = new StreamWriter("rubrica.txt");
            string s = "";

            for (int i = 0; i < Contatti.Count; i++)
            {
                s = Contatti[i].Nome.ToString() + ";";
                s += Contatti[i].Tel.ToString();
                sw.WriteLine(s);
            }
            sw.Close();

        }
    }

 
}
