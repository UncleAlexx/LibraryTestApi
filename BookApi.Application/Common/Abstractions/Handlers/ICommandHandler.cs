namespace Library.Application.Common.Abstractions.Handlers;

internal interface ICommandHandler<TCommand, TResponseType, TReponse> :
    IRequestHandler<TCommand, TReponse> where TCommand : ICommand<TResponseType, TReponse> where TReponse : IResult<TResponseType>;