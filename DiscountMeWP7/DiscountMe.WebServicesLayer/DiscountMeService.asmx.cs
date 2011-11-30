using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Services;
using AutoMapper;
using DiscountMe.BL;
using DiscountMe.BL.DTO;
using DiscountMe.Common;
using DiscountMe.DAL;

namespace DiscountMe.WebServicesLayer {
    /// <summary>
    /// Summary description for DiscountMeService
    /// </summary>
    [WebService(Namespace = "http://www.iberasoft.com/webservices")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class DiscountMeService : WebService {
        private IUnitOfWork uow;

        [WebMethod]
        public User Login(string username, string password, string uniqueId) {
            uow = new UnitOfWork();
            var usuario = uow.Users.Lista().SingleOrDefault(u => (u.UserName == username));
            if (usuario != null && usuario.Password == Constantes.EncodePassword(password, usuario.PasswordSalt))
                return usuario;
            return null;
        }

        [WebMethod]
        public List<DiscountCategory> ListaCategorias() {
            uow = new UnitOfWork();
            var lista = uow.DiscountCategories.Lista().OrderBy(dc => dc.Name).ToList();
            return new List<DiscountCategory>(lista);
        }

        [WebMethod]
        public List<DiscountDTO> DescuentosCercanos(double latitud, double longitud, string texto, int rango, DiscountCategory category, string medida) {
            AutoMapperConfiguration.Initialize();
            uow = new UnitOfWork();
            var pos = new GeoZone {Latitude = latitud, Longitude = longitud};
            var lista = uow.Discounts.Consulta(d => d.ProductName.Contains(texto) && d.DiscountCategory.Name == category.Name)
                .Select(Mapper.Map<Discount, DiscountDTO>).ToList();
            var listaDescuentos = DescuentosDentroDeRango(lista, pos, medida, rango);
            return listaDescuentos;
        }

        public List<DiscountDTO> DescuentosDentroDeRango(List<DiscountDTO> lista, GeoZone posicion, string medida, int rango = 100) {
            return (from discountDto in lista let pos = new GeoZone {Latitude = discountDto.Latitude, Longitude = discountDto.Longitude}
                    where DentroDeRango(pos, posicion, 100, medida)
                    select discountDto).ToList();
        }

        private static bool DentroDeRango(GeoZone oferta, GeoZone posicion, int rango, string medida) {
            double distancia = (medida == "Metros") ?
                Haversine.Distance(oferta, posicion, DistanceType.Kilometers)*1000 :
                Haversine.Distance(oferta, posicion, DistanceType.Miles) * 1000;
            return distancia < rango;
        }
    }
}