﻿global using BookView = Library.Domain.Book.Book;
global using Library.Domain.Common.Results.Interfaces;
global using System.Runtime.CompilerServices;
global using MediatR;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.Extensions.DependencyInjection;
global using FluentValidation;
global using Library.Application.BookModel.Behaviors;
global using Library.Application.Common.Abstractions.Handlers;
global using Library.Domain.Common.Results.ResultsKind;
global using Library.Application.Book.Validation.Extensions;
global using Library.Application.Common.Abstractions.Requests;
global using Library.Domain.Common.Enums;
global using Library.Domain.Common.Errors.ErrorKinds;
global using Library.Domain.Book.Entities.Pocos;
global using Library.Domain.Book.ValueObjects.Stock;
global using Library.Domain.Book.Persistence.Interfaces;
global using Library.Application.Common.Abstractions.ValidatableRequests;
global using Library.Application.Common.Validation.Extensions;
global using ValidationResult = FluentValidation.Results.ValidationResult;
global using Library.Application.Book.Validators;
global using Library.Domain.Book.Entities;
global using Library.Domain.Common.ValueObjects.Interfaces;
global using Library.Infrastructure.Login.Library.Jwt;
global using Library.Domain.Book.ValueObjects.Lending;
[assembly: InternalsVisibleTo("BookApi.Presentation")]
