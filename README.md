# Deesix

Deesix is a text-based RPG where each playthrough is a unique journey. Set in an AI-generated fantasy world, the game offers intricate choice mechanics and a skill-based progression system. Start in a wild landscape and evolve into complex civilizations, all shaped by your decisions and actions.

## Project Structure

The solution is divided into several projects, each with its own specific role:

### Deesix.AI

- `Deesix.AI`: This project is responsible for all AI-related functionalities. It references the `Deesix.Domain` project. The project file is `Deesix.AI.csproj`, which specifies the project's settings and dependencies. It targets .NET 6.0.

    The project contains several C# files, each implementing a specific functionality:
    - `GenerateAIService.cs`: This file defines the `GenerativeAIService` class, which implements the `IGenerativeAIService` interface from the `Deesix.Domain.Interfaces` namespace. This service is responsible for generating AI content.
    - `OpenAIImageGenerator.cs`: This file defines the `OpenAIImageGenerator` class, which is responsible for generating images using the OpenAI API.
    - `OpenAITextGenerator.cs`: This file defines the `OpenAITextGenerator` class, which is responsible for generating text using the OpenAI API.

    All classes in the `Deesix.AI` project are in the `Deesix.AI` namespace.

    The project uses several NuGet packages, including `Microsoft.Extensions.DependencyInjection` for dependency injection, `Newtonsoft.Json.Schema` for JSON schema validation, `NJsonSchema` for JSON schema generation, and `OpenAI-DotNet` for interacting with the OpenAI API.

### Deesix.Data

- `Deesix.Data`: This project handles all data-related operations and is responsible for the persistence layer of the application. It references the `Deesix.Domain` project. The project file is `Deesix.Data.csproj`, which specifies the project's settings and dependencies. It targets .NET 6.0.

    The project contains several C# files, each implementing a specific functionality:
    - `Configuration\ServiceCollectionExtensions.cs`: This file defines the `ServiceCollectionExtensions` class, which contains extension methods for the `IServiceCollection` interface. These methods are used to register the data services with the dependency injection container.
    - `Repositories\GameRepository.cs`: This file defines the `GameRepository` class, which implements the `IGameRepository` interface from the `Deesix.Domain.Interfaces` namespace. This repository is responsible for performing data operations related to the game entities.

### Deesix.Domain

- `Deesix.Domain`: This project contains the domain models and business logic. The project file is `Deesix.Domain.csproj`, which specifies the project's settings and dependencies. It targets .NET 6.0.

    The project contains several C# files, each implementing a specific functionality:
    - `Entities\Game.cs`: This file defines the `Game` class, which represents the game entity in the domain model.

    The project also contains several directories:
    - `Entities`: This directory contains the domain entities, which are the main business objects of the application.
    - `Interfaces`: This directory contains the interfaces that define the contracts for the services and repositories.

    The `Deesix.Domain` project is referenced by other projects in the solution, including `Deesix.AI`, `Deesix.Data`, `Deesix.GameMechanics`, `Deesix.Test`, and `Deesix.Web`.

### Deesix.GameMechanics

- `Deesix.GameMechanics`: This project is responsible for the game mechanics. It references the `Deesix.Domain` project. The project file is `Deesix.GameMechanics.csproj`, which specifies the project's settings and dependencies. It targets .NET 6.0.

    The project contains several C# files, each implementing a specific functionality:
    - `Configuration\ServiceCollectionExtensions.cs`: This file defines the `ServiceCollectionExtensions` class, which contains extension methods for the `IServiceCollection` interface. These methods are used to register the game mechanics services with the dependency injection container.
    - `Services\GameService.cs`: This file defines the `GameService` class, which implements game-related operations.

    The `Deesix.GameMechanics` project is referenced by other projects in the solution, including `Deesix.Test`.

### Deesix.Test

- `Deesix.Test`: This project contains all the unit tests for the solution. It references all other projects. The project file is `Deesix.Test.csproj`, which specifies the project's settings and dependencies. It targets .NET 6.0.

    The project contains several C# files, each implementing a specific functionality:
    - `AI\OpenAIImageGeneratorTests.cs`: This file defines the `OpenAIImageGeneratorTests` class, which contains unit tests for the `OpenAIImageGenerator` class in the `Deesix.AI` project.
    - `AI\OpenAITextGeneratorTests.cs`: This file defines the `OpenAITextGeneratorTests` class, which contains unit tests for the `OpenAITextGenerator` class in the `Deesix.AI` project.
    - `TestFixture.cs`: This file defines the `TestFixture` class, which sets up the common test environment for all tests.

    The `Deesix.Test` project is referenced by the CI/CD pipeline to run the unit tests as part of the build process.

### Deesix.Web

- `Deesix.Web`: This is the web application project. It contains the user interface and web server. The project file is `Deesix.Web.csproj`, which specifies the project's settings and dependencies. It targets .NET 6.0.

    The project contains several C# files, each implementing a specific functionality:
    - `Controllers\HomeController.cs`: This file defines the `HomeController` class, which handles HTTP requests to the home page.
    - `Startup.cs`: This file defines the `Startup` class, which configures services and the app's request pipeline.

    The project also contains several directories:
    - `Views`: This directory contains the Razor view files, which define the HTML to be sent to the client.
    - `wwwroot`: This directory contains static files, such as CSS, JavaScript, and images.

    The `Deesix.Web` project is the entry point of the application when deployed.

Each project is a .NET 6.0 project and uses the `Microsoft.Extensions.DependencyInjection` package for dependency injection.

