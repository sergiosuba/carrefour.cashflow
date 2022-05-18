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
    public class ChartAccountServiceTestUpdate : BaseTest
    {
        private IChartAccountService _chartAccountService;
        private readonly AutoMocker _autoMocker;
        private Mock<IGenericRepository<ChartAccount>> _genericRepository;
        private Mock<IMapper> _mapperMock;
        private static readonly IMapper _mapper = new MapperConfiguration(x =>
        {
            x.AddProfile(new MapperProfile());
        }).CreateMapper();

        public ChartAccountServiceTestUpdate()
        {
            _autoMocker = new AutoMocker();
            _genericRepository = _autoMocker.GetMock<IGenericRepository<ChartAccount>>();
            _mapperMock = _autoMocker.GetMock<IMapper>();
            _chartAccountService = _autoMocker.CreateInstance<ChartAccountService>();
        }

        [Theory]
        [AutoDomainDataAttribute]
        public async Task UpdateAsyncTest_Success(
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

                _genericRepository.Setup(x => x.UpdateAsync(It.IsAny<ChartAccount>()))
                    .ReturnsAsync(true);

                //When
                var result = await _chartAccountService.UpdateAsync(chartAccountDTO);

                //Then
                Assert.True(true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(UpdateAsyncTest_Success)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }
    }
}