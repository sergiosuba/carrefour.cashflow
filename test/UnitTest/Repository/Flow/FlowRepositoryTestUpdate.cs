using Xunit;
using System;
using AutoFixture.Xunit2;
using cashflow.repository;
using cashflow.domain.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Cashflow.Test.UnitTest.Repository
{
    public class FlowRepositoryTestUpdate : BaseTest
    {
        public FlowRepository flowRepository = new FlowRepository(GetApplicationRespository());

        [Theory]
        [AutoDomainDataAttribute]
        public async Task UpdateAsync_Success(
            [Frozen] Flow flow
        )
        {
            try
            {
                //Given
                var accountingEntries = new List<Flow>();

                InMemoryDatabase.Insert(accountingEntries);

                //When
                var result = await flowRepository.UpdateAsync(flow);

                //Then
                Assert.True(true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(UpdateAsync_Success)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }
    }
}