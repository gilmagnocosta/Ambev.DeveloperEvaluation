using Ambev.DeveloperEvaluation.Application.Shared;
using Ambev.DeveloperEvaluation.Application.Shared.Base;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductsByCategory;

public class ListProductsByCategoryQuery : RequestListBase, IRequest<ResultAsList<ListProductsByCategoryResult>>
{
    public string Category { get; set; } = string.Empty;
}

