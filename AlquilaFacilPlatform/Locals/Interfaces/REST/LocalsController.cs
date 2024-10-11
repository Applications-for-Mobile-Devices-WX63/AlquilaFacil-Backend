using System.Net.Mime;
using AlquilaFacilPlatform.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using AlquilaFacilPlatform.Locals.Domain.Model.Queries;
using AlquilaFacilPlatform.Locals.Domain.Services;
using AlquilaFacilPlatform.Locals.Interfaces.REST.Resources;
using AlquilaFacilPlatform.Locals.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace AlquilaFacilPlatform.Locals.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class LocalsController(ILocalCommandService localCommandService, ILocalQueryService localQueryService)
:ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateLocal(CreateLocalResource resource)
    {
        var createLocalCommand = CreateLocalCommandFromResourceAssembler.ToCommandFromResources(resource);
        var local = await localCommandService.Handle(createLocalCommand);
        if (local is null) return BadRequest();
        var localResource = LocalResourceFromEntityAssembler.ToResourceFromEntity(local);
        return CreatedAtAction(nameof(GetLocalById), new { localId = localResource.Id }, localResource);
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllLocals()
    {
        var getAllLocalsQuery = new GetAllLocalsQuery();
        var locals = await localQueryService.Handle(getAllLocalsQuery);
        var localResources = locals.Select(LocalResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(localResources);
    }

    [HttpGet("{localId:int}")]
    public async Task<IActionResult> GetLocalById(int localId)
    {
        var getLocalByIdQuery = new GetLocalByIdQuery(localId);
        var local = await localQueryService.Handle(getLocalByIdQuery);
        if (local == null) return NotFound();
        var localResource = LocalResourceFromEntityAssembler.ToResourceFromEntity(local);
        return Ok(localResource);
    }
    
    [HttpPut("{localId:int}")]
    public async Task<IActionResult> UpdateLocal(int localId, UpdateLocalResource resource)
    {
        var updateLocalCommand = UpdateLocalCommandFromResourceAssembler.ToCommandFromResource(localId, resource);
        var local = await localCommandService.Handle(updateLocalCommand);
        if (local is null) return BadRequest();
        var localResource = LocalResourceFromEntityAssembler.ToResourceFromEntity(local);
        return Ok(localResource);
    }
    
    [HttpGet("get-all-districts")]
    public IActionResult GetAllDistricts()
    {
        var getAllLocalDistrictsQuery = new GetAllLocalDistrictsQuery();
        var districts = localQueryService.Handle(getAllLocalDistrictsQuery);
        return Ok(districts);
    }
    
}