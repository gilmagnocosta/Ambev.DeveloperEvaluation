using Ambev.DeveloperEvaluation.Application.Shared;
using Ambev.DeveloperEvaluation.Application.Shared.Base;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts;

public class ListProductsQuery : QueryListBase, IRequest<ResultAsList<ListProductsResult>>
{

}

