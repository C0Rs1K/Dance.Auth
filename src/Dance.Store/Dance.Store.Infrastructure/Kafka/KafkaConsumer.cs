using Confluent.Kafka;
using Dance.Store.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Hosting;
using Dance.Store.Application.UseCases.Student.ProcessStudentRegistration;

namespace Dance.Store.Infrastructure.Kafka;

public class KafkaConsumer(ISender sender, IConsumer<string, Student> consumer) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            consumer.Subscribe("s");
            while (!stoppingToken.IsCancellationRequested)
            {
                var result = consumer.Consume(stoppingToken);

                var student = result.Message.Value;
                var command = new ProcessStudentRegistrationCommand(student);
                await sender.Send(command, stoppingToken);
            }
        }
        finally
        {
            consumer.Close();
        }
    }
}