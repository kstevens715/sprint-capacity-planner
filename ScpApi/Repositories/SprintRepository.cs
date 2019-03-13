using Nest;
using System;
using System.Collections;
using ScpApi.Models;

namespace ScpApi.Repositories
{
    class SprintRepository
    {
        private const string IndexName = "sprintnewerestv2";
        private static Uri ElasticSearchUri = new Uri("http://127.0.0.1:9200");

        public static Sprint GetSprint(string id)
        {
            var client = BuildClient();
            var sprintResponse = client.Get<Sprint>(id, idx => idx.Index(IndexName));

            return sprintResponse.Source;
        }

        public static IEnumerable GetAllSprints()
        {
            var client = BuildClient();
            var sprintResponse = client.Search<Sprint>(s => s.Size(100));

            var sprints = sprintResponse.Documents;
            return sprints;
        }

        public static void SaveSprint(Sprint sprint)
        {
            var client = BuildClient();
            client.IndexDocument(sprint);
        }

        // TODO: Remove this temporary method used to create test data
        public static void IndexRecord(string id)
        {
            var sprint = new Sprint()
            {
                Id = id,
                Name = "Spr1",
            };

            var personSprint = new TeamMemberSprint()
            {
                Name = "Kyle",
                DaysAvailableBeforeFF = 8,
                DaysAvailableAfterFF = 10,
            };

            var breakdown = new Breakdown()
            {
                Name = "Sprint 1",
                TargetPercent = 50.0m,
            };

            sprint.TeamMemberSprints.Add(personSprint);
            sprint.Breakdowns.Add(breakdown);
            SaveSprint(sprint);
        }

        private static Nest.ElasticClient BuildClient()
        {
            var settings = new ConnectionSettings(ElasticSearchUri).DefaultIndex(IndexName);

            return new ElasticClient(settings);
        }
    }
}