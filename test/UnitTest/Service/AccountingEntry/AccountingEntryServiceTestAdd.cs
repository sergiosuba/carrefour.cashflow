using Moq;
using Xunit;
using System;
using AutoMapper;
using Moq.AutoMock;
using AutoFixture.Xunit2;
using System.Threading.Tasks;
using cashflow.domain.DTO;
using cashflow.domain.common;
using cashflow.domain.Entity;
using cashflow.domain.Services;
using cashflow.domain.Interface.Repository;

namespace Cashflow.Test.UnitTest.Repository
{
    public class AccountingEntryServiceTest : BaseTest
    {
        private IAccountingEntryService _accountingEntryService;
        private readonly AutoMocker _autoMocker;
        private Mock<IAccountingEntryRepository> _accountingEntryRepository;
        private Mock<IMapper> _mapperMock;
        private static readonly IMapper _mapper = new MapperConfiguration(x =>
        {
            x.AddProfile(new MapperProfile());
        }).CreateMapper();

        public AccountingEntryServiceTest()
        {
            _autoMocker = new AutoMocker();
            _accountingEntryRepository = _autoMocker.GetMock<IAccountingEntryRepository>();
            _mapperMock = _autoMocker.GetMock<IMapper>();
        }

        [Theory]
        [AutoDomainDataAttribute]
        public async Task AddAsyncTest_Success(
            [Frozen] AccountingEntryDTO accountingEntryDTO, AccountingEntry accountingEntry
        )
        {
            try
            {
                //Given
                var mapperResult = _mapper.Map<AccountingEntry>(accountingEntryDTO);

                _mapperMock.Setup(x => x.Map<AccountingEntry>(It.IsAny<AccountingEntryDTO>()))
                    .Returns(mapperResult);

                _accountingEntryRepository.Setup(x => x.AddAsync(It.IsAny<AccountingEntry>()));

                //When
                var result = await _accountingEntryService.AddAsync(accountingEntryDTO);

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