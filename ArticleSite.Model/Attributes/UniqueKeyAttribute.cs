using System;

namespace ArticleSite.Model.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class UniqueKeyAttribute : Attribute
    {
    }
}