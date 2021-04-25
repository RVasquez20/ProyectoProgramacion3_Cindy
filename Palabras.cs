using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProyectoProgramacion
{
    public partial class Palabras : Form
    {
        public Palabras()
        {
            InitializeComponent();
            Actualizar();
        }

        private void Actualizar()
        {
            ListaPalabras.Text = "";
            string Mensaje = "";
            TextReader textReader = new StreamReader(@"ListadoPalabras.txt");
            Mensaje = textReader.ReadToEnd();
            textReader.Close();
            ListaPalabras.Text = Mensaje;
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            Actualizar();
        }

        private void Palabras_Load(object sender, EventArgs e)
        {
            fileSystemWatcher1.Path = @"C:\Users\rodri\Documents\GitHub\ProyectoCindy\ProyectoProgramacion\bin\Debug";
        }
    }
}
