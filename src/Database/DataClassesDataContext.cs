using System.Configuration;

namespace Database
{
    public partial class DataClassesDataContext
    {
        private static readonly string ConnectionString;

        static DataClassesDataContext()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["WorkflowConnectionString"].ConnectionString;
        }

        public DataClassesDataContext() : base(ConnectionString)
        { }
    }
}
