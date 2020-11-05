using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestMasGlobal.CalculatedSalary.Aplications.Interfaces.Dto;
using TestMasGlobal.CalculatedSalary.Infra.EnumConst.Exceptions;

namespace TestMasGlobal.CalculatedSalary.Aplications.Services.Helpers
{
    public static class AplicacionesGenerico
    {
        public static Response<T> Try<T>(Func<T> action)
        {
            var response = new Response<T>();
            try
            {
                response.Entidad = action();
                response.Exitoso = true;
            }
            catch (ExceptionsManagement be)
            {
                AdministrarErrorTry(be, response);
            }
            catch (Exception ex)
            {
                //Core.Logger.Current.Error(ex.Message);
                response.ExcepcionNoControlada = true;
                response.MensajeError = ex.InnerException?.Message ?? ex.Message;
                //response.MensajeError+= ex.InnerException?.StackTrace ?? ex.StackTrace;
            }

            return response;
        }

        public async static Task<Response<T>> TryAsync<T>(Func<Task<T>> action)
        {
            var response = new Response<T>();
            try
            {
                response.Entidad = await action();
                response.Exitoso = true;
            }
            catch (ExceptionsManagement be)
            {
                AdministrarErrorTry(be, response);
            }
            catch (Exception ex)
            {
                //Core.Logger.Current.Error(ex.Message);
                response.ExcepcionNoControlada = true;
                response.MensajeError = ex.InnerException?.Message ?? ex.Message;
                //response.MensajeError+= ex.InnerException?.StackTrace ?? ex.StackTrace;
            }

            return response;
        }

        public static T TryPlano<T>(Func<T> action)
        {

            try
            {
                return action();
            }
            catch (ExceptionsManagement be)
            {
                throw new Exception(be.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static void AdministrarErrorTry<T>(ExceptionsManagement be, Response<T> response)
        {
            response.MensajeError = be.Message;
            response.TipoError = be.Tipo;
            var numeroMensaje = 0;
            var canConvert = int.TryParse(be.Message, out numeroMensaje);
            if (canConvert && be.Tipo == ManagementExceptionsTypes.Validaciones || be.Tipo == ManagementExceptionsTypes.BaseDeDatos
                                                                              || be.Tipo == ManagementExceptionsTypes
                                                                                  .Autenticacion)
            {
                response.CodigoMensajeAlterno = numeroMensaje;
            }
        }
    }
}
