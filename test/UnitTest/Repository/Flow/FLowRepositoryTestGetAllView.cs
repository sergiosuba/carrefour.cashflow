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
    public class FlowRepositoryTestGetAllView : BaseTest
    {
        public FlowRepository flowRepository = new FlowRepository(GetApplicationRespository());

        [Fact(Skip = "Error with Concat sqlite inmemory")]
        public async Task GetAllViewAsync_Success()
        {
            try
            {
                //Given
                var flowList = new List<Flow>();
                var chartAccountList = new List<ChartAccount>();
                var flowList = new List<Flow>();

                InMemoryDatabase.Insert(flowList);
                InMemoryDatabase.Insert(chartAccountList);
                InMemoryDatabase.Insert(flowList);


                //When
                var result = await flowRepository.GetAllViewAsync();

                //Then
                Assert.True(true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(GetAllViewAsync_Success)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }
    }
}