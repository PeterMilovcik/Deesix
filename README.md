# Deesix

Deesix is a text-based RPG where each playthrough is a unique journey. Set in an AI-generated fantasy world, the game offers intricate choice mechanics and a skill-based progression system. Start in a wild landscape and evolve into complex civilizations, all shaped by your decisions and actions.

## Project Structure

The solution is divided into several projects, each with its own specific role:

### Deesix.AI

- `Deesix.AI`: This project is the hub for all artificial intelligence-driven functionalities within the Deesix game. It forms a crucial part of the game's dynamic content generation system by leveraging AI models. The project directly references `Deesix.Domain` to align closely with the game's domain models. The `Deesix.AI.csproj` outlines the project settings and dependencies, targeting .NET 6.0.

    The project is organized with several C# files, each designated for a unique aspect of AI functionality:
    - `GenerateAIService.cs`: Defines the `GenerativeAIService` class, which adheres to the `IGenerativeAIService` interface from `Deesix.Domain.Interfaces`. This class is pivotal in generating AI-driven content, such as dynamic terrain and biome types, ensuring a unique gaming experience in each playthrough.
    - `OpenAIImageGenerator.cs`: Introduces the `OpenAIImageGenerator` class, responsible for creating images through the OpenAI API. This could be utilized for generating unique visual elements in the game, like terrain maps or character portraits.
    - `OpenAITextGenerator.cs`: Implements the `OpenAITextGenerator` class, tasked with generating textual content via the OpenAI API. This class plays a key role in creating rich, descriptive narratives for world tiles, enhancing the textual interface of the game.

    Each class within the `Deesix.AI` project resides in the `Deesix.AI` namespace, ensuring a clear modular structure.

    The project depends on several NuGet packages to streamline its operations:
    - `Microsoft.Extensions.DependencyInjection`: Utilized for incorporating dependency injection, facilitating a clean and testable architecture.
    - `Newtonsoft.Json.Schema` and `NJsonSchema`: Employed for JSON schema validation and generation, critical in processing and interpreting AI-generated JSON content.
    - `OpenAI-DotNet`: A pivotal package that provides the necessary interface to communicate with the OpenAI API, bridging the gap between AI capabilities and the game's content needs.

    `Deesix.AI` stands as a testament to the game's commitment to leveraging cutting-edge AI technologies, driving forward the evolution of text-based RPGs by integrating advanced content generation techniques.

### Deesix.Data

- `Deesix.Data`: This project is the backbone of the data persistence layer for the Deesix application, managing all data operations. It establishes a direct reference to the `Deesix.Domain` project, ensuring seamless interaction with the domain models. The `Deesix.Data.csproj` file details the project's settings and dependencies, and it targets .NET 6.0.

    The project is structured with various C# files, each dedicated to specific data handling functionalities:
    - `Configuration\ServiceCollectionExtensions.cs`: Defines the `ServiceCollectionExtensions` class, which provides extension methods for the `IServiceCollection` interface. These methods play a crucial role in registering the data services within the dependency injection container, promoting a clean and modular architecture.
    - `Repositories\GameRepository.cs`: Implements the `GameRepository` class, adhering to the `IGameRepository` interface from `Deesix.Domain.Interfaces`. This repository centralizes data operations for game entities, encapsulating CRUD actions and other data interactions.
    - `Repositories\WorldTileRepository.cs`: This file introduces the `WorldTileRepository` class, aligning with the `IWorldTileRepository` interface. It manages data operations specifically for `WorldTile` entities, such as retrieving, creating, and updating world tiles in the context of the game's dynamic world generation.
    - `Context\DeesixDbContext.cs`: Defines the `DeesixDbContext` class, an EF Core DbContext, which serves as the primary liaison between the application and the database. It includes `DbSet` properties for each entity, including `WorldTile`, facilitating ORM capabilities and database interactions.
  
    The `Deesix.Data` project is pivotal in the overall application structure, ensuring robust and efficient data management. It underpins the persistence requirements of the application, interfacing directly with the database and serving as a crucial link in the application's data flow.

### Deesix.Domain

- `Deesix.Domain`: This project contains the domain models and business logic integral to the Deesix game. The `Deesix.Domain.csproj` file specifies project settings and dependencies, targeting .NET 6.0.

    The project hosts several C# files, each responsible for specific domain functionalities:
    - `Entities\Game.cs`: Defines the `Game` class, representing the core game entity.
    - `Entities\WorldTile.cs`: Represents individual tiles in the game world, including properties for terrain, biome, and position.
    - `Entities\Biome.cs`: Encapsulates the details of different biomes in the game.
    - `Entities\Terrain.cs`: Details the various terrain types found within the game world.

    The project is organized into directories for clarity and structure:
    - `Entities`: Contains the domain entities, forming the primary business objects. This includes `Game`, `WorldTile`, `Biome`, and `Terrain`.
    - `Interfaces`: Houses interfaces that define contracts for various services and repositories, crucial for data operations and business logic implementation.

    `Deesix.Domain` is a cornerstone project, referenced by other components in the solution, including `Deesix.AI` for AI-driven content generation, `Deesix.Data` for data management, `Deesix.GameMechanics` for gameplay logic, `Deesix.Test` for testing various functionalities, and `Deesix.Web` for web interface interactions.

