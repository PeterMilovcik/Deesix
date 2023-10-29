using Deesix.GameMechanics;
using Microsoft.Extensions.DependencyInjection;

namespace Deesix.Test;

public class TestFixture
{
    protected ServiceProvider ServiceProvider { get; private set; }

    [SetUp]
    public virtual void SetUp()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddGameMechanicsServices();
        serviceCollection.AddTestServices();
        ServiceProvider = serviceCollection.BuildServiceProvider();
    }
}
