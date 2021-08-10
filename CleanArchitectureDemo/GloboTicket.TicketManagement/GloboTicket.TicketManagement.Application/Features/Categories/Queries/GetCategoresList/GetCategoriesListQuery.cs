using MediatR;
using System.Collections.Generic;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoresList
{
    public class GetCategoriesListQuery : IRequest<List<CategoryListVm>>
    {
    }
}
