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
using cashflow.infrastructure.common;
using FluentValidation;
using cashflow.domain.Validators;

namespace Cashflow.Test.UnitTest.Repository
{
    public class AccountingEntryServiceTestAdd : BaseTest
    {
        private IAccountingEntryService _accountingEntryService;
        private readonly AutoMocker _autoMocker;
        private Mock<IGenericRepository<AccountingEntry>> _genericRepository;
        private Mock<IValidation<AccountingEntryDTO>> _validation;
        private Mock<IMapper> _mapperMock;
        private static readonly IMapper _mapper = new MapperConfiguration(x =>
        {
            x.AddProfile(new MapperProfile());
        }).CreateMapper();

        public AccountingEntryServiceTestAdd()
        {
            _autoMocker = new AutoMocker();
            _genericRepository = _autoMocker.GetMock<IGenericRepository<AccountingEntry>>();
            _validation = _autoMocker.GetMock<IValidation<AccountingEntryDTO>>();
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

                _genericRepository
                    .Setup(x => x.AddAsync(It.IsAny<AccountingEntry>()));

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

        [Theory]
        [AutoDomainDataAttribute]
        public async Task AddAsyncTest_Validation_Id(
            [Frozen] AccountingEntryDTO accountingEntryDTO
        )
        {
            try
            {
                //Given
                accountingEntryDTO.Id = string.Empty;

                var validationResult = "The Id value must contain a valid guid.";
                
                _validation
                    .Setup(x => x.ValidateAsync(It.IsAny<AccountingEntryDTO>(), It.IsAny<AccountingEntryValidator>()))
                    .Throws(new ValidationException(validationResult));

                var accountingEntry = _mapper.Map<AccountingEntry>(accountingEntryDTO);

                _mapperMock.Setup(x => x.Map<AccountingEntry>(It.IsAny<AccountingEntryDTO>()))
                    .Returns(accountingEntry);

                _genericRepository.Setup(x => x.AddAsync(It.IsAny<AccountingEntry>()));

                //When
                var result = await _accountingEntryService.AddAsync(accountingEntryDTO);

                //Then
                Assert.False(result.IsSuccess);
                Assert.Equal(400, result.Code);
                Assert.Equal("Unable to add record. Contact the administrator.", result.Info);
                Assert.Equal(validationResult, result.Error);
                Assert.True(result.IsFailure);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(AddAsyncTest_Validation_Id)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }

        [Theory]
        [AutoDomainDataAttribute]
        public async Task AddAsyncTest_Validation_ChartAccountId(
            [Frozen] AccountingEntryDTO accountingEntryDTO
        )
        {
            try
            {
                //Given
                accountingEntryDTO.ChartAccountId = string.Empty;

                var validationResult = "The ChartAccountId value must contain a valid guid.";

                _validation
                    .Setup(x => x.ValidateAsync(It.IsAny<AccountingEntryDTO>(), It.IsAny<AccountingEntryValidator>()))
                    .Throws(new ValidationException(validationResult));

                var accountingEntry = _mapper.Map<AccountingEntry>(accountingEntryDTO);

                _mapperMock.Setup(x => x.Map<AccountingEntry>(It.IsAny<AccountingEntryDTO>()))
                    .Returns(accountingEntry);

                _genericRepository.Setup(x => x.AddAsync(It.IsAny<AccountingEntry>()));

                //When
                var result = await _accountingEntryService.AddAsync(accountingEntryDTO);

                //Then
                Assert.False(result.IsSuccess);
                Assert.Equal(400, result.Code);
                Assert.Equal("Unable to add record. Contact the administrator.", result.Info);
                Assert.Equal(validationResult, result.Error);
                Assert.True(result.IsFailure);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(AddAsyncTest_Validation_ChartAccountId)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }

        [Theory]
        [AutoDomainDataAttribute]
        public async Task AddAsyncTest_Validation_Value(
            [Frozen] AccountingEntryDTO accountingEntryDTO
        )
        {
            try
            {
                //Given
                accountingEntryDTO.Value = 0;

                var validationResult = "The Value value should be greater then 0.";

                _validation
                    .Setup(x => x.ValidateAsync(It.IsAny<AccountingEntryDTO>(), It.IsAny<AccountingEntryValidator>()))
                    .Throws(new ValidationException(validationResult));

                var accountingEntry = _mapper.Map<AccountingEntry>(accountingEntryDTO);

                _mapperMock.Setup(x => x.Map<AccountingEntry>(It.IsAny<AccountingEntryDTO>()))
                    .Returns(accountingEntry);

                _genericRepository.Setup(x => x.AddAsync(It.IsAny<AccountingEntry>()));

                //When
                var result = await _accountingEntryService.AddAsync(accountingEntryDTO);

                //Then
                Assert.False(result.IsSuccess);
                Assert.Equal(400, result.Code);
                Assert.Equal("Unable to add record. Contact the administrator.", result.Info);
                Assert.Equal(validationResult, result.Error);
                Assert.True(result.IsFailure);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(AddAsyncTest_Validation_Value)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }

        [Theory]
        [AutoDomainDataAttribute]
        public async Task AddAsyncTest_Validation_FlowId(
            [Frozen] AccountingEntryDTO accountingEntryDTO
        )
        {
            try
            {
                //Given
                accountingEntryDTO.FlowId = string.Empty;

                var validationResult = "The FlowId value must contain a valid guid.";
               
                _validation
                    .Setup(x => x.ValidateAsync(It.IsAny<AccountingEntryDTO>(), It.IsAny<AccountingEntryValidator>()))
                    .Throws(new ValidationException(validationResult));

                var accountingEntry = _mapper.Map<AccountingEntry>(accountingEntryDTO);

                _mapperMock.Setup(x => x.Map<AccountingEntry>(It.IsAny<AccountingEntryDTO>()))
                    .Returns(accountingEntry);

                _genericRepository.Setup(x => x.AddAsync(It.IsAny<AccountingEntry>()));

                //When
                var result = await _accountingEntryService.AddAsync(accountingEntryDTO);

                //Then
                Assert.False(result.IsSuccess);
                Assert.Equal(400, result.Code);
                Assert.Equal("Unable to add record. Contact the administrator.", result.Info);
                Assert.Equal(validationResult, result.Error);
                Assert.True(result.IsFailure);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(AddAsyncTest_Validation_FlowId)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }

        [Theory]
        [AutoDomainDataAttribute]
        public async Task AddAsyncTest_Validation_Description_Smaller(
            [Frozen] AccountingEntryDTO accountingEntryDTO
        )
        {
            try
            {
                //Given
                accountingEntryDTO.Description = "ab";

                var validationResult = "The Description value should be between 3 and 400 characteres.";
                _validation
                    .Setup(x => x.ValidateAsync(It.IsAny<AccountingEntryDTO>(), It.IsAny<AccountingEntryValidator>()))
                    .Throws(new ValidationException(validationResult));

                var accountingEntry = _mapper.Map<AccountingEntry>(accountingEntryDTO);

                _mapperMock.Setup(x => x.Map<AccountingEntry>(It.IsAny<AccountingEntryDTO>()))
                    .Returns(accountingEntry);

                _genericRepository.Setup(x => x.AddAsync(It.IsAny<AccountingEntry>()));

                //When
                var result = await _accountingEntryService.AddAsync(accountingEntryDTO);

                //Then
                Assert.False(result.IsSuccess);
                Assert.Equal(400, result.Code);
                Assert.Equal("Unable to add record. Contact the administrator.", result.Info);
                Assert.Equal(validationResult, result.Error);
                Assert.True(result.IsFailure);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(AddAsyncTest_Validation_Description_Smaller)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }

        [Theory]
        [AutoDomainDataAttribute]
        public async Task AddAsyncTest_Validation_DescriptionBigger(
            [Frozen] AccountingEntryDTO accountingEntryDTO
        )
        {
            try
            {
                //Given
                accountingEntryDTO.Description = new string('x', 401);

                var validationResult = "The ChartAccountId value must contain a valid guid.";
                _validation
                    .Setup(x => x.ValidateAsync(It.IsAny<AccountingEntryDTO>(), It.IsAny<AccountingEntryValidator>()))
                    .Throws(new ValidationException(validationResult));

                var accountingEntry = _mapper.Map<AccountingEntry>(accountingEntryDTO);

                _mapperMock.Setup(x => x.Map<AccountingEntry>(It.IsAny<AccountingEntryDTO>()))
                    .Returns(accountingEntry);

                _genericRepository.Setup(x => x.AddAsync(It.IsAny<AccountingEntry>()));

                //When
                var result = await _accountingEntryService.AddAsync(accountingEntryDTO);

                //Then
                Assert.False(result.IsSuccess);
                Assert.Equal(400, result.Code);
                Assert.Equal("Unable to add record. Contact the administrator.", result.Info);
                Assert.Equal(validationResult, result.Error);
                Assert.True(result.IsFailure);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(AddAsyncTest_Validation_DescriptionBigger)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }

        [Theory]
        [AutoDomainDataAttribute]
        public async Task AddAsyncTest_Validation_CreationDate(
            [Frozen] AccountingEntryDTO accountingEntryDTO
        )
        {
            try
            {
                //Given
                accountingEntryDTO.CreationDate = null;

                var validationResult = "The Creation Date value must contain a valid date time.";
                _validation
                    .Setup(x => x.ValidateAsync(It.IsAny<AccountingEntryDTO>(), It.IsAny<AccountingEntryValidator>()))
                    .Throws(new ValidationException(validationResult));

                var accountingEntry = _mapper.Map<AccountingEntry>(accountingEntryDTO);

                _mapperMock.Setup(x => x.Map<AccountingEntry>(It.IsAny<AccountingEntryDTO>()))
                    .Returns(accountingEntry);

                _genericRepository.Setup(x => x.AddAsync(It.IsAny<AccountingEntry>()));

                //When
                var result = await _accountingEntryService.AddAsync(accountingEntryDTO);

                //Then
                Assert.False(result.IsSuccess);
                Assert.Equal(400, result.Code);
                Assert.Equal("Unable to add record. Contact the administrator.", result.Info);
                Assert.Equal(validationResult, result.Error);
                Assert.True(result.IsFailure);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(AddAsyncTest_Validation_CreationDate)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }
    }
}