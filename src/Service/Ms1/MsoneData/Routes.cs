namespace MsoneData
{
    public static class ApiRoutes
    {
        public const string Base = "api";
       
        public static class Company
        {
           
            public const string GetCompany = Base + "/Company";
            public const string CreateCompany = Base + "/Company/CreateNew";
            public const string UpdateCompany = Base + "/Company/Edit";
            public const string DeleteCompany = Base + "/Company";
        }

       
    }
}