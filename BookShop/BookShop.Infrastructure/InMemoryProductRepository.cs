﻿namespace BookShop.Infrastructure
{
    using BookShop.Application;
    using BookShop.Domain.ForSchool.Bags;
    using BookShop.Domain.Hobbies;
    using BookShop.Domain.Publications;

    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Publication> publications;
        private readonly List<Game> games;
        private readonly List<Bag> bags;

        public InMemoryProductRepository()
        {
            this.publications= new List<Publication>();
            this.games = new List<Game>();
            this.bags = new List<Bag>();
        }

        public void CreateBag(Bag bag)
        {
            this.bags.Add(bag);
        }

        public void CreateGame(Game game)
        {
            this.games.Add(game);
        }

        public void CreatePublication(Publication publication)
        {
            this.publications.Add(publication);
        }

        public IEnumerable<Publication> GetPublications()
        {
            return this.publications;
        }

        public Publication GetSinglePublication(int id)
        {
            return this.publications.FirstOrDefault(x => x.Id == id);
        }
    }
}
