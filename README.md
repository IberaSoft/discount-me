<p align="center">
  <img src="/Assets/discount-me-web.png" title="Discount Me">
</p>

# Discount Me

> Aplicación para móviles con sistema operativo Windows Phone que permite a los usuarios buscar descuentos en productos y/o servicios cercanos a su posición geográfica.

## Requisitos Necesarios

- **Sistema Operativo:** Windows 7
- **Herramientas:** [Visual Studio 2010](http://go.microsoft.com/?linkid=9709969), [MS SQL 2012 Express](http://www.microsoft.com/betaexperience/pd/SQLEXPCTAV2/enus/default.aspx).
- **Framework:** Framework 4.0
- **Windows Phone SDK:** [Windows Phone 7.1](http://download.microsoft.com/download/6/E/7/6E795194-EE2D-4636-AEBD-D1C42D2E06E1/WPSDKv71_en1.iso) (Opcionalmente se puede actualizar a la [versión 7.1.1](http://download.microsoft.com/download/5/6/C/56C12272-31DA-44CD-BBA3-603AA47FE564/WPSDK-7.1.1-KB2669191-x86.exe) para comprobar su funcionamiento en dispositivos de baja gama)
- **Microsoft Silverlight Toolkit (Nov 2011):** [Versión para Windows Phone](http://silverlight.codeplex.com/releases/view/75888).
- **ASP.**** NET MVC 3 Tools:** [Framework](http://www.microsoft.com/download/en/details.aspx?displaylang=en&amp;id=1491).
- **NuGet:** Repositorio de paquetes de librerías (Incluido en la instalación del framework de ASP.NET MVC3).
- [**AutoMapper**](http://nuget.org/packages/automapper) **:** Mapeador de objetos.
- [**BindableAppBar**](http://blogs.microsoft.co.il/blogs/tomershamam/archive/2011/08/22/windows-phone-enhanced-application-bar-or-bindable-appbar-part-i.aspx): Control que sustituye la ApplicationBar del SDK de Windows Phone y que permite enlaces a datos en sus propiedades.
- [**Prism**](http://compositewpf.codeplex.com/releases/view/75760#DownloadId=296865) **(Oct 26 2011)****:** Librería de patrones y buenas prácticas de Microsoft en su versión para Windows Phone (Requerido por cierta funcionalidad del componente BindableAppBar anterior).

**Tecnologías:** [ASP.NET MVC 3 (razor)](http://www.microsoft.com/download/en/details.aspx?displaylang=en&amp;id=1491), ADO.NET Entity Framework 4.3.1, [Fluent Validation 3.](http://fluentvalidation.codeplex.com/)2, [Structure Map](http://nuget.org/packages/structuremap/2.6.3) (DI/IoC), jQuery 1.7.1, jQuery UI, 1.8.18, JavaScript, Bing Maps AJAX Control v7.0 ISDK y Bing Maps REST Services (para la conversión de las coordenadas geográficas a direcciones físicas).

### Razones de utilización de las tecnologias propuestas

**ASP.NET MVC 3 con motor Razor:**

- Clara separación de responsabilidades entre interfaz, lógica de negocio y de control, que además provoca parte de las ventajas siguientes.
- Facilidad para la realización de pruebas unitarias de los componentes, así como de aplicar desarrollo guiado por pruebas (TDD o Test Driven Development).
- Simplicidad en el desarrollo y mantenimiento de los sistemas.
- Reutilización de los componentes.
- Facilidad para desarrollar prototipos rápidos.
- Sencillez para crear distintas representaciones de los mismos datos.
- Los sistemas son muy eficientes, y a la postre más escalables.

**ADO.NET Entity Framework 4.3.1:**

Las razón principal por la que nos hemos decidido por esta tecnología es que permite crear un modelo de clases POCO (Plain Old CLR Object) a partir del cual se puede generar una base de datos y/o mapear dichas clases a una base de datos existente.

La ventaja de usar clases POCO es que el modelo de clases es más limpio y las clases no tienen dependencia con EntityFramework (como sucede cuando las entidades heredan de EntityObject, implementan ciertas interfaces y contienen atributos).

De entre las posibles variantes para generar la base de datos, nos hemos decantado por la opción Code First, que nos da un mayor control sobre cómo se genera la base de datos así como un mayor dinamismo a la hora de la creación de la base de datos, ya que no se depende de un script para su generación ni tampoco hay que preocuparse de eliminar la base de datos si por cualquier razón nos vemos obligados a realizar algún tipo de cambio en nuestro modelo de negocio.

**Fluent Validation:**

Permite definir reglas de validación para nuestros objetos, aprovechando toda la versatilidad de las expresiones lambda y poner todas esas reglas en otra clase que es el validador.

**Inyección de dependencias (Structure Map):**

Porque permite eliminar la dependencia entre componentes, existe un patrón de diseño conocido como &quot;Inyección de dependencias&quot; (&quot;Dependency Injection&quot; o DI).  Este patrón consiste básicamente en que en vez de ser una clase la que crea objetos, estos se inyectan o resuelven en el último momento.

Uno de los objetivos que debe tener un buen programador es que su código esté poco acoplado, es decir, que dos componentes con funcionalidades distintas dependan el uno del otro lo mínimo posible. De esta forma conseguirá que sus dos componentes por separado sean reutilizables y más fáciles de mantener.

También permite el separar la funcionalidad de una determinada tarea de su implementación concreta.

## Descripción del proyecto

Se han desarrollado dos proyectos por separado. 

- DiscountMe
- DiscountMeWP7

Uno para gestionar la parte web por un lado, y otro para emular el funcionamiento de la aplicación del móvil por otro.

**Instrucciones de instalación de librerías necesarias para el proyecto web:**

1.- (Menu VS 2010) Tools > Extension Manager > Online Gallery (search) > NuGet Package Manager > Install

2.- (Menu VS 2010) Tools > Library Package Manager > Package Manager Console > Install-package

3.- (Menu VS 2010) Tools > Extension Manager > Online Gallery (search) > EF 4.x POCO Entity Generator for C#

**Ejemplos predefinidos en Base de Datos**

Se encuentran en el proyecto DiscountMe.DAL > DBContext > InitTables.cs

**INSTRUCCIONES DE INSTALACIÓN**

**Proyecto Web:**

Instalación de base de Datos: Al utilizar CodeFirst no se necesario.

En el caso de que se requieran permisos:

1.- Ejecutar el script que se adjunta en la documentación (Acceso a BBDD al usuario del IIS.sql)

2.- Desde el manager: Dar permisos al usuario IIS

BD DiscountME > Security > (boton derecho sobre el IIS APPPOOL\DefaultAppPool) > Properties > Membership > db\_datareader y db\_datawriter

**Proyecto Windows Phone:**

1.- Instalar paquete SDK de Windows Phone 7.1 (WPSDKv71\_en1.iso)

## Autores
- Juan Francisco Miranda Aguilar ([@jfmiranda75](https://twitter.com/jfmiranda75))
- Juan Cruz Llorens ([@juancllorens](https://twitter.com/juancllorens))

## License

- **[MIT license](http://opensource.org/licenses/mit-license.php)**
- Copyright 2011 © <a href="http://iberasoft.com" target="_blank">IberaSoft</a>.

