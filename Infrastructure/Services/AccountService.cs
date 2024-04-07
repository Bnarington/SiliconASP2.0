using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Services;

internal class AccountService(DbContext dbContext, UserManager<UserEntity> userManager)
{
    private readonly DbContext _dbContext = dbContext;
    private readonly UserManager<UserEntity> _userManager = userManager;

}
