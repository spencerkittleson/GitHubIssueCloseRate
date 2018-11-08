using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubIssueCloseRate.Interfaces {
    public interface IRepository<T> {
        Task<IList<T>> List();
        Task<T> Get(string id);
    }
}
