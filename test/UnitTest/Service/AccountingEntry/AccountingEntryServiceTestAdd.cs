using Moq;
using Xunit;
using System;
using AutoMapper;
using Moq.AutoMock;
using AutoFixture.Xunit2;
using System.Threading.Tasks;
using cashflow.service;
using cashflow.domain.DTO;
using cashflow.domain.common;
using cashflow.domain.Entity;
using cashflow.domain.Interface.Service;
using cashflow.domain.Interface.Repository;

namespace Cashflow.Test.UnitTest.Repository
{
    public class AccountingEntryServiceTestAdd : BaseTest
    {
        private IAccountingEntryService _accountingEntryService;
        private readonly AutoMocker _autoMocker;
        private Mock<IGenericRepository<AccountingEntry>> _genericRepository;

        private Mock<IMapper> _mapperMock;
        private static readonly IMapper _mapper = new MapperConfiguration(x =>
        {
            x.AddProfile(new MapperProfile());
        }).CreateMapper();

        public AccountingEntryServiceTestAdd()
        {
            _autoMocker = new AutoMocker();
            _genericRepository = _autoMocker.GetMock<IGenericRepository<AccountingEntry>>();
            _mapperMock = _autoMocker.GetMock<IMapper>();
            _accountingEntryService = _autoMocker.CreateInstance<AccountingEntryService>();
        }

        [Theory]
        [AutoDomainDataAttribute]
        public async Task AddAsyncTest_Success(
            [Frozen] AccountingEntryDTO accountingEntryDTO
        )
        {
            try
            {
                //Given
                var accountingEntry = _mapper.Map<AccountingEntry>(accountingEntryDTO);

                _mapperMock.Setup(x => x.Map<AccountingEntry>(It.IsAny<AccountingEntryDTO>()))
                    .Returns(accountingEntry);

                _genericRepository.Setup(x => x.AddAsync(It.IsAny<AccountingEntry>()));

                //When
                var result = await _accountingEntryService.AddAsync(accountingEntryDTO);

                //Then
                Assert.True(result.IsSuccess);
                Assert.Equal(201, result.Code);
                Assert.Equal("Record successfully added", result.Info);
                Assert.Equal(string.Empty, result.Error);
                Assert.False(result.IsFailure);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(AddAsyncTest_Success)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }
    }
}