namespace DiscountMe.DAL.DBContext {
    public class InitTables {
        public static void CreateCountries(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"INSERT INTO Countries (Name) 
                    select 'Argentina' union all
                    select 'Bolivia' union all
                    select 'Brasil' union all
                    select 'Canada' union all
                    select 'Chile' union all
                    select 'Colombia' union all
                    select 'Costa Rica' union all
                    select 'Cuba' union all
                    select 'Ecuador' union all
                    select 'El Salvador' union all
                    select 'España' union all
                    select 'Estados Unidos' union all 
                    select 'Guatemala' union all
                    select 'Honduras' union all
                    select 'Mexico' union all
                    select 'Nicaragua' union all
                    select 'Panama' union all
                    select 'Paraguay' union all 
                    select 'Peru' union all 
                    select 'Uruguay';");
        }

        public static void CreateProvinces(DiscountMeDbContext context) {
            ProvinciasDeArgentina(context);
            ProvinciasDeBolivia(context);
            ProvinciasDeBrasil(context);
            ProvinciasDeCanada(context);
            ProvinciasDeChile(context);
            ProvinciasDeColombia(context);
            ProvinciasDeCostaRica(context);
            ProvinciasDeCuba(context);
            ProvinciasDeEcuador(context);
            ProvinciasDeElSalvador(context);
            ProvinciasDeEspana(context);
            EstadosDeEstadosUnidos(context);
            ProvinciasDeGuatemala(context);
            ProvinciasDeHonduras(context);
            ProvinciasDeMexico(context);
            ProvinciasDeNicaragua(context);
            ProvinciasDePanama(context);
            ProvinciasDeParaguay(context);
            ProvinciasDePeru(context);
            ProinciasDeUruguay(context);
        }

        private static void ProinciasDeUruguay(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Provinces (Name, CountryId)
                select 'Artigas', 20 union all
                select 'Canelones', 20 union all
                select 'Cerro Largo', 20 union all
                select 'Colonia', 20 union all
                select 'Durazno', 20 union all
                select 'Flores', 20 union all
                select 'Florida', 20 union all
                select 'Lavalleja', 20 union all
                select 'Maldonado', 20 union all
                select 'Montevideo', 20 union all
                select 'Paysandu', 20 union all
                select 'Rio Negro', 20 union all
                select 'Rivera', 20 union all
                select 'Rocha', 20 union all
                select 'Salto', 20 union all
                select 'San Jose', 20 union all
                select 'Soriano', 20 union all
                select 'Tacuarembo', 20 union all
                select 'Treinta y Tres', 20;");
        }

        private static void ProvinciasDePeru(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Provinces (Name, CountryId)
                select 'Amazonas', 19 union all
                select 'Ancash', 19 union all
                select 'Apurimac', 19 union all
                select 'Arequipa', 19 union all
                select 'Ayacucho', 19 union all
                select 'Cajamarca', 19 union all
                select 'Callao', 19 union all
                select 'Cusco', 19 union all
                select 'Huancavelica', 19 union all
                select 'Huanuco', 19 union all
                select 'Ica', 19 union all
                select 'Junin', 19 union all
                select 'La Libertad', 19 union all
                select 'Lambayeque', 19 union all
                select 'Lima', 19 union all
                select 'Madre de Dios', 19 union all
                select 'Moquegua', 19 union all
                select 'Pasco', 19 union all
                select 'Piura', 19 union all
                select 'Puno', 19 union all
                select 'San Martin', 19 union all
                select 'Tacna', 19 union all
                select 'Tumbes', 19 union all
                select 'Ucayali', 19;");
        }

        private static void ProvinciasDeParaguay(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Provinces (Name, CountryId)
                select 'Alto Paraguay', 18 union all
                select 'Alto Parana', 18 union all
                select 'Amambay', 18 union all
                select 'Asuncion', 18 union all
                select 'Boqueron', 18 union all
                select 'Caaguazu', 18 union all
                select 'Caazapa', 18 union all
                select 'Canindeyu', 18 union all
                select 'Central', 18 union all
                select 'Concepcion', 18 union all
                select 'Cordillera', 18 union all
                select 'Guaira', 18 union all
                select 'Itapua', 18 union all
                select 'Misiones', 18 union all
                select 'Neembucu', 18 union all
                select 'Paraguari', 18 union all
                select 'Presidente Hayes', 18 union all
                select 'San Pedro', 18;");
        }

        private static void ProvinciasDePanama(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Provinces (Name, CountryId)
                select 'Bocas del Toro', 17 union all
                select 'Chiriqui', 17 union all
                select 'Cocle', 17 union all
                select 'Colon', 17 union all
                select 'Darien', 17 union all
                select 'Herrera', 17 union all
                select 'Los Santos', 17 union all
                select 'Panama', 17 union all
                select 'San Blas', 17 union all
                select 'Kuna Yala', 17 union all
                select 'Veraguas', 17;");
        }

        private static void ProvinciasDeNicaragua(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Provinces (Name, CountryId)
                select 'Atlantico Norte', 16 union all
                select 'Atlantico Sur', 16 union all
                select 'Boaco', 16 union all
                select 'Carazo', 16 union all
                select 'Chinandega', 16 union all
                select 'Chontales', 16 union all
                select 'Esteli', 16 union all
                select 'Granada', 16 union all
                select 'Jinotega', 16 union all
                select 'Leon', 16 union all
                select 'Madriz', 16 union all
                select 'Managua', 16 union all
                select 'Masaya', 16 union all
                select 'Matagalpa', 16 union all
                select 'Nueva Segovia', 16 union all
                select 'Rio San Juan', 16 union all
                select 'Rivas', 16;");
        }

        private static void ProvinciasDeMexico(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Provinces (Name, CountryId)
                select 'Aguascalientes', 15 union all
                select 'Baja California', 15 union all
                select 'Baja California Sur', 15 union all
                select 'Campeche', 15 union all
                select 'Chiapas', 15 union all
                select 'Chihuahua', 15 union all
                select 'Coahuila de Zaragoza', 15 union all
                select 'Colima', 15 union all
                select 'Distrito Federal', 15 union all
                select 'Durango', 15 union all
                select 'Guanajuato', 15 union all
                select 'Guerrero', 15 union all
                select 'Hidalgo', 15 union all
                select 'Jalisco', 15 union all
                select 'Mexico D.F.', 15 union all
                select 'Michoacan de Ocampo', 15 union all
                select 'Morelos', 15 union all
                select 'Nayarit', 15 union all
                select 'Nuevo Leon', 15 union all
                select 'Oaxaca', 15 union all
                select 'Puebla', 15 union all
                select 'Queretaro de Arteaga', 15 union all
                select 'Quintana Roo', 15 union all
                select 'San Luis Potosi', 15 union all
                select 'Sinaloa', 15 union all
                select 'Sonora', 15 union all
                select 'Tabasco', 15 union all
                select 'Tamaulipas', 15 union all
                select 'Tlaxcala', 15 union all
                select 'Veracruz-Llave', 15 union all
                select 'Yucatan', 15 union all
                select 'Zacatecas', 15;");
        }

        private static void ProvinciasDeHonduras(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Provinces (Name, CountryId)
                select 'Atlantida', 14 union all
                select 'Choluteca', 14 union all
                select 'Colon', 14 union all
                select 'Comayagua', 14 union all
                select 'Copan', 14 union all
                select 'Cortes', 14 union all
                select 'El Paraiso', 14 union all
                select 'Francisco Morazan', 14 union all
                select 'Gracias a Dios', 14 union all
                select 'Intibuca', 14 union all
                select 'Islas de la Bahia', 14 union all
                select 'La Paz', 14 union all
                select 'Lempira', 14 union all
                select 'Ocotepeque', 14 union all
                select 'Olancho', 14 union all
                select 'Santa Barbara', 14 union all
                select 'Valle', 14 union all
                select 'Yoro', 14;");
        }

