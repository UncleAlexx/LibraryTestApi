﻿global using Library.Presentation.Contracts.Book.Common.Bases;
global using Riok.Mapperly.Abstractions;
global using Library.Presentation.Contracts.Book.Add;
global using Library.Domain.Book.Entities.Pocos;
global using Library.Presentation.Contracts.Book.Update;
global using System.Collections.ObjectModel;
global using MediatR;
global using Library.Presentation.Endpoints;
global using BookEntity = Library.Domain.Book.Book;
global using Library.Presentation.Endpoints.Common.Extensions;
global using LoginQuery = Library.Application.Login.Queries.Login;
global using Library.Domain.Common.Results.ResultsKind;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Http.HttpResults;
global using Microsoft.AspNetCore.Routing;
global using Microsoft.AspNetCore.Http;
global using Library.Presentation.Endpoints.Common.Constants.Enums; 
global using Library.Presentation.Contracts.Book.Common.Mappers;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.AspNetCore.Mvc;
global using Library.Presentation.Contracts.Book.Common;
global using Library.Application.Book.Commands.Update;
global using Library.Application.Book.Commands.Remove;
global using Library.Application.Book.Commands.Add;
global using Library.Application.Book.Queries.GetAll;
global using Library.Application.Book.Queries.GetById;
global using Library.Application.Book.Queries.GetByIsbn;
global using Library.Application.Common.Abstractions.Requests;
global using System.Runtime.CompilerServices; 
global using Library.Presentation.Endpoints.Common.Constants;
global using Library.Presentation.Contracts.Book.Delete;
global using Library.Domain.Common.Results.Interfaces;
global using FluentValidation;