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
    public class ChartAccountServiceTestGetAll : BaseTest
    {
        private IChartAccountService _chartAccountService;
        private readonly AutoMocker _autoMocker;
        private Mock<IGenericRepository<ChartAccount>> _genericRepository;
        private Mock<IMapper> _mapperMock;
        private static readonly IMapper _mapper = new MapperConfiguration(x =>
        {
            x.AddProfile(new MapperProfile());
        }).CreateMapper();

        public ChartAccountServiceTestGetAll()
        {
            _autoMocker = new AutoMocker();
            _genericRepository = _autoMocker.GetMock<IGenericRepository<ChartAccount>>();
            _mapperMock = _autoMocker.GetMock<IMapper>();
            _chartAccountService = _autoMocker.CreateInstance<ChartAccountService>();
        }

        [Theory]
        [AutoDomainDataAttribute]
        public async Task GetAllAsyncAsyncTest_Success(
            [Frozen] List<ChartAccount> chartAccount
        )
        {
            try
            {
                //Given
                var chartAccountFilterDTO = new ChartAccountFilterDTO();

                var chartAccountDTO = _mapper.Map<List<ChartAccountDTO>>(chartAccount);

                _mapperMock.Setup(x => x.Map<List<ChartAccountDTO>>(It.IsAny<List<ChartAccount>>()))
                    .Returns(chartAccountDTO);

                _genericRepository.Setup(x => x.GetAllAsync(It.IsAny<ChartAccountFilterDTO>()))
                    .ReturnsAsync(chartAccount);

                //When
                var result = await _chartAccountService.GetAllAsync(chartAccountFilterDTO);

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