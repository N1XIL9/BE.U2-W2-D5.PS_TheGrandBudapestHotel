using BE.U2_W2_D5.PS_GrandBudapestHotel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BE.U2_W2_D5.PS_GrandBudapestHotel.Controllers
{
    public class ClienteController : Controller
    {
        [Authorize]
        // GET: Cliente
        public ActionResult DettagliCliente()
        {
            SqlConnection sql = Connessioni.GetConnection();
            sql.Open();


            List<Clienti> listaClienti = new List<Clienti>();
            try
            {
                SqlCommand com = Connessioni.GetCommand("select * from CLIENTE ", sql);
                

                SqlDataReader reader = com.ExecuteReader();



                while (reader.Read())
                {

                    Clienti c = new Clienti();
                    c.IdCliente = Convert.ToInt32(reader["IdCliente"]);                
                    c.Cognome = reader["Cognome"].ToString();
                    c.Nome = reader["Nome"].ToString();
                    c.CF = reader["CodiceFiscale"].ToString();
                    c.Citta = reader["Citta"].ToString();
                    c.Provincia = reader["Provincia"].ToString();
                    c.Email = reader["Email"].ToString();
                    c.Telefono = reader["Telefono"].ToString() ;
                    c.Cellulare = reader["Cellulare"].ToString();
                    listaClienti.Add(c);
                }
            }
            catch (Exception ex)
            {
                ViewBag.msgerror = ex.Message;
            }
            finally { sql.Close(); }

            return View(listaClienti);
        }


        // MODIFCA CLIENTE

        public ActionResult ModificaCliente(int id)
        {
            SqlConnection sql = Connessioni.GetConnection();
            sql.Open();

            SqlCommand com = Connessioni.GetCommand("SELECT * from CLIENTE where CLIENTE.IdCliente = @IdCliente", sql);
            com.Parameters.AddWithValue("IdCliente", id);
            SqlDataReader reader = com.ExecuteReader();

            Clienti c = new Clienti();

            while (reader.Read())
            {
                c.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                c.Cognome = reader["Cognome"].ToString();
                c.Nome = reader["Nome"].ToString();
                c.CF = reader["CodiceFiscale"].ToString();
                c.Citta = reader["Citta"].ToString();
                c.Provincia = reader["Provincia"].ToString();
                c.Email = reader["Email"].ToString();
                c.Telefono = reader["Telefono"].ToString();
                c.Cellulare = reader["Cellulare"].ToString();

            }
            sql.Close();
            return View(c);
        }

        [HttpPost]
        public ActionResult ModificaCliente(Clienti custom)
        {
            SqlConnection sql = Connessioni.GetConnection();
            sql.Open();

            try
            {

                SqlCommand com = Connessioni.GetCommand("UPDATE CLIENTE set Cognome=@Cognome, Nome=@Nome, CodiceFiscale=@CodiceFiscale, Citta=@Citta, Provincia=@Provincia, Email=@Email, Telefono=@Telefono, Cellulare=@Cellulare" +
                    " where CLIENTE.IdCliente = @IdCliente", sql);

                //com.Parameters.AddWithValue("IdPrenotazione", custom.IdPrenotazione);
                com.Parameters.AddWithValue("IdCliente", custom.IdCliente);
                com.Parameters.AddWithValue("Cognome", custom.Cognome);
                com.Parameters.AddWithValue("Nome", custom.Nome);
                com.Parameters.AddWithValue("CodiceFiscale", custom.CF);
                com.Parameters.AddWithValue("Citta", custom.Citta);
                com.Parameters.AddWithValue("Provincia", custom.Provincia);
                com.Parameters.AddWithValue("Email", custom.Email);
                com.Parameters.AddWithValue("Telefono", custom.Telefono);
                com.Parameters.AddWithValue("Cellulare", custom.Cellulare);



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

            return RedirectToAction("DettagliCliente");
        }

        //DETTAGLI CLIENTE
        public ActionResult DettaglioCliente(int id)
        {
            SqlConnection sql = Connessioni.GetConnection();
            sql.Open();
            Clienti c = new Clienti();

            try
            {
                SqlCommand com = Connessioni.GetCommand("SELECT * from CLIENTE where CLIENTE.IdCliente = @IdCliente", sql);
                com.Parameters.AddWithValue("IdCliente", id);

                SqlDataReader reader = com.ExecuteReader();



                while (reader.Read())
                {

                    c.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    c.Cognome = reader["Cognome"].ToString();
                    c.Nome = reader["Nome"].ToString();
                    c.CF = reader["CodiceFiscale"].ToString();
                    c.Citta = reader["Citta"].ToString();
                    c.Provincia = reader["Provincia"].ToString();
                    c.Email = reader["Email"].ToString();
                    c.Telefono = reader["Telefono"].ToString();
                    c.Cellulare = reader["Cellulare"].ToString();


                }
            }
            catch (Exception ex)
            {
                ViewBag.msgerror = ex.Message;
            }
            finally { sql.Close(); }

            return View(c);
        }

        // CANCELLA CLIENTE

        public ActionResult CancellaCliente(int id)
        {
            SqlConnection sql = Connessioni.GetConnection();
            sql.Open();
            Clienti c = new Clienti();

            try
            {
                SqlCommand com = Connessioni.GetCommand("SELECT * from CLIENTE where CLIENTE.IdCliente = @IdCliente", sql);
                com.Parameters.AddWithValue("IdCliente", id);

                SqlDataReader reader = com.ExecuteReader();



                while (reader.Read())
                {

                    c.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    c.Cognome = reader["Cognome"].ToString();
                    c.Nome = reader["Nome"].ToString();
                    c.CF = reader["CodiceFiscale"].ToString();
                    c.Citta = reader["Citta"].ToString();
                    c.Provincia = reader["Provincia"].ToString();
                    c.Email = reader["Email"].ToString();
                    c.Telefono = reader["Telefono"].ToString();
                    c.Cellulare = reader["Cellulare"].ToString();


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
        public ActionResult CancellaCliente(int id, Prenotazioni p)
        {
            SqlConnection sql = Connessioni.GetConnection();
            sql.Open();


            try
            {
                SqlCommand com = Connessioni.GetCommand("DELETE from CLIENTE  where IdCliente= @IdCliente", sql);
                com.Parameters.AddWithValue("IdCliente", id);

                SqlDataReader reader = com.ExecuteReader();


            }
            catch (Exception ex)
            {
                ViewBag.msgerror = ex.Message;
            }
            finally { sql.Close(); }

            return RedirectToAction("DettagliCliente");
        }

        // CREA CLIENTE

        public ActionResult CreaCliente()
        {
            
            return View();
        }


        [HttpPost]

        public ActionResult CreaCliente(Clienti c)
        {
            SqlConnection sql = Connessioni.GetConnection();
            sql.Open();

            try
            {

                SqlCommand com = Connessioni.GetCommand("INSERT INTO CLIENTE VALUES (@Cognome, @Nome, @CodiceFiscale, @Citta, @Provincia, @Email, @Telefono, @Cellulare, null)", sql);

               
                com.Parameters.AddWithValue("Cognome", c.Cognome);
                com.Parameters.AddWithValue("Nome", c.Nome);
                com.Parameters.AddWithValue("CodiceFiscale", c.CF);
                com.Parameters.AddWithValue("Citta", c.Citta);
                com.Parameters.AddWithValue("Provincia", c.Provincia);
                com.Parameters.AddWithValue("Email", c.Email);
                com.Parameters.AddWithValue("Telefono", c.Telefono);
                com.Parameters.AddWithValue("Cellulare", c.Cellulare);

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

            return RedirectToAction("DettagliCLiente");
        }
    }
}