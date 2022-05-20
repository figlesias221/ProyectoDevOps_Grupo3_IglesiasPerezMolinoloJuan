# Iteración 2


## Justificación de la inclusión de los bugs

En base al análisis de la iteración 1, decidimos reparar los siguientes dos bugs que cosideramos con mayor severidad para el sistema:

- *Error de lógica en ResortPricingCalculator #60*: En este caso, el sistema calcula erroneamente el los descuentos en los resorts, y los acumula en vez de tomar el mayor de estos. Dada la presencia de más de un descuento disponible para un mismo resort, el sistema llevaría a una pérdida de dinero que consideramos que debería ser eliminada del sistema. De forma que priorizmos el manejo de dinero para y utilizamos el criterio de reparar este error que significa una pérdida financiera potencialmente significativa. 

- *Error de fechas en reserva de hospedajes #44*: Decidimos incluír también este bug dado que modifica las fechas seleccionadas por el usuario al hacer una reserva. Esta modificación hace que la funcionalidad de reserva de hospedajes no funcione correctamente, y consideramos que su arreglo es fundamental para la funcionalidad del sistema, permitiendole a los usuarios realizar reservas de hospedajes satisfactoriamente. 