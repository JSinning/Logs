using System;
using System.Diagnostics;

namespace winEventos
{
    /// <summary>
    /// Parámetros para anotar logs de eventos de las aplicaciones
    /// </summary>
    public class eventosLogs
    {
        string origen;
        /// <summary>
        /// Nombre de la aplicación o servicio que genera el evento
        /// </summary>
        public string Origen
        {
            get
            {
                return origen;
            }
            set
            {
                origen = value;
            }
        }

        string tipoOrigen;
        /// <summary>
        /// Tipo de evento a anotar. Posibles opciones (Application / System / nombre personalizado)
        /// </summary>
        public string TipoOrigen
        {
            get
            {
                return tipoOrigen;
            }
            set
            {
                tipoOrigen = value;
            }
        }

        string evento;
        /// <summary>
        /// Nombre del evento a auditar
        /// </summary>
        public string Evento
        {
            get
            {
                return evento;
            }
            set
            {
                evento = value;
            }
        }

        string mensaje;
        /// <summary>
        /// Texto del mensaje a anotar
        /// </summary>
        public string Mensaje
        {
            get
            {
                return mensaje;
            }
            set
            {
                mensaje = value;
            }
        }

        string tipoEntrada;
        /// <summary>
        /// Tipo de entrada para el evento.  Posibles opciones (1=Error/2=FailureAudit/3=Information/4=SuccessAudit/5=Warning)
        /// </summary>
        public string TipoEntrada
        {
            get
            {
                return tipoEntrada;
            }
            set
            {
                tipoEntrada = value;
            }
        }

        string archivo;
        /// <summary>
        /// Archivo de logs en el que hará las anotaciones.  Debe incluir el nombre del archivo con la extensión
        /// </summary>
        public string Archivo
        {
            get
            {
                return archivo;
            }
            set
            {
                archivo = value;
            }
        }


    }
}
