using GitHubIssueCloseRate.Entities;
using GitHubIssueCloseRate.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubIssueCloseRate.Data {

    public class GitHubIssuesRepository : IGitHubIssueRepository {
        private RestClient client;

        public GitHubIssuesRepository(){ 
            Repo = "picturepan2/spectre";
            client = new RestClient {
                BaseUrl = new Uri($"https://api.github.com/repos/{Repo}")
            };
        }

        public string Repo { get;set;}

        public async Task<GitHubIssueModel> Get(string id)
        {
            var request = Request(Method.GET);
            request.Resource = $"/issues/{id}";
            IRestResponse<GitHubIssueModel> response = await client.ExecuteTaskAsync<GitHubIssueModel>(request);
            return response.Data;
        }

        public async Task<IList<GitHubIssueModel>> List()
        {
            var request = Request(Method.GET);
            request.Resource = "/issues?per_page=100&state=closed&sort=closed_at";
            var response = await client.ExecuteTaskAsync<List<GitHubIssueModel>>(request);
            return response.Data;
        }

        private RestRequest Request(Method method) { 
            var request = new RestRequest(method);
            request.AddHeader("Accept", "application/vnd.github.v3+json");
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            return request;
        }
    }
}
