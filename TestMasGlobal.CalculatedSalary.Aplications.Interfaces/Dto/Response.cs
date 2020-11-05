using TestMasGlobal.CalculatedSalary.Infra.EnumConst.Exceptions;

namespace TestMasGlobal.CalculatedSalary.Aplications.Interfaces.Dto
{
    public class Response<TEntidad>
    {
        public TEntidad Entidad { get; set; }
        public bool Exitoso { get; set; }
        public bool ExcepcionNoControlada { get; set; }
        public string MensajeError { get; set; }
        public int? CodigoMensajeAlterno { get; set; }
        public ManagementExceptionsTypes TipoError { get; set; }

        public Response()
        {
            Exitoso = false;
        }
    }
}
