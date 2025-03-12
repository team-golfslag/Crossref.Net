using Crossref.Net.Models;
using Crossref.Net.Services;
using DoiTools.Net;
using Microsoft.Extensions.Logging;

Doi doi = Doi.Parse("10.1016/j.chroma.2008.01.017");
CrossrefService crossrefService = new(new(), new Logger<CrossrefService>(new LoggerFactory()));
//
// Work? work = await crossrefService.GetWork(doi);
// Console.WriteLine(work?.Title.FirstOrDefault());
//
// List<Work> works = await crossrefService.GetWorks("chromatography");
// foreach (Work w in works)
// {
//     Console.WriteLine(w.Title.FirstOrDefault());
// }

string issn = "0360-4012";
Journal? journal = await crossrefService.GetJournal(issn);
Console.WriteLine(journal?.Title);

var journals = await crossrefService.GetJournals("biology");
foreach (Journal j in journals) Console.WriteLine(j.Title);
