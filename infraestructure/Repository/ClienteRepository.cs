using Dapper;
using infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace infraestructure.Repository
{
    public class ClienteRepository
    {
        private string _connectionString;
        private Npgsql.NpgsqlConnection connection;
        public ClienteRepository(string connectionString)
        {
            this._connectionString = connectionString;
            this.connection = new Npgsql.NpgsqlConnection(this._connectionString);
        }

        public ClienteModel consultarCliente(int id)
        {
            try
            {
                return connection.QueryFirst<ClienteModel>($"SELECT * FROM cliente WHERE id = {id}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string insertarCliente(ClienteModel cliente)
        {
            try
            {
                connection.Execute("insert into cliente(id, idciudad, nombres, apellidos, documento, telefono, email, fechanacimiento, ciudad, nacionalidad) " +
                    " values(@id, @idciudad, @nombres, @apellidos, @documento, @telefono, @email, @fechanacimiento, @ciudad, @nacionalidad)", cliente);
                return "Se inserto correctamente...";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public string eliminarCliente(int id)
        {
            try
            {
                connection.Execute($" DELETE FROM cliente WHERE id = {id}");
                return "Se eliminó correctamente el registro...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string modificarCliente(ClienteModel cliente, int id)
        {

            try
            {

                connection.Execute($"UPDATE cliente SET " +
                    "nombres = @nombres, " +
                    "apellidos = @apellidos, " +
                    "documento = @documento, " +
                    "telefono = @telefono, " +
                    "email = @email, " +
                    "fechanacimiento = @fechanacimiento, " +
                    "ciudad = @ciudad, " +
                    "nacionalidad = @nacionalidad " +
                    $"WHERE id = {id}", cliente);
                return "Se modificaron los datos correctamente...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}