using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auto.HttpApi.Controllers;

[ApiController]
[Authorize]
public class BasicController : ControllerBase
{
    protected readonly IMediator _mediator;

    public BasicController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
}