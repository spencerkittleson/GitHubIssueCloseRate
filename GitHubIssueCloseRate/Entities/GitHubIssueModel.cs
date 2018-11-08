using System;

namespace GitHubIssueCloseRate.Entities {
    public class GitHubIssueModel {
        public string State { get; set;}
        public string Locked { get; set;}
        public string Url { get; set;}
        public string Body { get; set;}
        public DateTime created_at { get;set; }       
    }
}
