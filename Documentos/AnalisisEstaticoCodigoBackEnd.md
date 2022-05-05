## Análisis de la deuda técnica del Backend

### Análisis estático del código

---

A nivel del backend, si analizamos el código de forma estática, se destacan los siguientes aspectos:

**Errores de lógica**: observamos que hay ciertos errores de lógica. Por ejemplo, si observamos la clase **ResortPricingCalcuator** vemos el siguiente:

El siguiente es un fragmento del método *CalculateTotalPriceForAccommodation* que dado una reserva, calcula el valor de esta, considerando cuántos adultos, bebes, niños, retirados o bebes, y los descuentos para cada uno.

```` 
foreach(GuestGroup guestGroup in guestGroups)
{
    List<IGuestGroupDiscountPolicy> applicableDiscounts = guestGroup.GetApplicableDiscountPolicies();
    int guestsWithDiscount = 0;
    int guestsWithoutDiscount = guestGroup.Amount;

    if (applicableDiscounts.Count > 0)
    {
        foreach (IGuestGroupDiscountPolicy policy in applicableDiscounts)
        {
            guestsWithDiscount = policy.AmountOfGuestsThatApplyForDiscount(guestGroup);
            guestsWithoutDiscount -= guestsWithDiscount;
            double discount = policy.GetAssociatedDiscount();

            totalPrice += (int)(amountOfNights * guestsWithDiscount * pricePerNight * discount);
            totalPrice += amountOfNights * guestsWithoutDiscount * pricePerNight;
        }
    }
    else 
        totalPrice += amountOfNights * guestsWithoutDiscount * pricePerNight;
}

    return totalPrice;
````  

Si vemos, para cada *GuestGroup* se hace un *foreach* de los descuentos disponibles que tiene, y se suma el precio correspondiente al total. Pero, ¿qué pasa si hay más de un descuento para ese grupo de huéspedes? Eso significa que se va a sumar dos veces el precio con cada descuento. Lo que se debería hacer acá es tomar el descuento que descuente más al precio total: considerando el que maximice el descuento considerando el porcentaje y la cantidad de huéspedes para los cuales aplica. Luego, ese es el descuento que se debe elegir para aplicar, pero no sumar el precio resultante de todos los descuentos disponibles, como se hace acá. El problema recae en que el código asume que solo habrá un descuento por cada grupo de huéspedes.

Luego, en esta misma clase vemos otro error de lògica cuando se cálcula la cantidad de noches en una reserva:

````
private int GetAmountOfNightsFromAccommodation(Accommodation accommodation)
{
    TimeSpan timespan = accommodation.CheckOut.Subtract(accommodation.CheckIn);
    return (int)Math.Ceiling(timespan.TotalDays);
}
````

Partiendo de la base que el día de mañana el FrontEnd puede cambiar y la lógica debe mantener consistencia de las reglas del negocio, este método no es correcto. ¿Por qué? Porque el tipo *DateTime* de *CheckIn* y  *CheckOut* admite tiempo, por lo que la cantidad de noches serán ````(int)Math.Ceiling(timespan.TotalDays)```` si y solo si el *CheckOut* es anterior en horas al *CheckIn*, de lo contrario se tendría que utilizar ````(int)Math.Floor(timespan.TotalDays)````.

Si bien esto se puede manejar a nivel del FrontEnd (siempre asumiendo que la hora es la misma para ambos *CheckIn* y  *CheckOut*), a nivel de Backend esto presenta una vulnerabilidad que puede ser explotada si el Frontend cambia a futuro.

---

**Acoplamiento**

De **BusinessLogic** con **DataAccess**:

Algo que llama la atención del paquete **BusinessLogic** del proyecto es la poca lógica que contiene. Si vemos las clases de lógica, los métodos lo único que hacen es llamadas al acceso a datos. Ejemplo:

````
public Category GetCategoryById(int categoryId)
{
    return _repositoryFacade.GetCategoryById(categoryId);
}
````

