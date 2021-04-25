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
    public partial class Facturas : Form
    {
        public Facturas()
        {
            InitializeComponent();
            Actualizar();
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            Actualizar();
        }
        private void Actualizar()
        {
            ListadoFacturas.Text = "";
            string Mensaje = "";
            TextReader textReader = new StreamReader(@"ListadoFacturas.txt");
            Mensaje = textReader.ReadToEnd();
            textReader.Close();
            ListadoFacturas.Text = Mensaje;
        }
        private void Facturas_Load(object sender, EventArgs e)
        {
            fileSystemWatcher1.Path = @"C:\Users\rodri\Documents\GitHub\ProyectoCindy\ProyectoProgramacion\bin\Debug";
        }
    }
}