        private static void ProvinciasDeGuatemala(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Provinces (Name, CountryId)
                select 'Alta Verapaz', 13 union all
                select 'Baja Verapaz', 13 union all
                select 'Chimaltenango', 13 union all
                select 'Chiquimula', 13 union all
                select 'El Progreso', 13 union all
                select 'Escuintla', 13 union all
                select 'Guatemala', 13 union all
                select 'Huehuetenango', 13 union all
                select 'Izabal, Jalapa', 13 union all
                select 'Jutiapa', 13 union all
                select 'Peten', 13 union all
                select 'Quetzaltenango', 13 union all
                select 'Quiche', 13 union all
                select 'Retalhuleu', 13 union all
                select 'Sacatepequez', 13 union all
                select 'San Marcos', 13 union all
                select 'Santa Rosa', 13 union all
                select 'Solola', 13 union all
                select 'Suchitepequez', 13 union all
                select 'Totonicapan', 13 union all
                select 'Zacapa', 13;");
        }

        private static void EstadosDeEstadosUnidos(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Provinces (Name, CountryId)
                select 'Alabama', 12 union all
                select 'Alaska', 12 union all
                select 'Arizona', 12 union all
                select 'Arkansas', 12 union all
                select 'California', 12 union all
                select 'Colorado', 12 union all
                select 'Connecticut', 12 union all
                select 'Delaware', 12 union all
                select 'District of Columbia', 12 union all
                select 'Florida', 12 union all
                select 'Georgia', 12 union all
                select 'Hawaii', 12 union all
                select 'Idaho', 12 union all
                select 'Illinois', 12 union all
                select 'Indiana', 12 union all
                select 'Iowa', 12 union all
                select 'Kansas', 12 union all
                select 'Kentucky', 12 union all
                select 'Louisiana', 12 union all
                select 'Maine', 12 union all
                select 'Maryland', 12 union all
                select 'Massachusetts', 12 union all
                select 'Michigan', 12 union all
                select 'Minnesota', 12 union all
                select 'Mississippi', 12 union all
                select 'Missouri', 12 union all
                select 'Montana', 12 union all
                select 'Nebraska', 12 union all
                select 'Nevada', 12 union all
                select 'New Hampshire', 12 union all
                select 'New Jersey', 12 union all
                select 'New Mexico', 12 union all
                select 'New York', 12 union all
                select 'North Carolina', 12 union all
                select 'North Dakota', 12 union all
                select 'Ohio', 12 union all
                select 'Oklahoma', 12 union all
                select 'Oregon', 12 union all
                select 'Puerto Rico', 12 union all
                select 'Pennsylvania', 12 union all
                select 'Rhode Island', 12 union all
                select 'South Carolina', 12 union all
                select 'South Dakota', 12 union all
                select 'Tennessee', 12 union all
                select 'Texas', 12 union all
                select 'Utah', 12 union all
                select 'Vermont', 12 union all
                select 'Virginia', 12 union all
                select 'Washington', 12 union all
                select 'West Virginia', 12 union all
                select 'Wisconsin', 12 union all
                select 'Wyoming', 12;");
        }

        private static void ProvinciasDeElSalvador(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Provinces (Name, CountryId)
                select 'Ahuachapan', 10 union all
                select 'Cabanas', 10 union all
                select 'Chalatenango', 10 union all
                select 'Cuscatlan', 10 union all
                select 'La Libertad', 10 union all
                select 'La Paz', 10 union all
                select 'La Union', 10 union all
                select 'Morazan', 10 union all
                select 'San Miguel', 10 union all
                select 'San Salvador', 10 union all
                select 'Santa Ana', 10 union all
                select 'San Vicente', 10 union all
                select 'Sonsonate', 10 union all
                select 'Usulutan', 10;");
        }

        private static void ProvinciasDeEcuador(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Provinces (Name, CountryId)
                select 'Azuay', 9 union all
                select 'Bolivar', 9 union all
                select 'Canar', 9 union all
                select 'Carchi', 9 union all
                select 'Chimborazo', 9 union all
                select 'Cotopaxi', 9 union all
                select 'El Oro', 9 union all
                select 'Esmeraldas', 9 union all
                select 'Galapagos', 9 union all
                select 'Guayas', 9 union all
                select 'Imbabura', 9 union all
                select 'Loja', 9 union all
                select 'Los Rios', 9 union all
                select 'Manabi', 9 union all
                select 'Morona-Santiago', 9 union all
                select 'Napo', 9 union all
                select 'Orellana', 9 union all
                select 'Pastaza', 9 union all
                select 'Pichincha', 9 union all
                select 'Sucumbios', 9 union all
                select 'Tungurahua', 9 union all
                select 'Zamora-Chinchipe', 9;");
        }

        private static void ProvinciasDeCuba(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Provinces (Name, CountryId)
                select 'Camaguey', 8 union all
                select 'Ciego de Avila', 8 union all
                select 'Cienfuegos', 8 union all
                select 'Ciudad de La Habana', 8 union all
                select 'Granma', 8 union all
                select 'Guantanamo', 8 union all
                select 'Holguin', 8 union all
                select 'Isla de la Juventud', 8 union all
                select 'La Habana', 8 union all
                select 'Las Tunas', 8 union all
                select 'Matanzas', 8 union all
                select 'Pinar del Rio', 8 union all
                select 'Sancti Spiritus', 8 union all
                select 'Santiago de Cuba', 8 union all
                select 'Villa Clara', 8;");
        }

        private static void ProvinciasDeCostaRica(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Provinces (Name, CountryId)
                select 'Alibori', 7 union all
                select 'Atakora', 7 union all
                select 'Atlantique', 7 union all
                select 'Borgou', 7 union all
                select 'Collines', 7 union all
                select 'Kouffo', 7 union all
                select 'Donga', 7 union all
                select 'Littoral', 7 union all
                select 'Mono', 7 union all
                select 'Oueme', 7 union all
                select 'Plateau', 7 union all
                select 'Zou', 7;");
        }

        private static void ProvinciasDeColombia(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Provinces (Name, CountryId)
                select 'Amazonas', 6 union all
                select 'Antioquia', 6 union all
                select 'Arauca', 6 union all
                select 'Atlantico', 6 union all
                select 'Distrito Capital de Bogota', 6 union all
                select 'Bolivar', 6 union all
                select 'Boyaca', 6 union all
                select 'Caldas', 6 union all
                select 'Caqueta', 6 union all
                select 'Casanare', 6 union all
                select 'Cauca', 6 union all
                select 'Cesar', 6 union all
                select 'Choco', 6 union all
                select 'Cordoba', 6 union all
                select 'Cundinamarca', 6 union all
                select 'Guainia', 6 union all
                select 'Guaviare', 6 union all
                select 'Huila', 6 union all
                select 'La Guajira', 6 union all
                select 'Magdalena', 6 union all
                select 'Meta', 6 union all
                select 'Narino', 6 union all
                select 'Norte de Santander', 6 union all
                select 'Putumayo', 6 union all
                select 'Quindio', 6 union all
                select 'Risaralda', 6 union all
                select 'San Andres y Providencia', 6 union all
                select 'Santander', 6 union all
                select 'Sucre', 6 union all
                select 'Tolima', 6 union all
                select 'Valle del Cauca', 6 union all
                select 'Vaupes', 6 union all
                select 'Vichada', 6;");
        }

