using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winEventos
{
    public partial class Form1 : Form
    {
        public Form1()
        { 
            InitializeComponent();
            try
            {
                string mensaje = "Inicia Aplixacion";
                anotarMensaje(mensaje, "3", true, false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void anotarMensaje(string mensaje, string tipo, bool log, bool visor)
        {
            try
            {
                eventosLogs evento = new eventosLogs();
                evento.Origen = "winEventos";           //Nombre de la aplicación o servicio que genera el evento
                evento.TipoOrigen = "EjemploEventos";   //Origen del evento (Application/System/Nombre personalizado)
                evento.Evento = "winEventos";           //Nombre del evento a auditar
                evento.Mensaje = mensaje;
                evento.TipoEntrada = tipo;   // 1=Error/2=FailureAudit/3=Information/4=SuccessAudit/5=Warning
                evento.Archivo = "LOGS.log";

                cEventos anotaEvento = new cEventos();

                if (log)
                {
                    string Directorio = ConfigurationManager.AppSettings["Dir"];
                    if (!Directory.Exists(Directorio)) Directory.CreateDirectory(Directorio);

                    anotaEvento.escribirArchivo(evento);
                }

                if (!visor) return;
                
                anotaEvento.escribirMensajeLog(evento);
                listBox1.Items.Add(mensaje);
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
        }
        public void escribirMensajeVisor(string mensaje, string tipo)
        {
            try
            {
                eventosLogs evento = new eventosLogs();
                evento.Origen = "winEventos";           //Nombre de la aplicación o servicio que genera el evento
                evento.TipoOrigen = "EjemploEventos";   //Origen del evento (Application/System/Nombre personalizado)
                evento.Evento = "winEventos";           //Nombre del evento a auditar
                evento.Mensaje = mensaje;
                evento.TipoEntrada = tipo;   // 1=Error/2=FailureAudit/3=Information/4=SuccessAudit/5=Warning
                evento.Archivo = "";

                cEventos anotaEvento = new cEventos();
                //Anota el evento en el visor de sucesos
                anotaEvento.escribirMensajeLog(evento);

                //Añade la anotación en la lista
                listBox1.Items.Add(mensaje);
            }
            catch (Exception)
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = "Mensaje de ejemplo del tipo 'Information'";
                anotarMensaje(mensaje, "3", true, false);
            }
            catch (Exception ex)
            {
                anotarMensaje(ex.Message, "1", true, false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = "Mensaje de ejemplo del tipo 'Warning'";
                anotarMensaje(mensaje, "5", true, false);
            }
            catch (Exception ex)
            {
                anotarMensaje(ex.Message, "1", true, false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = "Mensaje de ejemplo del tipo 'Error'";
                anotarMensaje(mensaje, "1", true, false);
            }
            catch (Exception ex)
            {
                anotarMensaje(ex.Message, "1", true, false);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int c = Convert.ToInt16("pepe");
            }
            catch (Exception ex)
            {
                anotarMensaje(ex.Message, "1", true, false);
            }
        }


    }
}
