using System.Linq;
using AnonymizeApi.Logic.Implementation;
using HtmlAgilityPack;
using Xunit;

namespace AnonymizeApiUnitTests2
{
    public class BasicAnonymizerShould : IClassFixture<BasicAnonymizerFixture>
    {
        const string DummyHtmlString = @"<!DOCTYPE html>
<html>
<body>
	<h1>This is <b>bold</b> heading</h1>
	<p>Paragraph node with a name like Steve Smith.</p>
	<h2>This is <i>italic</i> heading</h2>
</body>
</html> ";

        private readonly BasicAnonymizer _basicAnonymizer;

        public BasicAnonymizerShould(BasicAnonymizerFixture fixture)
        {
            _basicAnonymizer = fixture.BasicAnonymizer;
        }

        [Fact]
        public void GetHtmlDocument()
        {
            var htmlDocument = _basicAnonymizer.GetHtmlDocument("https://www.directsupply.com/stories/");

            Assert.NotNull(htmlDocument);
        }

        [Fact]
        public void ReplacePersonNamesInParagraphNodes()
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(DummyHtmlString);

            _basicAnonymizer.ReplacePersonNamesInParagraphNodes(htmlDoc);

            var paragraphNodes = htmlDoc.DocumentNode.SelectNodes("//p").ToList();

            Assert.Equal("Paragraph node with a name like Mike Hamlander.", paragraphNodes.First().InnerText);
        }
    }
}