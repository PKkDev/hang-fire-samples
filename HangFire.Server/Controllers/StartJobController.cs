using Microsoft.AspNetCore.Mvc;
using Hangfire;
using HangFire.JobInterfaces;

namespace HangFire.Server.Controllers
{
    [Route("jobs")]
    [ApiController]
    public class StartJobController : ControllerBase
    {
        /// <summary>
        /// инициализация
        /// </summary>
        public StartJobController()
        {

        }

        /// <summary>
        /// выполнение работы
        /// </summary>
        /// <returns></returns>
        [HttpGet("start")]
        public IActionResult StartJob()
        {
            BackgroundJob.Enqueue<IHellowWorldJob>((x) => x.WriteLine());
            return Ok();
        }

        /// <summary>
        /// выполнение работы
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpGet("start-text")]
        public IActionResult StartJobWithText([FromQuery] string text)
        {
            BackgroundJob.Enqueue<IHellowWorldJob>((x) => x.WriteLine(text));
            return Ok();
        }
    }
}
