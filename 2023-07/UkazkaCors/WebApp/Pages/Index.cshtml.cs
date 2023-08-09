using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

public class Index : PageModel
{
    [BindProperty]
    public string Message { get; set; }

    public static List<string> Messages { get; set; } = new();

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        Messages.Add(Message);
        return RedirectToPage("/Index");
    }
}