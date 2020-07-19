namespace AnonymizeApi.Logic
{
    public interface INameGenerator
    {
        string GenerateReplacementName(string name);
    }
}