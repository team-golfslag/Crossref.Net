// This program has been developed by students from the bachelor Computer Science at Utrecht
// University within the Software Project course.
// 
// © Copyright Utrecht University (Department of Information and Computing Sciences)

using Crossref.Net.Models;
using Crossref.Net.Services;
using DoiTools.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

var options = Options.Create(new CrossrefServiceOptions
{
    BaseUrl = "https://api.crossref.org",
    UserAgent = "Crossref.Net/1.0",
});
CrossrefService crossrefService = new(new(), options, new Logger<CrossrefService>(new LoggerFactory()));

// Doi doi = Doi.Parse("10.1016/j.chroma.2008.01.017");
// Work? work = await crossrefService.GetWorkAsync(doi);
// Console.WriteLine(work?.Title?.FirstOrDefault());
//
// List<Work> works = await crossrefService.GetWorksAsync("chromatography");
// foreach (Work w in works)
// {
//     Console.WriteLine(w.Title?.FirstOrDefault());
// }

const string issn = "0360-4012";
Journal? journal = await crossrefService.GetJournalAsync(issn);
Console.WriteLine(journal?.Title);

var journals = await crossrefService.GetJournalsAsync("biology");
foreach (Journal j in journals) Console.WriteLine(j.Title);
