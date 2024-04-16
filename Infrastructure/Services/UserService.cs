using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class UserService(UserRepo repository, AddressService addressService)
{
    private readonly UserRepo _repository = repository;
    private readonly AddressService _addressService = addressService;
}

