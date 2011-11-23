using System.Web.Security;

namespace DiscountMe.Infrastructure {
    public static class ErrorCodes {
        public static string ErrorCodeToString(MembershipCreateStatus createStatus) {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus) {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Nombre de usuario ya existe. Por favor, introduzca un nombre de usuario diferente.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "Un nombre de usuario para que la dirección de correo electrónico ya existe. Por favor, introduzca otra dirección de correo electrónico.";

                case MembershipCreateStatus.InvalidPassword:
                    return "La contraseña proporcionada no es válida. Por favor, introduzca un valor de contraseña válida.";

                case MembershipCreateStatus.InvalidEmail:
                    return "La dirección de correo electrónico proporcionada no es válida. Por favor, compruebe el valor y vuelva a intentarlo.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "La respuesta para recuperar la contraseña no es válida. Por favor, compruebe el valor y vuelva a intentarlo.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "La pregunta para recuperar la contraseña no es válida. Por favor, compruebe el valor y vuelva a intentarlo.";

                case MembershipCreateStatus.InvalidUserName:
                    return "El nombre de usuario proporcionado no es válido. Por favor, compruebe el valor y vuelva a intentarlo.";

                case MembershipCreateStatus.ProviderError:
                    return
                        "El proveedor de autenticación devuelto produjo un error. Por favor, verifique su entrada y vuelva a intentarlo. Si el problema persiste, póngase en contacto con el administrador del sistema.";

                case MembershipCreateStatus.UserRejected:
                    return
                        "La solicitud de creación de usuario ha sido cancelada. Por favor, verifique su entrada y vuelva a intentarlo. Si el problema persiste, póngase en contacto con el administrador del sistema.";

                default:
                    return
                        "Ocurrió un error desconocido. Por favor, verifique su entrada y vuelva a intentarlo. Si el problema persiste, póngase en contacto con el administrador del sistema.";
            }
        }
    }
}