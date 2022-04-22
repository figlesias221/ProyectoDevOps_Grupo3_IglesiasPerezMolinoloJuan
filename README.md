# ProyectoDevOps_Grupo3_IglesiasPerezMolinoloJuan

Integrantes: Marcelo Pérez -227362-, Federico Iglesias -244831-, Andrés Juan -241600-, Matías Molinolo -231323-.

## Proceso de Ingeniería

A continuación, la definición de los distintos aspectos de nuestro proceso de ingeniería:

### Marco de gestión ágil

Se utilizará Kanban para el proyecto como marco de gestión ágil con iteraciones de duración de dos semanas. 

Se celebrarán las ceremonias de retrospectiva -los viernes previos a la finalización de cada iteración- y daily stand ups -los martes y jueves de cada semana-. Asimismo, el board de Kanban guiará el trabajo del equipo.

### Estrategias de branching

El trabajo en el repositorio seguirá los lineamientos de GitFlow para el manejo de ramas. Mantendremos la rama _main_ con la última versión completa del sistema, en donde haremos un merge para cada entrega. Tendremos una rama _develop_ que mantendrá una versión estable del trabajo y desde la cual se crearán las ramas para features o hot fixes que luego serán mergeadas a _develop_ al ser completidas. Para ello, el responsable de la rama debe abrir un pull request con el código, para habilitar el review de sus compañeros y posteriormente integrar la rama a _develop_. 

Se considerará que una rama está pronta para ser mergeada a _develop_ si cumple con los siguientes requisitos:
- Su contenido fue revisado por otros integrantes del equipo, que realizaron su validación y dieron su approve.
- Los tests unitarios pasan satisfactoriamiente. 
- Se cumple con todos los criterios de aceptación asociados a la issue siendo desarrollada.

Al final de cada iteración, se mergeará _develop_ a _main_ y se creará un nuevo release para realizar la entrega pertinente. 

### Gestión del proceso

Para mantener un registro diario de las horas dedicadas por cada integrante del equipo utilizaremos una _timesheet_ que mantendremos en un documento compartido entre todos. De esta forma tendremos métricas del tiempo dedicado cada día, que luego podrán ser complementadas con otras métricas como medio de feedback para adaptar el proceso. 

<!-- TODO: Definir generación y recopilación de métricas para la adaptación del proceso: lead time, cycle time, deployment frequency, WIP -->

### Configuración del tablero Kanban

Se utilizará el tablero que ofrece GitHub en la sección de Proyectos. El tablero nos permitirá limitar el Work In Progress y maximizar el Flow.

Definimos las siguientes columnas:
- Backlog
- In Progress
- Blocked (?)
- QA
- Done

Designamos a Andrés como el responsable de la creación de las issues (tarjetas) en el tablero. Las issues deben ser explicativas, fáciles de entender y a su vez, deben tener asociados un conjunto de criterios de aceptación que clarifiquen el alcance de la issue (lo que se pretende hacer). Si bien Andrés será el encargado de la creación de las tarjetas, luego de creadas estas se discutirán y aclararán entre todos en la próxima ceremonia de daily stand up.
