using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructorCLass
{
    /// <summary>
    /// Represents a record of log history, including identifying information and a textual log of actions performed on
    /// the object.
    /// </summary>
    public class LogHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Requirement { get; set; }

        public string logHistory { get; set; }

        public LogHistory()
        {
            logHistory += $"Oject created at {DateTime.Now.ToString()} ... {Environment.NewLine}";
        }

        public LogHistory(int id) : this()
        {
            Id = id;
            logHistory += $"Id set to {id} at {DateTime.Now.ToString()} ... {Environment.NewLine}";
        }

        public LogHistory(int id, string name) : this(id)
        {
            Name = name;
            logHistory += $"Name set to {name} at {DateTime.Now.ToString()} ... {Environment.NewLine}";
        }

        public LogHistory(int id, string name, string requirement) : this(id, name)
        {
            Requirement = requirement;
            logHistory += $"Requirement set to {requirement} at {DateTime.Now.ToString()} ... {Environment.NewLine}";
        }
    }
}
