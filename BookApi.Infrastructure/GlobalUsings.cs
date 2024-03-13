﻿global using BookAggregate = Library.Domain.Book.Book;
global using JwtBearerOptions = Library.Infrastructure.Login.Library.Jwt.JwtBearerOptions;
global using Library.Infrastructure.Login.Library;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;
global using Library.Domain.Common.Persistence.Dapper.Abstractions;
global using Library.Domain.Book.Persistence.Interfaces;
global using Library.Infrastructure.Common;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Library.Infrastructure.Book.Persistence.Repositories;
global using Microsoft.EntityFrameworkCore;
global using Library.Infrastructure.Book.Persistence.Library;
global using Library.Domain.Common.Enums;
global using System.ComponentModel.DataAnnotations;
global using System.Diagnostics.CodeAnalysis;
global using Microsoft.Data.SqlClient;
global using Library.Domain.Book.Entities;
global using System.Security.Claims;
global using Dapper;
global using Library.Domain.Book.ValueObjects.Lending;
global using Library.Domain.Book.ValueObjects.Stock;
global using Library.Domain.Book.Persistence.Dapper.QueriesParameters;
global using Microsoft.Extensions.Options;
global using System.IdentityModel.Tokens.Jwt;
global using System.Text;
global using System.Web;
global using Microsoft.IdentityModel.Tokens;
global using Library.Domain.Book.Entities.Pocos;
global using Library.Infrastructure.Book.Persistence.Constants.Library;
global using Library.Infrastructure.Book.Persistence.Constants.Common;
global using Library.Infrastructure.Login.Library.Jwt;
