using System.Threading.Tasks;

namespace GitHubIssueCloseRate.Interfaces {
    interface IGitHubIssueService {
        Task Report();
    }
}
