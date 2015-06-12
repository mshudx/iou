using IouOne.WebApp.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace IouOne.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class FavorsController : Controller
    {
        private static DocumentClient client = new DocumentClient(
                new Uri(ConfigurationManager.AppSettings["DocumentDbUri"]),
                ConfigurationManager.AppSettings["DocumentDbKey"]);
        private static Database iouDatabase;
        private static DocumentCollection favorsDocumentCollection;

        private async Task EnsureDatabaseExists()
        {
            if (iouDatabase == null)
            {
                var iouDatabase = client
                    .CreateDatabaseQuery()
                    .Where(db => db.Id == "iou")
                    .AsEnumerable()
                    .FirstOrDefault();

                if (iouDatabase == null)
                {
                    iouDatabase = (await client.CreateDatabaseAsync(
                        new Database
                        {
                            Id = "iou"
                        })).Resource;
                }
            }

            if (favorsDocumentCollection == null)
            {
                var favorsDocumentCollection = client
                    .CreateDocumentCollectionQuery(iouDatabase.CollectionsLink)
                    .Where(c => c.Id == "favors")
                    .AsEnumerable()
                    .FirstOrDefault();

                if (favorsDocumentCollection == null)
                {
                    favorsDocumentCollection = await client.CreateDocumentCollectionAsync(
                        iouDatabase.CollectionsLink,
                        new DocumentCollection { Id = "favors" });
                }
            }
        }

        [HttpPost]
        public async Task AddFavor([FromBody]Favor favor)
        {
            await EnsureDatabaseExists();

            await client.CreateDocumentAsync(
                favorsDocumentCollection.DocumentsLink,
                favor);
        }

        [HttpGet]
        public async Task<List<Favor>> GetFavorsOwedTo(Guid recipientUserId)
        {
            await EnsureDatabaseExists();

            var favorsOwed = from favor in client.CreateDocumentQuery<Favor>(favorsDocumentCollection.DocumentsLink)
                             where favor.ToUser == recipientUserId
                             select favor;

            return await favorsOwed.ToListAsync();
        }
    }
}
