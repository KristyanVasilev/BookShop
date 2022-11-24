﻿namespace BookShop.Application.Contracts
{
    using BookShop.Domain.Hobbies;

    public interface IGameRepository
    {
        void CreateGame(Game game);

        string DeleteGame(int id);

        Game GetSingleGame(int id);

        IEnumerable<Game> GetGames();
    }
}