        private static void ProvinciasDeEspana(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Provinces (Name, CountryId) 
                select 'Álava', 11 union all
                select 'Albacete', 11 union all
                select 'Alicante', 11 union all
                select 'Almería', 11 union all
                select 'Ávila', 11 union all
                select 'Badajoz', 11 union all 
                select 'Baleares (Illes)', 11 union all
                select 'Barcelona', 11 union all
                select 'Burgos', 11 union all
                select 'Cáceres', 11 union all
                select 'Cádiz', 11 union all
                select 'Castellón', 11 union all
                select 'Ciudad Real', 11 union all
                select 'Córdoba', 11 union all
                select 'A Coruña', 11 union all
                select 'Cuenca', 11 union all
                select 'Girona', 11 union all
                select 'Granada', 11 union all
                select 'Guadalajara', 11 union all 
                select 'Guipúzcoa', 11 union all 
                select 'Huelva', 11 union all
                select 'Huesca', 11 union all
                select 'Jaén', 11 union all 
                select 'León', 11 union all
                select 'Lleida', 11 union all
                select 'La Rioja', 11 union all
                select 'Lugo', 11 union all
                select 'Madrid', 11 union all
                select 'Málaga', 11 union all
                select 'Murcia', 11 union all
                select 'Navarra', 11 union all
                select 'Ourense', 11 union all
                select 'Asturias', 11 union all
                select 'Palencia', 11 union all
                select 'La Palma', 11 union all
                select 'Pontevedra', 11 union all
                select 'Salamanca', 11 union all
                select 'Santa Cruz de Tenerife', 11 union all
                select 'Cantabria', 11 union all
                select 'Segovia', 11 union all
                select 'Sevilla', 11 union all
                select 'Soria', 11 union all
                select 'Tarragona', 11 union all
                select 'Teruel', 11 union all
                select 'Toledo', 11 union all
                select 'Valencia', 11 union all
                select 'Valladolid', 11 union all
                select 'Vizcaya', 11 union all
                select 'Zamora', 11 union all
                select 'Zaragoza', 11 union all
                select 'Ceuta', 11 union all
                select 'Melilla', 11;");
        }

        private static void ProvinciasDeArgentina(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Provinces (Name, CountryId) 
                select 'Buenos Aires', 1 union all 
                select 'Capital Federal', 1 union all
                select 'Catamarca', 1 union all
                select 'Chaco', 1 union all 
                select 'Chubut', 1 union all
                select 'Cordoba', 1 union all
                select 'Corrientes', 1 union all
                select 'Entre Rios', 1 union all
                select 'Formosa', 1 union all
                select 'Jujuy', 1 union all
                select 'La Pampa', 1 union all
                select 'La Rioja', 1 union all
                select 'Mendoza', 1 union all
                select 'Misiones', 1 union all
                select 'Neuquen', 1 union all
                select 'Rio Negro', 1 union all
                select 'Salta', 1 union all
                select 'San Juan', 1 union all
                select 'San Luis', 1 union all
                select 'Santa Cruz', 1 union all
                select 'Santa Fe', 1 union all
                select 'Santiago del Estero', 1 union all
                select 'Tierra del Fuego', 1 union all
                select 'Tucuman', 1;");
        }

        private static void ProvinciasDeBolivia(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Provinces (Name, CountryId)
                select 'Chuquisaca', 2 union all
                select 'Cochabamba', 2 union all
                select 'Beni', 2 union all
                select 'La Paz', 2 union all
                select 'Oruro', 2 union all
                select 'Pando', 2 union all
                select 'Potosi', 2 union all
                select 'Santa Cruz', 2 union all
                select 'Tarija', 2;");
        }

        private static void ProvinciasDeBrasil(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Provinces (Name, CountryId)
                select 'Acre', 3 union all
                select 'Alagoas', 3 union all
                select 'Amapa', 3 union all
                select 'Amazonas', 3 union all
                select 'Bahia', 3 union all
                select 'Ceara', 3 union all
                select 'Distrito Federal', 3 union all
                select 'Espirito Santo', 3 union all
                select 'Goias', 3 union all
                select 'Maranhao', 3 union all
                select 'Mato Grosso', 3 union all
                select 'Mato Grosso do Sul', 3 union all
                select 'Minas Gerais', 3 union all
                select 'Para', 3 union all
                select 'Paraiba', 3 union all
                select 'Parana', 3 union all
                select 'Pernambuco', 3 union all
                select 'Piaui', 3 union all
                select 'Rio de Janeiro', 3 union all
                select 'Rio Grande do Norte', 3 union all
                select 'Rio Grande do Sul', 3 union all
                select 'Rondonia', 3 union all
                select 'Roraima', 3 union all
                select 'Santa Catarina', 3 union all
                select 'Sao Paulo', 3 union all
                select 'Sergipe', 3 union all
                select 'Tocantins', 3");
        }

        private static void ProvinciasDeCanada(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Provinces (Name, CountryId)
                select 'Alberta', 4 union all
                select 'British Columbia', 4 union all
                select 'Manitoba', 4 union all
                select 'New Brunswick', 4 union all
                select 'Newfoundland and Labrador', 4 union all
                select 'Northwest Territories', 4 union all
                select 'Nova Scotia', 4 union all
                select 'Nunavut', 4 union all
                select 'Ontario', 4 union all
                select 'Prince Edward Island', 4 union all
                select 'Quebec', 4 union all
                select 'Saskatchewan', 4 union all
                select 'Yukon Territory', 4");
        }

        private static void ProvinciasDeChile(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Provinces (Name, CountryId)
                select 'Antofagasta', 5 union all
                select 'Araucania', 5 union all
                select 'Atacama', 5 union all
                select 'Bio-Bio', 5 union all
                select 'Coquimbo', 5 union all
                select 'Libertador General B.', 5 union all
                select 'Los Lagos', 5 union all
                select 'Magallanes', 5 union all
                select 'Maule', 5 union all
                select 'Santiago', 5 union all
                select 'Tarapaca', 5 union all
                select 'Valparaiso', 5;");
        }

        public static void CreateCities(DiscountMeDbContext context) {
            CiudadesDeAlava(context);
            CiudadesDeAlbacete(context);
            //CiudadesDeAlicante(context);
            CiudadesDeAlmeria(context);
            CiudadesDeAvila(context);
            //CiudadesDeBadajoz(context);
            //CiudadesDeBaleares(context);
            //CiudadesDeBarcelona(context);
            //CiudadesDeBurgos(context);
            //CiudadesDeCaceres(context);
            //CiudadesDeCadiz(context);
            //CiudadesDeCastellon(context);
            //CiudadesDeCiudadReal(context);
            //CiudadesDeCordoba(context);
            //CiudadesDeACoruna(context);
            //CiudadesDeCuenca(context);
            //CiudadesDeGirona(context);
            //CiudadesDeGranada(context);
            //CiudadesDeGuadalajara(context);
            //CiudadesDeGuipuzcoa(context);
            //CiudadesDeHuelva(context);
            //CiudadesDeHuesca(context);
            //CiudadesDeJaen(context);
            //CiudadesDeLeon(context);
            //CiudadesDeLleida(context);
            //CiudadesDeLaRioja(context);
            //CiudadesDeLugo(context);
            //CiudadesDeMadrid(context);
            CiudadesDeMalaga(context);
            //CiudadesDeMurcia(context);
            //CiudadesDeNavarra(context);
            //CiudadesDeOurense(context);
            //CiudadesDeAsturias(context);
            //CiudadesDePalencia(context);
            //CiudadesDeLasPalmas(context);
            //CiudadesDePontevedra(context);
            //CiudadesDeSalamanca(context);
            //CiudadesDeSantaCruzDeTenerife(context);
            //CiudadesDeCantabria(context);
            //CiudadesDeSegovia(context);
            //CiudadesDeSevilla(context);
            //CiudadesDeSoria(context);
            //CiudadesDeTarragona(context);
            //CiudadesDeTeruel(context);
            //CiudadesDeToledo(context);
            //CiudadesDeValencia(context);
            //CiudadesDeValladolid(context);
            //CiudadesDeVizcaya(context);
            //CiudadesDeZamora(context);
            //CiudadesDeZaragoza(context);
            //CiudadesDeCeuta(context);
            //CiudadesDeMelilla(context);
        }

