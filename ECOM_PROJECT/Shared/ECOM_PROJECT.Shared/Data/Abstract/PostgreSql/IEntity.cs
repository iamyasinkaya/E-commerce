using System;

namespace ECOM_PROJECT.Shared
{
    public interface IEntity<in TKey> where TKey : IEquatable<TKey>
    {
    }
}