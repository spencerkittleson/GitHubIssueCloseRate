using GitHubIssueCloseRate.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubIssueCloseRate.Services {
    public class GitHubIssueService : IGitHubIssueService {
        private IGitHubIssueRepository _repository;

        public GitHubIssueService(
            IGitHubIssueRepository repository){
            this._repository = repository;
        }

        public async Task Report()
        {
            var issues = await _repository.List();
            foreach(var issue in issues){ 
                Console.WriteLine(issue.Url);
            }            

            // TODO logic for report            
        }
    }
}
