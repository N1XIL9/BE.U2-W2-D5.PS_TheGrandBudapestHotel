using BE.U2_W2_D5.PS_GrandBudapestHotel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BE.U2_W2_D5.PS_GrandBudapestHotel.Controllers
{
    public class CamereController : Controller
    {
        // GET: Camere
        [Authorize]
        public ActionResult Camere()
        {
            List<Camera> listaCamere = new List<Camera>();

            SqlConnection sql = Connessioni.GetConnection();
            sql.Open();

            SqlCommand com = Connessioni.GetCommand("SELECT * FROM CAMERA", sql);
            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                Camera c = new Camera();


                c.IdCamera = Convert.ToInt32(reader["IdCamera"]);                
                c.NumeroCamera = Convert.ToInt32(reader["NumeroCamera"]);
                c.Descrizione = reader["Descrizione"].ToString();
                c.TipoCamera = reader["TipoCamera"].ToString();
                listaCamere.Add(c);

            }
            sql.Close();

            return View(listaCamere);
        }

        //MODIFICARE CAMERA - SELECT
        public ActionResult ModificaCamere(int id)
        {
            ViewBag.DropCamera = Camera.DropCamera;

            SqlConnection sql = Connessioni.GetConnection();
            sql.Open();

            SqlCommand com = Connessioni.GetCommand("SELECT * from CAMERA where CAMERA.IdCamera = @IdCamera", sql);
            com.Parameters.AddWithValue("IdCamera", id);
            SqlDataReader reader = com.ExecuteReader();

            Camera c = new Camera();

            while (reader.Read())
            {
                c.IdCamera = Convert.ToInt32(reader["IdCamera"]);
                c.NumeroCamera = Convert.ToInt32(reader["NumeroCamera"]);
                c.Descrizione = reader["Descrizione"].ToString();
                c.TipoCamera = reader["TipoCamera"].ToString();


            }
            sql.Close();
            return View(c);
        }

        [HttpPost]
        public ActionResult ModificaCamere(Camera custom)
        {
            SqlConnection sql = Connessioni.GetConnection();
            sql.Open();

            try
            {

                SqlCommand com = Connessioni.GetCommand("UPDATE CAMERA set NumeroCamera=@NumeroCamera, Descrizione=@Descrizione, TipoCamera=@TipoCamera" +
                    " where CAMERA.IdCamera = @IdCamera", sql);

                com.Parameters.AddWithValue("IdCamera", custom.IdCamera);
                com.Parameters.AddWithValue("NumeroCamera", custom.NumeroCamera);
                com.Parameters.AddWithValue("Descrizione", custom.Descrizione);
                com.Parameters.AddWithValue("TipoCamera", custom.TipoCamera);
          

                int row = com.ExecuteNonQuery();

                if (row > 0)
                {
                    ViewBag.confirm = "Scheda cliente modificata con successo";
                }

            }
            catch (Exception ex)
            {
                ViewBag.errore = ex.Message;
            }
            finally { sql.Close(); }

            return RedirectToAction("Camere");
        }

        // CANCELLA CAMERE

        public ActionResult CancellaCamere(int id)
        {
            SqlConnection sql = Connessioni.GetConnection();
            sql.Open();
            Camera c = new Camera();

            try
            {
                SqlCommand com = Connessioni.GetCommand("select * from CAMERA where CAMERA.IdCamera= @IdCamera", sql);
                com.Parameters.AddWithValue("IdCamera", id);

                SqlDataReader reader = com.ExecuteReader();



                while (reader.Read())
                {

                    c.IdCamera = Convert.ToInt32(reader["IdCamera"]);
                    c.NumeroCamera = Convert.ToInt32(reader["NumeroCamera"]);
                    c.Descrizione = reader["Descrizione"].ToString();
                    c.TipoCamera = reader["TipoCamera"].ToString();


                }
            }
            catch (Exception ex)
            {
                ViewBag.msgerror = ex.Message;
            }
            finally { sql.Close(); }

            return View(c);
        }

        [HttpPost]
        public ActionResult CancellaCamere(int id, Camera c)
        {

            //Verifico se ci sono prenotazioni collegate
            SqlConnection sqlc = Connessioni.GetConnection();
            sqlc.Open();

            try
            {
                SqlCommand comm = Connessioni.GetCommand("SELECT * FROM PRENOTAZIONE INNER JOIN CAMERA ON PRENOTAZIONE.IdCamera = CAMERA.IdCamera where NumeroCamera=@NumeroCamera", sqlc);
                comm.Parameters.AddWithValue("NumeroCamera", id);

                SqlDataReader reader = comm.ExecuteReader();

                //if (reader.HasRows)
                //{
                //    ViewBag.msgerror = "La camera non verrà eliminata se ci sono delle prenotazioni collegate ad essa. Controlla prima le prenotazioni.";
                //}
            }
            catch {  }
            
            finally { sqlc.Close(); }



            SqlConnection sql = Connessioni.GetConnection();
            sql.Open();


            try
            {
                SqlCommand com = Connessioni.GetCommand("DELETE from CAMERA where IdCamera= @IdCamera", sql);
                com.Parameters.AddWithValue("IdCamera", id);

                com.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                ViewBag.msgerror = ex.Message;
                
            }
            finally { sql.Close(); }

            return RedirectToAction("Camere");
        }

    }
}