````
public Region GetRegionById(int regionId)
{
    return _repositoryFacade.GetRegionById(regionId);
}
````

Esto sucede porque gran partes de las validaciones y el manejo de excepciones suceden en el paquete de *DataAccess*. Esto es un error dado que si queremos tener un diseño desacoplado a un mecanismo de persistencia específico, las reglas del negocio no pueden ser parte de este. La persistencia debe poder cambiar sin afectar la lógica. 

Con el diseño actual, si cambia el mecanismo de persistencia, perdemos todas estas validaciones con él. Estas validaciones deben ser parte de la lógica de negocios, para que si en el futuro la persistencia cambia, la lógica de negocios se mantenga inafectada. El paquete de persistencia únicamente debe ser CRUD, y nada más. 

---

**Ineficiencias**

Notamos que, a lo largo de toda la lógica del proyecto, cuando se crea una nueva entidad o se actualiza una ya existente, y se desea devolver el resultado de estas operaciones al cliente, en vez de utilizar la respuesta de las llamadas *create* o *update*, se hace un *get* posterior.

Veámoslo en código:

````
int newAdministratorId = _repositoryFacade.StoreAdministrator(administrator);
Administrator createdAdministrator = _repositoryFacade.GetAdministratorById(newAdministratorId);
return createdAdministrator;
````      
````
 _repositoryFacade.UpdateAdministrator(administrator);
Administrator updatedAdministrator = _repositoryFacade.GetAdministratorById(administrator.Id);
return updatedAdministrator;
````

Esto es ineficiente y desperdicia recursos; es mejor hacer que el repositorio para las operaciones *create* o *update* directamente devuelva la entidad que se quiere retornar, sin necesidad de hacer un *get* extra. Haciendo este *get* potencialmente necesitamos crear otra conexión con la base de datos, ir a buscar nuevamente el dato a la base de datos lo cual implica reducir la latencia y en fin, desperdiciar recursos y performance.

---
**Principios de diseño**

Tras abordar el proyecto, notamos que se hace protagonista la clase **RepositoryFacade**: una fachada del paquete de *DataAccess*. Esta es utilizada por *BusinessLogic* para llevar a cabo toda operación de acceso a datos, es decir, todas las clases en *BusinessLogic* la utilizan.

A nivel de deuda técnica, no creemos que este sea el mejor diseño, ya que como resultado tenemos una clase **RepositoryFacade** con demasiadas responsabilidades: el CRUD de cada entidad (la clase tiene un total de 25 métodos publicos). La clase, por tanto, no cumple con SRP (Single Responsibility Principle), teniendo así muchos motivos de cambio que pueden afectar a la amplia variedad de clases que la utilizan (todas las clases en *BusinessLogic*). Para cumplir con SRP y también con ISP (Interface Seggregation Principle), creemos que sería una mejor idea tener una interfaz para cada repositorio específico, e inyectar la dependencia del repositorio en particular que la clase necesite utilizar, sin necesidad de acoplarnos a una interfaz de la cual necesitamos solo un subconjunto muy reducido de todas las operaciones que ofrece.

---
**Clean code: uso de constantes (strings) en el código**

En lo que refiere al uso de constantes, vemos que repetidamente aparecen *magic constants* (constantes que yacen en el código, sin significado alguno). 

Por ejemplo, ¿cuál es el significado de la expresión regular? ¿Qué hace?

````
private void ValidateSurname()
{
    Regex nameRegex = new Regex(@"^[a-zA-ZñÑáéíóúü ]+$");

    if (Surname == null || !nameRegex.IsMatch(Surname))
                throw new InvalidRequestDataException("Invalid name");
}

private void ValidateName()
{
    Regex nameRegex = new Regex(@"^[a-zA-ZñÑáéíóúü ]+$");

    if (Name == null || !nameRegex.IsMatch(Name))
        throw new InvalidRequestDataException("Invalid name");
}
````

Extráyendola como un atributo constante de la clase, no solamente la podemos reusar sino que también le podemos dar un nombre explicativo que describa qué es lo que valida (*matchea*) esta expresión regular.

