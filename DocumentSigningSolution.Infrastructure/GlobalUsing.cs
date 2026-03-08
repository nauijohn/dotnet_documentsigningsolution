global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;

global using Azure.Storage.Blobs;

global using DocumentSigningSolution.Application.Common.Interfaces.Authentication;
global using DocumentSigningSolution.Application.Common.Interfaces.Persistence;
global using DocumentSigningSolution.Application.Common.Interfaces.Services;
global using DocumentSigningSolution.Application.Common.Interfaces.Storage;
global using DocumentSigningSolution.Domain.DocumentAggregate;
global using DocumentSigningSolution.Domain.DocumentAggregate.Enums;
global using DocumentSigningSolution.Domain.DocumentAggregate.ValueObjects;
global using DocumentSigningSolution.Domain.UserAggregate;
global using DocumentSigningSolution.Infrastructure.Authentication;
global using DocumentSigningSolution.Infrastructure.Persistence;
global using DocumentSigningSolution.Infrastructure.Persistence.Repositories;
global using DocumentSigningSolution.Infrastructure.Services;
global using DocumentSigningSolution.Infrastructure.Storage;

global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
