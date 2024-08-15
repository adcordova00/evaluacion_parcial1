namespace evaluacion_parcial1.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        private bool ValidarCamposObligatorios(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is TextBox && string.IsNullOrWhiteSpace(control.Text))
                {
                    MessageBox.Show($"El campo {control.Name} es obligatorio.");
                    return false;
                }
                else if (control is ComboBox && ((ComboBox)control).SelectedItem == null)
                {
                    MessageBox.Show($"Debes seleccionar un valor en {control.Name}.");
                    return false;
                }
            }
            return true;
        }

        public void CargarEventos()
        {
            lst_eventos.Items.Clear();

            if (lst_eventos.Items.Count > 0)
            {
                MessageBox.Show("El ListBox no se ha limpiado correctamente.");
            }

            List<EventoModel> eventos = eventoController.Eventos();

            foreach (var evento in eventos)
            {
                lst_eventos.Items.Add($"{evento.evento_id} - {evento.nombre} {evento.descripcion} - {evento.fecha.ToShortDateString()} - {evento.ubicacion}");
            }
        }
        private void LimpiarForm()
        {
            txt_nombre_evento.Text = string.Empty;
            txt_descripcion_evento.Text = string.Empty;
            txt_ubicacion_evento.Text = string.Empty;
        }

        //Logica Botones
        private void frm_eventos_Load(object sender, EventArgs e)
        {
            CargarEventos();
        }

        private void btn_guardar_evento_Click(object sender, EventArgs e)
        {
            if (ValidarCamposObligatorios(this))
            {
                EventoModel eventoModel = new EventoModel
                {
                    nombre = txt_nombre_evento.Text,
                    descripcion = txt_descripcion_evento.Text,
                    ubicacion = txt_ubicacion_evento.Text,
                    fecha = dtp_fecha_evento.Value,
                };

                string response = evento_id == 0
                    ? eventoController.SaveEvento(eventoModel)
                    : eventoController.UpdateEvento(eventoModel);

                if (response == "ok")
                {
                    MessageBox.Show("Se guardó con éxito");
                    CargarEventos();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error: " + response);
                }

                LimpiarForm();
            }
            
        }

        private void btn_salir_evento_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            lst_eventos.Items.Clear();
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
            if (lst_eventos.SelectedItem != null)
            {
                string selectedText = lst_eventos.SelectedItem.ToString();

                int evento_id = Convert.ToInt32(selectedText.Split('-')[0].Trim());

                DialogResult result = MessageBox.Show("Desea Eliminar el evento?", "Formulario de eventos", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    EventoModel eventoModel = new EventoModel { evento_id = evento_id };
                    string deleteResponse = eventoController.DeleteEvento(eventoModel);
                    if (deleteResponse == "ok")
                    {
                        MessageBox.Show("Se eliminó con éxito");
                        CargarEventos(); 
                        LimpiarForm();    
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al eliminar el evento: " + deleteResponse);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un evento para eliminar.");
            }

        }

        private void lst_eventos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_editar_evento_Click(object sender, EventArgs e)
        {
            if (ValidarCamposObligatorios(this))
            {
                EventoModel eventoModel = new EventoModel
                {
                    evento_id = this.evento_id,
                    nombre = txt_nombre_evento.Text,
                    descripcion = txt_descripcion_evento.Text,
                    ubicacion = txt_ubicacion_evento.Text,
                    fecha = dtp_fecha_evento.Value
                };

                string response = eventoController.UpdateEvento(eventoModel);

                if (response == "ok")
                {
                    MessageBox.Show("Cliente actualizado con éxito.");
                    CargarEventos();
                    LimpiarForm();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al actualizar el cliente: " + response);
                }
            }
        }

        private void lst_eventos_DoubleClick(object sender, EventArgs e)
        {
            if (lst_eventos.SelectedItem != null)
            {
                string selectedText = lst_eventos.SelectedItem.ToString();
                int evento_id = Convert.ToInt32(selectedText.Split('-')[0].Trim());

                EventoModel eventoSeleccionado = eventoController.Eventos().FirstOrDefault(ev => ev.evento_id == evento_id);

                if (eventoSeleccionado != null)
                {
                    this.evento_id = eventoSeleccionado.evento_id;
                    txt_nombre_evento.Text = eventoSeleccionado.nombre;
                    txt_descripcion_evento.Text = eventoSeleccionado.descripcion;
                    dtp_fecha_evento.Value = eventoSeleccionado.fecha;
                    txt_ubicacion_evento.Text = eventoSeleccionado.ubicacion;
                }
                else
                {
                    MessageBox.Show("No se pudo encontrar el evento seleccionado.");
                }
            }
        }
    }
}
