using ELCODE.Services.Interfaces;
using ELCODE.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ELCODE.Controllers
{
    /// <summary>
    /// Контроллер приложения
    /// </summary>
    public class ElcodeController : Controller
    {
        /// <summary>
        /// Сервис клиентов
        /// </summary>
        private readonly IClientService _clientSerivce;

        /// <summary>
        /// Сревис запросов
        /// </summary>
        private readonly IRequestService _requestSerivce;

        /// <summary>
        /// Сревис приоритетов
        /// </summary>
        private readonly IPriorityService _priorityService;

        public ElcodeController(IClientService clientService, IRequestService requestService, IPriorityService priorityService)
        {
            _clientSerivce = clientService;
            _requestSerivce = requestService;
            _priorityService = priorityService;
        }

        /// <summary>
        /// Страница задания
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index() => View();

        /// <summary>
        /// Страница решения
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Task()
        {
            var clientsViewModel = new List<ClientViewModel>();

            var clients = await _clientSerivce.GetClientsAsync();

            foreach (var client in clients)
                clientsViewModel.Add(new ClientViewModel
                {
                    Id = client.Id,
                    Name = client.Name
                });

            return View(clientsViewModel);

        }

        /// <summary>
        /// Страница создания клиента
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ClientCreator()
        {
            var importancesViewModel = new List<ImportanceViewModel>();

            var importances = await _clientSerivce.GetImportancesAsync();

            foreach (var importance in importances)
                importancesViewModel.Add(new ImportanceViewModel
                {
                    Id = importance.Id,
                    Name = importance.Type
                });

            return View(importancesViewModel);
        }

        /// <summary>
        /// Добавить клиента
        /// </summary>
        /// <param name="name"> Название клиента </param>
        /// <param name="importanceId"> Ключевитость клиента </param>
        /// <returns></returns>
        [HttpPost]
        public async Task AddClient(string name, int importanceId) => await _clientSerivce.CreateClientAsync(name, importanceId);

        /// <summary>
        /// Страница запроса
        /// </summary>
        /// <param name="clientId"> Идентификатор клиента </param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> RequestCreator(int clientId)
        {
            var requestTypesViewModel = new List<RequestTypeViewModel>();

            var requestTypes = await _requestSerivce.GetRequestTypesAsync();

            foreach (var requestType in requestTypes)
                requestTypesViewModel.Add(new RequestTypeViewModel
                {
                    Id = requestType.Id,
                    Name = requestType.Name
                });

            return View(requestTypesViewModel);
        }

        /// <summary>
        /// Получить запросы клиента
        /// </summary>
        /// <param name="clientId"> Идентификатор клиента </param>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetRequests(int clientId)
        {
            var requestsViewModel = new List<RequestViewModel>();

            var requests = await _requestSerivce.GetRequestsByIdAsync(clientId);

            foreach (var request in requests)
                if (request.MainRequestId is null)
                    requestsViewModel.Add(new RequestViewModel
                    {
                        Id = request.Id,
                        CreationDate = request.CreationDate.ToString()
                    });

            return Json(requestsViewModel);
        }

        /// <summary>
        /// Добавить запрос
        /// </summary>
        /// <param name="clientId"> Идентификатор клиента </param>
        /// <param name="requestTypeId"> Идентификатор типа запроса </param>
        /// <param name="description"> Содержание запроса </param>
        /// <param name="channelId"> Идентификатор канала </param>
        /// <param name="mainRequestId"> Идентификатора главного запроса (если текущий является уточняющим) </param>
        /// <returns></returns>
        [HttpPost]
        public async Task AddRequest(int clientId, int requestTypeId, string description, int channelId, int mainRequestId)
        {
            var clientImportance = await _clientSerivce.GetClientImportanceIdAsync(clientId);

            var priority = await _priorityService.GerPriorityAsync(clientImportance, requestTypeId, mainRequestId == default ? true : false);

            await _requestSerivce.CreateRequest(clientId, requestTypeId, description, channelId, priority, mainRequestId);
        }
    }
}