using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Mocknitor.Domain;
using Mocknitor.Domain.Mock;
using Mocknitor.Domain.Mock;
using Mocknitor.Server.Hubs;
using Mocknitor.Services.Service;


namespace Mocknitor.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ServicesController : ControllerBase
    {

        //private readonly ILogger<ServicesController> _logger;
        private readonly IService1 _s1;
        private readonly IService2 _s2;
        private readonly IService3 _s3;

        private readonly IHubContext<StreamHub> _hubContext;

        private readonly ILogService _logservice;



        public ServicesController(IService1 S1, IService2 S2, IService3 S3, ILogService logService, IHubContext<StreamHub> hubContext)
        {
            _s1 = S1;
            _s2 = S2;
            _s3 = S3;
            _logservice = logService;
            _hubContext = hubContext;
        }


        [Authorize]
        [HttpGet()]
        public IActionResult Get()
        {
            List<string> result = new List<string>();
            result.Add(_s1.Name);
            result.Add(_s2.Name);
            result.Add(_s3.Name);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("${service_name}")]
        public IActionResult Get(string service_name)
        {
            switch (service_name)
            {
                case "Service1":
                    return Ok(_s1.Get());
                case "Service2":
                    return Ok(_s2.Get());
                case "Service3":
                    return Ok(_s3.Get());
                default:
                    return NotFound();
            };
        }

        //[Authorize]
        [HttpPost("${service_name}")]
        public async Task<IActionResult> Post(string service_name, [FromBody] string action_name)
        {
            switch (service_name)
            {
                case "Service1":
                    try
                    {
                        Guid guid = Guid.NewGuid();
                        Task task = new Task(() =>
                        {
                            _logservice.InitializeStream(guid, (IAsyncEnumerable<string>)_s1.GetType().InvokeMember(action_name,
                            System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.InvokeMethod |
                            System.Reflection.BindingFlags.DeclaredOnly |
                            System.Reflection.BindingFlags.Instance, null, _s1, null));
                        });
                        task.Start();
                        return Ok(guid);

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    break;
                case "Service2":
                    try
                    {
                        Guid guid = Guid.NewGuid();
                        Task task = new Task(() =>
                        {
                            _logservice.InitializeStream(guid, (IAsyncEnumerable<string>)_s2.GetType().InvokeMember(action_name,
                            System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.InvokeMethod |
                            System.Reflection.BindingFlags.DeclaredOnly |
                            System.Reflection.BindingFlags.Instance, null, _s2, null));

                        });
                        task.Start();
                        return Ok(guid);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    break;
                case "Service3":
                    try
                    {
                        Guid guid = Guid.NewGuid();
                        Task task = new Task(() =>
                        {
                            _logservice.InitializeStream(guid, (IAsyncEnumerable<string>)_s3.GetType().InvokeMember(action_name,
                            System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.InvokeMethod |
                            System.Reflection.BindingFlags.DeclaredOnly |
                            System.Reflection.BindingFlags.Instance, null, _s3, null));

                        });
                        task.Start();
                        return Ok(guid);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    break;
                default:
                    return NotFound();
            };
        }
    }

    public class TaskC : Task
    {
        private Guid _id { get; set; }
        public Guid ID => _id;
        public TaskC(Action action, Guid id) : base(action)
        {
            _id = id;
        }
    }
}
