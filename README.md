# Song Streaming API

This is the backend API for a music streaming application, built with .NET 8. It provides CRUD operations for managing songs and other necessary endpoints to support the frontend application.

## Features

- **Song Management**
  - **Create**: Add new songs to the database.
  - **Read**: Retrieve details of a single song or a list of all songs.
  - **Update**: Modify existing song details.
  - **Delete**: Remove songs from the database.

- **Category Filtering**: Filter songs based on categories for organized browsing.

- **Search Functionality**: Search for songs by title, artist, or other criteria.

## Technologies Used

- **.NET 8**: The core framework for building the API.
- **Entity Framework Core**: For database interactions and ORM.
- **SQLite**: As the primary database for storing song data.
- **ASP.NET Core Web API**: For creating the RESTful endpoints.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Setup

1. Clone the repository:
    ```bash
    git https://github.com/fuadmuhe12/songApi
    cd songApi
    ```

2. Apply migrations to set up the database:
    ```bash
    dotnet ef database update
    ```

3. Run the application:
    ```bash
    dotnet run
    ```

### API Endpoints

- **GET /api/song**: Retrieve all songs.
- **GET /api/song/{id}**: Retrieve a song by ID.
- **POST /api/song**: Add a new song.
- **PUT /api/song/{id}**: Update an existing song.
- **DELETE /api/song/{id}**: Delete a song.

### Project Structure

- **Controllers**: Contains the API controllers that handle incoming HTTP requests.
- **Models**: Defines the data models used in the application.
- **Data**: Includes the DbContext for database interactions.
- **Repositories**: Implements the data access logic.
- **Interface**:Defines the the interfaces to be implemented by reposities

## Contributing

Contributions are welcome! Please create a pull request or submit an issue if you have any suggestions or improvements.

