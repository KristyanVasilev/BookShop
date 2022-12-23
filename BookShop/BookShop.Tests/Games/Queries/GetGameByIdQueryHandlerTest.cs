﻿namespace BookShop.Tests.Games.Queries
{
    using BookShop.Application.Games;
    using BookShop.Application.Games.Queries.GetGameById;
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using BookShop.Tests.Mocks;

    using Moq;
    using Shouldly;
    using Xunit;

    public class GetGameByIdQueryHandlerTest
    {
        private readonly Mock<IDeletableEntityRepository<Game>> mockRepo;
        private readonly Mock<IRepository<Genre>> genreMockRepo;

        public GetGameByIdQueryHandlerTest()
        {
            this.mockRepo = GameMockRepository.GetGameMockRepo();
            this.genreMockRepo = GenreMockRepository.GetGenreMockRepo();
        }

        [Fact]
        public async Task GetGameByIdTest()
        {
            var handler = new GetGameByIdHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            var result = await handler.Handle(new GetGameByIdQuery(1), CancellationToken.None);

            result.ShouldBeOfType<GameDto>();
        }

        [Fact]
        public async Task ShouldntChangeRepoCountTest()
        {
            var handler = new GetGameByIdHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            var result = await handler.Handle(new GetGameByIdQuery(1), CancellationToken.None);

            var count = this.mockRepo.Object.All().Count();

            Assert.True(count == 2);
        }

        [Fact]
        public async Task ShouldThrowGameNotFoundExceptionTest()
        {
            var handler = new GetGameByIdHandler(this.mockRepo.Object, this.genreMockRepo.Object);

            await Assert.ThrowsAsync<GameNotFoundException>(() =>
            handler.Handle(new GetGameByIdQuery(12321), CancellationToken.None));
        }
    }
}
