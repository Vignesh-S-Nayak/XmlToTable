using Microsoft.AspNetCore.Mvc;
using XmlToTable.Services;

public class HomeController : Controller
{
    private readonly XMLParserService _xmlParserService;

    public HomeController(XMLParserService xmlParserService)
    {
        _xmlParserService = xmlParserService;
    }

    public async Task<IActionResult> Index()
    {
        string url = "https://receiptservice.egretail.cloud/ARTSPOSLogSchema/6.0.0";

        // Fetch parsed elements from the service
        var parsedElements = await _xmlParserService.ParseXmlAsync(url);

        // Pass the parsed data to the view
        return View(parsedElements); // Pass List<ParsedElement>
    }
}
