using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Models;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private static readonly List<User> _users;
    private static int _index;

    static UsersController()
    {
        _users = new List<User>()
        {
            new User { Id = 1, Email = "emre@siliconmade.com", Username = "emre", Password = "1234"},
            new User { Id = 2, Email = "kerem@siliconmade.com", Username = "kerem", Password = "kerem12"},
            new User { Id = 3, Email = "seda@siliconmade.com", Username = "seda", Password = "password"},
        };

        _index = _users.Count + 1;
    }

    [HttpGet]
    public IActionResult Get()
    {

        return Ok(_users);
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id)
    {

        var user = _users.FirstOrDefault(x => x.Id == id);

        if (user is null)
            return NotFound($"Kullanıcı bulunamadı!");

        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create([FromBody] UserCreateModel model)
    {

        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        //Manual Mapping -> Auto Mapping (AutoMapper)
        User user = new User()
        {
            Id = _index++,
            Email = model.Email,
            Username = model.Username,
            Password = model.Password
        };
        _users.Add(user);
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user is null)
            return NotFound("Kullanıcı bulunmadı");

        _users.Remove(user);
        return Ok(user);

    }


}
