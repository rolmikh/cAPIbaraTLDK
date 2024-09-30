WEB API 

Для разработки была использована платформа ASP.NET Core, в качестве СУБД была использована MS SQL на базе Docker, а для создания базы данных был использован подход Code First с использованием Entity Framework.

Для установки образа MS SQL необходимо выполнить следующую команду в командной строке:
docker pull mcr.microsoft.com/mssql/server:2019-latest

Для создания контейнера необходимо выполнить следующую команду в командной строке:
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=r0lmikh_pass!" -p 1433:1433 --name rolmikh_sqlserver -d mcr.microsoft.com/mssql/server:2019-latest

Для проверки состояния контейнера необходимо ввести команду 
docker ps

!!Пароль необходимо установить точно такой же, по которому проходит авторизация для пользователя sa на локальном устройстве.

Также необходимо установить другой пароль в строку подключения в файлах проекта appsettings.json и appsettings.Development.json

"ConnectionStrings": {
  "con": "Server=localhost;Database=TeledokDataBase;User Id=sa;Password=r0lmikh_pass!;TrustServerCertificate=True;MultipleActiveResultSets=true"
},

После настройки MS SQL на базе Docker необходимо обновить базу данных в проекте. Для этого в Visual Studio в консоли диспетчера пакетов необходимо выполнить следующие команды

Add-Migration InitialCreate
Update-Database
