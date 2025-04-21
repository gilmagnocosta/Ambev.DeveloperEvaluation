using Ambev.DeveloperEvaluation.Application.Shared;
using Ambev.DeveloperEvaluation.Application.Shared.Base;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductCategories;

public class ListProductCategoriesQuery : RequestListBase, IRequest<ResultAsList<ListProductCategoriesResult>>
{

}

