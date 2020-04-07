using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace winEventos
{
    public class cEventos
    {
        /// <summary>
        /// Métodos para anotar logs de eventos de las aplicaciones
        /// </summary>
        public void escribirMensajeLog(eventosLogs evento)
        {
            try
            {
                EventLog miLog = new EventLog(evento.TipoOrigen, ".", evento.Origen);
                //Comprobamos si existe el registro de sucesos
                if (!EventLog.SourceExists(evento.Origen))
                {
                    //Si no existe el registro de sucesos, lo creamos
                    EventLog.CreateEventSource(evento.Origen, evento.TipoOrigen);
                }
                else
                {
                    // Recupera el registro de sucesos correspondiente del origen.
                    evento.TipoOrigen = EventLog.LogNameFromSourceName(evento.Origen, ".");
                }

                miLog.Source = evento.Origen;
                miLog.Log = evento.TipoOrigen;

                //Comprobamos el tipo de anotación y grabamos el evento
                switch (evento.TipoEntrada)
                {
                    case "1":
                        miLog.WriteEntry(evento.Mensaje, EventLogEntryType.Error);
                        break;
                    case "2":
                        miLog.WriteEntry(evento.Mensaje, EventLogEntryType.FailureAudit);
                        break;
                    case "3":
                        miLog.WriteEntry(evento.Mensaje, EventLogEntryType.Information);
                        break;
                    case "4":
                        miLog.WriteEntry(evento.Mensaje, EventLogEntryType.SuccessAudit);
                        break;
                    case "5":
                        miLog.WriteEntry(evento.Mensaje, EventLogEntryType.Warning);
                         break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
         public void escribirArchivo(eventosLogs eventos)
        {
            try
            {
                string Directorio = ConfigurationManager.AppSettings["Dir"];
                Trace.Listeners.Add(new TextWriterTraceListener(Directorio + @"\" + eventos.Archivo));
                Trace.AutoFlush = true;
                Trace.Indent();
                string cadena = Environment.NewLine + DateTime.Now.ToLocalTime().ToString();
                Trace.WriteLine(cadena + eventos.Mensaje);
                Trace.Unindent();
                Trace.Close();
                foreach (string item in Directory.GetFiles(Path.GetFileName(eventos.Archivo)))
                {
                    if (item != eventos.Archivo) File.Delete(item);

                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
        }

         
    }
}
