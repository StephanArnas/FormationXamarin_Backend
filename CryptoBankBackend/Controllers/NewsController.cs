using CryptoBankBackend.Web.Models.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CryptoBankBackend.Web.Controllers
{
    public class NewsController : ControllerBase
    {
        #region ----- CONSTRUCTOR -----------------------------------------------------

        public NewsController()
        {
        }

        #endregion

        #region ----- WEBSERVICE METHODS ----------------------------------------------

        [HttpGet, AllowAnonymous]
        [Route("api/v1/[controller]/[action]")]
        [ProducesResponseType(typeof(IEnumerable<NewsApi>), (int)HttpStatusCode.OK)]
        public IActionResult GetAll()
        {
            return Ok(new List<NewsApi>()
            {
                new NewsApi() { Title = "Cryptodeliv : un service d’achat de cryptos rapide et accessible à tous", Description = "La question d’acheter facilement et rapidement des cryptomonnaies se pose à tous les nouveaux investisseurs désireux de participer à l’aventure des blockchains. Cryptodeliv est un service qui vise exactement à répondre à cette problématique, en simplifiant autant que possible l’accès aux cryptoactifs.", ImageUrl = "https://journalducoin.com/wp-content/uploads/2019/11/cryptodeliv-1.jpg" },
                new NewsApi() { Title = "Les banques allemandes pourront bientôt conserver et vendre du Bitcoin", Description = "Partout dans le monde, la révolution économique qu’apportent Bitcoin et les cryptomonnaies fait bouger (en bien ou en mal) les législations des pays. En Allemagne, c’est un pas clair vers la pleine intégration des cryptos qui va être franchi : Bitcoin va bientôt pouvoir être géré par les banques traditionnelles, comme n’importe quel actif !", ImageUrl = "https://journalducoin.com/wp-content/uploads/2018/05/Allemagne-Bitcoin-BTC.jpg" },
                new NewsApi() { Title = "IDAX : exit scam du CEO de la plateforme ?", Description = "La plateforme d’échange de cryptomonnaies International Digital Asset Exchange (IDAX) a confirmé la disparition de son CEO. Aucune information concernant les fonds n’a été dévoilée. ", ImageUrl = "https://journalducoin.com/wp-content/uploads/2018/06/Wanted-scam-reward-prime.jpg" },
                new NewsApi() { Title = "Les cryptos sont bienvenues en Suisse et en Corée du Sud", Description = "Certains pays méritent réellement le titre de “crypto-nations”. La Suisse et la Corée du Sud vont toutes deux adapter leur législation afin de mieux intégrer les cryptomonnaies et les technologies de registres distribués (DLT), favorisant ainsi leur développement.", ImageUrl = "https://journalducoin.com/wp-content/uploads/2018/07/Coree-du-Sud-Seoul-2.jpg" },
            });
        }

        #endregion
    }
}
