using Xunit;
using System;
using AutoFixture.Xunit2;
using cashflow.repository;
using cashflow.domain.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Cashflow.Test.UnitTest.Repository
{
    public class FlowRepositoryTestGetById : BaseTest
    {
        public FlowRepository flowRepository = new FlowRepository(GetApplicationRespository());

        [Theory]
        [AutoDomainDataAttribute]
        public async Task GetByIdAsync_Success(
            [Frozen] Flow flow
        )
        {
            try
            {
                //Given
                var accountingEntries = new List<Flow>();

                InMemoryDatabase.Insert(accountingEntries);

                //When
                var result = await flowRepository.GetByIdAsync(flow.id);

                //Then
                Assert.True(true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(GetByIdAsync_Success)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }
    }
}