Otro ejemplo en el que vemos esto es en la clase *XMLImporter* ("File to parse"):
````
public XMLImporter(IConfiguration configuration)
{
    ....

    _requiredParameters = new List<ImporterParameterDescription>()
    {
        new ImporterParameterDescription()
        {
            Name = "File to parse",
            Type = PossibleParameters.File
        }
    };
}

public List<ImportedResort> RetrieveResorts(List<ImportingParameterValue> parameters)
{
    ....
    string fileName = parameters.Find(p => p.Name == "File to parse").Value;
    ....
}
````

Buscamos reusar estas constantes, y darle explicación a ellas para quien lee el código.

Esto lo vemos también en los tests. Todas las constantes que se utilizan con propósitos de testing deben ser extraídas como atributos constantes de la clase, con nombres descriptivos, y se debe apostar a reusarlas, en la medida de lo posible, en los distintos tests. De esa forma, los tests se vuelven más manejables.

Ver cómo en los siguientes tests repiten una gran cantidad de constantes ("Punta del este", "Playas", "Valid description"):

````
[TestMethod]
[ExpectedException(typeof(InvalidRequestDataException))]
public void TouristPointWithoutImageFailsValidation()
{
    TouristPoint touristPoint = new TouristPoint()
    {
        Name = "Punta del Este",
        Description = "Valid description",
        RegionId = 2
    };
    touristPoint.AddCategory(new Category() { Name = "Playas" });
    touristPoint.ValidOrFail();
}

[TestMethod]
[ExpectedException(typeof(InvalidRequestDataException))]
public void TouristPointWithInvalidImageFailsValidation()
{
    TouristPoint touristPoint = new TouristPoint()
    {
        Name = "Punta del Este",
        Description = "Valid description",
        Image = new Image() { },
        RegionId = 2
    };
    touristPoint.AddCategory(new Category() { Name = "Playas" });
    touristPoint.ValidOrFail();
}
````
---
**Connection Strings**

````
var connectionString = configuration.GetConnectionString(@"NaturalUruguayDB");
builder.UseSqlServer("Data Source=localhost\\sqlexpress,1433;Database=NaturalUruguayDB;User Id=SA;Password=MyPass@word;");
````

Otro aspecto con el que vemos constantes en el código es en el hardcodeo del connection string para la conexión con la base de datos (arriba). Es preferible tener estas configuraciones en archivos de configuración.

Además, si pensamos en tener una base de datos por ambiente (es decir, una de dev y otra de producción), los archivos de configuración se vuelven realmente importantes para diferenciar el connection string de dev con el de prod, leyendo el archivo correspondiente al ambiente en el que estemos.

---
**Manejo de excepciones pobre**

El paquete de exceptions cuenta únicamente con dos clases Exception: *InvalidRequestDataException* y *ResourceNotFoundException*. Esto significa que hay ciertos escenarios que quedan por fuera del alcance de estas excepciones, como pueden ser: falta de autenticación, falta de permisos para acceder a ciertas funcionalidades, u operaciones como querer hacer una reserva en un resort que no está disponible. Es decir, faltan excepciones propias al sistema, para evitar tener que utilizar las que son propias del lenguaje. 

---
**Aspectos de clean code en general**

Se observan algunas mejoras leves a nivel de clean code:
- Métodos que podrían ser de una sola línea, por ejemplo:
````
public bool PolicyAppliesToGuestGroup(GuestType guestGroupType)
{
     bool policyApplies = false;

    if (guestGroupType == GuestType.Baby)
        policyApplies = true;

    return policyApplies;
}
````

- Estándares de código, como falta de espacios:

````
if(Description == null)
````

Esto se puede arreglar con el uso de un linter.

- Evitar catchear exception, sino que utilizar excepciones específicas:

````
public bool IsTokenValid(Guid id)
{
    try 
    {
        AuthorizationToken token =  _repositoryFacade.GetAuthenticationTokenById(id);
        return true;
    }
    catch (Exception) 
    {
        return false;
    }
}
````

