using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Agile.Abp.RealTime.Client
{
    public interface IOnlineClientStore
    {
        void Add(IOnlineClient client);

        bool Remove(string connectionId);

        bool TryRemove(string connectionId, out IOnlineClient client);

        bool TryGet(string connectionId, out IOnlineClient client);

        bool Contains(string connectionId);

        IReadOnlyList<IOnlineClient> GetAll();

        IReadOnlyList<IOnlineClient> GetAll(Expression<Func<IOnlineClient, bool>> predicate);
    }
}
