namespace Library.Application.Common.Abstractions.Handlers;

public interface IQueryHandler<TQuery, TResponseType, TReponse> :
    IRequestHandler<TQuery, TReponse> where TQuery : IQuery<TResponseType, TReponse> where TReponse : IResult<TResponseType>
{
}