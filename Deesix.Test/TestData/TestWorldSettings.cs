using Deesix.Domain.Entities;

public class TestWorldSettings : WorldSettings
{
    public TestWorldSettings()
    {
        Id = 1;
        GameId = 2;
        Name = "Test World";
        Description = "Test Description";
        Theme = "Test Theme";   
    }
}