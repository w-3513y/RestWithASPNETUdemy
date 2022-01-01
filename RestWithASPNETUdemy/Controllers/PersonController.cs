using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Interfaces.Business;
using RestWithASPNETUdemy.Data.Entities;

namespace RestWithASPNETUdemy.Controllers;

[ApiVersion("1")]
[ApiController]
[Route("api/[controller]/v{version:apiversion}")]
public class PersonController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;
    private IPersonBusiness _personBusiness;

    public PersonController(
        ILogger<CalculatorController> logger,
        IPersonBusiness personBusiness)
    {
        _logger = logger;
        _personBusiness = personBusiness;
    }

    [HttpGet("get")]
    public IActionResult Get()
    {
        return Ok(_personBusiness.FindAll);
    }

    [HttpGet("getbyId")]
    public IActionResult GetById(int id)
    {
        var person = _personBusiness.FindByID(id);
        if (person == null) return NotFound();
        return Ok(person);
    }

    [HttpPost("post")]
    public IActionResult Post([FromBody] PersonEntity person)
    {
        if (person == null) return BadRequest();
        return Ok(_personBusiness.Create(person));
    }

    [HttpPut("update")]
    public IActionResult Update([FromBody] PersonEntity person)
    {
        if (person == null) return BadRequest();
        return Ok(_personBusiness.Update(person));
    }

    [HttpDelete("delete")]
    public IActionResult Delete(int id)
    {
        _personBusiness.Delete(id);
        return NoContent();
    }

}