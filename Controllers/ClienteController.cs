namespace evaluacion_parcial1.Controllers
{
    using System.Collections.Generic;
    using evaluacion_parcial1.Models;
    class ClienteController
    {
        private ClienteModel modeloCliente = new ClienteModel();

        public List<ClienteModel> Clientes()
        {
            return modeloCliente.Clientes();
        }
        public ClienteModel Cliente(ClienteModel cliente)
        {
            return modeloCliente.Cliente(cliente);
        }
        public string SaveCliente(ClienteModel cliente)
        {
            return modeloCliente.SaveCliente(cliente);
        }
        public string UpdateCliente(ClienteModel cliente)
        {
            return modeloCliente.UpdateCliente(cliente);
        }
        public string DeleteCliente(ClienteModel cliente)
        {
            return modeloCliente.DeleteCliente(cliente);
        }
    }
}
