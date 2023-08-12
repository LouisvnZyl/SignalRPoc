using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.Hubs;
using SignalR.Services.Interfaces;

namespace SignalRAppApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : Controller
    {
        private readonly IHubContext<TimedMessageHub> _timedMessageHub;

        public MessageController(IHubContext<TimedMessageHub> timedMessageHub)
        {
            _timedMessageHub = timedMessageHub;
        }

        [HttpPost]
        public async Task<IActionResult> SendMesage()
        {
            var messageIdentity = Guid.NewGuid().ToString();

            await _timedMessageHub.Clients.All.SendAsync("GetFeed", messageIdentity);

            return Ok();
        }

        [HttpPost("SendTestGroup")]
        public async Task<IActionResult> SendGroupMesage()
        {
            var messageIdentity = Guid.NewGuid().ToString();

            await _timedMessageHub.Clients.Group("TestGroup").SendAsync("GetTestFeed", messageIdentity);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SendGroupMesage()
        {
            var messageIdentity = Guid.NewGuid().ToString();

            await _timedMessageHub.Clients.Group("TestGroup").SendAsync("GetTestFeed", messageIdentity);

            return Ok();
        }
    }
}
