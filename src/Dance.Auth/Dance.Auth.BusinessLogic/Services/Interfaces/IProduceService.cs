using Dance.Auth.DataAccess.Models;

namespace Dance.Auth.BusinessLogic.Services.Interfaces;

public interface IProduceService
{
    Task ProduceAsync(string topic, User value, CancellationToken cancellationToken);
}