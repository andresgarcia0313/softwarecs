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

**Explicación del Error:**
Cuando intentas ejecutar tu proyecto .NET Core MVC en Ubuntu con HTTPS activado, puedes encontrarte con un error de SSL. Este error ocurre porque el entorno de desarrollo no reconoce el certificado SSL utilizado por tu aplicación como válido, especialmente cuando se utiliza un certificado autofirmado o generado por tu computador que no está en las raíces de confianza del sistema y hay que indicarle que este archivo ssl de comunicación encriptada es valido por que es tu aplicación y funciona perfecto con chrome en futuras versiones se manejara para otros navegadores web

**Script de Solución:**

1. **Generación del Certificado SSL:**

   ```bash
   # Genera un certificado SSL autofirmado utilizando OpenSSL
   openssl req -x509 -nodes -newkey rsa:2048 -keyout localhost.key -out localhost.crt -days 365
   ```

2. **Agrega el Certificado a las Raíces de Confianza:**

   ```bash
   # Copia el certificado a la carpeta de certificados confiables
   sudo cp localhost.crt /usr/local/share/ca-certificates/

   # Actualiza los certificados confiables del sistema
   sudo update-ca-certificates
   ```

3. **Configuración del Proyecto .NET Core:**

   - Abre tu archivo `launchSettings.json` en la carpeta `Properties` de tu proyecto .NET Core.
   - Asegúrate de que la configuración de desarrollo (`Development`) esté configurada para usar HTTPS y el certificado generado:

     ```json
     {
       "profiles": {
         "YourProjectName": {
           "commandName": "Project",
           "launchBrowser": true,
           "applicationUrl": "https://localhost:5001",
           "environmentVariables": {
             "ASPNETCORE_ENVIRONMENT": "Development"
           }
         }
       }
     }
     ```

     - Ajusta `"YourProjectName"` y el puerto según tu configuración específica.

4. **Ejecución del Proyecto:**

   - Al ejecutar tu proyecto .NET Core en Ubuntu, ahora deberías poder acceder a él a través de HTTPS sin errores de certificado SSL.

Este script proporciona los pasos necesarios para generar un certificado SSL autofirmado, agregarlo a las raíces de confianza de Ubuntu y configurar correctamente tu proyecto .NET Core para usar HTTPS, asegurando que se ejecute sin problemas de SSL en tu entorno de desarrollo.