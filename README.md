
# Support App

## Introducción 

Una compañia ha tomado la decisión de crear una herramienta de gestión de proyectos con la cuál puedan desbancar a empresas como Trello o Jira. Por el momento, como desarrolladores/as backends, nos han pedido un MVP de una API REST con el cuál podamos administrar nuestras tareas, proyectos y usuarios.

## Requerimientos funcionales

- Los proyectos deben de tener al menos una tarea asociada
- Los proyecto deben tener fecha inicial y fecha de finalización tiene que actualizarse con la fecha fin de la última tarea.
- Las tareas pueden tener un mismo nombre en diferentes proyectos
- Las tareas deben tener fecha de inicio y fecha de finalización
- Las tareas deben tener una forma de identificar si están realizadas o no
- Las tareas serán genericas y existiran previamente
- Las personas solo pueden realizar una tarea a la vez
- Las personas pueden tener varios roles dentro de los proyectos
- Las personas usuarias pueden asignarse a una tarea con un rol. Cuando se asigna a una tarea se actualiza el proyecto y fecha de inicio.
- Una persona usuaria puede finalizar una tarea que tenga asignada
- Las personas usuarias no pueden asignarse a un proyecto
- El usuario Administrador asignará a las personas ha al menos a un proyecto


## Requerimientos técnicos
- Incluir Repository Pattern
- Incluir LINQ
- Incluir AutoMapper
- Incluir Validaciones
- Incluir Gestión de errores
- Incluir testing con XUnit
- Incluir Autorización y autentificación
- Incluir Docker
- Incluir servicios customs
- Incluir diseño de base de datos
- Incluir cargar base datos

## Modalidad pedagógica
- Proyecto individual
- Desarollo en 3 sprints
- Fecha de finalización: 21/06

## Primera sprint (martes 11/06)
- Se debe entregar:
  - Crud de proyectos,
  - Repository de proyectos
  - Base de datos
  - Bonus track:
    - AutoMapper
    - Deploy en Azure
    - Testing

## Segundo sprint (lunes 17/06)
- Se debe entregar:
  - Crud de tareas y personas
  - AutoMapper
  - CORS
  - Relaciones entre tablas
  - Servicios customs
  - Bonus track:
    - Validaciones
    - Errores
    - Testing

## Tercer sprint (Viernes 21/06)
-  Se debe entregar
   - Autorización y autentificación
   - Testing
   - Validaciones
   - Errores
   - Bonus track:
     - Dockerizar el proyecto

## Evaluación
- Vía pull-request en Classroom

## Entregables
- Repositorio Github:
  - Readme con índice,contenido del repositorio, las tecnologías utilizadas, links a los recursos.
  - Modelo lógico de la base de datos.
  - Fichero de dump de la base de datos.
  - Instrucciones de instalación de la aplicación






