# Iteración 2

# Justificación de la inclusión de los bugs

En base al análisis de la iteración 1, decidimos reparar los siguientes dos bugs que cosideramos con mayor severidad para el sistema:

- _Error de lógica en ResortPricingCalculator #60_: En este caso, el sistema calcula erroneamente el los descuentos en los resorts, y los acumula en vez de tomar el mayor de estos. Dada la presencia de más de un descuento disponible para un mismo resort, el sistema llevaría a una pérdida de dinero que consideramos que debería ser eliminada del sistema. De forma que priorizmos el manejo de dinero para y utilizamos el criterio de reparar este error que significa una pérdida financiera potencialmente significativa.

- _Error de fechas en reserva de hospedajes #44_: Decidimos incluír también este bug dado que modifica las fechas seleccionadas por el usuario al hacer una reserva. Esta modificación hace que la funcionalidad de reserva de hospedajes no funcione correctamente, y consideramos que su arreglo es fundamental para la funcionalidad del sistema, permitiendole a los usuarios realizar reservas de hospedajes satisfactoriamente.

# Desarrollo/Mantenimiento del nuevo tablero utilizando BDD

Se realizaron modificaciones en las columnas del tablero con respecto a la iteración anterior, el resultado se puede ver a continuación:

<img src="../Imagenes/board2.png"  />
 
En particular, se eliminaron las columnas, In progress, Blocked y QA. En su lugar se creo una nueva columna por cada paso en el proceso de BDD, resultando 6 nuevas columnas, Requierments definiton (CCC), Test cases implementation, Application implementation, Automatic Unit testing, Refactoring y Build.
 
# Desarrollo/Mantenimiento del pipeline y vínculo con el tablero
 
Para la iteración 2, se creó una pipeline "Pipeline Ministerio de Turismo", a traves de github actions, que previo a hacer un merge de una rama hacia develop, la pipeline corre un build automáticamente e informa si el proceso es satisfactorio o no. Lo mismo ocurre con los tests, se corren todos los tests de la solución, y de esta manera nos aseguramos de no introducir tests que no pasan a develop.
 
A continuación podemos ver un ejemplo de un PR de una rama hacia develop en la cual el build se realiza con exito pero los tests no están pasando todos:
 
<img src="../Imagenes/pipeline.png"  />
 
En cuanto a la relación de la nueva pipeline con el tablero se asocia la columna Automatic Unit testing con la corrida automática de los tests y el build automático con la columna de Build.
