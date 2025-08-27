global using Azure.Identity;

global using DocumentSigningSolution.Api;
global using DocumentSigningSolution.Application;
global using DocumentSigningSolution.Application.Authentication.Commands.Register;
global using DocumentSigningSolution.Application.Authentication.Common;
global using DocumentSigningSolution.Application.Authentication.Queries.Login;
global using DocumentSigningSolution.Application.Documents.Commands.CreateDocument;
global using DocumentSigningSolution.Application.Documents.Commands.DeleteDocument;
global using DocumentSigningSolution.Application.Documents.Commands.UpdateDocument;
global using DocumentSigningSolution.Application.Documents.Queries.DownloadDocumentById;
global using DocumentSigningSolution.Application.Documents.Queries.GetDocumentById;
global using DocumentSigningSolution.Application.Documents.Queries.GetDocuments;
global using DocumentSigningSolution.Application.Folders.Commands.CreateFolder;
global using DocumentSigningSolution.Application.Folders.Commands.DeleteFolder;
global using DocumentSigningSolution.Application.Folders.Commands.UpdateFolder;
global using DocumentSigningSolution.Application.Folders.Queries.GetFolderById;
global using DocumentSigningSolution.Application.Folders.Queries.GetFolders;
global using DocumentSigningSolution.Contracts.Authentication;
global using DocumentSigningSolution.Contracts.Documents;
global using DocumentSigningSolution.Contracts.Folders;
global using DocumentSigningSolution.Domain.DocumentAggregate;
global using DocumentSigningSolution.Domain.FolderAggregate;
global using DocumentSigningSolution.Infrastructure;
global using DocumentSigningSolution.Shared;

global using ErrorOr;

global using Mapster;

global using MediatR;

global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.ModelBinding;
