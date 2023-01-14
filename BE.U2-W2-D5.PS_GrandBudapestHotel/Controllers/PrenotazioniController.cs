using BE.U2_W2_D5.PS_GrandBudapestHotel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BE.U2_W2_D5.PS_GrandBudapestHotel.Controllers
{
    public class PrenotazioniController : Controller
    {
        [Authorize]
        // GET: Prenotazioni
        public ActionResult PrenotazioneCLiente()
        {
            List<Prenotazioni> listaPrenotazioni = new List<Prenotazioni>();

            SqlConnection sql = Connessioni.GetConnection();
            sql.Open();

            SqlCommand com = Connessioni.GetCommand("SELECT * FROM PRENOTAZIONE INNER JOIN CLIENTE ON PRENOTAZIONE.IdCliente = CLIENTE.IdCliente" +
                " INNER JOIN PENSIONE ON PRENOTAZIONE.IdPensione = PENSIONE.IdPensione" +
                " INNER JOIN CAMERA ON PRENOTAZIONE.IdCamera = CAMERA.IdCamera" , sql);
            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                Prenotazioni p = new Prenotazioni();
                
                
                p.IdPrenotazione = Convert.ToInt32(reader["IdPrenotazione"]);                
                p.Cognome = reader["Cognome"].ToString();
                p.NumeroCamera = Convert.ToInt32(reader["NumeroCamera"]);
                p.DataPrenotazione = Convert.ToDateTime(reader["DataPrenotazione"]);
                p.Checkin = Convert.ToDateTime(reader["DataArrivo"]);
                p.CheckOut = Convert.ToDateTime(reader["DataPartenza"]);
                p.Caparra = Convert.ToDecimal(reader["Caparra"]);
                p.Nome = reader["Nome"].ToString();
                p.TariffaSoggiorno = Convert.ToDecimal(reader["TariffaSoggiorno"]);               
                p.TipoPensione = reader["TipoPensione"].ToString();
                listaPrenotazioni.Add(p);


            }
            sql.Close();

            return View(listaPrenotazioni);
        }

        //MODIFICARE - SELECT
        public ActionResult ModificaPrenotazione(int id)
        {
            SqlConnection sql = Connessioni.GetConnection();
            sql.Open();

            SqlCommand com = Connessioni.GetCommand("SELECT * from PRENOTAZIONE INNER JOIN CLIENTE ON PRENOTAZIONE.IdCliente = CLIENTE.IdCliente " +
                " INNER JOIN CAMERA ON PRENOTAZIONE.IdCamera = CAMERA.IdCamera" +
                "  INNER JOIN PENSIONE ON PRENOTAZIONE.IdPensione = PENSIONE.IdPensione" +
                " where PRENOTAZIONE.IdPrenotazione = @IdPrenotazione", sql);
            com.Parameters.AddWithValue("IdPrenotazione", id);
            SqlDataReader reader = com.ExecuteReader();

            Prenotazioni p = new Prenotazioni();

            while (reader.Read())
            {
                p.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                p.IdCamera = Convert.ToInt32(reader["IdCamera"]);
                p.IdPrenotazione = Convert.ToInt32(reader["IdPrenotazione"]);
                p.Cognome = reader["Cognome"].ToString();
                p.Nome = reader["Nome"].ToString();
                p.NumeroCamera = Convert.ToInt32(reader["NumeroCamera"]);
                p.DataPrenotazione = Convert.ToDateTime(reader["DataPrenotazione"]);
                p.Checkin = Convert.ToDateTime(reader["DataArrivo"]);
                p.CheckOut = Convert.ToDateTime(reader["DataPartenza"]);
                p.Caparra = Convert.ToDecimal(reader["Caparra"]);
                p.TariffaSoggiorno = Convert.ToDecimal(reader["TariffaSoggiorno"]);
                p.TipoPensione = reader["TipoPensione"].ToString();

                
            }
            sql.Close();
            return View(p);
        }

        [HttpPost]
        public ActionResult ModificaPrenotazione(Prenotazioni custom)
        {
            SqlConnection sql = Connessioni.GetConnection();
            sql.Open();

            try
            {

                SqlCommand com = Connessioni.GetCommand("UPDATE PRENOTAZIONE set IdCliente= @IdCliente, IdCamera=@IdCamera, DataPrenotazione=@DataPrenotazione, DataArrivo=@DataArrivo, DataPartenza=@DataPartenza, Caparra=@Caparra, TariffaSoggiorno=@TariffaSoggiorno" +
                    " where PRENOTAZIONE.IdPrenotazione = @IdPrenotazione", sql);

                com.Parameters.AddWithValue("IdPrenotazione", custom.IdPrenotazione);
                com.Parameters.AddWithValue("IdCliente", custom.IdCliente);
                com.Parameters.AddWithValue("IdCamera", custom.IdCamera);
                com.Parameters.AddWithValue("DataPrenotazione", custom.DataPrenotazione);
                com.Parameters.AddWithValue("DataArrivo", custom.Checkin);
                com.Parameters.AddWithValue("DataPartenza", custom.CheckOut);
                com.Parameters.AddWithValue("Caparra", custom.Caparra);
                com.Parameters.AddWithValue("TariffaSoggiorno", custom.TariffaSoggiorno);

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

            return RedirectToAction("PrenotazioneCLiente");
        }


        //DETTAGLI PRENOTAZIONE
        public ActionResult DettagliPrenotazione(int id)
        {
            SqlConnection sql = Connessioni.GetConnection();
            sql.Open();
            Prenotazioni p = new Prenotazioni();

            try
            {
                SqlCommand com = Connessioni.GetCommand("select * from PRENOTAZIONE INNER JOIN CLIENTE ON PRENOTAZIONE.IdCliente = CLIENTE.IdCliente" +
                    " INNER JOIN CAMERA ON PRENOTAZIONE.IdCamera = CAMERA.IdCamera" +
                    " INNER JOIN PENSIONE ON PRENOTAZIONE.IdPensione = PENSIONE.IdPensione" +
                    " where PRENOTAZIONE.IdPrenotazione= @idprenotazione", sql);
                com.Parameters.AddWithValue("IdPrenotazione", id);

                SqlDataReader reader = com.ExecuteReader();



                while (reader.Read())
                {

                    p.IdPrenotazione = Convert.ToInt32(reader["IdPrenotazione"]);
                    p.Cognome = reader["Cognome"].ToString();
                    p.Nome = reader["Nome"].ToString();
                
                    p.NumeroCamera = Convert.ToInt32(reader["NumeroCamera"]);
                    p.DataPrenotazione = Convert.ToDateTime(reader["DataPrenotazione"]);
                    p.Checkin = Convert.ToDateTime(reader["DataArrivo"]);
                    p.CheckOut = Convert.ToDateTime(reader["DataPartenza"]);
                    p.Caparra = Convert.ToDecimal(reader["Caparra"]);
                    p.TariffaSoggiorno = Convert.ToDecimal(reader["TariffaSoggiorno"]);
                    p.TipoPensione = reader["TipoPensione"].ToString();
                  

                }
            }
            catch (Exception ex)
            {
                ViewBag.msgerror = ex.Message;
            }
            finally { sql.Close(); }

            return View(p);
        }

        // CANCELLA PRENOTAZIONE

        public ActionResult CancellaPrenotazione(int id)
        {
            SqlConnection sql = Connessioni.GetConnection();
            sql.Open();
            Prenotazioni p = new Prenotazioni();

            try
            {
                SqlCommand com = Connessioni.GetCommand("select * from PRENOTAZIONE INNER JOIN CLIENTE ON PRENOTAZIONE.IdCliente = CLIENTE.IdCliente" +
                    " INNER JOIN CAMERA ON PRENOTAZIONE.IdCamera = CAMERA.IdCamera" +
                    " INNER JOIN PENSIONE ON PRENOTAZIONE.IdPensione = PENSIONE.IdPensione" +
                    " where PRENOTAZIONE.IdPrenotazione= @IdPrenotazione", sql);
                com.Parameters.AddWithValue("IdPrenotazione", id);

                SqlDataReader reader = com.ExecuteReader();



                while (reader.Read())
                {

                    p.IdPrenotazione = Convert.ToInt32(reader["IdPrenotazione"]);
                    p.Cognome = reader["Cognome"].ToString();
                    p.Nome = reader["Nome"].ToString();
                    p.NumeroCamera = Convert.ToInt32(reader["NumeroCamera"]);
                    p.DataPrenotazione = Convert.ToDateTime(reader["DataPrenotazione"]);
                    p.Checkin = Convert.ToDateTime(reader["DataArrivo"]);
                    p.CheckOut = Convert.ToDateTime(reader["DataPartenza"]);
                    p.Caparra = Convert.ToDecimal(reader["Caparra"]);
                    p.TariffaSoggiorno = Convert.ToDecimal(reader["TariffaSoggiorno"]);
                    p.TipoPensione = reader["TipoPensione"].ToString();


                }
            }
            catch (Exception ex)
            {
                ViewBag.msgerror = ex.Message;
            }
            finally { sql.Close(); }

            return View(p);
        }


        [HttpPost]
        public ActionResult CancellaPrenotazione(int id, Prenotazioni p)
        {
            SqlConnection sql = Connessioni.GetConnection();
            sql.Open();

            SqlCommand com = Connessioni.GetCommand("DELETE from SERVIZIO where IdPrenotazione= @IdPrenotazione", sql);
            com.Parameters.AddWithValue("IdPrenotazione", id);

            com.ExecuteNonQuery();

            sql.Close();




            SqlConnection cmd = Connessioni.GetConnection();
            cmd.Open();

            SqlCommand cmm = Connessioni.GetCommand("UPDATE CLIENTE SET IdPrenotazione=NULL WHERE IdPrenotazione= @IdPrenotazione", cmd);
            cmm.Parameters.AddWithValue("IdPrenotazione", id);

            cmm.ExecuteNonQuery();

            cmd.Close();




            SqlConnection con = Connessioni.GetConnection();
            con.Open();
           
            try
            {
                SqlCommand comm = Connessioni.GetCommand("DELETE from PRENOTAZIONE WHERE IdPrenotazione= @IdPrenotazione", con);
                comm.Parameters.AddWithValue("IdPrenotazione", id);

                comm.ExecuteNonQuery();
        
              
            }
            catch (Exception ex)
            {
                ViewBag.msgerror = ex.Message;
            }
            finally { con.Close(); }

            return RedirectToAction("PrenotazioneCliente");
        }

        // CREA PRENOTAZIONE

        public ActionResult CreaPrenotazione()
        {
            ViewBag.ListaClienti = Clienti.ListaClienti;
            return View();
        }


        [HttpPost]

        public ActionResult CreaPrenotazione(Prenotazioni p)
        {
            SqlConnection sql = Connessioni.GetConnection();
            sql.Open();

            try
            {

                SqlCommand com = Connessioni.GetCommand("INSERT INTO PRENOTAZIONE VALUES (@IdCliente, @IdCamera, @DataPrenotazione, @DataArrivo, @DataPartenza, @Caparra, @TariffaSoggiorno, @IdPensione)", sql);
            
                com.Parameters.AddWithValue("IdCliente", p.IdCliente);
                com.Parameters.AddWithValue("IdCamera", p.IdCamera);
                com.Parameters.AddWithValue("DataPrenotazione", p.DataPrenotazione);
                com.Parameters.AddWithValue("DataArrivo", p.Checkin);
                com.Parameters.AddWithValue("DataPartenza", p.CheckOut);
                com.Parameters.AddWithValue("Caparra", p.Caparra);
                com.Parameters.AddWithValue("TariffaSoggiorno", p.TariffaSoggiorno);
                com.Parameters.AddWithValue("IdPensione", p.TipoPensione);



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

            return RedirectToAction("PrenotazioneCLiente");
        }
    }


}
