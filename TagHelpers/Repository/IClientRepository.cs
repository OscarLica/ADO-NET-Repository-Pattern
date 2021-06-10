using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TagHelpers.Models;
using TagHelpers.Util;


namespace TagHelpers.Repository
{
    public interface IClientRepository
    {
        public Response Create(Cliente cliente);
        public Response Update(Cliente cliente);
        public Cliente Get(int id);
        public List<Cliente> GetAll();
    }

    public class ClienteRepository : Repository, IClientRepository
    {

        public ClienteRepository(SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            this.sqlConnection = sqlConnection;
            this.sqlTransaction = sqlTransaction;
        }
        public Response Create(Cliente cliente)
        {
            var query = "insert into cliente values (@Nombre, @Apellido, @Direccion)";
            var comando = CreateCommand(query);
            comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
            comando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
            comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);

            comando.ExecuteNonQuery();
           
            return new Response { Success = true, Message = "Cliente creado exitosamente" };
        }

        public Cliente Get(int id)
        {
            var query = "Select * from cliente where Id = @Id";
            var command = CreateCommand(query);
            command.Parameters.AddWithValue("@Id", id);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read()) {
                    return new Cliente
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        Direccion = reader["Direccion"].ToString()
                    };
                }
            }

            return null;
        }

        public List<Cliente> GetAll()
        {
            var query = "Select * from cliente";
            var command = CreateCommand(query);
            List<Cliente> result = new List<Cliente>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read()) {

                    result.Add(new Cliente {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        Direccion = reader["Direccion"].ToString()
                    });
                }
            }
            return result;
        }

        public Response Update(Cliente cliente)
        {
            var query = @"UPDATE cl 
                              set cl.Nombre = @Nombre,
                                  cl.Apellido = @Apellido,
                                  cl.Direccion = @Direccion
                        from cliente cl where cl.Id = @Id";

            var comando = CreateCommand(query);
            comando.Parameters.AddWithValue("@Id", cliente.Id);
            comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
            comando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
            comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);

            comando.ExecuteNonQuery();

            return new Response { Success = true, Message = "Cliente actualizado con exito" };
        }
    }
}
