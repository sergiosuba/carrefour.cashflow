using Xunit;
using System;
using AutoFixture.Xunit2;
using cashflow.repository;
using cashflow.domain.Entity;
using System.Threading.Tasks;

namespace Cashflow.Test.UnitTest.Repository
{
    public class AccountingEntryRepositoryTest : BaseTest
    {
        public AccountingEntryRepository accountingEntryRepository = new AccountingEntryRepository(GetApplicationRespository());

        [Theory]
        [AutoDomainDataAttribute]
        public async Task AddAsyncTest_Success(
            [Frozen] AccountingEntry accountingEntry
        )
        {
            try
            {
                //Given
                InMemoryDatabase.CreateTable<AccountingEntry>();

                //When
                await accountingEntryRepository.AddAsync(accountingEntry);

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