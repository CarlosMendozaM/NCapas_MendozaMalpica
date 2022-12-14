using System;
using System.Collections.Generic;
using System.Text;
using Financiera.Dominio;
using System.Transactions;
using System.Data.SqlClient;

namespace Financiera.Data
{
    public class PrestamoData
    {
        string cadenaConexion = "Server=localhost; DataBase=FINANCIERA; Integrated security=true";
        public bool Insertar(Prestamo prestamo, List<DetallePrestamo> detalles)
        {
            using (var transaccion = new TransactionScope())
            {
                using (var conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    var sql = "SELECT ISNULL(MAX(Numero),0) FROM Prestamo";
                    var numeroPrestamo = 0;
                    int ultimoId = 0;
                    //Obtener el siguiente numero de prestamo
                    using (var comando = new SqlCommand(sql, conexion))
                    {
                        numeroPrestamo = int.Parse(comando.ExecuteScalar().ToString());
                        numeroPrestamo++;
                        prestamo.Numero = numeroPrestamo.ToString().PadLeft(20, char.Parse("0"));
                    }
                    //Insertar y obtener el ultimo ID
                    sql = "INSERT INTO Prestamo (Numero, Fecha, IdCliente, Importe," +
                                "Tasa, Plazo, FechaDeposito, Estado) " +
                          "VALUES (@Numero, @Fecha, @IdCliente, @Importe, " +                                "@Tasa, @Plazo, @FechaDeposito, @Estado);" +
                          "SELECT ISNULL(@@IDENTITY,0);";
                    using (var comando = new SqlCommand(sql, conexion))
                    {
                        //Asignacion de parametros
                        comando.Parameters.AddWithValue("@Numero", prestamo.Numero);
                        comando.Parameters.AddWithValue("@Fecha", prestamo.Fecha);
                        comando.Parameters.AddWithValue("@IdCliente", prestamo.IdCliente);
                        comando.Parameters.AddWithValue("@Importe", prestamo.Importe);
                        comando.Parameters.AddWithValue("@Tasa", prestamo.tasa);
                        comando.Parameters.AddWithValue("@Plazo", prestamo.Plazo);
                        comando.Parameters.AddWithValue("@FechaDeposito", prestamo.FechaDeposito);
                        comando.Parameters.AddWithValue("@Estado", 1);
                        ultimoId = int.Parse(comando.ExecuteScalar().ToString());
                        prestamo.ID = ultimoId;
                    }

                    //Isercion del detalle prestamo
                    sql = "INSERT INTO DetallePrestamo (IdPrestamo, NumeroCuota," +
                                "ImporteCuota, FechaVencimiento, Estado) " +
                          "VALUES (@IdPrestamo, @NumeroCuota, @ImporteCuota, " +                                "@FechaVencimiento, @Estado)";
                    foreach (var detalle in detalles)
                    {
                        detalle.IdPrestamo = prestamo.ID;
                        using (var comando = new SqlCommand(sql, conexion))
                        {
                            //Asignacion de parametros
                            comando.Parameters.AddWithValue("@IdPrestamo", detalle.IdPrestamo);
                            comando.Parameters.AddWithValue("@NumeroCuota", detalle.NumeroCuota);
                            comando.Parameters.AddWithValue("@ImporteCuota", detalle.ImporteCuota);
                            comando.Parameters.AddWithValue("@FechaVencimiento", detalle.FechaVencimiento);
                            comando.Parameters.AddWithValue("@Estado", 1);
                            comando.ExecuteNonQuery();
                        }
                    }
                }
                transaccion.Complete();
            }
            return true;
        }
    }
}
