# Análisis Deuda Técnica FE

## Analisis estatico de codigo

### Clean Code

El uso de comentarios generalmente no es recomendado y la mayoria violan los principios de Clean Code.

CC sobre comentarios:

- “_When you feel the need to write a comment, first try to refactor the code so that any comment becomes superfluous.”_

- “_The best comment is a good name for a method or class.”_

Utilizacion comentarios redundantes

<img src="../Imagenes/comentarios1.png" alt="drawing" style="width:500px;"/>

---

Otro principio de CC, es que si se va a eliminar codigo, que se borre directamente, no comentarlo, porque despues queda el comentario olvidado:

<img src="../Imagenes/comentarios2.png" alt="drawing" style="width:400px;"/>

<img src="../Imagenes/comentarios3.png" alt="drawing" style="width:400px;"/>

---

Utilizacion de nombres redundantes para metodos, no hay necesidad de especificar “One” en todas las firmas, se entiende que `deleteAdministraitor` o `createAdministraitor` refiere a un admin. `getAdministrator`, `getCategory` seria más claro que `oneAdministrator` y `oneCategory` respectivamente.

<img src="../Imagenes/nombres1.png" alt="drawing" style="width:500px;"/>

<img src="../Imagenes/nombres2.png" alt="drawing" style="width:500px;"/>

<img src="../Imagenes/nombres3.png" alt="drawing" style="width:500px;"/>

---

Una buena practica seria importar todos los strings que son utlizados cómo constantes a un archivo comun en el proyecto, de la misma manera que se hace en endpoints.ts, el codigo queda más claro, y reduce el costo de cambio

<img src="../Imagenes/strings1.png" alt="drawing" style="width:500px;"/>

<img src="../Imagenes/strings2.png" alt="drawing" style="width:500px;"/>

<img src="../Imagenes/strings3.png" alt="drawing" style="width:250px;"/>

<img src="../Imagenes/strings5.png" alt="drawing" style="width:500px;"/>

En este metodo, los 3 bloques else if pueden ser suplantados por un unico bloque con un || entre las 3 condiciones, ya que, en los 3 se ejecuta el mismo codigo.

<img src="../Imagenes/ifElse.png" alt="drawing" style="width:450px;"/>

`else if (error.status === 400 || error.status === 409 || error.status === 500){ alert(error.error); handled = true; }`

---

Existen dependencias que no se utilizan, una buena practica seria eliminar todas las dependencias innecesarias

<img src="../Imagenes/dependancy.png" alt="drawing" style="width:450px;"/>

---

Extraer `this.resortSearchModel.acommodationDetails` para no tener que repetirlo tantas veces.

<img src="../Imagenes/extract.png" alt="drawing" style="width:450px;"/>

---

Utilizar nombres descriptivos, en este caso puede no quedar claro lo que es `p`

<img src="../Imagenes/unused.png" alt="drawing" style="width:450px;"/>

---

## Mejoras

Un aspecto que es de GRAN ayuda para ordenar, organizar y vizualizar el codigo es usar algun formateador de codigo, cómo puede ser `Prettier`. Para dar un poco de perspectiva:

**Sin Prettier:**

El codigo queda fuera de la pantalla horizontalmente y se hace tedioso de leer y entender.

<img src="../Imagenes/prettier1.png" alt="drawing" style="width:450px;"/>

<img src="../Imagenes/prettier2.png" alt="drawing" style="width:450px;"/>

---

**Con Prettier:**

<img src="../Imagenes/prettier3.png" alt="drawing" style="width:450px;"/>

<img src="../Imagenes/prettier4.png" alt="drawing" style="width:450px;"/>

---

Otro aspecto de mejora podria ser separar imports externos/internos con un salto de linea, por ejemplo:

<img src="../Imagenes/dependecies1.png" alt="drawing" style="width:450px;"/>

---

Eliminar response que no se utilizan para reducir complejidad.

<img src="../Imagenes/unused.png" alt="drawing" style="width:450px;"/>

<img src="../Imagenes/unused2.png" alt="drawing" style="width:450px;"/>

---

Extraer funciones repetidas a un archivo comun. La funcion showError se puede encotrar repetida en varios archivos

<img src="../Imagenes/function.png" alt="drawing" style="width:450px;"/>

---

En este archivo, podria ser una buena idea ordernar los imports alfabeticamente para mantener el orden y el entendiemiento:

<img src="../Imagenes/dependecies2.png" alt="drawing" style="width:450px;"/>

---

## Bugs
