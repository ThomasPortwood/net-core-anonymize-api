using System.Threading.Tasks;
using AnonymizeApi.Logic.Implementation;
using Xunit;

/*
 * Run CoreNLP server: docker run -p 9000:9000 nlpbox/corenlp
 */
namespace AnonymizeApiUnitTests2
{
    public class StanfordCoreNlpPersonNameFinderShould : IClassFixture<StanfordCoreNlpPersonNameFinderFixture>
    {
        private readonly StanfordCoreNlpPersonNameFinder _stanfordCoreNlpPersonNameFinder;

        public StanfordCoreNlpPersonNameFinderShould(StanfordCoreNlpPersonNameFinderFixture fixture)
        {
            _stanfordCoreNlpPersonNameFinder = fixture.StanfordCoreNlpPersonNameFinder;
        }

        [Fact]
        public async Task FindNamesInString()
        {
            var names =
                await _stanfordCoreNlpPersonNameFinder.FindPersonNames("This is a test for Steve Smith.");

            Assert.Collection(
                names,
                s => Assert.Contains("Steve Smith", s));
        }
    }
}