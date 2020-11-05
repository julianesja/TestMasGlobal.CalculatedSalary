using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestMasGlobal.CalculatedSalary.Infra.EnumConst.Exceptions
{
    public class ExceptionsManagement : Exception
    {

        private const int CODIGO_ERROR_REGISTROS_ASOCIADOS = 547;


        public ManagementExceptionsTypes Tipo { get; }

        public ExceptionsManagement()
        {
            Tipo = ManagementExceptionsTypes.Generico;
        }


        public ExceptionsManagement(string mensaje) : base(mensaje)
        {
            Tipo = ManagementExceptionsTypes.Generico;
        }


        public ExceptionsManagement(ManagementExceptionsTypes tipoExcepcion, string mensaje) : base(mensaje.Replace("Validation failed", "Validación fallida"))
        {

            Tipo = tipoExcepcion;
        }


        public ExceptionsManagement(ManagementExceptionsTypes tipoExcepcion, List<string> mensajes) : base(string.Join("\r\n", mensajes.Select(r => $"*{r}")))
        {
            Tipo = tipoExcepcion;
        }



        public ExceptionsManagement(ManagementExceptionsTypes tipoExcepcion, string mensaje, Exception innerException) : base(mensaje, innerException)
        {

            Tipo = tipoExcepcion;
        }
    }
}
