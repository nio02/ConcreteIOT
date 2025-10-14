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
    
    public static class Projects
    {
        private const string Base = $"{ApiBase}/projects";
        
        public const string Create = Base;
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
    }
    
    public static class UserProject
    {
        private const string Base = $"{ApiBase}/projects";

        public const string AddVisitor = $"{Base}/{{projectId:guid}}/visitors";
    }
    
    public static class ConcreteMix
    {
        private const string Base = $"{ApiBase}/projects";

        public const string Create = $"{Base}/{{projectId:guid}}/mixes";
        public const string Get = $"{Base}/{{projectId:guid}}/mixes/{{id:guid}}";
        public const string GetAll = $"{Base}/{{projectId:guid}}/mixes";
        public const string Update = $"{Base}/{{projectId:guid}}/mixes/{{id:guid}}";
        public const string Delete = $"{Base}/{{projectId:guid}}/mixes/{{id:guid}}";
    }
    
    public static class Devices
    {
        private const string Base = $"{ApiBase}/devices";
        
        public const string Create = Base;
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
    }
}