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
using System.Collections.Generic;
using cashflow.domain.Interface.Service;

namespace Cashflow.Test.UnitTest.Repository
{
    public class AccountingEntryServiceTestGetAll : BaseTest
    {
        private IAccountingEntryService _accountingEntryService;
        private readonly AutoMocker _autoMocker;
        private Mock<IGenericRepository<AccountingEntry>> _genericRepository;
        private Mock<IMapper> _mapperMock;
        private static readonly IMapper _mapper = new MapperConfiguration(x =>
        {
            x.AddProfile(new MapperProfile());
        }).CreateMapper();

        public AccountingEntryServiceTestGetAll()
        {
            _autoMocker = new AutoMocker();
            _genericRepository = _autoMocker.GetMock<IGenericRepository<AccountingEntry>>();
            _mapperMock = _autoMocker.GetMock<IMapper>();
            _accountingEntryService = _autoMocker.CreateInstance<AccountingEntryService>();
        }

        [Theory]
        [AutoDomainDataAttribute]
        public async Task GetAllAsyncAsyncTest_Success(
            [Frozen] List<AccountingEntry> accountingEntry
        )
        {
            try
            {
                //Given
                var accountingEntryFilterDTO = new AccountingEntryFilterDTO();

                var accountingEntryDTO = _mapper.Map<List<AccountingEntryDTO>>(accountingEntry);

                _mapperMock.Setup(x => x.Map<List<AccountingEntryDTO>>(It.IsAny<List<AccountingEntry>>()))
                    .Returns(accountingEntryDTO);

                _genericRepository.Setup(x => x.GetAllAsync(It.IsAny<AccountingEntryFilterDTO>()))
                    .ReturnsAsync(accountingEntry);

                //When
                var result = await _accountingEntryService.GetAllAsync(accountingEntryFilterDTO);

                //Then
                Assert.True(result.IsSuccess);
                Assert.Equal(200, result.Code);
                Assert.Equal("Record(s) successfully recovered", result.Info);
                Assert.Equal(string.Empty, result.Error);
                Assert.False(result.IsFailure);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(GetAllAsyncAsyncTest_Success)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }
    }
}