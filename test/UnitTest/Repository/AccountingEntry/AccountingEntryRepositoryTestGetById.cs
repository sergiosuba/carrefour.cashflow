using Xunit;
using System;
using AutoFixture.Xunit2;
using cashflow.repository;
using cashflow.domain.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Cashflow.Test.UnitTest.Repository
{
    public class AccountingEntryRepositoryTestGetById : BaseTest
    {
        public AccountingEntryRepository accountingEntryRepository = new AccountingEntryRepository(GetApplicationRespository());

        [Theory]
        [AutoDomainDataAttribute]
        public async Task GetByIdAsync_Success(
            [Frozen] AccountingEntry accountingEntry
        )
        {
            try
            {
                //Given
                var accountingEntries = new List<AccountingEntry>();

                InMemoryDatabase.Insert(accountingEntries);

                //When
                var result = await accountingEntryRepository.GetByIdAsync(accountingEntry.id);

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