using Medhelp.Contracts.Groups;
using Medhelp.Services.Abstractions.Groups;
using Microsoft.AspNetCore.Mvc;

namespace Medhelp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActiveSubstanceController(IActiveSubstanceService service) 
    : BaseGroupController<ActiveSubstanceModel>(service)
{
}
