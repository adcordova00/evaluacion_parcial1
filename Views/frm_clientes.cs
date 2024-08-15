namespace evaluacion_parcial1.Views
{
    using System;
    using System.Windows.Forms;
    using evaluacion_parcial1.Controllers;
    using evaluacion_parcial1.Models;
    using System.Collections.Generic;
    using System.Linq;

    public partial class frm_clientes : Form
    {
        ClienteController clienteController = new ClienteController();
        public int cliente_id = 0;
        public frm_clientes()
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

        public void CargarClientes() {
            lst_clientes.Items.Clear(); 
            List<ClienteModel> clientes = clienteController.Clientes();

            foreach (var cliente in clientes)
            {
                lst_clientes.Items.Add($"{cliente.cliente_id} - {cliente.nombre} {cliente.apellido} - {cliente.email} - {cliente.telefono}");
            }
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
            if (ValidarCamposObligatorios(this))
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
                    lst_clientes.Items.Clear();
                    CargarClientes(); 
                }
                else
                {
                    MessageBox.Show("Ocurrió un error: " + response);
                }

                LimpiarForm();
            }
        }

        private void lst_clientes_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btn_eliminar_cliente_Click(object sender, EventArgs e)
        {
            if (lst_clientes.SelectedItem != null)
            {
                
                string selectedText = lst_clientes.SelectedItem.ToString();
                int cliente_id = Convert.ToInt32(selectedText.Split('-')[0].Trim());
                DialogResult result = MessageBox.Show("Desea Eliminar el cliente?", "Formulario de clientes", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ClienteModel clienteModel = new ClienteModel { cliente_id = cliente_id };
                    string deleteResponse = clienteController.DeleteCliente(clienteModel);

                    if (deleteResponse == "ok")
                    {
                        MessageBox.Show("Se eliminó con éxito");
                        CargarClientes(); 
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al eliminar: " + deleteResponse);
                    }
                }
                else
                {
                    MessageBox.Show("El usuario canceló la operación");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.");
            }
        }

        private void btn_editar_cliente_Click(object sender, EventArgs e)
        {
            if (ValidarCamposObligatorios(this))
            {
                ClienteModel clienteModel = new ClienteModel
                {
                    cliente_id = this.cliente_id, 
                    nombre = txt_nombre_cliente.Text,
                    apellido = txt_apellido_cliente.Text,
                    email = txt_email_cliente.Text,
                    telefono = txt_telefono_cliente.Text
                };

                string response = clienteController.UpdateCliente(clienteModel);

                if (response == "ok")
                {
                    MessageBox.Show("Cliente actualizado con éxito.");
                    CargarClientes(); 
                    LimpiarForm();  
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al actualizar el cliente: " + response);
                }
            }
        }

        private void lst_clientes_DoubleClick(object sender, EventArgs e)
        {
            if (lst_clientes.SelectedItem != null)
            {
                
                string selectedText = lst_clientes.SelectedItem.ToString();
                int cliente_id = Convert.ToInt32(selectedText.Split('-')[0].Trim());

                ClienteModel clienteSeleccionado = clienteController.Clientes().FirstOrDefault(c => c.cliente_id == cliente_id);

                if (clienteSeleccionado != null)
                {
                    txt_nombre_cliente.Text = clienteSeleccionado.nombre;
                    txt_apellido_cliente.Text = clienteSeleccionado.apellido;
                    txt_email_cliente.Text = clienteSeleccionado.email;
                    txt_telefono_cliente.Text = clienteSeleccionado.telefono;
                    this.cliente_id = clienteSeleccionado.cliente_id;
                }
                else
                {
                    MessageBox.Show("No se pudo encontrar el cliente seleccionado.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para editar.");
            }
        }
    }
}