        private static void CiudadesDeCeuta(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeMelilla(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeZaragoza(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeZamora(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeVizcaya(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeValladolid(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeValencia(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeToledo(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeTeruel(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeTarragona(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeSoria(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeSevilla(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeSegovia(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeCantabria(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeSantaCruzDeTenerife(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeSalamanca(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDePontevedra(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeLasPalmas(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDePalencia(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeAsturias(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeOurense(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeNavarra(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeMurcia(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeMadrid(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeLugo(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeLaRioja(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeLleida(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeLeon(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeJaen(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeHuesca(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeHuelva(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeGuipuzcoa(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeGuadalajara(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeGranada(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeGirona(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeCuenca(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeACoruna(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeCordoba(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeCiudadReal(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeCastellon(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeCadiz(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeCaceres(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeBurgos(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeBarcelona(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeBaleares(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeBadajoz(DiscountMeDbContext context) {
            throw new System.NotImplementedException();
        }

        private static void CiudadesDeAvila(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"
                select 186, 'Adanero' union all
                select 186, 'Adrada (La)' union all
                select 186, 'Albornos' union all
                select 186, 'Aldeanueva de Santa Cruz' union all
                select 186, 'Aldeaseca' union all
                select 186, 'Aldehuela (La)' union all
                select 186, 'Amavida' union all
                select 186, 'Arenal (El)' union all
                select 186, 'Arenas de San Pedro' union all
                select 186, 'Arevalillo' union all
                select 186, 'Arévalo' union all
                select 186, 'Aveinte' union all
                select 186, 'Avellaneda' union all
                select 186, 'Ávila' union all
                select 186, 'Barco de Ávila (El)' union all
                select 186, 'Barraco (El)' union all
                select 186, 'Barromán' union all
                select 186, 'Becedas' union all
                select 186, 'Becedillas' union all
                select 186, 'Bercial de Zapardiel' union all
                select 186, 'Berlanas (Las)' union all
                select 186, 'Bernuy-Zapardiel' union all
                select 186, 'Berrocalejo de Aragona' union all
                select 186, 'Blascomillán' union all
                select 186, 'Blasconuño de Matacabras' union all
                select 186, 'Blascosancho' union all
                select 186, 'Bohodón (El)' union all
                select 186, 'Bohoyo' union all
                select 186, 'Bonilla de la Sierra' union all
                select 186, 'Brabos' union all
                select 186, 'Bularros' union all
                select 186, 'Burgohondo' union all
                select 186, 'Cabezas de Alambre' union all
                select 186, 'Cabezas del Pozo' union all
                select 186, 'Cabezas del Villar' union all
                select 186, 'Cabizuela' union all
                select 186, 'Canales' union all
                select 186, 'Candeleda' union all
                select 186, 'Cantiveros' union all
                select 186, 'Cardeñosa' union all
                select 186, 'Carrera (La)' union all
                select 186, 'Casas del Puerto' union all
                select 186, 'Casasola' union all
                select 186, 'Casavieja' union all
                select 186, 'Casillas' union all
                select 186, 'Castellanos de Zapardiel' union all
                select 186, 'Cebreros' union all
                select 186, 'Cepeda la Mora' union all
                select 186, 'Chamartín' union all
                select 186, 'Cillán' union all
                select 186, 'Cisla' union all
                select 186, 'Colilla (La)' union all
                select 186, 'Collado de Contreras' union all
                select 186, 'Collado del Mirón' union all
                select 186, 'Constanzana' union all
                select 186, 'Crespos' union all
                select 186, 'Cuevas del Valle' union all
                select 186, 'Diego del Carpio' union all
                select 186, 'Donjimeno' union all
                select 186, 'Donvidas' union all
                select 186, 'Espinosa de los Caballeros' union all
                select 186, 'Flores de Ávila' union all
                select 186, 'Fontiveros' union all
                select 186, 'Fresnedilla' union all
                select 186, 'Fresno (El)' union all
                select 186, 'Fuente el Saúz' union all
                select 186, 'Fuentes de Año' union all
                select 186, 'Gallegos de Altamiros' union all
                select 186, 'Gallegos de Sobrinos' union all
                select 186, 'Garganta del Villar' union all
                select 186, 'Gavilanes' union all
                select 186, 'Gemuño' union all
                select 186, 'Gil García' union all
                select 186, 'Gilbuena' union all
                select 186, 'Gimialcón' union all
                select 186, 'Gotarrendura' union all
                select 186, 'Grandes y San Martín' union all
                select 186, 'Guisando' union all
                select 186, 'Gutierre-Muñoz' union all
                select 186, 'Hernansancho' union all
                select 186, 'Herradón de Pinares' union all
                select 186, 'Herreros de Suso' union all
                select 186, 'Higuera de las Dueñas' union all
                select 186, 'Hija de Dios (La)' union all
                select 186, 'Horcajada (La)' union all
                select 186, 'Horcajo de las Torres' union all
                select 186, 'Hornillo (El)' union all
                select 186, 'Hoyo de Pinares (El)' union all
                select 186, 'Hoyocasero' union all
                select 186, 'Hoyorredondo' union all
                select 186, 'Hoyos de Miguel Muñoz' union all
                select 186, 'Hoyos del Collado' union all
                select 186, 'Hoyos del Espino' union all
                select 186, 'Hurtumpascual' union all
                select 186, 'Junciana' union all
                select 186, 'Langa' union all
                select 186, 'Lanzahíta' union all
                select 186, 'Llanos de Tormes (Los)' union all
                select 186, 'Losar del Barco (El)' union all
                select 186, 'Madrigal de las Altas Torres' union all
                select 186, 'Maello' union all
                select 186, 'Malpartida de Corneja' union all
                select 186, 'Mamblas' union all
                select 186, 'Mancera de Arriba' union all
                select 186, 'Manjabálago' union all
                select 186, 'Marlín' union all
                select 186, 'Martiherrero' union all
                select 186, 'Martínez' union all
                select 186, 'Mediana de Voltoya' union all
                select 186, 'Medinilla' union all
                select 186, 'Mengamuñoz' union all
                select 186, 'Mesegar de Corneja' union all
                select 186, 'Mijares' union all
                select 186, 'Mingorría' union all
                select 186, 'Mirón (El)' union all
                select 186, 'Mironcillo' union all
                select 186, 'Mirueña de los Infanzones' union all
                select 186, 'Mombeltrán' union all
                select 186, 'Monsalupe' union all
                select 186, 'Moraleja de Matacabras' union all
                select 186, 'Muñana' union all
                select 186, 'Muñico' union all
                select 186, 'Muñogalindo' union all
                select 186, 'Muñogrande' union all
                select 186, 'Muñomer del Peco' union all
                select 186, 'Muñopepe' union all
                select 186, 'Muñosancho' union all
                select 186, 'Muñotello' union all
                select 186, 'Narrillos del Álamo' union all
                select 186, 'Narrillos del Rebollar' union all
                select 186, 'Narros de Saldueña' union all
                select 186, 'Narros del Castillo' union all
                select 186, 'Narros del Puerto' union all
                select 186, 'Nava de Arévalo' union all
                select 186, 'Nava del Barco' union all
                select 186, 'Navacepedilla de Corneja' union all
                select 186, 'Navadijos' union all
                select 186, 'Navaescurial' union all
                select 186, 'Navahondilla' union all
                select 186, 'Navalacruz' union all
                select 186, 'Navalmoral' union all
                select 186, 'Navalonguilla' union all
                select 186, 'Navalosa' union all
                select 186, 'Navalperal de Pinares' union all
                select 186, 'Navalperal de Tormes' union all
                select 186, 'Navaluenga' union all
                select 186, 'Navaquesera' union all
                select 186, 'Navarredonda de Gredos' union all
                select 186, 'Navarredondilla' union all
                select 186, 'Navarrevisca' union all
                select 186, 'Navas del Marqués (Las)' union all
                select 186, 'Navatalgordo' union all
                select 186, 'Navatejares' union all
                select 186, 'Neila de San Miguel' union all
                select 186, 'Niharra' union all
                select 186, 'Ojos-Albos' union all
                select 186, 'Orbita' union all
                select 186, 'Oso (El)' union all
                select 186, 'Padiernos' union all
                select 186, 'Pajares de Adaja' union all
                select 186, 'Palacios de Goda' union all
                select 186, 'Papatrigo' union all
                select 186, 'Parral (El)' union all
                select 186, 'Pascualcobo' union all
                select 186, 'Pedro Bernardo' union all
                select 186, 'Pedro-Rodríguez' union all
                select 186, 'Peguerinos' union all
                select 186, 'Peñalba de Ávila' union all
                select 186, 'Piedrahíta' union all
                select 186, 'Piedralaves' union all
                select 186, 'Poveda' union all
                select 186, 'Poyales del Hoyo' union all
                select 186, 'Pozanco' union all
                select 186, 'Pradosegar' union all
                select 186, 'Puerto Castilla' union all
                select 186, 'Rasueros' union all
                select 186, 'Riocabado' union all
                select 186, 'Riofrío' union all
                select 186, 'Rivilla de Barajas' union all
                select 186, 'Salobral' union all
                select 186, 'Salvadiós' union all
                select 186, 'San Bartolomé de Béjar' union all
                select 186, 'San Bartolomé de Corneja' union all
                select 186, 'San Bartolomé de Pinares' union all
                select 186, 'San Esteban de los Patos' union all
                select 186, 'San Esteban de Zapardiel' union all
                select 186, 'San Esteban del Valle' union all
                select 186, 'San García de Ingelmos' union all
                select 186, 'San Juan de Gredos' union all
                select 186, 'San Juan de la Encinilla' union all
                select 186, 'San Juan de la Nava' union all
                select 186, 'San Juan del Molinillo' union all
                select 186, 'San Juan del Olmo' union all
                select 186, 'San Lorenzo de Tormes' union all
                select 186, 'San Martín de la Vega del Alberche' union all
                select 186, 'San Martín del Pimpollar' union all
                select 186, 'San Miguel de Corneja' union all
                select 186, 'San Miguel de Serrezuela' union all
                select 186, 'San Pascual' union all
                select 186, 'San Pedro del Arroyo' union all
                select 186, 'San Vicente de Arévalo' union all
                select 186, 'Sanchidrián' union all
                select 186, 'Sanchorreja' union all
                select 186, 'Santa Cruz de Pinares' union all
                select 186, 'Santa Cruz del Valle' union all
                select 186, 'Santa María de los Caballeros' union all
                select 186, 'Santa María del Arroyo' union all
                select 186, 'Santa María del Berrocal' union all
                select 186, 'Santa María del Cubillo' union all
                select 186, 'Santa María del Tiétar' union all
                select 186, 'Santiago del Collado' union all
                select 186, 'Santiago del Tormes' union all
                select 186, 'Santo Domingo de las Posadas' union all
                select 186, 'Santo Tomé de Zabarcos' union all
                select 186, 'Serrada (La)' union all
                select 186, 'Serranillos' union all
                select 186, 'Sigeres' union all
                select 186, 'Sinlabajos' union all
                select 186, 'Solana de Ávila' union all
                select 186, 'Solana de Rioalmar' union all
                select 186, 'Solosancho' union all
                select 186, 'Sotalbo' union all
                select 186, 'Sotillo de la Adrada' union all
                select 186, 'Tiemblo (El)' union all
                select 186, 'Tiñosillos' union all
                select 186, 'Tolbaños' union all
                select 186, 'Tormellas' union all
                select 186, 'Tornadizos de Ávila' union all
                select 186, 'Torre (La)' union all
                select 186, 'Tórtoles' union all
                select 186, 'Umbrías' union all
                select 186, 'Vadillo de la Sierra' union all
                select 186, 'Valdecasa' union all
                select 186, 'Vega de Santa María' union all
                select 186, 'Velayos' union all
                select 186, 'Villaflor' union all
                select 186, 'Villafranca de la Sierra' union all
                select 186, 'Villanueva de Ávila' union all
                select 186, 'Villanueva de Gómez' union all
                select 186, 'Villanueva del Aceral' union all
                select 186, 'Villanueva del Campillo' union all
                select 186, 'Villar de Corneja' union all
                select 186, 'Villarejo del Valle' union all
                select 186, 'Villatoro' union all
                select 186, 'Viñegra de Moraña' union all
                select 186, 'Vita' union all
                select 186, 'Zapardiel de la Cañada' union all
                select 186, 'Zapardiel de la Ribera';");
        }

        private static void CiudadesDeAlmeria(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"
                Insert into Cities (ProvinceId, Name)
                select 185, 'Abla' union all
                select 185, 'Abrucena' union all
                select 185, 'Adra' union all
                select 185, 'Albánchez' union all
                select 185, 'Alboloduy' union all
                select 185, 'Albox' union all
                select 185, 'Alcolea' union all
                select 185, 'Alcóntar' union all
                select 185, 'Alcudia de Monteagud' union all
                select 185, 'Alhabia' union all
                select 185, 'Alhama de Almería' union all
                select 185, 'Alicún' union all
                select 185, 'Almería' union all
                select 185, 'Almócita' union all
                select 185, 'Alsodux' union all
                select 185, 'Antas' union all
                select 185, 'Arboleas' union all
                select 185, 'Armuña de Almanzora' union all
                select 185, 'Bacares' union all
                select 185, 'Bayárcal' union all
                select 185, 'Bayarque' union all
                select 185, 'Bédar' union all
                select 185, 'Beires' union all
                select 185, 'Benahadux' union all
                select 185, 'Benitagla' union all
                select 185, 'Benizalón' union all
                select 185, 'Bentarique' union all
                select 185, 'Berja' union all
                select 185, 'Canjáyar' union all
                select 185, 'Cantoria' union all
                select 185, 'Carboneras' union all
                select 185, 'Castro de Filabres' union all
                select 185, 'Chercos' union all
                select 185, 'Chirivel' union all
                select 185, 'Cóbdar' union all
                select 185, 'Cuevas del Almanzora' union all
                select 185, 'Dalías' union all
                select 185, 'Ejido (El)' union all
                select 185, 'Enix' union all
                select 185, 'Felix' union all
                select 185, 'Fines' union all
                select 185, 'Fiñana' union all
                select 185, 'Fondón' union all
                select 185, 'Gádor' union all
                select 185, 'Gallardos (Los)' union all
                select 185, 'Garrucha' union all
                select 185, 'Gérgal' union all
                select 185, 'Huécija' union all
                select 185, 'Huércal de Almería' union all
                select 185, 'Huércal-Overa' union all
                select 185, 'Illar' union all
                select 185, 'Instinción' union all
                select 185, 'Laroya' union all
                select 185, 'Láujar de Andarax' union all
                select 185, 'Líjar' union all
                select 185, 'Lubrín' union all
                select 185, 'Lucainena de las Torres' union all
                select 185, 'Lúcar' union all
                select 185, 'Macael' union all
                select 185, 'María' union all
                select 185, 'Mojácar' union all
                select 185, 'Mojonera (La)' union all
                select 185, 'Nacimiento' union all
                select 185, 'Níjar' union all
                select 185, 'Ohanes' union all
                select 185, 'Olula de Castro' union all
                select 185, 'Olula del Río' union all
                select 185, 'Oria' union all
                select 185, 'Padules' union all
                select 185, 'Partaloa' union all
                select 185, 'Paterna del Río' union all
                select 185, 'Pechina' union all
                select 185, 'Pulpí' union all
                select 185, 'Purchena' union all
                select 185, 'Rágol' union all
                select 185, 'Rioja' union all
                select 185, 'Roquetas de Mar' union all
                select 185, 'Santa Cruz de Marchena' union all
                select 185, 'Santa Fe de Mondújar' union all
                select 185, 'Senés' union all
                select 185, 'Serón' union all
                select 185, 'Sierro' union all
                select 185, 'Somontín' union all
                select 185, 'Sorbas' union all
                select 185, 'Suflí' union all
                select 185, 'Tabernas' union all
                select 185, 'Taberno' union all
                select 185, 'Tahal' union all
                select 185, 'Terque' union all
                select 185, 'Tíjola' union all
                select 185, 'Tres Villas (Las)' union all
                select 185, 'Turre' union all
                select 185, 'Turrillas' union all
                select 185, 'Uleila del Campo' union all
                select 185, 'Urrácal' union all
                select 185, 'Velefique' union all
                select 185, 'Vélez-Blanco' union all
                select 185, 'Vélez-Rubio' union all
                select 185, 'Vera' union all
                select 185, 'Viator' union all
                select 185, 'Vícar' union all
                select 185, 'Zurgena';");
        }

        private static void CiudadesDeAlicante(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Cities(ProvinceId, Name)
                select 184, 'Adsubia' union all
                select 184, 'Agost' union all
                select 184, 'Agres' union all
                select 184, 'Aigües' union all
                select 184, 'Albatera' union all
                select 184, 'Alcalalí' union all
                select 184, 'Alcocer de Planes' union all
                select 184, 'Alcoleja' union all
                select 184, 'Alcoy/Alcoi' union all
                select 184, 'Alfafara' union all
                select 184, 'Alfàs del Pi (L\')' union all
                select 184, 'Algorfa' union all
                select 184, 'Algueña' union all
                select 184, 'Alicante/Alacant' union all
                select 184, 'Almoradí' union all
                select 184, 'Almudaina' union all
                select 184, 'Alqueria d\'Asnar' union all
                select 184, 'Altea' union all
                select 184, 'Aspe' union all
                select 184, 'Balones' union all
                select 184, 'Banyeres de Mariola' union all
                select 184, 'Benasau' union all
                select 184, 'Beneixama' union all
                select 184, 'Benejúzar' union all
                select 184, 'Benferri' union all
                select 184, 'Beniarbeig' union all
                select 184, 'Beniardá' union all
                select 184, 'Beniarrés' union all
                select 184, 'Benidoleig' union all
                select 184, 'Benidorm' union all
                select 184, 'Benifallim' union all
                select 184, 'Benifato' union all
                select 184, 'Benigembla' union all
                select 184, 'Benijófar' union all
                select 184, 'Benilloba' union all
                select 184, 'Benillup' union all
                select 184, 'Benimantell' union all
                select 184, 'Benimarfull' union all
                select 184, 'Benimassot' union all
                select 184, 'Benimeli' union all
                select 184, 'Benissa' union all
                select 184, 'Benitachell/Poble Nou de Benitatxell (El)' union all
                select 184, 'Biar' union all
                select 184, 'Bigastro' union all
                select 184, 'Bolulla' union all
                select 184, 'Busot' union all
                select 184, 'Callosa de Segura' union all
                select 184, 'Callosa d\'En Sarrià' union all
                select 184, 'Calpe/Calp' union all
                select 184, 'Campello (El)' union all
                select 184, 'Campo de Mirra/Camp de Mirra (El)' union all
                select 184, 'Cañada' union all
                select 184, 'Castalla' union all
                select 184, 'Castell de Castells' union all
                select 184, 'Castell de Guadalest (El)' union all
                select 184, 'Catral' union all
                select 184, 'Cocentaina' union all
                select 184, 'Confrides' union all
                select 184, 'Cox' union all
                select 184, 'Crevillent' union all
                select 184, 'Daya Nueva' union all
                select 184, 'Daya Vieja' union all
                select 184, 'Dénia' union all
                select 184, 'Dolores' union all
                select 184, 'Elche/Elx' union all
                select 184, 'Elda' union all
                select 184, 'Facheca' union all
                select 184, 'Famorca' union all
                select 184, 'Finestrat' union all
                select 184, 'Fondó de les Neus (El)' union all
                select 184, 'Formentera del Segura' union all
                select 184, 'Gaianes' union all
                select 184, 'Gata de Gorgos' union all
                select 184, 'Gorga' union all
                select 184, 'Granja de Rocamora' union all
                select 184, 'Guardamar del Segura' union all
                select 184, 'Hondón de los Frailes' union all
                select 184, 'Ibi' union all
                select 184, 'Jacarilla' union all
                select 184, 'Jalón/Xaló' union all
                select 184, 'Jávea/Xàbia' union all
                select 184, 'Jijona/Xixona' union all
                select 184, 'Llíber' union all
                select 184, 'Lorcha/Orxa (L\')' union all
                select 184, 'Millena' union all
                select 184, 'Monforte del Cid' union all
                select 184, 'Monóvar/Monòver' union all
                select 184, 'Montesinos (Los)' union all
                select 184, 'Murla' union all
                select 184, 'Muro de Alcoy' union all
                select 184, 'Mutxamel' union all
                select 184, 'Novelda' union all
                select 184, 'Nucia (La)' union all
                select 184, 'Ondara' union all
                select 184, 'Onil' union all
                select 184, 'Orba' union all
                select 184, 'Orihuela' union all
                select 184, 'Orxeta' union all
                select 184, 'Parcent' union all
                select 184, 'Pedreguer' union all
                select 184, 'Pego' union all
                select 184, 'Penàguila' union all
                select 184, 'Petrer' union all
                select 184, 'Pilar de la Horadada' union all
                select 184, 'Pinós (El)/Pinoso' union all
                select 184, 'Planes' union all
                select 184, 'Poblets (Els)' union all
                select 184, 'Polop' union all
                select 184, 'Quatretondeta' union all
                select 184, 'Rafal' union all
                select 184, 'Ràfol d\'Almúnia (El)' union all
                select 184, 'Redován' union all
                select 184, 'Relleu' union all
                select 184, 'Rojales' union all
                select 184, 'Romana (La)' union all
                select 184, 'Sagra' union all
                select 184, 'Salinas' union all
                select 184, 'San Fulgencio' union all
                select 184, 'San Isidro' union all
                select 184, 'San Miguel de Salinas' union all
                select 184, 'San Vicente del Raspeig/Sant Vicent del Raspeig' union all
                select 184, 'Sanet y Negrals' union all
                select 184, 'Sant Joan d\'Alacant' union all
                select 184, 'Santa Pola' union all
                select 184, 'Sax' union all
                select 184, 'Sella' union all
                select 184, 'Senija' union all
                select 184, 'Tàrbena' union all
                select 184, 'Teulada' union all
                select 184, 'Tibi' union all
                select 184, 'Tollos' union all
                select 184, 'Tormos' union all
                select 184, 'Torremanzanas/Torre de les Maçanes' union all
                select 184, 'Torrevieja' union all
                select 184, 'Vall d\'Alcalà' union all
                select 184, 'Vall de Ebo' union all
                select 184, 'Vall de Gallinera' union all
                select 184, 'Vall de Laguar' union all
                select 184, 'Verger (El)' union all
                select 184, 'Villajoyosa/Vila Joiosa (La)' union all
                select 184, 'Villena';");
        }

        private static void CiudadesDeAlbacete(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Cities (ProvinceId, Name)
                select 183, 'Abengibre' union all
                select 183, 'Alatoz' union all
                select 183, 'Albacete' union all
                select 183, 'Albatana' union all
                select 183, 'Alborea' union all
                select 183, 'Alcadozo' union all
                select 183, 'Alcalá del Júcar' union all
                select 183, 'Alcaraz' union all
                select 183, 'Almansa' union all
                select 183, 'Alpera' union all
                select 183, 'Ayna' union all
                select 183, 'Balazote' union all
                select 183, 'Ballestero (El)' union all
                select 183, 'Balsa de Ves' union all
                select 183, 'Barrax' union all
                select 183, 'Bienservida' union all
                select 183, 'Bogarra' union all
                select 183, 'Bonete' union all
                select 183, 'Bonillo (El)' union all
                select 183, 'Carcelén' union all
                select 183, 'Casas de Juan Núñez' union all
                select 183, 'Casas de Lázaro' union all
                select 183, 'Casas de Ves' union all
                select 183, 'Casas-Ibáñez' union all
                select 183, 'Caudete' union all
                select 183, 'Cenizate' union all
                select 183, 'Chinchilla de Monte-Aragón' union all
                select 183, 'Corral-Rubio' union all
                select 183, 'Cotillas' union all
                select 183, 'Elche de la Sierra' union all
                select 183, 'Férez' union all
                select 183, 'Fuensanta' union all
                select 183, 'Fuente-Álamo' union all
                select 183, 'Fuentealbilla' union all
                select 183, 'Gineta (La)' union all
                select 183, 'Golosalvo' union all
                select 183, 'Hellín' union all
                select 183, 'Herrera (La)' union all
                select 183, 'Higueruela' union all
                select 183, 'Hoya-Gonzalo' union all
                select 183, 'Jorquera' union all
                select 183, 'Letur' union all
                select 183, 'Lezuza' union all
                select 183, 'Liétor' union all
                select 183, 'Madrigueras' union all
                select 183, 'Mahora' union all
                select 183, 'Masegoso' union all
                select 183, 'Minaya' union all
                select 183, 'Molinicos' union all
                select 183, 'Montalvos' union all
                select 183, 'Montealegre del Castillo' union all
                select 183, 'Motilleja' union all
                select 183, 'Munera' union all
                select 183, 'Navas de Jorquera' union all
                select 183, 'Nerpio' union all
                select 183, 'Ontur' union all
                select 183, 'Ossa de Montiel' union all
                select 183, 'Paterna del Madera' union all
                select 183, 'Peñas de San Pedro' union all
                select 183, 'Peñascosa' union all
                select 183, 'Pétrola' union all
                select 183, 'Povedilla' union all
                select 183, 'Pozo Cañada' union all
                select 183, 'Pozohondo' union all
                select 183, 'Pozo-Lorente' union all
                select 183, 'Pozuelo' union all
                select 183, 'Recueja (La)' union all
                select 183, 'Riópar' union all
                select 183, 'Robledo' union all
                select 183, 'Roda (La)' union all
                select 183, 'Salobre' union all
                select 183, 'San Pedro' union all
                select 183, 'Socovos' union all
                select 183, 'Tarazona de la Mancha' union all
                select 183, 'Tobarra' union all
                select 183, 'Valdeganga' union all
                select 183, 'Vianos' union all
                select 183, 'Villa de Ves' union all
                select 183, 'Villalgordo del Júcar' union all
                select 183, 'Villamalea' union all
                select 183, 'Villapalacios' union all
                select 183, 'Villarrobledo' union all
                select 183, 'Villatoya' union all
                select 183, 'Villavaliente' union all
                select 183, 'Villaverde de Guadalimar' union all
                select 183, 'Viveros' union all
                select 183, 'Yeste';");
        }

        private static void CiudadesDeAlava(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"INSERT INTO Cities (ProvinceId, Name)
                select 182, 'Alegría-Dulantzi' union all
                select 182, 'Amurrio' union all
                select 182, 'Añana' union all
                select 182, 'Aramaio' union all
                select 182, 'Armiñón' union all
                select 182, 'Arraia-Maeztu' union all
                select 182, 'Arrazua-Ubarrundia' union all
                select 182, 'Artziniega' union all
                select 182, 'Asparrena' union all
                select 182, 'Ayala/Aiara' union all
                select 182, 'Baños de Ebro/Mañueta' union all
                select 182, 'Alegría-Dulantzi' union all
                select 182, 'Amurrio' union all
                select 182, 'Añana' union all
                select 182, 'Aramaio' union all
                select 182, 'Armiñón' union all
                select 182, 'Arraia-Maeztu' union all
                select 182, 'Arrazua-Ubarrundia' union all
                select 182, 'Artziniega' union all
                select 182, 'Asparrena' union all
                select 182, 'Ayala/Aiara' union all
                select 182, 'Baños de Ebro/Mañueta' union all
                select 182, 'Barrundia' union all
                select 182, 'Berantevilla' union all
                select 182, 'Bernedo' union all
                select 182, 'Campezo/Kanpezu' union all
                select 182, 'Elburgo/Burgelu' union all
                select 182, 'Elciego' union all
                select 182, 'Elvillar/Bilar' union all
                select 182, 'Harana/Valle de Arana' union all
                select 182, 'Iruña Oka/Iruña de Oca' union all
                select 182, 'Iruraiz-Gauna' union all
                select 182, 'Kripan' union all
                select 182, 'Kuartango' union all
                select 182, 'Labastida/Bastida' union all
                select 182, 'Lagrán' union all
                select 182, 'Laguardia' union all
                select 182, 'Lanciego/Lantziego' union all
                select 182, 'Lantarón' union all
                select 182, 'Lapuebla de Labarca' union all
                select 182, 'Laudio/Llodio' union all
                select 182, 'Legutiano' union all
                select 182, 'Leza' union all
                select 182, 'Moreda de Álava' union all
                select 182, 'Navaridas' union all
                select 182, 'Okondo' union all
                select 182, 'Oyón-Oion' union all
                select 182, 'Peñacerrada-Urizaharra' union all
                select 182, 'Ribera Alta' union all
                select 182, 'Ribera Baja/Erribera Beitia' union all
                select 182, 'Salvatierra/Agurain' union all
                select 182, 'Samaniego' union all
                select 182, 'San Millán/Donemiliaga' union all
                select 182, 'Urkabustaiz' union all
                select 182, 'Valdegovía/Gaubea' union all
                select 182, 'Villabuena de Álava/Eskuernaga' union all
                select 182, 'Vitoria-Gasteiz' union all
                select 182, 'Yécora/Iekora' union all
                select 182, 'Zalduondo' union all
                select 182, 'Zambrana' union all
                select 182, 'Zigoitia' union all
                select 182, 'Zuia';");
        }

        private static void CiudadesDeMalaga(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Cities (Name, ProvinceId)
                select 'Alameda', 210 union all
                select 'Alcaucín', 210 union all
                select 'Alfarnate', 210 union all
                select 'Alfarnatejo', 210 union all
                select 'Algarrobo', 210 union all
                select 'Algatocín', 210 union all
                select 'Alhaurín de la Torre', 210 union all
                select 'Alhaurín el Grande', 210 union all
                select 'Almáchar', 210 union all
                select 'Almargen', 210 union all
                select 'Almogía', 210 union all
                select 'Álora', 210 union all
                select 'Alozaina', 210 union all
                select 'Alpandeire', 210 union all
                select 'Antequera', 210 union all
                select 'Árchez', 210 union all
                select 'Archidona', 210 union all
                select 'Ardales', 210 union all
                select 'Arenas', 210 union all
                select 'Arriate', 210 union all
                select 'Atajate', 210 union all
                select 'Benadalid', 210 union all
                select 'Benahavís', 210 union all
                select 'Benalauría', 210 union all
                select 'Benalmádena', 210 union all
                select 'Benamargosa', 210 union all
                select 'Benamocarra', 210 union all
                select 'Benaoján', 210 union all
                select 'Benarrabá', 210 union all
                select 'Borge (El)', 210 union all
                select 'Burgo (El)', 210 union all
                select 'Campanillas', 210 union all
                select 'Campillos', 210 union all
                select 'Canillas de Aceituno', 210 union all
                select 'Canillas de Albaida', 210 union all
                select 'Cañete la Real', 210 union all
                select 'Carratraca', 210 union all
                select 'Cartajima', 210 union all
                select 'Cártama', 210 union all
                select 'Casabermeja', 210 union all
                select 'Casarabonela', 210 union all
                select 'Casares', 210 union all
                select 'Coín', 210 union all
                select 'Colmenar', 210 union all
                select 'Comares', 210 union all
                select 'Cómpeta', 210 union all
                select 'Cortes de la Frontera', 210 union all
                select 'Cuevas Bajas', 210 union all
                select 'Cuevas de San Marcos', 210 union all
                select 'Cuevas del Becerro', 210 union all
                select 'Cútar', 210 union all
                select 'Estepona', 210 union all
                select 'Faraján', 210 union all
                select 'Frigiliana', 210 union all
                select 'Fuengirola', 210 union all
                select 'Fuente de Piedra', 210 union all
                select 'Gaucín', 210 union all
                select 'Genalguacil', 210 union all
                select 'Guaro', 210 union all
                select 'Humilladero', 210 union all
                select 'Igualeja', 210 union all
                select 'Istán', 210 union all
                select 'Iznate', 210 union all
                select 'Jimera de Líbar', 210 union all
                select 'Jubrique', 210 union all
                select 'Júzcar', 210 union all
                select 'Macharaviaya', 210 union all
                select 'Málaga', 210 union all
                select 'Manilva', 210 union all
                select 'Marbella', 210 union all
                select 'Mijas', 210 union all
                select 'Moclinejo', 210 union all
                select 'Mollina', 210 union all
                select 'Monda', 210 union all
                select 'Montejaque', 210 union all
                select 'Nerja', 210 union all
                select 'Ojén', 210 union all
                select 'Parauta', 210 union all
                select 'Periana', 210 union all
                select 'Pizarra', 210 union all
                select 'Pujerra', 210 union all
                select 'Rincón de la Victoria', 210 union all
                select 'Riogordo', 210 union all
                select 'Ronda', 210 union all
                select 'Salares', 210 union all
                select 'Sayalonga', 210 union all
                select 'Sedella', 210 union all
                select 'Sierra de Yeguas', 210 union all
                select 'Teba', 210 union all
                select 'Tolox', 210 union all
                select 'Torremolinos', 210 union all
                select 'Torrox', 210 union all
                select 'Totalán', 210 union all
                select 'Valle de Abdalajís', 210 union all
                select 'Vélez-Málaga', 210 union all
                select 'Villanueva de Algaidas', 210 union all
                select 'Villanueva de Tapia', 210 union all
                select 'Villanueva del Rosario', 210 union all
                select 'Villanueva del Trabuco', 210 union all
                select 'Viñuela', 210 union all
                select 'Yunquera', 210;");
        }

        public static void CreateDiscountCategories(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into DiscountCategories (Name, Description)
                select 'Motor', 'Descuentos relativos a motor' union all
                select 'Inmobiliaria', 'Descuentos inmobiliarios' union all
                select 'Libros', 'Descuentos en libros' union all
                select 'Música', 'Descuentos en música' union all
                select 'Cine', 'Descuentos en productos de cine' union all
                select 'Cursos', 'Descuentos en cursos' union all
                select 'Servicios', 'Descuentos en diversos servicios' union all
                select 'Informática', 'Descuentos en productos informáticos' union all
                select 'Imagen y sonido', 'Descuentos en productos relacionados con la imagen y el sonido' union all
                select 'Electrónica', 'Descuentos en productos electrónicos' union all
                select 'Telefonía', 'Descuentos en productos de telefonía' union all
                select 'Juegos', 'Descuentos en productos relacionados con los videojuegos' union all
                select 'Casa y jardín', 'Descuentos en productos para la casa' union all
                select 'Moda y complementos', 'Descuentos relacionados con la moda y los complementos' union all
                select 'Deportes', 'Descuentos relacionados con actividades deportivas' union all
                select 'Bares y restaurantes', 'Descuentos en bares y restaurantes' union all
                select 'Hoteles', 'Descuentos en hoteles' union all
                select 'Viajes', 'Descuentos en viajes' union all
                select 'Mascotas', 'Descuentos en productos para las mascotas' union all
                select 'Náutica', 'Descuentos en productos náuticos';");
        }

        public static void CreateFakeMapPositions(DiscountMeDbContext context) {
            //            context.Database.ExecuteSqlCommand(@"Insert into GeoZones (Latitude , Longitude)
            //                select 36.717574, -4.445043;");
        }

        public static void CreateFakeAddress(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Addresses (Street, PostalCode, CityId)
                select 'c/ Prueba 1', '29010', 67;");
        }

        public static void CreateFakeAdvertiser(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Advertisers (Name, Surname, UserName, Website,
                CompanyName, Description, Cif, PrimaryPhone, PrimaryFax, Email, Comment, Password, PasswordSalt,
                CreateDate, LastModifiedDate, LastLoginDate, LastLoginIp, IsActivated, IsLockedOut, LastLockedOutDate,
                NewPasswordKey, NewPasswordRequestedDate, NewEmailKey, Latitude, Longitude, AddressId) 
                select 'Juan', 'García', 'jgarcia', null, 'Juan Garcia y asociados', null, 'A38928347', '952222222', null, 'jgarcia@gmail.com',
                null, 'F626D6FC44F6E3E5A6119D4CA9CD36710DAF2ABE', 'vc61paN92dqrrPnjFstHM5h0C6z4ZMmc4KeQbA9Mm8c=',
                '20111023 0:0:0', '20111023 0:0:0', '20111023 0:0:0', null, 1, 0, null, null, null, null, 0, 0, 1;");
        }

        public static void CreateRoles(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(@"Insert into Roles (RoleName, Description)
                select 'Administrator', 'Administrator role' union all
                select 'Advertiser', 'Advertiser role' union all
                select 'BasicUser', 'Basic user role';");
        }

        public static void CreateFakeDiscounts(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into Discounts (ProductName, Description, Price, DiscountPercent, StockQuantity, StockWarningLevel, FromDate,
                UntilDate, IsPublished, Comment, AdvertiserId ,DiscountCategoryId) 
                select 'Zapatos', 'Zapatos tacón alto', 25, 5, 100, 10, '20111023 0:0:0', null, 1, null, 1, 14;");
        }

        public static void CreateFakeUsers(DiscountMeDbContext context) {
            context.Database.ExecuteSqlCommand(
                @"Insert into User (Name, Surname, UserName, Password, Email, PasswordSalt, CreateDate, LastModifiedDate, LastLoginDate,
                LastLoginIp, IsActivated, IsLockedOut, LastLockedOutDate, NewPasswordKey, NewPasswordRequestedDate, NewEmailKey) 
                select 'Sergio', 'Sanchez', 'sergio', 'uWqyVAYcpYhX+AXfG5gK6hHzVMs=', 'sergio@gmail.com', 'caAp79UTxM456eXlNk2lQuhopPN+kY1+VFiBvJF+3Ek=', '2012-04-11 19:59:24.647', '2012-04-11 19:59:24.650', null, False, False, '2012-04-11 19:59:24.647', null, '2012-04-11 19:59:24.650', '6fc70c0c-7228-4306-ab4d-4b1228f1b6cb' union all
                select 'Maria', 'Fernandez', 'maria', 'zwnfoIenDSiEYg3zuD008XR12A0=', 'maria@gmail.com', 'aGHokSlj57TSuFFJxHlqQi10wevDzsTrsYPg3N+wtjU=', '2012-04-11 22:08:51.563', '2012-04-11 22:08:51.563', null, False, False, '2012-04-11 22:08:51.563', null, '2012-04-11 22:08:51.563', 'fca1d207-8319-469c-ba57-f361afa9056a' union all
                select 'Jose', 'Lopez', 'jose', 'uWqyVAYcpYhX+AXfG5gK6hHzVMs=', 'jose@gmail.com', 'caAp79UTxM456eXlNk2lQuhopPN+kY1+VFiBvJF+3Ek=', '2012-04-12 19:59:24.647', '2012-04-12 19:59:24.650', null, False, False, '2012-04-12 19:59:24.647', null, '2012-04-12 19:59:24.650', '6fc70c0c-7228-4306-ab4d-4b1228f1b6cb'
                ;");
        }
    }
}