using Ambev.DeveloperEvaluation.Application.Shared.Base;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers;

/// <summary>
/// Response model for ListUsers operation
/// </summary>
public class ListUsersResult : ResultListBase
{
    /// <summary>
    /// Gets or sets the items returned
    /// </summary>
    public ICollection<GetUserResult>? Data { get; set; }

    public ListUsersResult(ICollection<GetUserResult> data, int currentPage, int pageSize, int totalItems)
    {
        Data = data;
        CurrentPage = currentPage;
        TotalItems = totalItems;
        TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
    }
}
