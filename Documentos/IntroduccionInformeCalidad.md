# Introducción al informe de calidad y deuda técnica

Para nuestro informe de calidad y deuda técnica, llevaremos a cabo un análisis que contempla el análisis estático del código (tanto del backend como del frontend) y el testing exploratorio realizado para encontrar bugs en el sistema. 

A grandes rasgos, la aplicación es funcional y está en un estado aceptable. Sin embargo, encontramos muchas deficiencias en diferentes niveles de análisis que presentamos a continuación.

A nivel de requerimientos, la gran mayoría se cumplen satisfactoriamente pero existen algunos que no se cumplen. Por ejemplo, un administrador no puede **"Modificar la capacidad actual de un hospedaje"** a través de la interfaz web. 

En cuanto a la calidad del código: el mismo es comprensible, la arquitectura está diseñada acordemente y es modificable. De todos modos se encontraron puntos débiles como la falta de Clean Code, los cuales se podrán ver más adelante en este informe.

La interfaz de usuario facilita la utilización de las funcionalidades del sistema y destacamos positivamente la navegación y diseño. Asimismo, existe una gran cantidad de bugs en el front end, tanto funcionales como de UI. En algunos casos, por ejemplo cuando se modifica el tamaño de la ventana en la que se despliega, los componentes se superponen y la funcionalidad se ve afectada. Además, varios aspectos de la página web tienen defectos como errores de ortografía o un diseño que reduce la usabilidad, todos de los cuales se verán evidenciados a continuación.

