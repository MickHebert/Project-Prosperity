using Microsoft.AspNetCore.Mvc;
using ProjectProsperity.Models;

namespace ProjectProsperity.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase {
    private readonly ILogger<AccountController> _logger;

    public static Dictionary<string, Account> accounts = new Dictionary<string, Account>();
    
    public record Account {
        public string ID { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public string Email { get; init; }
        public string Name { get; init; }
    }

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }

    [HttpPost()]
    public IActionResult RegisterAccount([FromBody]RegisterRequest registerRequest) {
        _logger.LogInformation("Register request received: {registerRequest}", registerRequest.Description);
        var account = new Account() {
            ID = Guid.NewGuid().ToString(),
            Username = registerRequest.Username,
            Password = registerRequest.Password,
            Email = registerRequest.Email,
            Name = registerRequest.Name
        };

        if (accounts.Keys.Contains(registerRequest.Username)) {
            return BadRequest();
        }
        accounts.Add(registerRequest.Username, account);
        return Ok();
    }

    [HttpPost("login")]
    public ActionResult<string> Login([FromBody]LoginRequest loginInfo) {
        _logger.LogInformation("Login request received: {loginRequest}", loginInfo.Description);
        var account = accounts[loginInfo.Username]; //Account?
        return account != null && loginInfo.Password == account.Password ? Ok(account.ID) : Unauthorized(); 
    }

    [HttpGet()]
    public ActionResult<Account> Get(string ID) {
        var account = accounts.Values.FirstOrDefault(a => a.ID == ID);
        return account != null ? Ok(account) : NotFound();
    }
};