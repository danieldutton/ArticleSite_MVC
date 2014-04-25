using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ArticleSite.DataAccess
{
    public class ArticleDbConfiguration : DbConfiguration
    {        
            public ArticleDbConfiguration()
            {
                SetDefaultConnectionFactory(new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0"));
                SetDatabaseInitializer(new ArticleDataInitialiser());
            }       
    }
}
