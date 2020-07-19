namespace AnonymizeApi.Logic
{
    public interface IAnonymizer
    {
        string AnonymizeNamesInHtmlContent(string url);
    }
}