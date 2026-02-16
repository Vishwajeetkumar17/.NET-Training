using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge4_TournamentRankingSystem
{
    public class Team : IComparable<Team>
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public int CompareTo(Team other)
        {
            // TODO: Compare by points descending, then by name
            int pointComparison = other.Points.CompareTo(this.Points);
            if (pointComparison != 0)
                return pointComparison;

            return this.Name.CompareTo(other.Name);
        }
    }

    public class Match
    {
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }

        public Match(Team t1, Team t2)
        {
            Team1 = t1;
            Team2 = t2;
        }

        public Match Clone()
        {
            return new Match(Team1, Team2)
            {
                Team1Score = this.Team1Score,
                Team2Score = this.Team2Score
            };
        }
    }

    public class Tournament
    {
        private SortedList<int, Team> _rankings = new SortedList<int, Team>();
        private LinkedList<Match> _schedule = new LinkedList<Match>();
        private Stack<Match> _undoStack = new Stack<Match>();

        // Add match to schedule
        public void ScheduleMatch(Match match)
        {
            // TODO: Add to linked list
            _schedule.AddLast(match);
        }

        // Record match result and update rankings
        public void RecordMatchResult(Match match, int team1Score, int team2Score)
        {
            _undoStack.Push(match.Clone());
            // TODO: Update team points and re-sort rankings

            match.Team1Score = team1Score;
            match.Team2Score = team2Score;

            if (team1Score > team2Score)
                match.Team1.Points += 3;
            else if (team2Score > team1Score)
                match.Team2.Points += 3;
            else
            {
                match.Team1.Points += 1;
                match.Team2.Points += 1;
            }

            UpdateRankings(match.Team1);
            UpdateRankings(match.Team2);
        }

        // Undo last match
        public void UndoLastMatch()
        {
            // TODO: Use stack to revert last match
            if (_undoStack.Count == 0)
                return;

            Match lastMatch = _undoStack.Pop();

            if (lastMatch.Team1Score > lastMatch.Team2Score)
                lastMatch.Team1.Points -= 3;
            else if (lastMatch.Team2Score > lastMatch.Team1Score)
                lastMatch.Team2.Points -= 3;
            else
            {
                lastMatch.Team1.Points -= 1;
                lastMatch.Team2.Points -= 1;
            }

            UpdateRankings(lastMatch.Team1);
            UpdateRankings(lastMatch.Team2);
        }

        // Get ranking position using binary search
        public int GetTeamRanking(Team team)
        {
            // TODO: Implement ranking lookup
            var teams = _rankings.Values.ToList();
            return teams.BinarySearch(team);
        }

        private void UpdateRankings(Team team)
        {
            if (!_rankings.ContainsValue(team))
            {
                int key = GenerateUniqueKey(team.Points);
                _rankings.Add(key, team);
            }
            else
            {
                var existing = _rankings.First(kv => kv.Value == team);
                _rankings.Remove(existing.Key);
                int key = GenerateUniqueKey(team.Points);
                _rankings.Add(key, team);
            }
        }

        private int GenerateUniqueKey(int points)
        {
            int key = -points;
            while (_rankings.ContainsKey(key))
                key--;
            return key;
        }

        public List<Team> GetRankings()
        {
            return _rankings.Values.OrderBy(t => t).ToList();
        }
    }
    class Program
    {
        static void Main()
        {
            Tournament tournament = new Tournament();
            Team teamA = new Team { Name = "Team Alpha", Points = 0 };
            Team teamB = new Team { Name = "Team Beta", Points = 0 };

            Match match = new Match(teamA, teamB);

            tournament.ScheduleMatch(match);
            tournament.RecordMatchResult(match, 3, 1);

            var rankings = tournament.GetRankings();
            Console.WriteLine(rankings[0].Name);

            tournament.UndoLastMatch();
            Console.WriteLine(teamA.Points);
        }
    }

}
