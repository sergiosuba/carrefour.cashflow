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
    public class ChartAccountServiceTestGetById : BaseTest
    {
        private IChartAccountService _chartAccountService;
        private readonly AutoMocker _autoMocker;
        private Mock<IGenericRepository<ChartAccount>> _genericRepository;
        private Mock<IMapper> _mapperMock;
        private static readonly IMapper _mapper = new MapperConfiguration(x =>
        {
            x.AddProfile(new MapperProfile());
        }).CreateMapper();

        public ChartAccountServiceTestGetById()
        {
            _autoMocker = new AutoMocker();
            _genericRepository = _autoMocker.GetMock<IGenericRepository<ChartAccount>>();
            _mapperMock = _autoMocker.GetMock<IMapper>();
            _chartAccountService = _autoMocker.CreateInstance<ChartAccountService>();
        }

        [Theory]
        [AutoDomainDataAttribute]
        public async Task GetByIdAsyncTest_Success(
            [Frozen] ChartAccountDTO chartAccountDTO
        )
        {
            try
            {
                //Given
                chartAccountDTO.Id = "19c95d2f-8cab-40f4-a04d-61975c403251";

                var chartAccount = _mapper.Map<ChartAccount>(chartAccountDTO);

                _mapperMock.Setup(x => x.Map<ChartAccount>(It.IsAny<ChartAccountDTO>()))
                    .Returns(chartAccount);

                _genericRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>()))
                    .ReturnsAsync(chartAccount);

                //When
                var result = await _chartAccountService.GetByIdAsync(chartAccountDTO.Id);

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