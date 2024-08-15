namespace evaluacion_parcial1.Views
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using evaluacion_parcial1.Controllers;
    using evaluacion_parcial1.Models;
    public partial class frm_eventos : Form
    {
        EventoController eventoController = new EventoController();
        public int evento_id = 0;
        public frm_eventos()
        {
            InitializeComponent();
        }

        public void CargarEventos()
        {
            lst_eventos.Items.Clear();
            List<EventoModel> eventos = eventoController.Eventos();

            foreach (var evento in eventos)
            {
                lst_eventos.Items.Add($"{evento.nombre} {evento.descripcion} - {evento.fecha} - {evento.ubicacion}");
            }
        }
        private void LimpiarForm()
        {
            txt_nombre_evento.Text = string.Empty;
            txt_descripcion_evento.Text = string.Empty;
            txt_ubicacion_evento.Text = string.Empty;
        }
        private void frm_eventos_Load(object sender, EventArgs e)
        {
            CargarEventos();
        }

        private void btn_guardar_evento_Click(object sender, EventArgs e)
        {
            string response = "";
            EventoModel eventoModel = new EventoModel
            {
                evento_id = evento_id,
                nombre = txt_nombre_evento.Text,
                descripcion = txt_descripcion_evento.Text,
                fecha = Convert.ToDateTime(dtp_fecha_evento.Text),
                ubicacion = txt_ubicacion_evento.Text,
            };
            try
            {
                if (evento_id == 0)
                {
                    response = eventoController.SaveEvento(eventoModel);
                    MessageBox.Show("Guardado");
                }
                else
                {
                    response = eventoController.UpdateEvento(eventoModel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Se guardo con exito");
            evento_id = 0;
            CargarEventos();
        }

        private void btn_salir_evento_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            lst_eventos.SelectedIndex = -1;
            evento_id = 0;
            this.Close();
        }

        private void btn_cancelar_evento_Click(object sender, EventArgs e)
        {
            LimpiarForm();
        }

        private void btn_eliminar_evento_Click(object sender, EventArgs e)
        {
            EventoModel eventoModel = new EventoModel { evento_id = evento_id };
            DialogResult result = MessageBox.Show("Desea Eliminar el evento?", "Formulario de eventos", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (eventoController.DeleteEvento(eventoModel) == "OK")
                {
                    MessageBox.Show("Se elimino con exito");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al eliminar");
                }
            }
            else
            {
                MessageBox.Show("El usuario cancelo la operacion");
            }

        }

        private void lst_eventos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_editar_evento_Click(object sender, EventArgs e)
        {

        }
    }
}
