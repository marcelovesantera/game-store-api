using GameStore.API.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new GameDto(1, "The Witcher 3", "RPG", "The Witcher 3: Wild Hunt is a story-driven open world RPG set in a visually stunning fantasy universe full of meaningful choices and impactful consequences.", 29.99m, new DateOnly(2015, 5, 19)),
    new GameDto(2, "Cyberpunk 2077", "RPG", "Cyberpunk 2077 is an open-world, action-adventure story set in Night City, a megalopolis obsessed with power, glamour and body modification.", 59.99m, new DateOnly(2020, 12, 10)),
    new GameDto(3, "The Elder Scrolls V: Skyrim", "RPG", "The Elder Scrolls V: Skyrim is an open world action role-playing video game developed by Bethesda Game Studios and published by Bethesda Softworks.", 19.99m, new DateOnly(2011, 11, 11)),
    new GameDto(4, "Grand Theft Auto V", "Action", "Grand Theft Auto V is a 2013 action-adventure game developed by Rockstar North and published by Rockstar Games.", 29.99m, new DateOnly(2013, 9, 17)),
    new GameDto(5, "Red Dead Redemption 2", "Action", "Red Dead Redemption 2 is a 2018 action-adventure game developed and published by Rockstar Games.", 39.99m, new DateOnly(2018, 10, 26))
];

// GET /games
app.MapGet("/games", () => games);

// GET /games/{id}
app.MapGet("/games/{id}", (int id) => games.Find(g => g.Id == id));

app.Run();
