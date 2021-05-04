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
    public partial class Principal : Form
    {
        Hashtable palabras = new Hashtable();
        public Principal()
        {
            InitializeComponent();
            Generar();
            button1.Focus();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["captcha"] as captcha) == null)
            {
                Queue<String> paths = new Queue<String>();
                Queue<Queue<Bitmap>> Listado = new Queue<Queue<Bitmap>>();
                OpenFileDialog imgs = new OpenFileDialog();
                imgs.InitialDirectory = "C:\\";
                imgs.Filter = "Archivos de Imagen (*.jpg)|*jpg;";
                imgs.Title = "Selecciona las Facturas";
                imgs.Multiselect = true;
                if (imgs.ShowDialog() == DialogResult.OK)
                {
                    foreach (string item in imgs.FileNames)
                    {
                        paths.Enqueue(item);
                        
                    }
                    foreach (string item in paths)
                    {
                        
                        Listado.Enqueue(Pedazos(item));
                    }
                    
                    captcha ob1 = new captcha(Listado);
                    ob1.Show();


                }
                else
                {
                    MessageBox.Show("No se selecciono imagen", "Sin seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["captcha"] as captcha) == null)
            {
                this.Close();
            }
        }

        public Bitmap Delimitador(Bitmap recurso, Rectangle tamanio)
        {
            Bitmap bitmap = new Bitmap(tamanio.Width, tamanio.Height);
            Graphics graph = Graphics.FromImage(bitmap);

            graph.DrawImage(recurso, 0, 0, tamanio, GraphicsUnit.Pixel);

            return bitmap;
        }

        public Queue<Bitmap> Pedazos(string path)
        {

            Queue<Bitmap> pedazosLista = new Queue<Bitmap>();
            int X = 0, Y = 0, anchura = 300, altura = 200;
            Bitmap bitmap = new Bitmap(@path);

            

            for (int i = 0; i < (bitmap.Height / 200); i++)
            {
                X = 0;
                for (int j = 0; j < (bitmap.Width / 300); j++)
                {

                    Rectangle Cuadro = new Rectangle(X, Y, anchura, altura);

                    Bitmap pedazo = Delimitador(bitmap, Cuadro);
                    pedazosLista.Enqueue(pedazo);

                    X = 300;
                }
                Y += 200;
            }
            return pedazosLista;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["AcercaDe"] as AcercaDe) == null)
            {
                AcercaDe formacercade = new AcercaDe();
                formacercade.Show();
            }
        }

        private void MPalabras_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["Palabras"] as Palabras) == null)
            {
                Palabras v1 = new Palabras();
                v1.Show();
            }
        }
        public void Generar()
        {
            if (!File.Exists(@"ListadoPalabras.txt"))
            {


                palabras.Add(1, "Cindy");
                palabras.Add(2, "Fernando");
                palabras.Add(3, "Willy");
                TextWriter text = new StreamWriter(@"ListadoPalabras.txt");
                for (int i = 1; i <= palabras.Count; i++)
                {
                    text.WriteLine(i);
                    text.WriteLine(palabras[i].ToString());
                }
                text.Close();
            }
            if (!File.Exists(@"ListadoFacturas.txt"))
            {
                TextWriter text = new StreamWriter(@"ListadoFacturas.txt");
                text.Close();
            }
        }

        private void MFacturas_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["Facturas"] as Facturas) == null)
            {
                Facturas v2 = new Facturas();
                v2.Show();
            }
        }
    }
}
