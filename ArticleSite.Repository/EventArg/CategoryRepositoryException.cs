using System;

namespace ArticleSite.Repository.EventArg
{
    public class CategoryRepositoryException : Exception
    {
        public CategoryRepositoryException()
        {            
        }

        public CategoryRepositoryException(string message) 
            :base(message)
        {           
        }

        public CategoryRepositoryException(string message, Exception innerException)
            :base(message, innerException )
        {           
        }


    }
}
