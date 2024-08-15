namespace evaluacion_parcial1.Views
{
    using evaluacion_parcial1.Controllers;
    using evaluacion_parcial1.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    using static evaluacion_parcial1.Models.ClienteModel;

    public partial class frm_reservaciones : Form
    {
        ReservacionController reservacionController = new ReservacionController();
        ClienteController clienteController = new ClienteController();
        EventoController eventoController = new EventoController();
        public int reservacion_id = 0;
        public frm_reservaciones()
        {
            InitializeComponent();
        }

        //Esta es una funcion para validar todos los campos en general. Se tuviera un archivo utils esto iria ahi
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

        public void CargarReservas()
        {
            lst_reservas.Items.Clear();

            if (lst_reservas.Items.Count > 0)
            {
                MessageBox.Show("El ListBox no se ha limpiado correctamente.");
            }

            List<ReservacionModel> reservas = reservacionController.Reservas();

            foreach (var reserva in reservas)
            {
                lst_reservas.Items.Add($"{reserva.reservacion_id} - {reserva.nombre} - {reserva.cliente_id} - {reserva.evento_id} - {reserva.fecha.ToShortDateString()} - {reserva.descripcion}");
            }
        }

        public void CargarClientesBox()
        {
            List<ClienteModel> clientes = new List<ClienteModel>();
            clientes = clienteController.ObtenerClientes();
            foreach (var cliente in clientes)
            {
                cb_cliente_reserva.Items.Add(new ClienteComboBoxItem
                {
                    Id = cliente.cliente_id,
                    DisplayText = $"{cliente.cliente_id} - {cliente.nombre} {cliente.apellido}"
                });
            }
            cb_cliente_reserva.DisplayMember = "DisplayText"; 
            cb_cliente_reserva.ValueMember = "Id";
        }

        private void CargarEventosBox()
        {
            List<EventoModel> eventos = eventoController.ObtenerEventos();
            cb_evento_reserva.DataSource = eventos;
            cb_evento_reserva.DisplayMember = "nombre";
            cb_evento_reserva.ValueMember = "evento_id";
        }

        private void frm_reservaciones_Load(object sender, EventArgs e)
        {
            CargarReservas();
            CargarClientesBox();
            CargarEventosBox();
        }
        private void LimpiarForm()
        {
            txt_nombre_reserva.Text = string.Empty;
            txt_descripcion_reserva.Text = string.Empty;
        }
        private void btn_guardar_reserva_Click(object sender, EventArgs e)
        {
            if (ValidarCamposObligatorios(this))
            {
                ReservacionModel reservacionModel = new ReservacionModel
                {
                    nombre = txt_nombre_reserva.Text,
                    cliente_id = ((ClienteComboBoxItem)cb_cliente_reserva.SelectedItem).Id,
                    evento_id = Convert.ToInt32(cb_evento_reserva.SelectedValue),
                    fecha = dtp_fecha_reserva.Value,
                    descripcion = txt_descripcion_reserva.Text,
                };

                string response = reservacion_id == 0
                    ? reservacionController.SaveReserva(reservacionModel)
                    : reservacionController.UpdateReserva(reservacionModel);

                if (response == "ok")
                {
                    MessageBox.Show("Se guardó con éxito");
                    CargarReservas(); 
                }
                else
                {
                    MessageBox.Show("Ocurrió un error: " + response);
                }

                LimpiarForm();
            }

        }

        private void btn_editar_reserva_Click(object sender, EventArgs e)
        {
            if (ValidarCamposObligatorios(this))
            {
                ReservacionModel reservacionModel = new ReservacionModel
                {
                    reservacion_id = this.reservacion_id,
                    nombre = txt_nombre_reserva.Text,
                    cliente_id = ((ClienteComboBoxItem)cb_cliente_reserva.SelectedItem).Id,
                    evento_id = Convert.ToInt32(cb_evento_reserva.SelectedValue),
                    fecha = dtp_fecha_reserva.Value,
                    descripcion = txt_descripcion_reserva.Text,
                };

                string response = reservacionController.UpdateReserva(reservacionModel);

                if (response == "ok")
                {
                    MessageBox.Show("Cliente actualizado con éxito.");
                    CargarReservas();
                    LimpiarForm();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al actualizar el cliente: " + response);
                }
            }
            
        }
        private void btn_cancelar_reserva_Click(object sender, EventArgs e)
        {
            LimpiarForm();
        }

        private void btn_salir_reserva_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            lst_reservas.Items.Clear();
            lst_reservas.SelectedIndex = -1;
            reservacion_id = 0;
            this.Close();

        }

        private void btn_eliminar_reserva_Click(object sender, EventArgs e)
        {
            if (lst_reservas.SelectedItem != null)
            {
                
                string selectedText = lst_reservas.SelectedItem.ToString();
                int reservacion_id = Convert.ToInt32(selectedText.Split('-')[0].Trim());

                DialogResult result = MessageBox.Show("¿Desea eliminar esta reserva?", "Eliminar Reserva", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ReservacionModel reservacionModel = new ReservacionModel { reservacion_id = reservacion_id };
                    string deleteResponse = reservacionController.DeleteReserva(reservacionModel);
                    if (deleteResponse == "ok")
                    {
                        MessageBox.Show("Reserva eliminada con éxito.");
                        CargarReservas(); 
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al eliminar la reserva: " + deleteResponse);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una reserva para eliminar.");
            }

        }

        private void lst_reservas_DoubleClick(object sender, EventArgs e)
        {
            if (lst_reservas.SelectedItem != null)
            {
                string selectedText = lst_reservas.SelectedItem.ToString();
                int reservacion_id = Convert.ToInt32(selectedText.Split('-')[0].Trim());

                ReservacionModel reservacionModel = new ReservacionModel { reservacion_id = reservacion_id };
                ReservacionModel reservaSeleccionada = reservacionController.Reserva(reservacionModel);

                if (reservaSeleccionada != null)
                {
                    txt_nombre_reserva.Text = reservaSeleccionada.nombre;
                    cb_cliente_reserva.SelectedValue = reservaSeleccionada.cliente_id;
                    cb_evento_reserva.SelectedValue = reservaSeleccionada.evento_id;
                    dtp_fecha_reserva.Value = reservaSeleccionada.fecha;
                    txt_descripcion_reserva.Text = reservaSeleccionada.descripcion;
                    this.reservacion_id = reservaSeleccionada.reservacion_id;
                }
                else
                {
                    MessageBox.Show("No se pudo encontrar la reserva seleccionada.");
                }
            }
        }
    }
}
