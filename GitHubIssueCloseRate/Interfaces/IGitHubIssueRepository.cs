using GitHubIssueCloseRate.Entities;

namespace GitHubIssueCloseRate.Interfaces {
    public interface IGitHubIssueRepository : IRepository<GitHubIssueModel>  {
        string Repo { get;set;}
    }
}
