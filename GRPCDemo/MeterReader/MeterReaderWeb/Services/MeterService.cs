using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MeterReaderLib;
using MeterReaderLib.Models;
using MeterReaderWeb.Data;
using MeterReaderWeb.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MeterReaderWeb.Services
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MeterService:MeterReadingService.MeterReadingServiceBase
    {
        private readonly ILogger<MeterService> _logger;
        private readonly IReadingRepository _readingRepository;
        private readonly JwtTokenValidationService _jwtTokenValidationService;

        public MeterService(ILogger<MeterService> logger,IReadingRepository readingRepository, JwtTokenValidationService jwtTokenValidationService)
        {
            _logger = logger;
            _readingRepository = readingRepository;
            _jwtTokenValidationService = jwtTokenValidationService;
        }

        [AllowAnonymous]
        public async override Task<TokenResponse> CreateToken(TokenRequest request, ServerCallContext context)
        {
            var creds = new CredentialModel()
            {
                UserName = request.Username,
                Passcode = request.Password
            };

            var response = await _jwtTokenValidationService.GenerateTokenModelAsync(creds);
            if (response.Success)
            {
                return new TokenResponse()
                {
                    Token = response.Token,
                    Expiration = Timestamp.FromDateTime(response.Expiration),
                    Success = true

                };
            }
            return new TokenResponse()
            {
                Success = false
            };
        }
        public async override Task<StatusMessage> AddReading(ReadingPacket request, ServerCallContext context)
        {
            var result = new StatusMessage()
            {
                Success = ReadingStatus.Failure
            };
            if(request.Successful==ReadingStatus.Success)
            {
                try 
                { 
                    foreach(var r in request.Readings)
                    {
                        if (r.ReadingValue < 1000)
                        {
                            _logger.LogDebug("Reading Value below acceptable level");
                            var trailers = new Metadata()
                            {
                                {"BadValue",r.ReadingValue.ToString() },
                                {"Field","ReadingValue" },
                                {"Message","Readings are invalid" }
                            };
                            throw new RpcException(new Status(StatusCode.OutOfRange, "Value too low"),trailers);
                        }
                        var reading = new MeterReading()
                        {
                            Value = r.ReadingValue,
                            CustomerId = r.CustomerId,
                            ReadingDate = r.ReadingTime.ToDateTime()
                        };
                        _readingRepository.AddEntity(reading);
                    }

                    if(await _readingRepository.SaveAllAsync())
                    {
                        _logger.LogInformation($"Stored {request.Readings.Count} new readings...");
                        result.Success = ReadingStatus.Success;
                    }
                }
                catch(RpcException)
                {

                    throw;
                }
                catch(Exception ex)
                {
                    
                    _logger.LogError($"Exception thrown during saving of readings:{ex}");
                    throw new RpcException(Status.DefaultCancelled, "Exception thrown during process");
                }
            }
            return result;
        }

        public override async Task<Empty> SendDiagnostics(IAsyncStreamReader<ReadingMessage> requestStream, ServerCallContext context)
        {
            var theTask = Task.Run(async () =>
            {
                await foreach (var reading in requestStream.ReadAllAsync())
                {
                    _logger.LogInformation($"Received Reading:{reading}");
                }
            });
            await theTask;//we could have done a await Task.Run(....)
            return new Empty();
        }


    }
}
