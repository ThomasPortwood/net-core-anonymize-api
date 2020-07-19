using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AnonymizeApi.Data;

/*
 * Run CoreNLP server: docker run -p 9000:9000 nlpbox/corenlp
 */
namespace AnonymizeApi.Logic.Implementation
{
    public class StanfordCoreNlpPersonNameFinder : IPersonNameFinder
    {
        public async Task<IEnumerable<string>> FindPersonNames(string s)
        {
            var httpClient = new HttpClient();
            
            var content = new StringContent(s);

            var response = await httpClient.PostAsync("http://localhost:9000", content);

            var root = JsonSerializer.Deserialize<Root>(await response.Content.ReadAsStringAsync());

            return root.sentences
                .SelectMany(s => s.entitymentions)
                .Where(e => e.ner.Equals("PERSON"))
                .Select(e => e.text);
        }
    }
}