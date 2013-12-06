using System;

namespace ArticleSite.Repository.EventArg
{
    public class ArticleRepositoryException : Exception
    {
        public ArticleRepositoryException()
        {               
        }

        public ArticleRepositoryException(string message)
            :base(message)
        {           
        }

        public ArticleRepositoryException(string message, Exception innerException)
            :base(message, innerException)
        {
            
        }
    }
}
