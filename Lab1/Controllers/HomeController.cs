using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab1.Models;

namespace Lab1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public string Search(string x, int counter)
    {
        return $"x={x}, counter{counter}";
    }

    [HttpPost]
    public string Create(string name, int age)
    {
        return $"$name={name}, age={age}";
    }

    [HttpGet("{id}")]
    public Book FindBook(int id)
    {
        return new Book()
        {
            Id = id,
            Title = "Atlas Shrugged",
            Pages = 123
        };
    }

    [HttpPost]
    public Book CreateBook([FromBody] Book book)
    {
        Random random = new Random();
        return new Book()
        {
            Id = random.Next(100),
            Title = book.Title,
            Pages = book.Pages
        };
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public class Book
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public int Pages { get; set; }

    }
}