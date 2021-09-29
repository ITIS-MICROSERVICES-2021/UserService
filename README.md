# ITIS_2021_2_UserService

## **Предусловие**

Должны быть установлены:

* .NET 5 [download](https://dotnet.microsoft.com/download/dotnet/5.0)
* PostgreSQL [download](https://www.postgresql.org/download/)

## **Как запустить?**

1. Отредактируйте строку подключения к базе данных в `appsettings.json`
2. Из корня проекта откройте терминал и используйте команду `dotnet ef database update -s UserService.Webhost -p UserService.Data`
3. Откройте файл `UserService.sln` в Rider/Visual Studio
4. Запустите
5. https://localhost:17001/swagger