using Dance.Store.Domain.Entities;
using Dance.Store.Domain.Interfaces;
using Dance.Store.Infrastructure.Context;

namespace Dance.Store.Infrastructure.Repositories;

public class RegistrationStatusRepository(DanceDbContext context) : BaseRepository<RegistrationStatus>(context), IRegistrationStatusRepository;