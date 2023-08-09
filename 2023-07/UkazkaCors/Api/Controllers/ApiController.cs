using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
public class ApiController : ControllerBase
{

    [HttpGet("/api/email-messages")]
    [HttpOptions("/api/email-messages")]
    [EnableCors("AllowForum")]
    public IActionResult Get()
    {
        List<Email> emls = new List<Email>(20);
        for(int i =0; i < 20; i++)
        {
            emls.Add(new Email() {Text = $"email message {i}"});
        }

        return Ok(emls);
    }
}

public class Email
{
    public string Text { get; set; }
}