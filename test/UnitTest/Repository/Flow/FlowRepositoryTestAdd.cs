using Xunit;
using System;
using AutoFixture.Xunit2;
using cashflow.repository;
using cashflow.domain.Entity;
using System.Threading.Tasks;

namespace Cashflow.Test.UnitTest.Repository
{
    public class FlowRepositoryTest : BaseTest
    {
        public FlowRepository flowRepository = new FlowRepository(GetApplicationRespository());

        [Theory]
        [AutoDomainDataAttribute]
        public async Task AddAsyncTest_Success(
            [Frozen] Flow flow
        )
        {
            try
            {
                //Given
                InMemoryDatabase.CreateTable<Flow>();

                //When
                await flowRepository.AddAsync(flow);

                //Then
                Assert.True(true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(AddAsyncTest_Success)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }
    }
}