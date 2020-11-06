namespace MstwoData
{
    public static class ApiRoutes
    {
        public const string Base = "api";
       
        public static class Employee
        {
           
            public const string GetEmployee = Base + "/Employee";
            public const string CreateEmployee = Base + "/Employee/CreateNew";
            public const string UpdateEmployee = Base + "/Employee/Edit";
            public const string DeleteEmployee = Base + "/Employee";
        }

       
    }
}