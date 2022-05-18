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
    public class FlowServiceTestAdd : BaseTest
    {
        private IFlowService _flowService;
        private readonly AutoMocker _autoMocker;
        private Mock<IGenericRepository<Flow>> _genericRepository;

        private Mock<IMapper> _mapperMock;
        private static readonly IMapper _mapper = new MapperConfiguration(x =>
        {
            x.AddProfile(new MapperProfile());
        }).CreateMapper();

        public FlowServiceTestAdd()
        {
            _autoMocker = new AutoMocker();
            _genericRepository = _autoMocker.GetMock<IGenericRepository<Flow>>();
            _mapperMock = _autoMocker.GetMock<IMapper>();
            _flowService = _autoMocker.CreateInstance<FlowService>();
        }

        [Theory]
        [AutoDomainDataAttribute]
        public async Task AddAsyncTest_Success(
            [Frozen] FlowDTO flowDTO
        )
        {
            try
            {
                //Given
                var flow = _mapper.Map<Flow>(flowDTO);

                _mapperMock.Setup(x => x.Map<Flow>(It.IsAny<FlowDTO>()))
                    .Returns(flow);

                _genericRepository.Setup(x => x.AddAsync(It.IsAny<Flow>()));

                //When
                var result = await _flowService.AddAsync(flowDTO);

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