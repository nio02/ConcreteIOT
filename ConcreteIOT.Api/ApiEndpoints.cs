namespace ConcreteIOT.Api;

public class ApiEndpoints
{
    private const string ApiBase = "concreteiot";
    
    public static class Users
    {
        private const string Base = $"{ApiBase}/users";

        public const string Create = Base;
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
    }
}