---
**Tests identificados con números**

- Se repite varias veces el tener tests identificados con números, por ejemplo:
````
public void TotalPriceForAccommodationCalculatedCorrectly1() { ... }
public void TotalPriceForAccommodationCalculatedCorrectly2() { ... }
public void TotalPriceForAccommodationCalculatedCorrectly3() { ... }
public void TotalPriceForAccommodationCalculatedCorrectly4() { ... }
````

```

public void UpdateResortPunctuationDoesAsExpected1()
public void UpdateResortPunctuationDoesAsExpected1()
public void UpdateResortPunctuationDoesAsExpected1()
public void UpdateResortPunctuationDoesAsExpected1()
````

Si los tests están testeando el mismo código entonces no tiene sentido tener tests repetidos. Por otro lado, si los tests, cada uno de ellos, están testeando diferentes flujos (como ya sea uno que atrapa una excepción y hace determinada operación) entonces se recomienda ponerle un nombre descriptivo al test que lo diferencie de los demás. Igualmente, en este caso nos encontramos frente al primer caso, los tests testean lo mismo.

Esto se ve corregido en otros tests, en los que se usa la anotación *DataTestMethod* para cuando queremos testear con más de un set de parámetros, que es lo que proponemos para resolver el problema antes descrito:

````

[DataTestMethod]
[DataRow(GuestType.Baby, 3)]
[DataRow(GuestType.Baby, 1)]
[DataRow(GuestType.Baby, 6)]
public void DiscountAppliesToAllBabies(GuestType guestType, int amountGuests) { ... }
````
---
**Comparación de strings usando `==`**

A modo de ejemplo, en el siguiente método, dentro de la clase `JSONImporter`, podemos ver que se realiza la comparación de strings utilizando `==`, en vez de usando el método `.equals`. 

```
public List<ImportedResort> RetrieveResorts(List<ImportingParameterValue> parameters)
        {
            List<ImportedResort> parsedResorts = new List<ImportedResort>();

            ValidateParametersOrFail(parameters);
            string fileName = parameters.Find(p => p.Name == "File to parse").Value; 

            try
            {
                ...
```

Por más que el operador `==` compara strings, usar `.equals` es más robusto ya que permite la comparación de strings ignorando si son en mayúsculas o minúsculas.

---
**Importación de múltiples archivos** 

Podemos ver, dentro de la clase `JSONImporter`, que no es posible importar múltiples archivos JSON. Esto se debe a que la siguiente línea:

```
    string fileName = parameters.Find(p => p.Name == "File to parse").Value; 
```

Encuentra solo el primer valor que tenga `p.Name` igual a `"File to Parse"`. En caso de querer importar múltiples archivos, no será posible hacerlo.

---
Dentro del paquete `Models`, no se encontraron bugs evidentes o carencias en lo que respectan a buenos estándares y prácticas de codificación (Clean Code, uso de patrones, etc.)

También, podemos ver que en el paquete `ServiceRegistration`, los paquetes se registran correctamente a su interfaz, para cumplir así con el principio de inversión de dependencias.

---
**Códigos de respuesta en la API**

Una carencia encontrada al realizar este análisis estático fue el hecho que todos los endpoints devuelven `200 OK`, indistintamente del resultado. Esto no es correcto, ya que, si busco un usuario que no existe, el código de respuesta debería indicarlo, en vez de indicar que la solicitud fue exitosa.

```
[HttpGet("{id:int}")]
        public IActionResult GetSpecificRegion(int id)
        {
            Region retrievedRegion = _regionManager.GetRegionById(id);
            RegionBasicInfoModel regionModel = new RegionBasicInfoModel(retrievedRegion);
            return Ok(regionModel);
        }
```

De lo anterior, surge también el hecho que no existe el manejo de excepciones a nivel de los endpoints. Debido a esto, no se pueden retornar distintos códigos de error en función de la respuesta obtenida de la lógica. 






