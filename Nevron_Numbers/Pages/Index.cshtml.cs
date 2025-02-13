using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nevron_Numbers.Services;

namespace Nevron_Numbers.Pages
{
    public class IndexModel : PageModel
    {
        private readonly INumbersService _numbersService;

        public List<int> Numbers { get; set; } = new List<int>();
        public int Sum { get; set; }
        public int Count { get; set; }

        public IndexModel(ILogger<IndexModel> logger, INumbersService numbersService)
        {
            _numbersService = numbersService;
        }

        public void OnGet()
        {
            Numbers = _numbersService.GetList().GetAwaiter().GetResult();
            Sum = _numbersService.GetSum().GetAwaiter().GetResult();
            Count = Numbers.Count;
        }

        [HttpPost]
        public JsonResult OnPostAddNumber()
        {
            int newNumber = _numbersService.GetNumber();
            _numbersService.AddNumberToStorage(newNumber).GetAwaiter().GetResult();
            int newCount = _numbersService.GetList().GetAwaiter().GetResult().Count;
            return new JsonResult(new { Number = newNumber, Count = newCount });
        }
        [HttpPost]
        public JsonResult OnPostSumNumbers()
        {
            int sum = _numbersService.SumNumbers().GetAwaiter().GetResult();
            return new JsonResult(sum);

        }
        [HttpPost]
        public JsonResult OnPostClearNumbers()
        {
            _numbersService.ClearNumbers();
            return new JsonResult(true);
        }
    }
}
