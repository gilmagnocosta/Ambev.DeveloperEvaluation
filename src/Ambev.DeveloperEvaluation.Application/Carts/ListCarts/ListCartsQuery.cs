using Ambev.DeveloperEvaluation.Application.Shared.Base;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts;

public class ListCartsQuery : QueryListBase, IRequest<ListCartsResult>
{

}

