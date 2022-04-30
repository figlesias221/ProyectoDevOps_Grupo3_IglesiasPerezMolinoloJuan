# Análisis Deuda Técnica FE

## Análisis estático de código

### Clean Code

El uso de comentarios generalmente no es recomendado y la mayoría violan los principios de Clean Code.

CC sobre comentarios:

- “_When you feel the need to write a comment, first try to refactor the code so that any comment becomes superfluous.”_

- “_The best comment is a good name for a method or class.”_

Utilización comentarios redundantes

<img src="../Imagenes/comentarios1.png" alt="drawing" style="width:500px;"/>
 
---
 
Otro principio de CC, es que si se va a eliminar código, que se borre directamente, no comentarlo, porque después queda el comentario olvidado:
 
<img src="../Imagenes/comentarios3.png" alt="drawing" style="width:400px;"/>
 
---
 
Utilización de nombres redundantes para métodos, no hay necesidad de especificar “One” en todas las firmas, se entiende que `deleteAdministraitor` o `createAdministraitor` refiere a un admin. `getAdministrator`, `getCategory` sería más claro que `oneAdministrator` y `oneCategory` respectivamente.
 
<img src="../Imagenes/nombres1.png" alt="drawing" style="width:500px;"/>
 
---
 
Una buena practica seria importar todos los strings que son utilizados cómo constantes a un archivo común en el proyecto, de la misma manera que se hace en endpoints.ts, el código queda más claro, y reduce el costo de cambio
 
<img src="../Imagenes/strings5.png" alt="drawing" style="width:500px;"/>
 
---
 
En este método, los 3 bloques else if pueden ser suplantados por un único bloque con un || entre las 3 condiciones ya que en los 3 se ejecuta el mismo código.
 
<img src="../Imagenes/ifElse.png" alt="drawing" style="width:450px;"/>
 
`else if (error.status === 400 || error.status === 409 || error.status === 500){ alert(error.error); handled = true; }`
 
---
 
Existen dependencias que no se utilizan, una buena práctica sería eliminar todas las dependencias innecesarias
 
<img src="../Imagenes/dependancy.png" alt="drawing" style="width:450px;"/>
 
---
 
Extraer `this.resortSearchModel.acommodationDetails` para no tener que repetirlo tantas veces.
 
<img src="../Imagenes/extract.png" alt="drawing" style="width:450px;"/>
 
---
 
Utilizar nombres descriptivos, en este caso puede no quedar claro lo que es `p`
 
<img src="../Imagenes/param.png" alt="drawing" style="width:450px;"/>
 
---
 
## Mejoras
 
Un aspecto que es de GRAN ayuda para ordenar, organizar y visualizar el código es usar algún formateador de código, cómo puede ser `Prettier`. Para dar un poco de perspectiva:
 
**Sin Prettier:**
 
El código queda fuera de la pantalla horizontalmente y se hace tedioso de leer y entender.
 
<img src="../Imagenes/prettier1.png" alt="drawing" style="width:450px;"/>
 
**Con Prettier:**
 
<img src="../Imagenes/prettier3.png" alt="drawing" style="width:450px;"/>
 
---
 
Otro aspecto de mejora podría ser separar imports externos/internos con un salto de línea, por ejemplo:
 
<img src="../Imagenes/dependecies1.png" alt="drawing" style="width:450px;"/>
 
---
 
Eliminar respuestas que no se utilizan para reducir complejidad.
 
<img src="../Imagenes/unused.png" alt="drawing" style="width:450px;"/>
 
---
 
Extraer funciones repetidas a un archivo común. La función showError se puede encontrar repetida en varios archivos
 
<img src="../Imagenes/function.png" alt="drawing" style="width:450px;"/>
 
---
 
En este archivo, podría ser una buena idea ordenar los imports alfabéticamente para mantener el orden y el entendimiento:
 
<img src="../Imagenes/dependecies2.png" alt="drawing" style="width:450px;"/>
 
---
 
## Bugs Front End

---

Un bug que se puede ver repetidas veces a los largo del Front End de la aplicación son las faltas de ortografía. En particular, la omisión casi total de los tildes: 

<img src="../Imagenes/bugFE-tildes.png" alt="drawing" style="width:450px;"/>

--- 

Otro bug generalizado se da en la *responsiveness* del sistema. Por ejemplo, dado un width pequeño del browser el texto "Aquí puedes crear puntos turísticos!" se descentra:

<img src="../Imagenes/bugFE-responsiveness.png" alt="drawing" style="width:450px;"/>

Otro ejemplo es la sección de Explorar:

<img src="../Imagenes/bugFE-responsiveness2.png" alt="drawing" style="width:450px;"/>

---

Cuando se accede a la sección de 'Hospedajes' de la página, la lista que se despliega contiene un índice que no es funcional:

<img src="../Imagenes/bugFE-listaHospedajes.png" alt="drawing" style="width:450px;"/>

---

La sección de 'Reporte' de la página comienza desplegando ciertos elementos que son reemplazados en seguida por otros. En caso de que esté cargando debería de tener un feedback correspondiente:

<img src="../Imagenes/bugFE-reporteCarga.png" alt="drawing" style="width:450px;"/>


---

Cuando se hace hover sobre el navegador de la página en el lado izquierdo, "Punto Turístico" aparece en dos líneas y en seguida se mueve a una, lo cual tiene una efecto de visualización defectuoso:

<img src="../Imagenes/bugFE-hoverNav1.png" alt="drawing" style="width:150px;"/>

<img src="../Imagenes/bugFE-hoverNav2.png" alt="drawing" style="width:150px;"/>


---

En la sección Explorar, cuando el width del browser en pequeño las opciones de huespedes se superponen:

<img src="../Imagenes/bugFE-componentesSinSuper.png" alt="drawing" style="width:450px;"/>

<img src="../Imagenes/bugFE-componentesSuperposicion.png" alt="drawing" style="width:450px;"/>

---

En la sección Tu opinión, el campo para escribir la Reseña puede ser expandido indefinidamente, hasta resultar demasiado extenso:

<img src="../Imagenes/bugFE-reseñaExtensa.png" alt="drawing" style="width:450px;"/>