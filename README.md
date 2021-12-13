# ProjectLinbis

_.NET Core: Project API Service - Interview Take Home Assignment by José Manuel Salazar Sosa_

## Comenzando 🚀

_Como se solicta en las instrucciones construí un total de 3 proyectos: WebApi, Services y XUnitTestProject1_

### Instalación 🔧

_Solo basta con descargar el proyecto y ejecutar en tu maquina, el proyecto de inicio es la WebAppi_

_Hay dos archivos .json: Developers y Projects que es donde guardo el modelo de datos_

```
  {
    "id": 1,
    "name": "Jose",
    "projectId": 1,
    "addedDate": "2021-12-11T14:48:15.3226333-06:00",
    "costByDay": 750.0
  },
  {
    "id": 2,
    "name": "Yessica",
    "projectId": 2,
    "addedDate": "2021-12-11T14:48:15.3226333-06:00",
    "costByDay": 750.0
  }
```
```
  {
    "id": 1,
    "name": "Project 1",
    "isActive": true,
    "addedDate": "2021-12-01T14:45:06.6019156-06:00",
    "effortRequireInDays": 30,
    "developmentCost": 0.0,
    "developers": null
  },
  {
    "id": 2,
    "name": "Project 2",
    "isActive": true,
    "addedDate": "2021-12-02T14:45:06.6144586-06:00",
    "effortRequireInDays": 25,
    "developmentCost": 0.0,
    "developers": null
  }
```

## Ejecutando las pruebas ⚙️

### GET Tests 🔩

_La primera prueba es para obtener un Proyecto y los desarrolladores que estas asginados a él a partir del ID del proyecto. 
Obteniendo el código 200 (Ok Result) como respuesta_

```
        [Fact]
        public void GetProject_Ok()
        {
            var okResult = projectsController.GetProjects(3);

            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
```

_La segunda prueba es para obtener un Proyecto y los desarrolladores que estas asginados a él a partir del ID del proyecto 
pero esta vez obteniendo el código 404 (Not Found) como respuesta._

```
        [Fact]
        public void GetProject_NotFound()
        {
            var notFoundResult = projectsController.GetProjects(4654);

            Assert.IsType<NotFoundResult>(notFoundResult as NotFoundResult);
        }
```

### DELETE Tests 🔩

_La tercera prueba es para eliminar un proyecto obteniendo el codigo de respuesta 204 (No Content)_

```
        [Fact]
        public void DeleteProject_NoContent()
        {
            var noContent = projectsController.DeleteProject(10);

            Assert.IsType<NotFoundResult>(noContent as NotFoundResult);
        }
```

_La cuarta prueba es para eliminar un proyecto pero sin éxito, obteniendo el codigo de respuesta 404 (No found)_

```
        [Fact]
        public void DeleteProject_NotFound()
        {
            var notFoundResult = projectsController.DeleteProject(654);

            Assert.IsType<NotFoundResult>(notFoundResult as NotFoundResult);
        }
```

### POST Tests 🔩

_La quinta prueba es para dar de alta un nuevo desarrollador asignandole un proyecto, obteniendo el codigo de respuesta 201 (Created)_

```
        [Fact]
        public void PostDeveloper_Created()
        {
            Random random = new Random();
            Developer developer = new Developer
            {
                id = random.Next(99999),
                name = "Test1",
                addedDate = DateTimeOffset.Now,
                costByDay = 300
            };

            var createdResult = developersController.PostDeveloper(developer, 3);

            Assert.IsType<StatusCodeResult>(createdResult as StatusCodeResult);
        }
```

_La sexta prueba es para dar de alta un desarrollador nuevo pero pasando como parametro un id de proyecto que no existe,
obteniendo el codigo de respuesta 404 (No found)_

```
        [Fact]
        public void PostDeveloper_NotFound_IdProject()
        {
            Developer developer = new Developer
            {
                id = 6,
                name = "Test1",
                addedDate = DateTimeOffset.Now,
                costByDay = 300
            };

            var notFoundResult = developersController.PostDeveloper(developer, 1234432);

            Assert.IsType<NotFoundResult>(notFoundResult as NotFoundResult);
        }
```
_La septima prueba es para dar de alta un desarrollador nuevo pero pasando como parametro un id ya existente,
obteniendo el codigo de respuesta 404 (No found)_

```
        [Fact]
        public void PostDeveloper_NotFound_Id_Repeated()
        {
            Developer developer = new Developer
            {
                id = 1,
                name = "Test1",
                addedDate = DateTimeOffset.Now,
                costByDay = 300
            };

            var notFoundResult = developersController.PostDeveloper(developer, 1);

            Assert.IsType<NotFoundResult>(notFoundResult as NotFoundResult);
        }
```

## Construido con 🛠️

_Proyecto desarrollado con .Net Core 3.1 y en Visual Studio 2019, también utilice Postman para realizar pruebas._

## Independientemente del resultado les agradezco mucho por la oportunidad brindada. 🎁
