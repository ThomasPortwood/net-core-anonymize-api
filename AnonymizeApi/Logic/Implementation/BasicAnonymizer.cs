using System;
using System.IO;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;

namespace AnonymizeApi.Logic.Implementation
{
    public class BasicAnonymizer : IAnonymizer
    {
        private readonly ILogger<BasicAnonymizer> _logger;
        private readonly IPersonNameFinder _personNameFinder;
        private readonly INameGenerator _nameGenerator;

        public BasicAnonymizer(ILogger<BasicAnonymizer> logger, IPersonNameFinder personNameFinder,
            INameGenerator nameGenerator)
        {
            _logger = logger;
            _personNameFinder = personNameFinder;
            _nameGenerator = nameGenerator;
        }

        public string AnonymizeNamesInHtmlContent(string url)
        {
            var htmlDocument = GetHtmlDocument(url);

            ReplacePersonNamesInParagraphNodes(htmlDocument);

            var sw = new StringWriter();
            
            htmlDocument.Save(sw);

            return sw.ToString();
        }

        public HtmlDocument GetHtmlDocument(string url)
        {
            var web = new HtmlWeb();
            return web.Load(url);
        }

        public async void ReplacePersonNamesInParagraphNodes(HtmlDocument htmlDocument)
        {
            var paragraphNodes = htmlDocument.DocumentNode.SelectNodes("//p");

            foreach (var node in paragraphNodes)
            {
                var pieces = node.InnerHtml.Split('.');

                foreach (var s in pieces)
                {
                    try
                    {
                        var names = await _personNameFinder.FindPersonNames(s);

                        foreach (var name in names)
                        {
                            var newName = _nameGenerator.GenerateReplacementName(name);

                            node.InnerHtml = node.InnerHtml.Replace(name, newName);
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e, e.Message);
                    }
                }
            }
        }
    }
}