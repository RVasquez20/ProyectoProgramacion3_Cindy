using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
namespace ProyectoProgramacion
{
    public partial class captcha : Form
    {
        String start = "", Progress = "",PalabraEscritaConfirmada="";
        int intentos = 3, PedazosMostrados = 0,j=1;
        Hashtable Confirmadas = new Hashtable();
        Queue<Bitmap> Pedazitos = new Queue<Bitmap>();
        Queue<Queue<Bitmap>> Listado = new Queue<Queue<Bitmap>>();
        public captcha(Queue<Queue<Bitmap>> Pedazos)
        {
            InitializeComponent();
            Listado = Pedazos;
            Pedazitos = Listado.Dequeue();
            pictureBox1.Image = Pedazitos.Dequeue();
            CargarDatos();
           
                palabraconf.Text = Confirmadas[1].ToString();
        
        }

        private void CargarDatos()
        {
            string Palabra = "", LLave = "";
            TextReader textReader = new StreamReader(@"ListadoPalabras.txt");
            LLave = textReader.ReadLine();
            Palabra = textReader.ReadLine();
            while (LLave != null)
            {
                Confirmadas.Add(int.Parse(LLave), Palabra);
                LLave = textReader.ReadLine();
                Palabra = textReader.ReadLine();
            }
            textReader.Close();
        }

        private void GuardarPalabra(int key,string palabra)
        {
            TextWriter textWriter = new StreamWriter(@"ListadoPalabras.txt",true);
            textWriter.WriteLine(key);
            textWriter.WriteLine(palabra);
            textWriter.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBoxconfirmada.Text.Equals("") || textBoxnoconfirmada.Text.Equals(""))
            {
                MessageBox.Show("Llene los campos Primero");
            }
            else
            {
                if (j > Confirmadas.Count)
                { j = 1; }
                if (intentos == 3)
                    {
                    PalabraEscritaConfirmada = "";
                        start = "";
                        start = textBoxnoconfirmada.Text;
                        textBoxnoconfirmada.Text = "";
                    PalabraEscritaConfirmada = palabraconf.Text;
                    MessageBox.Show(PalabraEscritaConfirmada);
                    
                     if (PalabraEscritaConfirmada.Equals(textBoxconfirmada.Text)) {
                        --intentos; textBoxconfirmada.Focus(); textBoxconfirmada.Text = ""; textBoxnoconfirmada.Text = "";
                    }
                        else {
                        MessageBox.Show("Las Palabras no coinciden Inicie de nuevo intentos 3 1");
                        intentos = 3; textBoxconfirmada.Focus();
                         }
                    }
                    else

                    if (intentos > 0 && intentos < 3)
                    {
                    PalabraEscritaConfirmada = "";
                    Progress = "";
                        Progress = textBoxnoconfirmada.Text;
                        textBoxnoconfirmada.Text = "";
                    PalabraEscritaConfirmada = palabraconf.Text;
                    
                    
                        if (start.Equals(Progress)&& PalabraEscritaConfirmada.Equals(textBoxconfirmada.Text))
                        {
                        textBoxconfirmada.Focus(); textBoxconfirmada.Text = "";
                        --intentos;
                        }
                        else
                        {
                            MessageBox.Show("Las Palabras no coinciden Inicie de nuevo intentos 3 2");
                            intentos = 3;
                        textBoxconfirmada.Focus();
                    }

                    }
                
                    if (intentos == 0)
                    {
                    PalabraEscritaConfirmada = "";
                    textBoxnoconfirmada.Text = "";
                    
                    textBoxconfirmada.Text = "";
                    string mensaje = "";
                    textBoxconfirmada.Focus();
                        MessageBox.Show("Palabra Confirmada");
                        int key = 0;
                        key = GenerarKey();
                        Confirmadas.Add(key, start);
                    GuardarPalabra(key,start);
                    PedazosMostrados++;
                    ListarFacturas(PedazosMostrados,start);
                        for (int i = 1; i <= Confirmadas.Count; i++)
                        {
                            mensaje += "\n" + Confirmadas[i].ToString();
                        }
                        MessageBox.Show(mensaje);
                    j++;
                    palabraconf.Text = Confirmadas[j].ToString();
                    if (Pedazitos.Count != 0)
                        {
                        MessageBox.Show("Test");
                        pictureBox1.Image = Pedazitos.Dequeue();
                            this.Invoke(new Action(() =>
                            {
                                pictureBox1.Refresh();
                            }));
                            intentos = 3;
                        
                       
                        }
                        else
                        
                        if (Pedazitos.Count==0&& Listado.Count != 0)
                        {
                        Pedazitos.Clear();
                            Pedazitos = Listado.Dequeue();
                            j = 1;
                            pictureBox1.Image = Pedazitos.Dequeue();
                            palabraconf.Text = Confirmadas[1].ToString();
                            this.Invoke(new Action(() => { pictureBox1.Refresh();  }));
                            intentos = 3;
                        }
                        else
                        {
                            this.Close();
                        }
                    
                    }//intentos==3
                
            }//else

        }
        private void ListarFacturas(int PedazosMostrados, string starts)
        {
            TextWriter sw = new StreamWriter(@"ListadoFacturas.txt", true);
            if (PedazosMostrados == 1)
            {
                sw.WriteLine("Nit: " + starts);
            }
            else if (PedazosMostrados == 2)
            {
                sw.WriteLine("Fecha: " + starts);
            }
            else if (PedazosMostrados % 2 == 0)
            {
                sw.WriteLine("Cantidad: " + starts);
            }
            else
            {
                sw.WriteLine("Producto: " + starts );
            }
            sw.Close();
        }

        private int GenerarKey()
        {
            return Confirmadas.Count + 1;
        }
    }
}
