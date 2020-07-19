using Bogus;

namespace AnonymizeApi.Logic.Implementation
{
    public class RandomNameGenerator : INameGenerator
    {
        private readonly Faker _faker;

        public RandomNameGenerator()
        {
            _faker = new Faker();
        }

        public string GenerateReplacementName(string s)
        {
            if (!s.Contains(' ') && !s.Contains(','))
            {
                return _faker.Name.FirstName();
            }

            if (s.Contains(','))
            {
                return _faker.Name.LastName() + ", " + _faker.Name.FirstName();
            }

            return _faker.Name.FirstName() + ' ' + _faker.Name.LastName();
        }
    }
}