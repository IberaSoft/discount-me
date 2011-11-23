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
                    return "Un nombre de usuario para que la direcci�n de correo electr�nico ya existe. Por favor, introduzca otra direcci�n de correo electr�nico.";

                case MembershipCreateStatus.InvalidPassword:
                    return "La contrase�a proporcionada no es v�lida. Por favor, introduzca un valor de contrase�a v�lida.";

                case MembershipCreateStatus.InvalidEmail:
                    return "La direcci�n de correo electr�nico proporcionada no es v�lida. Por favor, compruebe el valor y vuelva a intentarlo.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "La respuesta para recuperar la contrase�a no es v�lida. Por favor, compruebe el valor y vuelva a intentarlo.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "La pregunta para recuperar la contrase�a no es v�lida. Por favor, compruebe el valor y vuelva a intentarlo.";

                case MembershipCreateStatus.InvalidUserName:
                    return "El nombre de usuario proporcionado no es v�lido. Por favor, compruebe el valor y vuelva a intentarlo.";

                case MembershipCreateStatus.ProviderError:
                    return
                        "El proveedor de autenticaci�n devuelto produjo un error. Por favor, verifique su entrada y vuelva a intentarlo. Si el problema persiste, p�ngase en contacto con el administrador del sistema.";

                case MembershipCreateStatus.UserRejected:
                    return
                        "La solicitud de creaci�n de usuario ha sido cancelada. Por favor, verifique su entrada y vuelva a intentarlo. Si el problema persiste, p�ngase en contacto con el administrador del sistema.";

                default:
                    return
                        "Ocurri� un error desconocido. Por favor, verifique su entrada y vuelva a intentarlo. Si el problema persiste, p�ngase en contacto con el administrador del sistema.";
            }
        }
    }
}