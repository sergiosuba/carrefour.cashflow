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
    public class FlowServiceTestUpdate : BaseTest
    {
        private IFlowService _flowService;
        private readonly AutoMocker _autoMocker;
        private Mock<IGenericRepository<Flow>> _genericRepository;
        private Mock<IMapper> _mapperMock;
        private static readonly IMapper _mapper = new MapperConfiguration(x =>
        {
            x.AddProfile(new MapperProfile());
        }).CreateMapper();

        public FlowServiceTestUpdate()
        {
            _autoMocker = new AutoMocker();
            _genericRepository = _autoMocker.GetMock<IGenericRepository<Flow>>();
            _mapperMock = _autoMocker.GetMock<IMapper>();
            _flowService = _autoMocker.CreateInstance<FlowService>();
        }

        [Theory]
        [AutoDomainDataAttribute]
        public async Task UpdateAsyncTest_Success(
            [Frozen] FlowDTO flowDTO
        )
        {
            try
            {
                //Given
                flowDTO.Id = "19c95d2f-8cab-40f4-a04d-61975c403251";

                var flow = _mapper.Map<Flow>(flowDTO);

                _mapperMock.Setup(x => x.Map<Flow>(It.IsAny<FlowDTO>()))
                    .Returns(flow);

                _genericRepository.Setup(x => x.UpdateAsync(It.IsAny<Flow>()))
                    .ReturnsAsync(true);

                //When
                var result = await _flowService.UpdateAsync(flowDTO);

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