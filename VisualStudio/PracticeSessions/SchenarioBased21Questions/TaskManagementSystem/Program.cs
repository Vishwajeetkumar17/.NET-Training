namespace TaskManagementSystem
{
    public class TaskItem
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public string AssignedTo { get; set; }
    }

    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectManager { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }

    public class TaskManager
    {
        private readonly List<Project> projects = new List<Project>();
        private int projectCounter = 1;
        private int taskCounter = 1;

        public void CreateProject(string name, string manager, DateTime start, DateTime end)
        {
            projects.Add(new Project
            {
                ProjectId = projectCounter++,
                ProjectName = name,
                ProjectManager = manager,
                StartDate = start,
                EndDate = end
            });
        }

        public void AddTask(int projectId, string title, string description, string priority, DateTime dueDate, string assignee)
        {
            foreach (var p in projects)
            {
                if (p.ProjectId == projectId)
                {
                    p.Tasks.Add(new TaskItem
                    {
                        TaskId = taskCounter++,
                        Title = title,
                        Description = description,
                        Priority = priority,
                        Status = "ToDo",
                        DueDate = dueDate,
                        AssignedTo = assignee
                    });
                    return;
                }
            }
        }
        public Dictionary<string, List<TaskItem>> GroupTasksByPriority()
        {
            Dictionary<string, List<TaskItem>> grouped =
                new Dictionary<string, List<TaskItem>>();

            foreach (var p in projects)
            {
                foreach (var t in p.Tasks)
                {
                    if (!grouped.ContainsKey(t.Priority))
                        grouped[t.Priority] = new List<TaskItem>();

                    grouped[t.Priority].Add(t);
                }
            }
            return grouped;
        }

        public List<TaskItem> GetOverdueTasks()
        {
            List<TaskItem> result = new List<TaskItem>();
            DateTime now = DateTime.Now;

            foreach (var p in projects)
            {
                foreach (var t in p.Tasks)
                {
                    if (t.DueDate < now && t.Status != "Completed")
                        result.Add(t);
                }
            }
            return result;
        }

        public List<TaskItem> GetTasksByAssignee(string assigneeName)
        {
            List<TaskItem> result = new List<TaskItem>();

            foreach (var p in projects)
            {
                foreach (var t in p.Tasks)
                {
                    if (t.AssignedTo == assigneeName)
                        result.Add(t);
                }
            }
            return result;
        }
        public List<Project> GetProjects() => projects;
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TaskManager manager = new TaskManager();

            while (true)
            {
                Console.WriteLine("1 Create Project");
                Console.WriteLine("2 Add Task");
                Console.WriteLine("3 Group Tasks By Priority");
                Console.WriteLine("4 Overdue Tasks");
                Console.WriteLine("5 Tasks By Assignee");
                Console.WriteLine("6 Exit");
                Console.Write("Choice: ");

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    Console.Write("Name: ");
                    string n = Console.ReadLine();

                    Console.Write("Manager: ");
                    string m = Console.ReadLine();

                    Console.Write("Start yyyy-MM-dd: ");
                    DateTime s = DateTime.Parse(Console.ReadLine());

                    Console.Write("End yyyy-MM-dd: ");
                    DateTime e = DateTime.Parse(Console.ReadLine());

                    manager.CreateProject(n, m, s, e);
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Projects:");
                    foreach (var p in manager.GetProjects())
                        Console.WriteLine(p.ProjectId + " " + p.ProjectName);

                    Console.Write("Project Id: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Title: ");
                    string t = Console.ReadLine();

                    Console.Write("Description: ");
                    string d = Console.ReadLine();

                    Console.Write("Priority: ");
                    string pr = Console.ReadLine();

                    Console.Write("Due yyyy-MM-dd: ");
                    DateTime dd = DateTime.Parse(Console.ReadLine());

                    Console.Write("Assignee: ");
                    string a = Console.ReadLine();

                    manager.AddTask(id, t, d, pr, dd, a);
                }
                else if (choice == 3)
                {
                    var grouped = manager.GroupTasksByPriority();

                    foreach (var g in grouped)
                    {
                        Console.WriteLine(g.Key);
                        foreach (var t in g.Value)
                            Console.WriteLine(t.TaskId + " " + t.Title);
                        Console.WriteLine();
                    }
                }
                else if (choice == 4)
                {
                    var list = manager.GetOverdueTasks();
                    foreach (var t in list)
                        Console.WriteLine(t.TaskId + " " + t.Title);
                }
                else if (choice == 5)
                {
                    Console.Write("Assignee: ");
                    string name = Console.ReadLine();

                    var list = manager.GetTasksByAssignee(name);
                    foreach (var t in list)
                        Console.WriteLine(t.TaskId + " " + t.Title);
                }
                else if (choice == 6)
                {
                    break;
                }

                Console.WriteLine();
            }
        }
    }
}
