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
    public class AccountingEntryServiceTestGetAllView : BaseTest
    {
        private IAccountingEntryService _accountingEntryService;
        private readonly AutoMocker _autoMocker;
        private Mock<IAccountingEntryRepository> _accountingEntryRepository;
        private Mock<IMapper> _mapperMock;
        private static readonly IMapper _mapper = new MapperConfiguration(x =>
        {
            x.AddProfile(new MapperProfile());
        }).CreateMapper();

        public AccountingEntryServiceTestGetAllView()
        {
            _autoMocker = new AutoMocker();
            _accountingEntryRepository = _autoMocker.GetMock<IAccountingEntryRepository>();
            _mapperMock = _autoMocker.GetMock<IMapper>();
            _accountingEntryService = _autoMocker.CreateInstance<AccountingEntryService>();
        }

        [Theory]
        [AutoDomainDataAttribute]
        public async Task GetByIdAsyncTest_Success(
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

                _accountingEntryRepository.Setup(x => x.GetAllViewAsync(It.IsAny<AccountingEntryFilterDTO>()))
                    .ReturnsAsync(accountingEntry);

                //When
                var result = await _accountingEntryService.GetAllViewAsync(accountingEntryFilterDTO);

                //Then
                Assert.True(result.IsSuccess);
                Assert.Equal(200, result.Code);
                Assert.Equal("Record(s) successfully recovered", result.Info);
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