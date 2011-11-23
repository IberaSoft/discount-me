using System;
using System.Globalization;
using System.Text.RegularExpressions;
using FluentValidation;

namespace DiscountMe.BL {
    public class AdvertiserValidator : AbstractValidator<Advertiser> {
        public AdvertiserValidator() {
            RuleFor(ad => ad.Name).NotEmpty().WithMessage("El nombre no puede estar vac�o");
            RuleFor(ad => ad.Surname).NotEmpty().WithMessage("El apellido no puede estar vac�o");
            RuleFor(ad => ad.Latitude).NotNull().WithMessage("Elija su posici�n en el mapa");
            RuleFor(ad => ad.Longitude).NotNull().WithMessage("Elija su posici�n en el mapa");
            RuleFor(ad => ad.CompanyName).NotEmpty().WithMessage("El nombre de la empresa no puede estar vac�o");
            RuleFor(ad => ad.UserName).NotEmpty().WithMessage("El nombre de usuario no puede estar vac�o");
            RuleFor(ad => ad.PrimaryPhone).NotEmpty().WithMessage("El tel�fono no puede estar vac�o")
                .Must(telefono => BeAValidPhoneNumber(telefono) && IsNumeric(telefono))
                .When(cliente => !string.IsNullOrWhiteSpace(cliente.PrimaryPhone)).WithMessage("Introduzca un n�mero de tel�fono v�lido");
            RuleFor(ad => ad.Cif).NotEmpty().WithMessage("El CIF no puede estar vac�o")
                .Must(cif => CifValido(cif) || VerificarNif(cif)).WithMessage("El CIF indicado no es v�lido");
            RuleFor(ad => ad.Email).NotEmpty().WithMessage("El email no puede estar vac�o")
                .EmailAddress().WithMessage("La direcci�n de email no es v�lida");
            RuleFor(ad => ad.Password).NotEmpty().WithMessage("La contrase�a no puede estar vac�a")
                .Length(8, 200).WithMessage("La contrase�a debe contener al menos 8 caracteres");
        }

        /// <summary>
        /// Funcion que valida un CIF
        /// </summary>
        /// <param name="numero">El numero del CIF a validar</param>
        /// <returns>True si el CIF es correcto</returns>
        public bool CifValido(string numero) {
            if (string.IsNullOrEmpty(numero) || numero.Length != 9)
                return false;
            //Valida el cif actual
            string[] letrasCodigo = { "J", "A", "B", "C", "D", "E", "F", "G", "H", "I" };

            string letraInicial = numero[0].ToString();
            string digitoControl = numero[numero.Length - 1].ToString();
            string n = numero.Substring(1, numero.Length - 2);
            int sumaPares = 0;
            int sumaImpares = 0;
            int sumaTotal = 0;
            int i;
            bool retVal;

            // Recorrido por todos los d�gitos del n�mero
            // Recorrido por todos los d�gitos del n�mero
            for (i = 0; i < n.Length; i++) {
                int aux;
                int.TryParse(n[i].ToString(), out aux);
                if ((i + 1) % 2 == 0) {
                    // Si es una posici�n par, se suman los d�gitos
                    sumaPares += aux;
                }
                else {
                    // Si es una posici�n impar, se multiplican los d�gitos por 2
                    aux = aux * 2;
                    // se suman los d�gitos de la suma
                    sumaImpares += SumaDigitos(aux);
                }
            }
            // Se suman los resultados de los n�meros pares e impares
            sumaTotal += sumaPares + sumaImpares;
            // Se obtiene el d�gito de las unidades
            int unidades = sumaTotal % 10;
            // Si las unidades son distintas de 0, se restan de 10
            if (unidades != 0)
                unidades = 10 - unidades;
            switch (letraInicial) {
                // S�lo n�meros
                case "A":
                case "B":
                case "E":
                case "H":
                    retVal = digitoControl == unidades.ToString();
                    break;
                // S�lo letras
                case "K":
                case "P":
                case "Q":
                case "S":
                    retVal = digitoControl == letrasCodigo[unidades];
                    break;
                default:
                    retVal = (digitoControl == unidades.ToString()) || (digitoControl == letrasCodigo[unidades]);
                    break;
            }
            return retVal;
        }

        private int SumaDigitos(int digitos) {
            string sNumero = digitos.ToString();
            int suma = 0;
            for (var i = 0; i < sNumero.Length; i++) {
                int aux;
                int.TryParse(sNumero[i].ToString(), out aux);
                suma += aux;
            }
            return suma;
        }

        /// <summary>
        /// Comprueba si es un NIF v�lido
        /// No usar espacios ni separadores para la letra
        /// Devuelve True si es correcto
        /// </summary>
        /// <remarks>Adaptado de un c�digo de SGF</remarks>
        public bool VerificarNif(string valor) {
            if (string.IsNullOrEmpty(valor) || valor.Length != 9)
                return false;
            valor = valor.ToUpper(); // ponemos la letra en may�scula
            var numero = valor.Substring(0, valor.Length - 1);
            string letra;
            if (numero.Length >= 7 && IsNumeric(numero)) {
                letra = CalculaNif(numero).ToString(); // calculamos la letra del NIF para comparar con la que tenemos
                if (letra == "0")
                    return false;
            }
            else {
                return false;
            }
            return valor == numero + letra;
        }

        /// <summary> Genera la letra correspondiente a un DNI. </summary>
        /// <param name="dni"> DNI a procesar. </param>
        /// <returns> Letra correspondiente al DNI. </returns>
        public char CalculaNif(string dni) {
            const string correspondencia = "TRWAGMYFPDXBNJZSQVHLCKE";

            int n;
            if ((dni == null) || (dni.Length != 8) || (!int.TryParse(dni.Substring(0, 8), out n))) {
                return '0';
            }
            return correspondencia[n % 23];
        }

        public bool IsNumeric(string numero) {
            double retNum;

            bool isNum = Double.TryParse(Convert.ToString(numero), NumberStyles.Any, NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        public bool BeAValidPhoneNumber(string telefono) {
            return !string.IsNullOrWhiteSpace(telefono) && Regex.Match(telefono, @"^(9|[6-7])[0-9]{8}$").Success;
        }
    }
}