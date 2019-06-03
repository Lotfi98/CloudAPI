using Microsoft.AspNetCore.Mvc;


public class SayHiController : Controller 
{
[Route("hi")]
[HttpGet]

public IActionResult Hello()
{
    var result = Content ("Hello World!");
    result.StatusCode = 200;
    return result;
}

}