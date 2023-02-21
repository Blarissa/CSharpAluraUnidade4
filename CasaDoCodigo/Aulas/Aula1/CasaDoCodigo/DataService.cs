namespace CasaDoCodigo
{
    public partial class Startup
    {
        class DataService : IDataService
        {
            private readonly ApplicationContext context;

            public DataService(ApplicationContext context)
            {
                this.context = context;
            }

            public void InicializaDB()
            {
                context.Database.EnsureCreated();
            }

        }
    }
}
