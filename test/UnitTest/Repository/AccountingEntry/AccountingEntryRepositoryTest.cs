using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using Xunit;
using cashflow.domain.Entity;
using Moq;
using System;
using System.Collections.Generic;
using cashflow.domain.Interface.Repository;
using cashflow.infrastructure.repository;
using Moq.AutoMock;

namespace Cashflow.Test.UnitTest.Repository
{
    public class AccountingEntryRepositoryTest : AutoDomainDataAttribute
    {
        public readonly IInMemoryDatabase _inMemoryDatabase;
        private IAccountingEntryRepository _accountingEntryRepository;
        private readonly Mock<IDatabaseConnectionFactory> _connectionFactoryMock = new Mock<IDatabaseConnectionFactory>();
        private readonly AutoMocker _autoMocker;

        public AccountingEntryRepositoryTest()
        {
            _autoMocker = new AutoMocker();
            _accountingEntryRepository = _autoMocker.CreateInstance<IAccountingEntryRepository>();
        }

        [Theory]
        [AutoDomainDataAttribute]
        public async Task AddAsyncTest_Success([Frozen] List<AccountingEntry> accountingEntry)
        {
            try
            {
                //Given
                await Task.Yield();

                accountingEntry[0].id = Guid.NewGuid().ToString();

                _connectionFactoryMock.Setup(c => c.GetConnection())
                     .Returns(_inMemoryDatabase.OpenConnection());

                _inMemoryDatabase.Insert(typeof(AccountingEntry).Name, accountingEntry);

                //When
                await _accountingEntryRepository.AddAsync(accountingEntry[0]);

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