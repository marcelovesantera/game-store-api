# GameStore API

GameStore API is a RESTful API developed with **ASP.NET Core 8.0** and **Entity Framework Core** to manage games and genres. It uses **SQLite** as the database and Minimal APIs for simple and direct endpoint definitions.

## Technologies Used

- **ASP.NET Core 8.0**
- **Entity Framework Core 9.0.2**
- **SQLite**
- **Minimal APIs**

## Features

- Game Management
  - Create, list, update, and delete games
- Genre Management
  - Create, list, update, and delete genres

## Project Structure

```
GameStore.API/
│-- Data/
│   ├── Migrations/
│   │   ├── (Migrations Files)
│   ├── GameStoreContext.cs
│   ├── DataExtensions.cs
│-- Dtos/
│   ├── CreateGameDto.cs
│   ├── CreateGenreDto.cs
│   ├── GameDetailsDto.cs
│   ├── GameSummaryDto.cs
│   ├── GenreDto.cs
│   ├── UpdateGameDto.cs
│   ├── UpdateGenreDto.cs
│-- Endpoints/
│   ├── GamesEndpoints.cs
│   ├── GenresEndpoints.cs
│-- Entities/
│   ├── Game.cs
│   ├── Genre.cs
│-- Mapping/
│   ├── GameMapping.cs
│   ├── GenreMapping.cs
│-- Properties/
│   ├── launchSettings.json
│-- appsettings.json
│-- appsettings.Development.json
│-- games.http
│-- GameStore.db
│-- Program.cs
│-- GameStore.API.csproj
```

## How to Run the Project

### 1. Clone the Repository

```sh
git clone https://github.com//GameStore.API.git
cd GameStore.API
```

### 2. Configure the Database

Ensure the connection string in `appsettings.json` is correctly set:

```json
"ConnectionStrings": {
  "GameStore": "Data Source=GameStore.db"
}
```

### 3. Restore Dependencies

```sh
dotnet restore
```

### 4. Apply Migrations and Initialize the Database

```sh
dotnet ef database update
```

### 5. Run the API

```sh
dotnet run
```

The API will be available at `http://localhost:5086`.

## Available Endpoints

### Games

- `GET /games` - List all games
- `GET /games/{id}` - Get a game by ID
- `POST /games` - Add a new game
- `PUT /games/{id}` - Update an existing game
- `DELETE /games/{id}` - Remove a game

### Genres

- `GET /genres` - List all genres
- `GET /genres/{id}` - Get a genre by ID
- `POST /genres` - Add a new genre
- `PUT /genres/{id}` - Update an existing genre
- `DELETE /genres/{id}` - Remove a genre
