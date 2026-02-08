using System;
using System.Collections.Generic;

namespace LoanWorkflowEngine
{
    public enum LoanState
    {
        Draft,
        Submitted,
        InReview,
        Approved,
        Rejected,
        Disbursed
    }
    public class LoanApplication
    {
        public string Id { get; }
        public LoanState CurrentState { get; private set; }
        public List<LoanState> History { get; } = new();
        public LoanApplication(string id)
        {
            Id = id;
            CurrentState = LoanState.Draft;
            History.Add(CurrentState);
        }
        public void SetState(LoanState newState)
        {
            CurrentState = newState;
            History.Add(newState);
        }
    }
    public class WorkflowEngine
    {
        private readonly Dictionary<string, LoanApplication> _apps = new();

        private readonly Dictionary<LoanState, HashSet<LoanState>> _transitions =
            new()
            {
                { LoanState.Draft, new HashSet<LoanState>{ LoanState.Submitted } },
                { LoanState.Submitted, new HashSet<LoanState>{ LoanState.InReview } },
                { LoanState.InReview, new HashSet<LoanState>{ LoanState.Approved, LoanState.Rejected } },
                { LoanState.Approved, new HashSet<LoanState>{ LoanState.Disbursed } },
                { LoanState.Rejected, new HashSet<LoanState>() },
                { LoanState.Disbursed, new HashSet<LoanState>() }
            };
        public void CreateApp(string id)
        {
            _apps[id] = new LoanApplication(id);
        }
        public void ChangeState(string appId, LoanState newState)
        {
            if (!_apps.ContainsKey(appId))
                throw new Exception("Application not found");

            var app = _apps[appId];
            var current = app.CurrentState;

            if (!_transitions[current].Contains(newState))
                throw new Exception($"Invalid transition: {current} -> {newState}");

            if (newState == LoanState.Disbursed &&
                current != LoanState.Approved)
                throw new Exception("Cannot disburse without approval");

            app.SetState(newState);
        }
        public void PrintHistory(string appId)
        {
            var app = _apps[appId];
            Console.WriteLine("State History:");
            foreach (var s in app.History)
                Console.WriteLine($"  {s}");
        }
        public LoanState GetState(string appId)
        {
            return _apps[appId].CurrentState;
        }
    }
    class Program
    {
        static void Main()
        {
            var engine = new WorkflowEngine();

            Console.Write("Enter Application ID: ");
            string id = Console.ReadLine()!;

            engine.CreateApp(id);

            while (true)
            {
                Console.WriteLine($"\nCurrent State: {engine.GetState(id)}");
                Console.WriteLine("Enter next state (Submitted, InReview, Approved, Rejected, Disbursed)");
                Console.WriteLine("Or type EXIT");

                string input = Console.ReadLine()!;
                if (input.Equals("EXIT", StringComparison.OrdinalIgnoreCase))
                    break;
                try
                {
                    LoanState next = Enum.Parse<LoanState>(input);
                    engine.ChangeState(id, next);
                    Console.WriteLine("Transition successful");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            engine.PrintHistory(id);
        }
    }
}
