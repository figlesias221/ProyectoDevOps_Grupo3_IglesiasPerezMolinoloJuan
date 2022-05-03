# ProyectoDevOps_Grupo3_IglesiasPerezMolinoloJuan

Integrantes: Marcelo Pérez -227362-, Federico Iglesias -244831-, Andrés Juan -241600-, Matías Molinolo -231323-.

Letra del obligatorio: https://fi365.sharepoint.com/:w:/s/IngSoft_ISA2/EYTQH9GaZQlGoOZ21O9BRJEBAk3wSQY6UeoB2SvIKk4c2g?e=6TDPhl

## Proceso de Ingeniería

A nivel de ingeniería, utilizaremos BDD como framework para desarrollo y mantenimiento. El output de BDD van a ser nuestras user stories, que luego serán sometidas a toda la pipeline definida a continuación (en este orden):

- **Requirements definition**: definición de las user stories en el formato COMO tipo de usuario QUIERO funcionalidad PARA beneficio.
- **Test cases implementation**: definición de criterios de aceptación (escenarios) en el formato DADO contexto CUANDO evento ENTONCES resultados.
- **Application implementation**: desarrollo de la aplicación que llevan a cabo los desarrolladores.
- **Automatic unit testing**: implementar testing unitario que corre de forma automática.
- **Refactoring**: luchar contra la deuda técnica identificando posibilidades de mejora en términos de eficiencia, estilos del código o errores de diseño.
- **Build**: hacer un _build_ de la aplicación.
- **Automatic integration testing**: implementar testing automático para testear la interacción entre los distintos módulos de software.
- **Deploy to staging**: desplegar el sistema en _staging_, reconociendo potenciales fallos, sin afectar usuarios finales.
- **Acceptance tests**: determinar si los requerimientos fueron satisfechos.
- **Deploy to production**: desplegar el sistema a producción, entregando valor al usuario final.

### Marco de gestión ágil

Se utilizará Kanban para el proyecto como marco de gestión ágil con iteraciones de duración de dos semanas.

Se celebrarán las ceremonias de retrospectiva -los viernes previos a la finalización de cada iteración- y daily stand ups -los miércoles a las 11 am y viernes a las 4 pm de cada semana-. Asimismo, el board de Kanban guiará el trabajo del equipo.

### Estrategias de branching

El trabajo en el repositorio seguirá los lineamientos de GitFlow para el manejo de ramas. Mantendremos la rama _main_ con la última versión completa del sistema, en donde haremos un merge para cada entrega. Tendremos una rama _develop_ que mantendrá una versión estable del trabajo y desde la cual se crearán las ramas para features o hot fixes que luego serán mergeadas a _develop_ al ser completidas. Para ello, el responsable de la rama debe abrir un pull request con el código, para habilitar el review de sus compañeros y posteriormente integrar la rama a _develop_.

Se considerará que una rama está pronta para ser mergeada a _develop_ si cumple con los siguientes requisitos:

- Su contenido fue revisado por otros integrantes del equipo, que realizaron su validación y dieron su approve.
- Los tests unitarios pasan satisfactoriamiente.
- Se cumple con todos los criterios de aceptación asociados a la issue siendo desarrollada.

Al final de cada iteración, se mergeará _develop_ a _main_ y se creará un nuevo release para realizar la entrega pertinente.

### Gestión del proceso

Para medir el esfuerzo en HS-P de cada issue o user story, cada persona deberá marcar y actualizar la medida de esfuerzo dedicada (en HS-P) en cada una de sus issues o user stories en el tablero. Además, en futuras iteraciones se estimará también el esfuerzo de cada una de ellas, para luego comparar los dos valores y en base a ello adaptar el proceso. Utilizaremos las métricas como medio de feedback para adaptar el proceso. Ejemplo:

<img src="/imagenes/ejemplo_card_esfuerzo.png" style="height: 250px" />

Para la adaptación del proceso utilizaremos las siguientes métricas: lead time, cycle time, deployment frequency, WIP. Para su recopilación y generación utilizaremos el log de movimientos que que genera github cada vez que una issue es se mueve de columna en columna.

### Configuración inicial del tablero Kanban

Se utilizará el tablero que ofrece GitHub en la sección de Proyectos. El tablero nos permitirá limitar el Work In Progress y maximizar el Flow.

Definimos las siguientes columnas, considerando que en esta etapa del proyecto no tenemos historias de usuario que puedan ser sometidas a toda la pipeline descrita anteriormente, sin perjuicio de que en el futuro el tablero cambie:

- Backlog
- In Progress
- Blocked
- QA
- Done

Designamos a Andrés como el responsable de la creación de las issues (tarjetas) en el tablero. Las issues deben ser explicativas, fáciles de entender y a su vez. Si bien Andrés será el encargado de la creación de las tarjetas, luego de creadas estas se discutirán y aclararán entre todos en la próxima ceremonia de daily stand up.

## Documentos

[Deuda Técnica FE](./Documentos/DeudaT%C3%A9cnicaFE.md)

[Informe de calidad y deuda técnica](./Documentos/InformeCalidad.md)