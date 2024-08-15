namespace evaluacion_parcial1
{
    using System;
    using System.Windows.Forms;
    using evaluacion_parcial1.Views;
    public partial class Form1 : Form
    {
        frm_clientes frm_Clientes = new frm_clientes();
        frm_eventos frm_Eventos = new frm_eventos();
        frm_reservaciones frm_Reservaciones = new frm_reservaciones();
        public Form1()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Clientes.ShowDialog(this);
        }

        private void eventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Eventos.ShowDialog(this);
        }

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Reservaciones.ShowDialog(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("INSTRUCCIONES PARA EDITAR CUALQUIER ELEMENTO: DAR DOBLE CLICK EN EL ELEMENTO - MODIFICAR LOS DATOS - GUARDAR CON EL BOTON EDITAR");
        }
    }
}
