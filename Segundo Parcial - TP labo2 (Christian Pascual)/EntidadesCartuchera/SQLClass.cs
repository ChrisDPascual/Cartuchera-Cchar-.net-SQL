using System;
using System.Collections.Generic;
using System.Data.SqlClient; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCartuchera
{
    public class SQLClass
    {
        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;

        static SQLClass()
        {
            connectionString = "Server=.;Database=CARTUCHERADB;Trusted_Connection=True";
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;

        }

        public static List<Cartuchera<Utiles>> LeerCartucheras()
        {
            List<Cartuchera<Utiles>> listaCartucheras = new List<Cartuchera<Utiles>>();

            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "SELECT * FROM CARTUCHERAS";
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    listaCartucheras.Add(new Cartuchera<Utiles>(dataReader["NOMBRE_DUENIO"].ToString(), (int)dataReader["ID_CARTUCHERA"], (double)dataReader["PRECIO_TOTAL"], (int)dataReader["CAPACIDAD"]));
                }
                connection.Close();
                return listaCartucheras;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public static List<Utiles> LeerUtiles(Cartuchera<Utiles> cartuchera)
        {
            List<Utiles> listaUtiles = new List<Utiles>();

            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "SELECT * FROM UTILES WHERE ID_CARTUCHERA = @id";
                command.Parameters.AddWithValue("@id", cartuchera.ID);
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    if ((string)dataReader["UTIL"] == "lapiz") 
                    {
                        listaUtiles.Add(new Lapiz(dataReader["MARCA"].ToString(), (double)dataReader["PRECIO_UNITARIO"], dataReader["ESTILO"].ToString(), (int)dataReader["CANTIDAD"], dataReader["COLORES"].ToString(), (int)dataReader["ID_CARTUCHERA"]));
                    }

                    if((string)dataReader["UTIL"] == "goma")
                    {
                        bool tinta = false ;
                        bool lapiz = false;
                        if((string)dataReader["BORRA"] == "borra todo") 
                        {
                            tinta = true;
                            lapiz = true;
                        }
                        if ((string)dataReader["BORRA"] == "borra tinta")
                        {
                            tinta = true;
                            lapiz = false;
                        }
                        if ((string)dataReader["BORRA"] == "borra lapiz")
                        {
                            tinta = false;
                            lapiz = true;
                        }

                        listaUtiles.Add(new Goma(dataReader["MARCA"].ToString(), (double)dataReader["PRECIO_UNITARIO"], dataReader["ESTILO"].ToString(), (int)dataReader["CANTIDAD"],lapiz,tinta,(int)dataReader["ID_CARTUCHERA"]));
                    }

                    if((string)dataReader["UTIL"] == "sacapuntas")
                    {
                        listaUtiles.Add(new Sacapuntas(dataReader["MARCA"].ToString(), (double)dataReader["PRECIO_UNITARIO"], dataReader["ESTILO"].ToString(), (int)dataReader["CANTIDAD"], (int)dataReader["AGUJEROS"], (int)dataReader["ID_CARTUCHERA"]));
                    }
                    
                }
                

                return listaUtiles;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public static void GuardarCartuchera(Cartuchera<Utiles> cartuchera)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"INSERT INTO CARTUCHERAS (NOMBRE_DUENIO,CAPACIDAD,PRECIO_TOTAL,ID_CARTUCHERA) VALUES (@nombre, @capacidad,@precioTotal,@id)";
                command.Parameters.AddWithValue("@nombre", cartuchera.Duenio);
                command.Parameters.AddWithValue("@capacidad", cartuchera.Capacidad);
                command.Parameters.AddWithValue("@precioTotal", cartuchera.PrecioTotal);
                command.Parameters.AddWithValue("@id", cartuchera.ID);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public static void GuardarUtil(Cartuchera<Utiles> cartuchera, Utiles util)
        {
            try
            {
                

                command.Parameters.Clear();

                if (util.Util == "lapiz")
                {
                    command.Parameters.AddWithValue("@color", ((Lapiz)util).Color);
                    command.Parameters.AddWithValue("@agujeros", string.Empty);
                    command.Parameters.AddWithValue("@borra", string.Empty);
                }

                if (util.Util == "sacapuntas")
                {
                    command.Parameters.AddWithValue("@agujeros", ((Sacapuntas)util).CantidadAgujeros);
                    command.Parameters.AddWithValue("@borra", string.Empty);
                    command.Parameters.AddWithValue("@color", string.Empty);
                }

                if (util.Util == "goma")
                {
                    command.Parameters.AddWithValue("@color", string.Empty);
                    command.Parameters.AddWithValue("@agujeros", string.Empty);
                    if (((Goma)util).ParaLapiz == "si" && ((Goma)util).ParaTinta == "si") 
                    {
                        command.Parameters.AddWithValue("@borra","borra todo");
                    }
                    else 
                    {
                        if (((Goma)util).ParaLapiz == "no" && ((Goma)util).ParaTinta == "si")
                        {
                            command.Parameters.AddWithValue("@borra", "borra tinta");
                        }
                        else 
                        {
                            command.Parameters.AddWithValue("@borra", "borra lapiz");
                        }
                    }

                }

                connection.Open();
                command.CommandText = $"INSERT INTO UTILES (UTIL,MARCA,PRECIO_UNITARIO,ESTILO,CANTIDAD,ID_CARTUCHERA,COLORES,AGUJEROS,BORRA) VALUES (@util, @marca,@precioUnitario,@estilo,@cantidad,@id,@color,@agujeros,@borra)";
                command.Parameters.AddWithValue("@util", util.Util);
                command.Parameters.AddWithValue("@marca", util.Marca);
                command.Parameters.AddWithValue("@cantidad", util.Cantidad);
                command.Parameters.AddWithValue("@precioUnitario", (float)util.Precio);
                command.Parameters.AddWithValue("@estilo", util.Estilo);
                command.Parameters.AddWithValue("@id", cartuchera.ID);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
        public static void EliminarTodo()
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"DELETE FROM CARTUCHERAS";
                command.ExecuteNonQuery();
                command.CommandText = $"DELETE FROM UTILES";
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public static void EliminarID(int id)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"DELETE * FROM CARTUCHERAS WHERE ID_CARTUCHERA = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();


                command.Parameters.Clear();
                command.CommandText = $"DELETE * FROM UTILES WHERE ID_CARTUCHERA = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public static void ModificarCartuchera(Cartuchera<Utiles> cartuchera)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"UPDATE CARTUCHERAS SET NOMBRE_DUENIO = @nombre, CAPACIDAD = @capacidad, PRECIO_TOTAL = @precioTotal, ID_CARTUCHERA = @idCartuchera WHERE ID_CARTUCHERA = @idCartuchera";
                command.Parameters.AddWithValue("@nombre", cartuchera.Duenio);
                command.Parameters.AddWithValue("@capacidad", cartuchera.CalucularMercaderiaAcumulada(cartuchera));
                command.Parameters.AddWithValue("@precioTotal", cartuchera.CalcularTotal(cartuchera));
                command.Parameters.AddWithValue("@idCartuchera", cartuchera.ID);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public static void ModificarUtil(Cartuchera<Utiles> cartuchera, Utiles util)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"UPDATE UTILES SET PRECIO_UNITARIO = @precioUnitario, CANTIDAD = @capacidad WHERE ID_CARTUCHERA = @id";
                command.Parameters.AddWithValue("@capacidad", util.Cantidad);
                command.Parameters.AddWithValue("@precioUnitario", util.Precio);
                command.Parameters.AddWithValue("@id", cartuchera.ID);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public static List<Lapiz> retornarLapices()
        {
            List<Lapiz> listaLapices = new List<Lapiz>();

            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "SELECT * FROM UTILES WHERE UTIL = @util";
                command.Parameters.AddWithValue("@util", "lapiz");
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {           
                   listaLapices.Add(new Lapiz(dataReader["MARCA"].ToString(), (double)dataReader["PRECIO_UNITARIO"], dataReader["ESTILO"].ToString(), (int)dataReader["CANTIDAD"], dataReader["COLORES"].ToString(), (int)dataReader["ID_CARTUCHERA"]));                                  
                }


                return listaLapices;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }


}