### Deesix.GameMechanics

- `Deesix.GameMechanics`: This project manages the core game mechanics and logic of Deesix. It directly references the `Deesix.Domain` project, ensuring tight integration with the game's domain models. The `Deesix.GameMechanics.csproj` file outlines the project's settings and dependencies, targeting .NET 6.0.

    The project encompasses a range of C# files, each tailored to specific aspects of game mechanics:
    - `Configuration\ServiceCollectionExtensions.cs`: Defines `ServiceCollectionExtensions`, a class hosting extension methods for `IServiceCollection`. These methods facilitate the registration of game mechanics services within the dependency injection container, ensuring modularity and maintainability.
    - `Services\GameService.cs`: Implements the `GameService` class, which encapsulates operations related to gameplay, such as player actions, game state management, and interaction rules.
    - `Services\WorldGenerationService.cs`: This file introduces the `WorldGenerationService` class, responsible for dynamically generating and managing world tiles based on player exploration and game events. It plays a pivotal role in creating an immersive and evolving game world.
    - `Services\WorldTileNeighborGenerator.cs`: Contains the logic for generating neighboring tiles in the game world, ensuring consistency and coherence with the game's procedural generation principles.

    `Deesix.GameMechanics` stands as a fundamental component within the solution, underpinning the game's interactive elements. It is also integral to the unit testing framework, as denoted by its reference in the `Deesix.Test` project, ensuring that game mechanics are thoroughly vetted and reliable.

### Deesix.Test

- `Deesix.Test`: This project is dedicated to maintaining the quality and integrity of the Deesix application through comprehensive unit testing. It is an essential component of the software development lifecycle, ensuring that all features and functionalities meet the expected standards. The project, defined in `Deesix.Test.csproj`, includes references to all other projects in the solution, allowing for thorough testing across the entire application. It is configured to target .NET 6.0.

    The project is structured with various C# files, each focused on testing different aspects of the application:
    - `AI\OpenAIImageGeneratorTests.cs`: Hosts the `OpenAIImageGeneratorTests` class, containing unit tests specifically designed for the `OpenAIImageGenerator` class within the `Deesix.AI` project. These tests validate the functionality and reliability of the image generation process.
    - `AI\OpenAITextGeneratorTests.cs`: Comprises the `OpenAITextGeneratorTests` class, dedicated to testing the `OpenAITextGenerator` class from the `Deesix.AI` project. This ensures the accuracy and effectiveness of AI-driven text generation.
    - `Data\WorldTileRepositoryTests.cs`: Introduces tests for the `WorldTileRepository` class from the `Deesix.Data` project, verifying the data persistence mechanisms related to world tiles.
    - `GameMechanics\WorldGenerationServiceTests.cs`: Contains tests for the `WorldGenerationService` class in the `Deesix.GameMechanics` project, assessing the logic and algorithms used in dynamic world generation.
    - `TestFixture.cs`: Defines the `TestFixture` class, which sets up a shared test environment and common configurations for all unit tests. This class plays a pivotal role in ensuring consistency and efficiency in the testing process.

    `Deesix.Test` is a critical part of the Continuous Integration/Continuous Deployment (CI/CD) pipeline. It is automatically invoked to run all unit tests as part of the build process, guaranteeing that every iteration of the application is rigorously evaluated for quality and stability.

### Deesix.Web

- `Deesix.Web`: This project forms the front-facing component of the Deesix game, encompassing the web application, user interface, and web server functionalities. It acts as the primary entry point for players when the application is deployed. The `Deesix.Web.csproj` file delineates the project's specific settings and dependencies, targeting .NET 6.0 for robust web app development.

    The project's structure is defined through a series of C# files, each catering to distinct aspects of the web application:
    - `Controllers\HomeController.cs`: Defines the `HomeController` class, responsible for handling HTTP requests directed to the game's home page. It acts as a central point for directing user interactions within the web interface.
    - `Controllers\WorldTileController.cs`: Introduces the `WorldTileController` class, which manages HTTP requests related to world tile interactions, such as retrieving specific tiles or triggering the generation of new ones. It serves as a vital link between the game's backend mechanics and the player's frontend experience.
    - `Startup.cs`: Implements the `Startup` class, essential for configuring services and setting up the application's request pipeline. This class is pivotal in initializing and tying together various components of the web app, such as dependency injection, middleware, and routing.

    Additionally, the project includes key directories integral to the web application's structure and presentation:
    - `Views`: Houses the Razor view files, which are instrumental in defining the HTML content delivered to the client. These views render the game's user interface, presenting an engaging and interactive visual experience.
    - `wwwroot`: Contains static files crucial for the web app's presentation layer, including CSS for styling, JavaScript for client-side interactivity, and images that enrich the visual aesthetics.

    `Deesix.Web` stands as the gateway through which players interact with the Deesix game, providing a seamless and immersive web-based gaming experience. It leverages the capabilities of .NET 6.0 and utilizes `Microsoft.Extensions.DependencyInjection` for effective dependency management, ensuring a cohesive and scalable web application.

