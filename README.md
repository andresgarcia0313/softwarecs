# Instalación de paquetes

``` bash
dotnet tool install --global dotnet-ef
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

# Crear migraciones:

``` bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

# Generación controlador MVC

Este comando genera un controlador llamado UsersController que interactúa con el modelo User previamente creado en User.cs utilizando el contexto de base de datos AppDbContext en un proyecto ASP.NET MVC con SQLite.

``` bash
dotnet aspnet-codegenerator controller -name UsersController -m User -dc AppDbContext --relativeFolderPath Controllers -udl --referenceScriptLibraries
```

# Limpiar, Compilar y Ejecutar

dotnet clean && clear && dotnet build && dotnet run

# Defecto al ejecutar y solución:

## Límite de instancias inotify alcanzado: Error System.IO.IOException

### Explicación:

El error ocurre porque el límite configurado en el sistema para instancias inotify (128) se ha alcanzado, impidiendo la creación de nuevas instancias para monitorear cambios en el sistema de archivos.

### Solución ejecutar en terminal:

``` bash
sudo sysctl fs.inotify.max_user_instances=512
```

## El navegador web pone error de SSL al ejecutar proyecto .NET Core MVC en Ubuntu

**Explicación:**
Cuando intentas ejecutar tu proyecto .NET Core MVC en Ubuntu con HTTPS activado, puedes encontrarte con un error de SSL. Este error ocurre porque el entorno de desarrollo no reconoce el certificado SSL utilizado por tu aplicación como válido, especialmente cuando se utiliza un certificado autofirmado o generado por tu computador que no está en las raíces de confianza del sistema y hay que indicarle que este archivo ssl de comunicación encriptada es valido por que es tu aplicación y funciona perfecto con chrome en futuras versiones se manejara para otros navegadores web

**Script de Solución:**

```bash
# Instalar dependencias necesarias
sudo apt-get install -y openssl

# Crear un certificado autofirmado para desarrollo
dotnet dev-certs https --clean --import
dotnet dev-certs https -ep ~/.aspnet/https/aspnetapp.pfx -p password

# Agregar el certificado al almacén de certificados confiables
sudo mkdir -p /usr/local/share/ca-certificates/extra
sudo cp ~/.aspnet/https/aspnetapp.crt /usr/local/share/ca-certificates/extra/aspnetapp.crt
sudo update-ca-certificates
```
**Fuente**

https://learn.microsoft.com/es-es/aspnet/core/security/enforcing-ssl?view=aspnetcore-8.0&tabs=visual-studio%2Clinux-ubuntu