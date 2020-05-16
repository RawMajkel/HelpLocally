# HelpLocally

**Autor**: Michał Droździk<br/>
**Platforma**: .NET Core 3.1.4<br/>
**Projekt**: Razor Pages

## Screenshoty

`Index` - widok domyślny aplikacji

![alt text](https://screen.proudmedia.eu/v2new/msedge_2020-05-16_16-36-36.jpg)

`Register` - widok rejestracji użytkowników

![alt text](https://screen.proudmedia.eu/v2new/msedge_2020-05-16_16-37-00.jpg)

`Users list` - lista wszystkich użytkowników

![alt text](https://screen.proudmedia.eu/v2new/msedge_2020-05-16_16-38-44.jpg)

`Companies list` - lista wszystkich firm (każda firma ma właściciela)

![alt text](https://screen.proudmedia.eu/v2new/msedge_2020-05-16_16-40-29.jpg)

`Create offer` - widok tworzenia oferty / vouchera przez właściciela firmy

![alt text](https://screen.proudmedia.eu/v2new/msedge_2020-05-16_16-41-39.jpg)

`Offers list` - widok ofert, stworzonych przez przedsiębiorcę

![alt text](https://screen.proudmedia.eu/v2new/msedge_2020-05-16_16-43-32.jpg)

`Offers` - czyli jak klient widzi oferty (wszystkie w systemie)

![alt text](https://screen.proudmedia.eu/v2new/msedge_2020-05-16_16-45-00.jpg)

## Baza danych (docker)

W folderze `HelpLocally` (z plikiem `HelpLocally.sln` i `docker-compose.dev.yml`)
    
    docker-compose -f docker-compose.dev.yml up -d

## Migracje

W folderze `HelpLocally/HelpLocally.Infrastructure`

### Generowanie migracji

    dotnet ef migrations add NazwaMigracji -s ../HelpLocally.Web/

### Update bazy danych 

    dotnet ef database update -s ../HelpLocally.Web/
