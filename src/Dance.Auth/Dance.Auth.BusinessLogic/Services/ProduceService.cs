using Confluent.Kafka;
using Dance.Auth.BusinessLogic.Services.Interfaces;
using Dance.Auth.DataAccess.Models;
using Dance.Auth.BusinessLogic.Dtos.ResponseDto;

namespace Dance.Auth.BusinessLogic.Services;

public class ProduceService(IProducer<string, UserResponseDto> producer) : IProduceService
{
    public async Task ProduceAsync(string topic, User value, CancellationToken cancellationToken)
    {
        var userDto = new UserResponseDto
        {
            Id = value.Id,
            Email = value.Email,
            UserName = value.UserName,
            Name = value.Name
        };

        await producer.ProduceAsync(topic, new Message<string, UserResponseDto>
        {
            Key = value.Id.ToString(),
            Value = userDto
        }, cancellationToken);
    }
}