namespace evaluacion_parcial1.Views
{
    using System;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    using System.Data;
    using evaluacion_parcial1.Controllers;
    using evaluacion_parcial1.Models;
    using System.Collections.Generic;

    public partial class frm_clientes : Form
    {
        ClienteController clienteController = new ClienteController();
        public int cliente_id = 0;
        public frm_clientes()
        {
            InitializeComponent();
        }

        public void CargarClientes() {
            lst_clientes.DataSource = null; // Limpia la fuente de datos anterior
            lst_clientes.DataSource = clienteController.Clientes(); // Vincula la lista de clientes
            lst_clientes.DisplayMember = "DisplayInfo"; // Usa una propiedad que formatees en el modelo
            lst_clientes.ValueMember = "cliente_id";
        }

        private void LimpiarForm() {
            txt_nombre_cliente.Text = string.Empty;
            txt_apellido_cliente.Text = string.Empty;
            txt_email_cliente.Text = string.Empty;
            txt_telefono_cliente.Text = string.Empty;
        }

        private void frm_clientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void btn_salir_cliente_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            lst_clientes.Items.Clear();
            lst_clientes.SelectedIndex = -1;
            cliente_id = 0;
            this.Close();
        }

        private void btn_cancelar_cliente_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            cliente_id = 0;
        }

        private void btn_guardar_cliente_Click(object sender, EventArgs e)
        {
            ClienteModel clienteModel = new ClienteModel
            {
                nombre = txt_nombre_cliente.Text,
                apellido = txt_apellido_cliente.Text,
                email = txt_email_cliente.Text,
                telefono = txt_telefono_cliente.Text
            };

            string response = cliente_id == 0
                ? clienteController.SaveCliente(clienteModel)
                : clienteController.UpdateCliente(clienteModel);

            if (response == "ok")
            {
                MessageBox.Show("Se guardó con éxito");
                CargarClientes(); // Recargar la lista de clientes
            }
            else
            {
                MessageBox.Show("Ocurrió un error: " + response);
            }

            LimpiarForm();
        }

        private void lst_clientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_clientes.SelectedItem != null)
            {
                ClienteModel clienteSeleccionado = (ClienteModel)lst_clientes.SelectedItem;
                cliente_id = clienteSeleccionado.cliente_id;
            }
        }

        private void btn_eliminar_cliente_Click(object sender, EventArgs e)
        {
            ClienteModel clienteModel = new ClienteModel { cliente_id = cliente_id };
            DialogResult result = MessageBox.Show("Desea Eliminar el cliente?", "Formulario de clientes", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (clienteController.DeleteCliente(clienteModel) == "OK")
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
    }
}
