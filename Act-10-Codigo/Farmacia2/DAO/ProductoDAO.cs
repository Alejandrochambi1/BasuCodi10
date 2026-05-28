using Npgsql;
using Farmacia2.Models;

namespace Farmacia2.DAO
{
    public class ProductoDAO
    {
        public bool Insertar(Producto p)
        {
            using var conexion = ConexionBD.GetConnection();

            string sql = @"INSERT INTO producto (nombre, precio, stock, vencimiento, id_proveedor) 
                           VALUES (@nombre, @precio, @stock, @vencimiento, @idProveedor)";

            using var cmd = new NpgsqlCommand(sql, conexion);

            cmd.Parameters.AddWithValue("@nombre", p.Nombre);
            cmd.Parameters.AddWithValue("@precio", p.Precio);
            cmd.Parameters.AddWithValue("@stock", p.Stock);
            cmd.Parameters.AddWithValue("@vencimiento", p.Vencimiento ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@idProveedor", p.IdProveedor);

            int resultado = cmd.ExecuteNonQuery();
            return resultado > 0;
        }
    }
}