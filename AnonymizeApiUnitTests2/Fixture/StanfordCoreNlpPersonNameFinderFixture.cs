using AnonymizeApi.Logic.Implementation;

namespace AnonymizeApiUnitTests2
{
    public class StanfordCoreNlpPersonNameFinderFixture
    {
        public StanfordCoreNlpPersonNameFinderFixture()
        {
            StanfordCoreNlpPersonNameFinder = new StanfordCoreNlpPersonNameFinder();
        }

        public StanfordCoreNlpPersonNameFinder StanfordCoreNlpPersonNameFinder { get; }

        public void Dispose()
        {
        }
    }
}