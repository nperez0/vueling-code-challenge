# **Proyecto International Business Men**

## **Ejecución**

El target framework es 4.6.1, para ejecutar el proyect hay que restaurar los nuget packages, seleccionar el proyecto Api como proyecto de inicio y ejecutarlo.

La página de inicio se redirecciona a swagger que tiene la interfaz lista para ejecutar los servicios.

**Servicios Disponibles**

- /api/conversions: Obtiene la lista completa de las tasas de conversión
- /api/transactions: Obtiene la lista completa de las transacciones en euros
- /api/transactions/{sku}: Obtiene la lista las transacciones por producto y la suma total de todas las transacciones en euros

## **Proyecto**

El proyecto esta distribuido en varios proyectos y cada uno es una capa

- Capa de dominio (Domain): Contiene toda las entidades, servicios y abstracciones para el proceso de los datos según las reglas de negocio. Los servicios especificos para esta capa son los que calculan la conversion de tasas y los que obtienen la sumatoria de las transacciones por producto en euros.
- Capa de datos (Data): Contiene la implementación de los repositorios de donde se obtienen los datos de diferentes fuentes y también toda la parte de persistencia de datos
- Capa de Aplicación (Application): En esta capa se orquesta las capas inferiores (Dominio y Datos) para proveer un servicio final, se utilizan DTOs (data transfer object) para devolver información especifica
- Capa de Servicios (Api): Contiene los endpoints para la consulta externa y es donde se configura toda la aplicación
- Capa de Infraestructura (Infrastrucure): Es una capa horizontal que ofrece servicios utilitarios al resto de las capas

**Logs y persistencia de datos**

El log de errores se encuentra en el directorio Files dentro del proyecto.

Las conversiones y las transacciones se guardan en archivos txt en formato JSON, también se encuentrar en el directorio Files

**Pruebas con productos**

Para facilitar las pruebas con un producto especifico ya que el API siempre devuelve datos random, es posible cambiar la configuración para obtener los datos desde los archivos y así no cambiar de datos y escoger uno. 

En el archivo web.config se puede cambiar la llave **DataFromFile** a true para obtener los datos desde los archivos, por defecto esta en false, se encuentra la sección de los appSettings.

Los archivos se encuentran dentro del directorio Files.

**Patrones de Diseño**

- Principios SOLID
- DDD (hasta donde se puede)
- Patrón Repositorio
- Inyección de Dependencias
- Singleton

**Tecnologías Utilizadas**

- Framework 4.6.1
- ASP.NET Web API
- StructureMap
- AutoMapper
- Log4Net
- NewtonJson
- Swagger

# **International Business Men**
*(Duración máxima: 4 horas)*

Trabajas para el GNB (Gloiath National Bank), y tu jefe, Barney Stinson, te ha pedido que diseñes e implementes una aplicación backend para ayudar a los ejecutivos de la empresa que vuelan por todo el mundo. Los ejecutivos necesitan un listado de cada producto con el que GNB comercia, y el total de la suma de las ventas de estos productos.

Para esta tarea debes crear un webservice. Este webservice puede devolver los resultados en formato XML o en JSON. Eres libre de escoger el formato con el que te sientas más cómodo (sólo es necesario que se implemente uno de los formatos).

Recursos a utilizar:

- [http://quiet-stone-2094.herokuapp.com/rates.xml](http://quiet-stone-2094.herokuapp.com/rates.xml) o [http://quiet-stone-2094.herokuapp.com/rates.json](http://quiet-stone-2094.herokuapp.com/rates.json) devuelve un documento con los siguientes formatos;

**XML**
```
<?xml version="1.0" encoding="UTF-8"?>
<rates>
 <rate from="EUR" to="USD" rate="1.359"/>
 <rate from="CAD" to="EUR" rate="0.732"/>
 <rate from="USD" to="EUR" rate="0.736"/>
 <rate from="EUR" to="CAD" rate="1.366"/>
</rates>
```

**JSON**
```
[
 { "from": "EUR", "to": "USD", "rate": "1.359" },
 { "from": "CAD", "to": "EUR", "rate": "0.732" },
 { "from": "USD", "to": "EUR", "rate": "0.736" },
 { "from": "EUR", "to": "CAD", "rate": "1.366" }
]
```

Cada entrada en la colección especifica una conversión de una moneda a otra (cuando te devuelve una conversión, la conversión contraria también se devuelve), sin embargo hay algunas conversiones que no se devuelven, y en caso de ser necesarias, deberán ser calculadas utilizando las conversiones que se dispongan. Por ejemplo, en el ejemplo no se envía la conversión de USD a CAD, esta debe ser calculada usando la conversión USD a EUR y después EUR a CAD.

- [http://quiet-stone-2094.herokuapp.com/transactions.xml](http://quiet-stone-2094.herokuapp.com/transactions.xml) o [http://quiet-stone-2094.herokuapp.com/transactions.json](http://quiet-stone-2094.herokuapp.com/transactions.json) devuelve un documento con los siguientes formatos:

**XML**
```
<?xml version="1.0" encoding="UTF-8"?> <transactions>
 <transaction sku="T2006" amount="10.00" currency="USD"/>
 <transaction sku="M2007" amount="34.57" currency="CAD"/>
 <transaction sku="R2008" amount="17.95" currency="USD"/>
 <transaction sku="T2006" amount="7.63" currency="EUR"/>
 <transaction sku="B2009" amount="21.23" currency="USD"/>
 ...
</transactions>
```

**JSON**
```
[
 { "sku": "T2006", "amount": "10.00", "currency": "USD" },
 { "sku": "M2007", "amount": "34.57", "currency": "CAD" },
 { "sku": "R2008", "amount": "17.95", "currency": "USD" },
 { "sku": "T2006", "amount": "7.63", "currency": "EUR" },
 { "sku": "B2009", "amount": "21.23", "currency": "USD" }
]
```

Cada entrada en la colección representa una transacción de un producto (el cual se identifica mediante el campo SKU), el valor de dicha transacción (amount) y la moneda utilizada (currency).

La aplicación debe tener un método desde el cuál se pueda obtener el listado de todas las transacciones. Otro método con el que obtener todos los rates. Y por último un método al que se le pase un SKU, y devuelva un listado con todas las transacciones de ese producto en EUR, y la suma total de todas esas transacciones, también en EUR.

Por ejemplo, utilizando los datos anteriores, la suma total para el producto T2006 debería ser 14,99.

Además necesitamos un plan B en caso que el webservice del que obtenemos la información no esté disponible. Para ello, la aplicación debe persistir la información cada vez que la obtenemos (eliminando y volviendo a insertar los nuevos datos). Puedes utilizar el sistema que prefieras para ello.

## **Requisitos**

    Puedes utilizar cualquier framework y cualquier librería de terceros.
    Recuerda que pueden faltar algunas conversiones, deberás calcularlas mediante la información que tengas.
    Separación de responsabilidades en distintas capas: Servicios distribuidos, capa de aplicación, capa de dominio.
    Implementación de log de error y manejo de excepciones en cada capa.
    Tener en cuenta los principios SOLID y correcta capitalización del código.
    Uso de Inyección de dependencias.

## **Puntos extra (No obligatorios)**

    Estamos tratando con divisas, intenta no utilizar números con coma flotante.
    Después de cada conversión, el resultado debe ser redondeado a dos decimales usando el redondeo Banker's Rounding (http://en.wikipedia.org/wiki/Rounding#Round_half_to_even)
    
 **Por favor, el comentario del commit final ha de ser "Finished", para informarnos de que se ha finalizado la prueba.**