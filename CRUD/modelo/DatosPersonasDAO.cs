using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC
{
    public static class DatosPersonasDAO
    {
        private static String cadenaConexion= @"server=PC1\SQLEXPRESS2016; database= TI2020; Integrated Security=true";
        /// <summary>
        /// Crear y guardar datos personales
        /// </summary>
        /// <param name="datosPersonas"></param>
        /// <returns></returns>
        public static int crear(DatosPersona datosPersonas)
        {
            //1. configurar la conexión con una fuente de datos
            //string cadenaConexion = @"server=A-SIS-0KP\SQLEXPRESS2016; database= TI2020; user id=sa; password=isa";
            //string cadenaConexion = @"server=PC1\SQLEXPRESS2016; database= TI2020; Integrated Security=true";
            //definir un objeto tipo conexión
            SqlConnection conn = new SqlConnection(cadenaConexion);

            //2. Definir y configurar la operación a realizar en el motor de BDD
            //escribir sentencia sql
            string sql = "insert into DatosPersonas(cedula,apellidos,nombres,sexo, " +
                "fechaNacimiento, correo, estaturacm, peso) values(@cedula,@apellidos,@nombres, " +
                "@sexo, @fechaNacimiento, @correo, @estaturacm, @peso)";

            //definir un comando para ejecutar esa sentencia sql (operación a realizar)
            SqlCommand comando = new SqlCommand(sql, conn);
            comando.CommandType = System.Data.CommandType.Text; //valor por defecto
            comando.Parameters.AddWithValue("@cedula", datosPersonas.Cedula);
            comando.Parameters.AddWithValue("@apellidos", datosPersonas.Apellidos);
            comando.Parameters.AddWithValue("@nombres", datosPersonas.Nombres);
            comando.Parameters.AddWithValue("@sexo", datosPersonas.Sexo);
            comando.Parameters.AddWithValue("@fechaNacimiento", datosPersonas.FechaNacimiento.Date);
            comando.Parameters.AddWithValue("@estaturacm", datosPersonas.Estatura);
            comando.Parameters.AddWithValue("@peso", datosPersonas.Peso);
            comando.Parameters.AddWithValue("@correo", datosPersonas.Correo);

            //3. Se abre la conexión y se ejecuta el comando
            conn.Open();
            int x = comando.ExecuteNonQuery(); //ejecutamos el comando
            //4. cerrar la conexión
            conn.Close();

            return x;
        }
        /// <summary>
        /// Mostrar todos los datos en la tabla DataGridView
        /// </summary>
        /// <returns></returns>
        public static DataTable getAll()
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);
            //1.definir y configurar conexion
            string sql = "select cedula,apellidos+' '+nombres [Nombre Completo],sexo," +
                "fechaNacimiento, correo, estaturacm " +
                "from DatosPersonas " +
                "order by apellidos, nombres";
            //definir un adaptador de datos: es un puente que permite pasar los datos de nuestra BDD, hacia
            //el datatable
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            //3. recuperamos los datos
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
        /// <summary>
        /// codigo boolean si existe cedula
        /// </summary>
        /// <param name="scedula"></param>
        /// <returns></returns>
        public static Boolean existeCedula(String scedula)
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);
            //1.definir y configurar conexion
            string sql = "select cedula " +
                "from DatosPersonas " +
                "where cedula=@cedula";
            //definir un adaptador de datos: es un puente que permite pasar los datos de nuestra BDD, hacia
            //el datatable
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            ad.SelectCommand.Parameters.AddWithValue("@cedula", scedula);

            //3. recuperamos los datos
            DataTable dt = new DataTable();
            ad.Fill(dt);
            Boolean existe = false;//si existe filas
            if (dt.Rows.Count > 0)
                existe = true;

            return existe;
        }
        public static int delete(String cedula)
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);

            string sql = "delete from DatosPersonas " +
                "where cedula=@cedula";
            SqlCommand comando = new SqlCommand(sql, conn);
            //vonfiguramos los parametros

            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@cedula", cedula);
            conn.Open();
            int x = comando.ExecuteNonQuery(); //ejecutamos el comando
            conn.Close();
            return x;

        }

    }
}
