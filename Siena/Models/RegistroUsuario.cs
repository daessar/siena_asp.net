using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Siena.Models
{
    public class RegistroUsuario
    {
        private SqlConnection con;

        private void Conectar() //Se crea una función para conectar a la base de bd
        {
            string constr = ConfigurationManager.ConnectionStrings["admin"].ToString();
            con = new SqlConnection(constr);
        }
        public int Insertar(Usuario usr) //Se crean los elementos
        {
            Conectar();
            SqlCommand comando = new SqlCommand("INSERT INTO es_usuarios (usu_documento, usu_tipodoc, usu_nombre, usu_celular, usu_email, usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro)values(@documento,@tipodocumento,@nombre,@celular,@email,@genero,@aprendiz,@egresado,@areaformacion,@fechaegresado,@direccion,@barrio,@ciudad,@departamento,@fecharegistro)", con);

            //Especifica que tipo de datos es
            comando.Parameters.Add("@documento", SqlDbType.Int);
            comando.Parameters.Add("@tipodocumento", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@celular", SqlDbType.Int);
            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters.Add("@genero", SqlDbType.VarChar);
            comando.Parameters.Add("@aprendiz", SqlDbType.VarChar);
            comando.Parameters.Add("@egresado", SqlDbType.VarChar);
            comando.Parameters.Add("@areaformacion", SqlDbType.VarChar);
            comando.Parameters.Add("@fechaegresado", SqlDbType.Date);
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@barrio", SqlDbType.VarChar);
            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando.Parameters.Add("@departamento", SqlDbType.VarChar);
            comando.Parameters.Add("@fecharegistro", SqlDbType.DateTime);

            //Lee y modifica los datos

            comando.Parameters["@documento"].Value = usr.Documento;
            comando.Parameters["@tipodocumento"].Value = usr.TipoDocumento;
            comando.Parameters["@nombre"].Value = usr.Nombre;
            comando.Parameters["@celular"].Value = usr.Celular;
            comando.Parameters["@email"].Value = usr.Email;
            comando.Parameters["@genero"].Value = usr.Genero;
            comando.Parameters["@aprendiz"].Value = usr.Aprendiz;
            comando.Parameters["@egresado"].Value = usr.Egresado;
            comando.Parameters["@areaformacion"].Value = usr.AreaFormacion;
            comando.Parameters["@fechaegresado"].Value = usr.FechaEgresado;
            comando.Parameters["@direccion"].Value = usr.Direccion;
            comando.Parameters["@barrio"].Value = usr.Barrio;
            comando.Parameters["@ciudad"].Value = usr.Ciudad;
            comando.Parameters["@departamento"].Value = usr.Departamento;
            comando.Parameters["@fecharegistro"].Value = DateTime.Today;

            con.Open(); //Abre la conexion
            int i = comando.ExecuteNonQuery(); //Devuelve el numero de filas afectadas
            con.Close(); //Cierra la conexion
            return i; //Retornas cuantas filas se afectaron
        }
        public List<Usuario> RecupearTodos()
        {
            Conectar();
            List<Usuario> usuario = new List<Usuario>(); //Trae todos los datos que estan en la bd

            SqlCommand com = new SqlCommand("SELECT usu_id,usu_documento,usu_tipodoc,usu_nombre,usu_celular,usu_email,usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro FROM es_usuarios ORDER BY usu_nombre ASC", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();

            while (registros.Read()) //Se muestran los campos por filas, uno por uno 
            {
                Usuario usr = new Usuario
                {
                    Id = int.Parse(registros["usu_id"].ToString()),
                    Documento = int.Parse(registros["usu_documento"].ToString()),
                    TipoDocumento = registros["usu_tipodoc"].ToString(),
                    Nombre = registros["usu_nombre"].ToString(),
                    Celular = int.Parse(registros["usu_celular"].ToString()),
                    Email = registros["usu_email"].ToString(),
                    Genero = registros["usu_genero"].ToString(),
                    Aprendiz = registros["usu_aprendiz"].ToString(),
                    Egresado = registros["usu_egresado"].ToString(),
                    AreaFormacion = registros["usu_areaformacion"].ToString(),
                    FechaEgresado= DateTime.Parse( registros["usu_fechaegresado"].ToString()),
                    Direccion = registros["usu_direccion"].ToString(),
                    Barrio = registros["usu_barrio"].ToString(),
                    Ciudad= registros["usu_ciudad"].ToString(),
                    Departamento = registros["usu_departamento"].ToString(),
                    FechaRegistro = DateTime.Parse(registros["usu_fechaRegistro"].ToString()),


                };
                usuario.Add(usr);

            }
            con.Close();
            return usuario;
        }
        public Usuario Recuperar(int id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("SELECT usu_id,usu_documento,usu_tipodoc,usu_nombre,usu_celular,usu_email,usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro FROM es_usuarios WHERE usu_id=@id", con);

            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters["@id"].Value = id;

            con.Open();
            SqlDataReader registros = comando.ExecuteReader(); //Trae las lineas que se guardaron o afectaron y ejecuta la sentencia
            Usuario usuario = new Usuario();

            //Trae la informacion de la base de datos para pasarla al controlador y despues el controlador los envia a la vista.
            if (registros.Read())
            {
                usuario.Id = int.Parse(registros["usu_id"].ToString());
                usuario.Documento = int.Parse(registros["usu_documento"].ToString());
                usuario.TipoDocumento = registros["usu_tipodoc"].ToString();
                usuario.Nombre = registros["usu_nombre"].ToString();
                usuario.Celular = int.Parse(registros["usu_celular"].ToString());
                usuario.Email = registros["usu_email"].ToString();
                usuario.Genero = registros["usu_genero"].ToString();
                usuario.Aprendiz = registros["usu_aprendiz"].ToString();
                usuario.Egresado =  registros["usu_egresado"].ToString();
                usuario.AreaFormacion = registros["usu_areaFormacion"].ToString();
                usuario.FechaEgresado = DateTime.Parse(registros["usu_fechaegresado"].ToString());
                usuario.Direccion = registros["usu_direccion"].ToString();
                usuario.Barrio = registros["usu_barrio"].ToString();
                usuario.Ciudad = registros["usu_ciudad"].ToString();
                usuario.Departamento = registros["usu_departamento"].ToString();
            }
            con.Close();
            return usuario;
        }
        public int Modificar(Usuario usr)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("UPDATE es_usuarios set usu_tipodoc=@tipodocumento,usu_nombre=@nombre,usu_celular=@celular,usu_email=@email,usu_genero=@genero,usu_aprendiz=@aprendiz,usu_egresado=@egresado,usu_areaformacion=@areaformacion,usu_fechaegresado=@fechaegresado,usu_direccion=@direccion,usu_barrio=@barrio,usu_ciudad=@ciudad,usu_departamento=@departamento,usu_fecharegistro=@fecharegistro WHERE usu_id=@id", con);
            //Muestra la información
            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters.Add("@documento", SqlDbType.Int);
            comando.Parameters.Add("@tipodocumento", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@celular", SqlDbType.Int);
            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters.Add("@genero", SqlDbType.VarChar);
            comando.Parameters.Add("@aprendiz", SqlDbType.VarChar);
            comando.Parameters.Add("@egresado", SqlDbType.VarChar);
            comando.Parameters.Add("@areaformacion", SqlDbType.VarChar);
            comando.Parameters.Add("@fechaegresado", SqlDbType.DateTime);
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@barrio", SqlDbType.VarChar);
            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando.Parameters.Add("@departamento", SqlDbType.VarChar);
            comando.Parameters.Add("@fecharegistro", SqlDbType.DateTime);

            comando.Parameters["@id"].Value = usr.Id;
            comando.Parameters["@documento"].Value = usr.Documento;
            comando.Parameters["@tipodocumento"].Value = usr.TipoDocumento;
            comando.Parameters["@nombre"].Value = usr.Nombre;
            comando.Parameters["@celular"].Value = usr.Celular;
            comando.Parameters["@email"].Value = usr.Email;
            comando.Parameters["@genero"].Value = usr.Genero;
            comando.Parameters["@aprendiz"].Value = usr.Aprendiz;
            comando.Parameters["@egresado"].Value = usr.Egresado;
            comando.Parameters["@areaformacion"].Value = usr.AreaFormacion;
            comando.Parameters["@fechaegresado"].Value = usr.FechaEgresado;
            comando.Parameters["@direccion"].Value = usr.Direccion;
            comando.Parameters["@barrio"].Value = usr.Barrio;
            comando.Parameters["@ciudad"].Value = usr.Ciudad;
            comando.Parameters["@departamento"].Value = usr.Departamento;
            comando.Parameters["@fecharegistro"].Value = DateTime.Now;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int Borrar(int id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("DELETE FROM es_usuarios WHERE usu_id=@id", con);
            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters["@id"].Value = id;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

    }
}