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

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["admin"].ToString();
            con = new SqlConnection(constr);
        }
        public int Insertar(Usuario usr)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("INSERT INTO es_usuarios (usu_documento, usu_tipodoc, usu_nombre, usu_celular, usu_email, usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro)values(@documento,@tipodocumento,@nombre,@celular,@email,@genero,@aprendiz,@egresado,@areaformacion,@fechaegresado,@direccion,@barrio,@ciudad,@departamento,@fecharegistro)", con);

            comando.Parameters.Add("@documento", SqlDbType.Int);
            comando.Parameters.Add("@tipodocumento", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@celular", SqlDbType.Int);
            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters.Add("@genero", SqlDbType.VarChar);
            comando.Parameters.Add("@aprendiz", SqlDbType.Bit);
            comando.Parameters.Add("@egresado", SqlDbType.Bit);
            comando.Parameters.Add("@areaformacion", SqlDbType.VarChar);
            comando.Parameters.Add("@fechaegresado", SqlDbType.Date);
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@barrio", SqlDbType.VarChar);
            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando.Parameters.Add("@departamento", SqlDbType.VarChar);
            comando.Parameters.Add("@fecharegistro", SqlDbType.DateTime);

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

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public List<Usuario> RecupearTodos()
        {
            Conectar();
            List<Usuario> usuario = new List<Usuario>();

            SqlCommand com = new SqlCommand("SELECT usu_documento,usu_tipodoc,usu_nombre,usu_celular,usu_email,usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro FROM es_usuarios ORDER BY usu_nombre ASC", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();

            while (registros.Read())
            {
                Usuario usr = new Usuario
                {
                    Documento = int.Parse(registros["usu_documento"].ToString()),
                    TipoDocumento = registros["usu_tipodoc"].ToString(),
                    Nombre = registros["usu_nombre"].ToString(),
                    Celular = int.Parse(registros["usu_celular"].ToString()),
                    Email = registros["usu_email"].ToString(),
                    Genero = registros["usu_genero"].ToString(),
                    Aprendiz = bool.Parse(registros["usu_aprendiz"].ToString()),
                    Egresado = bool.Parse(registros["usu_egresado"].ToString()),
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
        public Usuario Recuperar(int documento)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("SELECT usu_documento,usu_tipodoc,usu_nombre,usu_celular,usu_email,usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccionusu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro FROM Usuarios WHERE documento=@documento", con);

            comando.Parameters.Add("@documento", SqlDbType.Int);
            comando.Parameters["@documento"].Value = documento;

            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Usuario usuario = new Usuario();

            if (registros.Read())
            {
                usuario.Documento = int.Parse(registros["codigo"].ToString());
                usuario.TipoDocumento = registros["tipoDocumento"].ToString();
                usuario.Nombre = registros["nombre"].ToString();
                usuario.Celular = int.Parse(registros["documento"].ToString());
                usuario.Email = registros["email"].ToString();
                usuario.Genero = registros["genero"].ToString();
                usuario.Aprendiz = bool.Parse(registros["aprendiz"].ToString());
                usuario.Egresado = bool.Parse(registros["egresado"].ToString());
                usuario.AreaFormacion = registros["areaFormacion"].ToString();
                usuario.FechaEgresado = DateTime.Parse(registros["usu_fechaegresado"].ToString());
                usuario.Direccion = registros["direccion"].ToString();
                usuario.Barrio = registros["barrio"].ToString();
                usuario.Ciudad = registros["ciudad"].ToString();
                usuario.Departamento = registros["departamento"].ToString();
                usuario.FechaRegistro = DateTime.Parse(registros["fechaRegistro"].ToString());
            }
            con.Close();
            return usuario;
        }
        public int Modificar(Usuario usr)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("UPDATE es_usuarios set tipoDocumento=@tipodocumento,nombre=@nombre,celular=@celular,email=@email,genero=@genero,aprendiz=@aprendiz,egresado=@egresado,areaFormacion=@areaformacion,fechaEgresado=@fechaegresado,direccion=@direccion,barrio=@barrio,ciudad=@ciudad,departamento=@departamento,fechaRegistro=@fecharegistro WHERE documento=@documento", con);
            comando.Parameters.Add("@documento", SqlDbType.Int);
            comando.Parameters.Add("@tipodocumento", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@celular", SqlDbType.Int);
            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters.Add("@genero", SqlDbType.VarChar);
            comando.Parameters.Add("@aprendiz", SqlDbType.VarChar);
            comando.Parameters.Add("@egresado", SqlDbType.VarChar);
            comando.Parameters.Add("@areaformacion", SqlDbType.VarChar);
            comando.Parameters.Add("@fechaegresado", SqlDbType.VarChar);
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@barrio", SqlDbType.VarChar);
            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando.Parameters.Add("@departamento", SqlDbType.VarChar);
            comando.Parameters.Add("@fecharegistro", SqlDbType.VarChar);

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
            comando.Parameters["@fecharegistro"].Value = usr.FechaRegistro;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int Borrar(int documento)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("DELETE FROM es_usuarios WHERE documento=@documento", con);
            comando.Parameters.Add("@documento", SqlDbType.Int);
            comando.Parameters["@documento"].Value = documento;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

    }
}