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
using cashflow.domain.Interface.Repository;
using cashflow.service;
using cashflow.domain.Interface.Service;

namespace Cashflow.Test.UnitTest.Repository
{
    public class AccountingEntryServiceTestGetById : BaseTest
    {
        private IAccountingEntryService _accountingEntryService;
        private readonly AutoMocker _autoMocker;
        private Mock<IGenericRepository<AccountingEntry>> _genericRepository;
        private Mock<IMapper> _mapperMock;
        private static readonly IMapper _mapper = new MapperConfiguration(x =>
        {
            x.AddProfile(new MapperProfile());
        }).CreateMapper();

        public AccountingEntryServiceTestGetById()
        {
            _autoMocker = new AutoMocker();
            _genericRepository = _autoMocker.GetMock<IGenericRepository<AccountingEntry>>();
            _mapperMock = _autoMocker.GetMock<IMapper>();
            _accountingEntryService = _autoMocker.CreateInstance<AccountingEntryService>();
        }

        [Theory]
        [AutoDomainDataAttribute]
        public async Task GetByIdAsyncTest_Success(
            [Frozen] AccountingEntryDTO accountingEntryDTO
        )
        {
            try
            {
                //Given
                accountingEntryDTO.Id = "19c95d2f-8cab-40f4-a04d-61975c403251";

                var accountingEntry = _mapper.Map<AccountingEntry>(accountingEntryDTO);

                _mapperMock.Setup(x => x.Map<AccountingEntry>(It.IsAny<AccountingEntryDTO>()))
                    .Returns(accountingEntry);

                _genericRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>()))
                    .ReturnsAsync(accountingEntry);

                //When
                var result = await _accountingEntryService.GetByIdAsync(accountingEntryDTO.Id);

                //Then
                Assert.True(result.IsSuccess);
                Assert.Equal(200, result.Code);
                Assert.Equal("Record successfully geted", result.Info);
                Assert.Equal(string.Empty, result.Error);
                Assert.False(result.IsFailure);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(GetByIdAsyncTest_Success)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }
    }
}