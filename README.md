<h1>Gestión Tareas</h1>
<p>Proyecto de prueba técnica</p>
<p>Desarrollar una aplicación de gestión de tareas que incluya tanto el backend como el frontend. El candidato debe demostrar su capacidad para estructurar un backend eficiente y aplicar conceptos de desarrollo en el frontend.</p>

# Solución Backend

 <p>Proyecto en Net Core 8</p>
 <p>BD: SQLite</p>

<p>En la API se implementó lo siguiente:</p> 

 <li>Swagger para la documentación</li>
 <li>JWT Berer para la seguridad </li>
 <li>FluentValidation para las validaciones de entrada </li>
 <li>SQLite para los datos en memoria </li>
 <li>Serilog para el registro de errores</li>
 <br>
<p>Se trabajó bajo buenas prácticas de desarrollo implementando el modelo DDD, separando la lógica de los controladores e implementado la capa de Infraestructura para la persistencia de los datos</p>
<p>Se hicieron dos pruebas unitarias para validar la respuesta Ok 200 del Login y para validar que el token venga dentro de la respuesta (body)</p>

 ![Angular](https://img.shields.io/badge/-dotnet-333333?style=flat&logo=dotnet)

# Solución Front
 <p>Proyecto en Angular </p> 
 <p>v: 18</p>
 <p>Se importo el componente de Google Materialize, se crearon los ambientes, se creo el servicio de tareas y se agrego el componente de carga de tabla ppal</p>
 
 ![Angular](https://img.shields.io/badge/-Angular-333333?style=flat&logo=angular)

# Instrucciones para ejecutar proyectos
 <p>Clonar el repo:  https://github.com/cm8064/GestionTareas.git </p>
 <p>Rama main</p>
 <p>Para ejecutar el backend haga: dotnet run</p>
 <p>En la ubicación: GestionTareas\GestionTareas.Api\</p>
 
 <p>Para ejecutar el angular del frontend haga: npm start ó ng serve -o</p>
 <p>En la ubicación: GestionTareas\GestionTareas.Portal\</p>
