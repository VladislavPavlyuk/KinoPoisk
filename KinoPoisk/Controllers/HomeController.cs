#pragma warning disable SYSLIB0014
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View("Privacy");
    }


    [HttpGet]
    public IActionResult GetMovieInfo(string movieName)
    {
        string apiKey = "47f67b4c";
        string url = $"http://www.omdbapi.com/?t={movieName}&apikey={apiKey}";
        using (WebClient client = new())
        {
            string json = client.DownloadString(url);
            dynamic? result = JsonConvert.DeserializeObject(json);
            if (result != null)
            {
                if (result.Response == "True")
                {
                    string movieInfo = $"<img src=\"{result.Poster}\" class=\"rounded float-end\" alt=\"poster\">" +
                                       $"<h3>{result.Title}</h3>" +
                                       $"<p><strong>Год:</strong> {result.Year}</p>" +
                                       $"<p><strong>Рейтинг:</strong> {result.imdbRating}</p>" +
                                       $"<p><strong>Длительность:</strong> {result.Runtime}</p>" +
                                       $"<p><strong>Режиссер:</strong> {result.Director}</p>" +
                                       $"<p><strong>Актеры:</strong> {result.Actors}</p>" +
                                       $"<p><strong>Описание:</strong> {result.Plot}</p>" +
                                       $"<p><strong>Рейтинг:</strong> {result.Rated}</p>" +
                                       $"<p><strong>Жанр:</strong> {result.Genre}</p>" +
                                       $"<p><strong>Автор сценария:</strong> {result.Writer}</p>" +
                                       $"<p><strong>Язык оригинала:</strong> {result.Language}</p>" +
                                       $"<p><strong>Страна:</strong> {result.Country}</p>" +
                                       $"<p><strong>Награды:</strong> {result.Awards}</p>" +
                                       $"<p><strong>Тип:</strong> {result.Type}</p>" +
                                       $"<p><strong>DVD:</strong> {result.DVD}</p>" +
                                       $"<p><strong>Выручка:</strong> {result.BoxOffice}</p>" +
                                       $"<p><strong>Production:</strong> {result.Production}</p>" +
                                       $"<p><strong>Website:</strong> {result.Website}</p>" +
                                       $"<p><strong>Выход в прокат:</strong> {result.Released}</p>";

                    return Content(movieInfo);
                }
                else
                {
                    return Content("Фильм не найден.");
                }
            }
            else
            {
                return Content("Упс... Что-то пошло не так...");
            }
        }
    }
}

