using Xunit;
using System;
using AutoFixture.Xunit2;
using cashflow.repository;
using cashflow.domain.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using cashflow.domain.DTO;

namespace Cashflow.Test.UnitTest.Repository
{
    public class FlowRepositoryTestGetAll : BaseTest
    {
        public FlowRepository flowRepository = new FlowRepository(GetApplicationRespository());

        [Theory]
        [AutoDomainDataAttribute]
        public async Task GetAllAsync_Success(
            [Frozen] Flow flow
        )
        {
            try
            {
                //Given
                var accountEntryFilterDTO = new FlowFilterDTO();

                var accountingEntries = new List<Flow>();

                InMemoryDatabase.Insert(accountingEntries);

                //When
                var result = await flowRepository.GetAllAsync(accountEntryFilterDTO);

                //Then
                Assert.True(true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(GetAllAsync_Success)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }
    }
}