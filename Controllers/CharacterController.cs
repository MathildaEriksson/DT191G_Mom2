using System.Text.Json;
using DT191G_Mom2.Models;
using Microsoft.AspNetCore.Mvc;

namespace DT191G_Mom2.Controllers;

public class CharacterController : Controller
{
    [Route("karaktarer/alla")]
    public IActionResult Index()
    {
        //Läs in Jsonfil
        string jsonStr = System.IO.File.ReadAllText("characters.json");
        var characters = JsonSerializer.Deserialize<List<CharacterModel>>(jsonStr) ?? new List<CharacterModel>();
        int characterCount = characters.Count;

        ViewBag.CharacterCount = characterCount;
        return View(characters); // Parameterpassning med en vy-modell i grunden
    }

    [Route("karaktarer/skapa")]
    public IActionResult Create()
    {
        // Skicka med listor med klasser, raser och bakgrunder
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
    [Route("karaktarer/skapa")]
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