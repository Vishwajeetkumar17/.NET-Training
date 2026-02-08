using System.Linq;

namespace GymMembershipManagement
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string MembershipType { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
    public class FitnessClass
    {
        public string ClassName { get; set; }
        public string Instructor { get; set; }
        public DateTime Schedule { get; set; }
        public int MaxParticipants { get; set; }
        public List<int> RegisteredMembers { get; set; }

        public FitnessClass()
        {
            RegisteredMembers = new List<int>();
        }
    }
    public class GymManager
    {
        private readonly List<Member> MemberList = new List<Member>();
        private readonly List<FitnessClass> ClassList = new List<FitnessClass>();
        private int membershipId = 1;
        public void AddMember(string name, string membershipType, int months)
        {
            Member member = new Member()
            {
                MemberId = membershipId++,
                Name = name,
                MembershipType = membershipType,
                JoinDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddMonths(months)
            };
            MemberList.Add(member);
        }
        public void AddClass(string className, string instructor, DateTime schedule, int maxParticipants)
        {
            FitnessClass fitnessClass = new FitnessClass()
            {
                ClassName = className,
                Instructor = instructor,
                Schedule = schedule,
                MaxParticipants = maxParticipants
            };
            ClassList.Add(fitnessClass);
        }
        public bool RegisterForClass(int memberId, string className)
        {
            Member member = null;
            foreach(Member m in MemberList)
            {
                if (m.MemberId == memberId)
                {
                    member = m;
                    break;
                }
            }
            if (member == null || member.ExpiryDate < DateTime.Now)
                return false;

            foreach (FitnessClass c in ClassList)
            {
                if (c.ClassName == className)
                {
                    if (c.RegisteredMembers.Count < c.MaxParticipants && !c.RegisteredMembers.Contains(memberId))
                    {
                        c.RegisteredMembers.Add(memberId);
                        return true;
                    }
                }
            }
            return false;
        }
        public Dictionary<string, List<Member>> GroupMembersByMembershipType()
        {
            Dictionary<string, List<Member>> grouped =
                new Dictionary<string, List<Member>>();

            foreach (Member member in MemberList)
            {
                if (!grouped.ContainsKey(member.MembershipType))
                {
                    grouped[member.MembershipType] = new List<Member>();
                }
                grouped[member.MembershipType].Add(member);
            }
            return grouped;

            //return MemberList
            //    .GroupBy(m => m.MembershipType)
            //    .ToDictionary(g => g.Key, g => g.ToList());
        }
        public List<FitnessClass> GetUpcomingClasses()
        {
            List<FitnessClass> upcoming = new List<FitnessClass>();
            DateTime now = DateTime.Now;
            DateTime nextWeek = now.AddDays(7);

            foreach (FitnessClass c in ClassList)
            {
                if (c.Schedule >= now && c.Schedule <= nextWeek)
                {
                    upcoming.Add(c);
                }
            }
            return upcoming;

            //DateTime now = DateTime.Now;
            //DateTime nextWeek = DateTime.Now.AddDays(7);
            //return ClassList.Where(c => c.Schedule >= now && c.Schedule <= nextWeek).ToList();
        }
        public List<Member> GetMembers() => MemberList;
        public List<FitnessClass> GetClasses() => ClassList;

    }
    public class Program
    {
        static void Main(string[] args)
        {
            GymManager manager = new GymManager();

            while (true)
            {
                Console.WriteLine("1. Add Member");
                Console.WriteLine("2. Add Fitness Class");
                Console.WriteLine("3. Register Member for Class");
                Console.WriteLine("4. Group Members by Membership Type");
                Console.WriteLine("5. View Upcoming Classes");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Membership Type (Basic/Premium/Platinum): ");
                    string type = Console.ReadLine();

                    Console.Write("Enter Duration (months): ");
                    int months = int.Parse(Console.ReadLine());

                    manager.AddMember(name, type, months);
                    Console.WriteLine("Member added.\n");
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Class Name: ");
                    string className = Console.ReadLine();

                    Console.Write("Enter Instructor Name: ");
                    string instructor = Console.ReadLine();

                    Console.Write("Enter Schedule (yyyy-MM-dd HH:mm): ");
                    DateTime schedule = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter Max Participants: ");
                    int max = int.Parse(Console.ReadLine());

                    manager.AddClass(className, instructor, schedule, max);
                    Console.WriteLine("Class added.\n");
                }
                else if (choice == 3)
                {
                    Console.Write("Enter Member ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Enter Class Name: ");
                    string className = Console.ReadLine();

                    bool registered = manager.RegisterForClass(id, className);
                    Console.WriteLine(
                        registered ? "Registration successful.\n"
                                   : "Registration failed.\n"
                    );
                }
                else if (choice == 4)
                {
                    var groups = manager.GroupMembersByMembershipType();

                    foreach (var group in groups)
                    {
                        Console.WriteLine($"Membership Type: {group.Key}");
                        foreach (Member m in group.Value)
                        {
                            Console.WriteLine(
                                $"ID: {m.MemberId}, Name: {m.Name}, Expiry: {m.ExpiryDate:dd-MM-yyyy}"
                            );
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == 5)
                {
                    var upcoming = manager.GetUpcomingClasses();

                    if (upcoming.Count == 0)
                    {
                        Console.WriteLine("No upcoming classes in the next 7 days.\n");
                    }
                    else
                    {
                        foreach (FitnessClass c in upcoming)
                        {
                            Console.WriteLine(
                                $"{c.ClassName} | {c.Instructor} | {c.Schedule} | " +
                                $"Seats: {c.RegisteredMembers.Count}/{c.MaxParticipants}"
                            );
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == 6)
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice.\n");
                }
            }
        }
    }
}
