using System;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApplication4.Models;
using WebApplication4.Models.ResponseModels;
using WebApplication4.Models.StorageModels;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private EfContext Context { get; }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, EfContext context)
        {
            _logger = logger;
            Context = context;
        }

        [HttpGet]
        public JsonResult Get(string data)
        {
            return GetErrorResult("No data. Данные не переданы.");
        }

        [HttpGet]
        public ActionResult Results()
        {
            var model = new ResultsViewModel
            {
                Houses = Context.Houses.ToList()
            };

            return new ViewResult
            {
                ViewName = "Results",
                ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), ModelState)
                {
                    Model = model
                }
            };
        }


        [HttpGet]
        public JsonResult SendTemperature(string login, string password, string value)
        {
            HouseTeamModel house;
            try
            {
                house = GetHouseByCridentials(login, password);
            }
            catch (Exception e)
            {
                return GetSuccessfulResult(e.Message);
            }

            Log(new LogEntity
            {
                AdditionalData = value,
                Login = login,
                Method = "SendTemperature",
                Time = DateTime.Now
            });

            value = value?.Replace('.', ',');

            if (!double.TryParse(value, out var buf))
            {
                var answer = house.Temperature.HasValue
                    ? house.Temperature.Value.ToString(CultureInfo.InvariantCulture)
                    : "<null>";

                var response1 = $"Temperature not received so it is still {answer}.";

                return GetErrorResult(response1);
            }

            var response = $"Temperature is setted to {buf}.";
            house.Temperature = buf;

            house.LastRequestTime = DateTime.Now;
            Context.Houses.Update(house);
            Context.SaveChanges();

            return GetSuccessfulResult(response);
        }


        [HttpGet]
        public JsonResult SendHumidity(string login, string password, string value)
        {
            HouseTeamModel house;
            try
            {
                house = GetHouseByCridentials(login, password);
            }
            catch (Exception e)
            {
                return GetSuccessfulResult(e.Message);
            }

            Log(new LogEntity
            {
                AdditionalData = value,
                Login = login,
                Method = "SendHumidity",
                Time = DateTime.Now
            });

            value = value?.Replace('.', ',');

            if (!double.TryParse(value, out var buf))
            {
                var answer = house.Humidity.HasValue
                    ? house.Humidity.Value.ToString(CultureInfo.InvariantCulture)
                    : "<null>";

                var response1 = $"Humidity not received so it is still {answer}.";
                
                return GetErrorResult(response1);
            }

            var response = $"Humidity is setted to {buf}.";
            house.Humidity = buf;

            house.LastRequestTime = DateTime.Now;
            Context.Houses.Update(house);
            Context.SaveChanges();
            
            return GetSuccessfulResult(response);
        }


        [HttpGet]
        public JsonResult CallGuard(string login, string password)
        {
            HouseTeamModel house;
            try
            {
                house = GetHouseByCridentials(login, password);
            }
            catch (Exception e)
            {
                return GetErrorResult(e.Message);
            }

            Log(new LogEntity
            {
                Login = login,
                Method = "CallGuard",
                Time = DateTime.Now
            });

            house.LastGuardCall = DateTime.Now;
            var response =
                $"The guard has called at {house.LastGuardCall.Value.ToLongTimeString()}. Служба охраны вызвана в {house.LastGuardCall.Value.ToLongTimeString()}";

            house.LastRequestTime = DateTime.Now;
            Context.Houses.Update(house);
            Context.SaveChanges();
            
            return GetSuccessfulResult(response);
        }


        [HttpGet]
        public JsonResult GetLogs(string login, string password)
        {
            HouseTeamModel house;
            try
            {
                house = GetHouseByCridentials(login, password);
            }
            catch (Exception e)
            {
                return GetSuccessfulResult(e.Message);
            }

            Log(new LogEntity
            {
                Login = login,
                Method = "GetLogs",
                Time = DateTime.Now
            });

            var message = Context.Logs
                .Where(x => x.Login == login)
                .ToList()
                .Select(x => x.Login + " | " + x.Time + " | " + x.Method + " | " + x.AdditionalData)
                .Join(" ::: ");

            return GetSuccessfulResult(message);
        }


        private HouseTeamModel GetHouseByCridentials(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login)) throw new Exception("Username is empty. Имя пользователя пусто.");
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("Password is empty. Пароль пуст.");
            if (Context.Houses.All(x => x.Login != login))
                throw new Exception("There isn't any user with this name. Пользователя с таким именем не существует.");

            HouseTeamModel entity = Context.Houses.SingleOrDefault(x => x.Login == login && x.Password == password);
            if (entity == null) throw new Exception("Wrong username or password. Неверный логин или пароль.");

            return entity;
        }

        private void Log(LogEntity entity)
        {
            Context.Logs.Add(entity);
            Context.SaveChanges();
        }

        protected JsonResult GetSuccessfulResult(string message)
        {
            var messageModel = new HouseMessageModel(message);

            return new JsonResult(messageModel);
        }

        protected JsonResult GetErrorResult(string message)
        {
            var messageModel = new ErrorResponseModel(message);

            return new JsonResult(messageModel);
        }
    }
}