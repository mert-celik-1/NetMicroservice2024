using MediatR;
using NetMicroservice.Shared;

namespace NetMicroservice.Catalog.Api.Features.Categories.Create;

public record CreateCategoryCommand(string Name) : IRequest<ServiceResult<CreateCategoryResponse>>;
