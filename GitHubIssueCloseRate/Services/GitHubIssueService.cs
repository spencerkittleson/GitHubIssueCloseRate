using GitHubIssueCloseRate.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubIssueCloseRate.Services {
    public class GitHubIssueService : IGitHubIssueService {
        private ILogger<Program> _logger;
        private IGitHubIssueRepository _repository;

        public GitHubIssueService(
            ILoggerFactory logger,
            IGitHubIssueRepository repository){
            this._logger = logger.CreateLogger<Program>();
            this._repository = repository;
        }

        public async Task Report()
        {
            var issues = await _repository.List();
            

            // TODO logic for report            
        }
    }
}
