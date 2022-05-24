using EntityLayer;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VisioForge.Libs.MediaFoundation.OPM;
using WebApplication3.Models;
using System.Xml;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        About about = new About();
        Comments comnts = new Comments();
        Context context = new Context();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();

        //}

        public IActionResult first()
        {
            return View();
        }

      
        //[HttpPost]
        public IActionResult Index(About about)
        {
           
            var html = @"https://www.yelp.com/biz/ark-ranch-construction-inc-no-title";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);


            var title = htmlDoc.DocumentNode.SelectSingleNode("//div/div/h1").InnerText;
            var phone = htmlDoc.DocumentNode.SelectSingleNode("//section/div/div/div/div/p[2]").InnerText;
            //var desc = htmlDoc.DocumentNode.SelectSingleNode("//section[6]/div[2]").InnerText;
            var rate = htmlDoc.DocumentNode.SelectSingleNode("/html/body/yelp-react-root/div[1]/div[3]/div[1]/div[1]/div/div[2]/div[2]/div[1]/span/div").Attributes["aria-label"].Value;
            var review_c = htmlDoc.DocumentNode.SelectSingleNode("/html/body/yelp-react-root/div[1]/div[3]/div[1]/div[1]/div/div[2]/div[2]/div[2]/span").InnerText;
            var location = htmlDoc.DocumentNode.SelectSingleNode("//p[@class=' css-qyp8bo']").InnerText;


            about.headernames = title.ToString();
            about.phone = phone.ToString();
            about.location = location.ToString();
            about.reviews_rate = rate.ToString();
            about.reviews_c = review_c.ToString();

            context.abouts.Add(about);
            context.SaveChanges();

            var values = context.abouts.ToList();
           

            return View(values);

        }

        public IActionResult Commenti()
        {
           
            var html = @"https://www.yelp.com/biz/ark-ranch-construction-inc-no-title";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            

            List<string> comments = new List<string>();
            
            var username = htmlDoc.DocumentNode.SelectSingleNode("/div/div/span/a[@class='css-1m051bw']").InnerText;
            var location = htmlDoc.DocumentNode.SelectSingleNode("/html/body/yelp-react-root/div[1]/div[4]/div/div/div[2]/div/div[1]/main/div[2]/section[2]/div[2]/div/ul/li[1]/div/div[1]/div/div[1]/div/div/div[2]/div[1]/div/div/span").InnerText;
            var rate = htmlDoc.DocumentNode.SelectSingleNode("/ html / body / yelp - react - root / div[1] / div[4] / div / div / div[2] / div / div[1] / main / div[2] / section[2] / div[2] / div / ul / li[1] / div / div[2] / div / div[1] / span / div").Attributes["aria-label"].Value;
            var comment = htmlDoc.DocumentNode.SelectSingleNode("/html/body/yelp-react-root/div[1]/div[4]/div/div/div[2]/div/div[1]/main/div[2]/section[2]/div[2]/div/ul/li[1]/div/div[4]/p/span").InnerText;
            foreach(var item in username)
            {
                comments.Add(item.ToString());
                comnts.username = username.ToString();

            }
            foreach(var item in location)
            {
                comments.Add(item.ToString());
                comnts.user_location = location.ToString();
            }
            foreach(var item in rate)
            {
                comments.Add(item.ToString());
                comnts.user_rate = rate.ToString();
            }
            foreach(var item in comment)
            {
                comments.Add(item.ToString());
                comnts.user_comment = comment.ToString();
            }

            context.comments.Add(comnts);
            context.SaveChanges();

            var values = context.comments.ToList();
            return View(values);

        }

    }
}
