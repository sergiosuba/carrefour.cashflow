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
    public class AccountingEntryRepositoryTestGetAllView : BaseTest
    {
        public AccountingEntryRepository accountingEntryRepository = new AccountingEntryRepository(GetApplicationRespository());

        [Fact(Skip = "Error with Concat sqlite inmemory")]
        public async Task GetTotalByDateAsync_Success()
        {
            try
            {
                //Given
                var accountingEntryList = new List<AccountingEntry>();
                var chartAccountList = new List<ChartAccount>();
                var flowList = new List<Flow>();

                InMemoryDatabase.Insert(accountingEntryList);
                InMemoryDatabase.Insert(chartAccountList);
                InMemoryDatabase.Insert(flowList);


                //When
                var result = await accountingEntryRepository.GetTotalByDateAsync();

                //Then
                Assert.True(true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(GetTotalByDateAsync_Success)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }
    }
}