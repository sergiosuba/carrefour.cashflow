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
                var flowFilterDTO = new FlowFilterDTO();

                var flows = new List<Flow>();

                InMemoryDatabase.Insert(flows);

                //When
                var result = await flowRepository.GetAllAsync(flowFilterDTO);

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