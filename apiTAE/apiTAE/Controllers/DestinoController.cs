using apiTAE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace apiTAE.Controllers
{
    [ApiController]
    [Route("Destino")]
    public class DestinoController : ControllerBase
    {
        private readonly IConfiguration Configuration;

        public DestinoController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> ListarDestinos() 
        {
            List<DestinoModel> Lista = new List<DestinoModel>();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec ObtenerDestinos";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DestinoModel model = new DestinoModel();

                        model.IdDestino = Int32.Parse(dataReader["ID"].ToString());
                        model.Nombre = dataReader["NOMBRE"].ToString();
                        model.Descripcion = dataReader["DESCRIPCION"].ToString();
                        model.IMG = dataReader["IMG"].ToString();
                        model.Precio = Int32.Parse(dataReader["PRECIO"].ToString());
                        model.Capacidad = Int32.Parse(dataReader["CAPACIDAD"].ToString());
                        model.Provincia = Int32.Parse(dataReader["PROVINCIA"].ToString());
                        model.Clasificacion_Edad = Int32.Parse(dataReader["CLASIFICACION_EDAD"].ToString());
                        model.Facilidad = Int32.Parse(dataReader["FACILIDADES"].ToString());
                        model.Actividad_Principal = Int32.Parse(dataReader["ACTIVIDAD_PRINCIPAL"].ToString());
                        model.Latitud = dataReader["LATITUD"].ToString();
                        model.Longitud = dataReader["LONGITUD"].ToString();
                        model.Clase = dataReader["CLASE"].ToString();
                        Lista.Add(model);
                    } 
                    connection.Close();
                }
            }
            return Ok(Lista);
        }

        [HttpGet]
        [Route("ObtenerPorId/{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            DestinoModel model = new DestinoModel();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec ObtenerPorId @id = {id}";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        model.IdDestino = Int32.Parse(dataReader["ID"].ToString());
                        model.Nombre = dataReader["NOMBRE"].ToString();
                        model.Descripcion = dataReader["DESCRIPCION"].ToString();
                        model.IMG = dataReader["IMG"].ToString();
                        model.Precio = Int32.Parse(dataReader["PRECIO"].ToString());
                        model.Capacidad = Int32.Parse(dataReader["CAPACIDAD"].ToString());
                        model.Provincia = Int32.Parse(dataReader["PROVINCIA"].ToString());
                        model.Clasificacion_Edad = Int32.Parse(dataReader["CLASIFICACION_EDAD"].ToString());
                        model.Facilidad = Int32.Parse(dataReader["FACILIDADES"].ToString());
                        model.Actividad_Principal = Int32.Parse(dataReader["ACTIVIDAD_PRINCIPAL"].ToString());
                        model.Clase = dataReader["CLASE"].ToString();
                    }
                    connection.Close();
                }
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("ObtenerProbabilidad/{clase}/{attrname}/{attrvalue}")]
        public async Task<IActionResult> ObtenerProbabilidad(string clase, string attrname, string attrvalue) {

            ProbabilidadModel model = new ProbabilidadModel();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"exec getprobability @classt = {clase}, @attrNamet={attrname}, @attrValuet={attrvalue}";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        model.probability = float.Parse(dataReader["probability"].ToString());
                    }
                    connection.Close();
                }
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("Euclides")]
        public async Task<IActionResult> Euclides(int provincia, int capacidad, int classEdad,
            int actividad, int precio, int facilidad) {
            List<DestinoModel> lista = new List<DestinoModel>();
            
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //se escribe la consulta
                string sqlQuery = $"EXEC[dbo].[euclides] @provincia={provincia},@capacidad={capacidad}, @class_edad={classEdad}, @actividad_principal={actividad}, @precio={precio},@facilidades={facilidad}";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DestinoModel model = new DestinoModel();
                        model.IdDestino = Int32.Parse(dataReader["ID"].ToString());
                        model.Nombre = dataReader["NOMBRE"].ToString();
                        model.Descripcion = dataReader["DESCRIPCION"].ToString();
                        model.IMG = dataReader["IMG"].ToString();
                        model.Precio = Int32.Parse(dataReader["PRECIO"].ToString());
                        model.Capacidad = Int32.Parse(dataReader["CAPACIDAD"].ToString());
                        model.Provincia = Int32.Parse(dataReader["PROVINCIA"].ToString());
                        model.Clasificacion_Edad = Int32.Parse(dataReader["CLASIFICACION_EDAD"].ToString());
                        model.Facilidad = Int32.Parse(dataReader["FACILIDADES"].ToString());
                        model.Actividad_Principal = Int32.Parse(dataReader["ACTIVIDAD_PRINCIPAL"].ToString());
                        model.Clase = dataReader["CLASE"].ToString();
                        lista.Add(model);
                    }
                    connection.Close();
                }
            }
            return Ok(lista);
        }
    }
}
