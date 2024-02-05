using System.Text.Json;
using DT191G_Mom2.Models;
using Microsoft.AspNetCore.Mvc;

namespace DT191G_Mom2.Controllers;

public class CharacterController : Controller
{
    [Route("karaktarer")]
    public IActionResult Index()
    {
        //Läs in Jsonfil
        string jsonStr = System.IO.File.ReadAllText("characters.json");
        var characters = JsonSerializer.Deserialize<List<CharacterModel>>(jsonStr);
        return View(characters); // Parameterpassning med en vy-modell i grunden
    }

    public IActionResult Create()
    {
        // Skicka en lista med klasser
        ViewBag.Classes = new List<string> {
            "Barbarian",
            "Bard",
            "Cleric",
            "Druid",
            "Fighter",
            "Monk",
            "Paladin",
            "Ranger",
            "Rogue",
            "Sorcerer",
            "Warlock",
            "Wizard"
        };
        ViewBag.Races = new List<string> {
            "Dragonborn",
            "Dwarf",
            "Elf",
            "Gnome",
            "Half-Elf",
            "Halfling",
            "Half-Orc",
            "Human",
            "Tiefling"
        };
        ViewBag.Backgrounds = new List<string> {
            "Acolyte",
            "Charlatan",
            "Criminal",
            "Entertainer",
            "Folk Hero",
            "Guild Artisan",
            "Hermit",
            "Noble",
            "Outlander",
            "Sage",
            "Sailor",
            "Soldier",
            "Urchin"
        };
        return View();
    }

    [HttpPost]
    public IActionResult Create(CharacterModel model)
    {
        //Validera input
        if (ModelState.IsValid)
        {
            string jsonStr = System.IO.File.ReadAllText("characters.json");
            var characters = JsonSerializer.Deserialize<List<CharacterModel>>(jsonStr) ?? new List<CharacterModel>();

            if (characters != null)
            {
                characters.Add(model);
                jsonStr = JsonSerializer.Serialize(characters);
                System.IO.File.WriteAllText("characters.json", jsonStr);
            }

            ModelState.Clear();

            //Redirect
            return RedirectToAction("Index", "Character");
        }
        else
        {
            // Återuppbygg ViewBag-data här eftersom ViewBag-datan inte sparas över HTTP-begäran
            ViewBag.Classes = new List<string> {
                    "Barbarian",
                    "Bard",
                    "Cleric",
                    "Druid",
                    "Fighter",
                    "Monk",
                    "Paladin",
                    "Ranger",
                    "Rogue",
                    "Sorcerer",
                    "Warlock",
                    "Wizard"
                };
            ViewBag.Races = new List<string> {
                    "Dragonborn",
                    "Dwarf",
                    "Elf",
                    "Gnome",
                    "Half-Elf",
                    "Halfling",
                    "Half-Orc",
                    "Human",
                    "Tiefling"
                };
            ViewBag.Backgrounds = new List<string> {
                    "Acolyte",
                    "Charlatan",
                    "Criminal",
                    "Entertainer",
                    "Folk Hero",
                    "Guild Artisan",
                    "Hermit",
                    "Noble",
                    "Outlander",
                    "Sage",
                    "Sailor",
                    "Soldier",
                    "Urchin"
                };
        }

        return View(model);
    }
}