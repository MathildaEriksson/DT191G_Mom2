using System.Text.Json;
using DT191G_Mom2.Models;
using Microsoft.AspNetCore.Mvc;

namespace DT191G_Mom2.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        string jsonStr = System.IO.File.ReadAllText("characters.json");
        var characters = JsonSerializer.Deserialize<List<CharacterModel>>(jsonStr) ?? new List<CharacterModel>();
        int characterCount = characters.Count;

        ViewBag.CharacterCount = characterCount;

        return View();
    }
}