using System.Text.Json;
using Confluent.Kafka;
using Dance.Auth.BusinessLogic.Dtos.ResponseDto;

namespace Dance.Auth.BusinessLogic.Services;

public class UserJsonSerializer : ISerializer<UserResponseDto>
{
    public byte[] Serialize(UserResponseDto data, SerializationContext context)
    {
        return JsonSerializer.SerializeToUtf8Bytes(data);
    }
}