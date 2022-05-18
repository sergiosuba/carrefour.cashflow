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
    public class FlowServiceTestDelete : BaseTest
    {
        private IFlowService _flowService;
        private readonly AutoMocker _autoMocker;
        private Mock<IGenericRepository<Flow>> _genericRepository;
        private Mock<IMapper> _mapperMock;
        private static readonly IMapper _mapper = new MapperConfiguration(x =>
        {
            x.AddProfile(new MapperProfile());
        }).CreateMapper();

        public FlowServiceTestDelete()
        {
            _autoMocker = new AutoMocker();
            _genericRepository = _autoMocker.GetMock<IGenericRepository<Flow>>();
            _mapperMock = _autoMocker.GetMock<IMapper>();
            _flowService = _autoMocker.CreateInstance<FlowService>();
        }

        [Theory]
        [AutoDomainDataAttribute]
        public async Task DeleteAsyncTest_Success(
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

                _genericRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>()))
                    .ReturnsAsync(flow);

                _genericRepository.Setup(x => x.DeleteAsync(It.IsAny<Flow>()))
                    .ReturnsAsync(true);

                //When
                var result = await _flowService.DeleteAsync(flowDTO.Id);

                //Then
                Assert.True(result.IsSuccess);
                Assert.Equal(200, result.Code);
                Assert.Equal("Record successfully deleted", result.Info);
                Assert.Equal(string.Empty, result.Error);
                Assert.False(result.IsFailure);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(DeleteAsyncTest_Success)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }
    }
}