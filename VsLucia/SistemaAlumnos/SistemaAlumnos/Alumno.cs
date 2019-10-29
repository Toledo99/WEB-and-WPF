using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SistemaAlumnos
{
    class Alumno
    {
        public Int16 claveUnica { get; set; } //propiedades autoimplementadas
        public String nombre { get; set; }
        public String sexo { get; set; }
        public String correo { get; set; }
        public Int16 semestre { get; set; }
        public int programa { get; set; }



        public Alumno()
        {
        }

        public Alumno(short claveUnica, string nombre, string sexo, string correo, short semestre, int programa)
        {
            this.claveUnica = claveUnica;
            this.nombre = nombre;
            this.sexo = sexo;
            this.correo = correo;
            this.semestre = semestre;
            this.programa = programa;
        }

        public Alumno(short claveUnica, string correo)
        {
            this.claveUnica = claveUnica;
            this.correo = correo;
        }



        //funcion de agregar un alumno a la tabla alumno, y regresa un etero positivo 
        //si lo pudo agregar o un entero negativo si no lo agregó

        public int agregar(Alumno a)
        {
            int res = 0;
            //abrir la conexion 
            SqlConnection con;
            con = Conexion.conectar();

            //command para ejecutar el query (insert)
            SqlCommand cmd = new SqlCommand(String.Format("insert into alumno (claveUnica, nombre, sexo, correo, semestre, idPrograma) values({0}, '{1}', '{2}', '{3}', {4},{5})", a.claveUnica, a.nombre, a.sexo, a.correo, a.semestre, a.programa), con);
            res = cmd.ExecuteNonQuery(); //num de colunas(registros) afectados (-1 indica no modificaciones)
            //cerrar la conexion 
            con.Close();

            return res;
        }

        public int eliminar(int cu)
        {
            int res = 0;
            //abrir la conexion 
            SqlConnection con;
            con = Conexion.conectar();

            //command para ejecutar el query (insert)
            SqlCommand cmd = new SqlCommand(String.Format("delete from alumno where claveUnica={0} ", cu), con);
            res = cmd.ExecuteNonQuery(); //num de colunas(registros) afectados (-1 indica no modificaciones)
            //cerrar la conexion 
            con.Close();

            return res;
        }

        public int modificar(Alumno a)
        {
            int res = 0;
            //abrir la conexion 
            SqlConnection con;
            con = Conexion.conectar();

            //command para ejecutar el query (insert)
            SqlCommand cmd = new SqlCommand(String.Format("update alumno set correo='{0}' where claveUnica={1}", a.correo, a.claveUnica), con);
            res = cmd.ExecuteNonQuery(); //num de colunas(registros) afectados (-1 indica no modificaciones)
            //cerrar la conexion 
            con.Close();

            return res;
        }

        public List<Alumno> buscar(String nombre)
        {
            List<Alumno> lis = new List<Alumno>();
            Alumno a;
            SqlDataReader rd;

            //abrir la conexion 
            SqlConnection con;
            con = Conexion.conectar();

            //command para ejecutar el query (insert)
            SqlCommand cmd = new SqlCommand(String.Format("select * from alumno where nombre like '%{0}%'", nombre), con);
            //ejecutar el query
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                a = new Alumno();
                a.claveUnica = rd.GetInt16(0);
                a.nombre = rd.GetString(1);
                a.sexo = rd.GetString(2);
                a.correo = rd.GetString(3);
                a.semestre = rd.GetInt16(4);
                a.programa = rd.GetInt16(5);
                lis.Add(a);

            }

            con.Close();
            return lis;
        }


    }
}
