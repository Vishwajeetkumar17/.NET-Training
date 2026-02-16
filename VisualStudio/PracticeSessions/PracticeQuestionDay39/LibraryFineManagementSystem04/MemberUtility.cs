namespace LibraryFineManagementSystem04
{
    public class MemberUtility
    {
        private SortedDictionary<int, List<Member>> members = new SortedDictionary<int, List<Member>>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        public void AddMember(Member member)
        {
            if (!members.ContainsKey(member.FineAmount))
                members[member.FineAmount] = new List<Member>();

            members[member.FineAmount].Add(member);
        }

        public void DisplayMembers()
        {
            foreach (var entry in members)
            {
                foreach (var m in entry.Value)
                {
                    Console.WriteLine($"Details: {m.MemberId} {m.Name} {m.FineAmount}");
                }
            }
        }

        public void PayFine(string memberId, int amount)
        {
            if (amount <= 0)
                throw new InvalidFineException("Invalid Fine");

            foreach (var entry in members)
            {
                foreach (var m in entry.Value)
                {
                    if (m.MemberId.Equals(memberId))
                    {
                        entry.Value.Remove(m);

                        int newFine = m.FineAmount - amount;
                        if (newFine < 0)
                            throw new InvalidFineException("Invalid Fine");

                        m.FineAmount = newFine;

                        if (!members.ContainsKey(m.FineAmount))
                            members[m.FineAmount] = new List<Member>();

                        members[m.FineAmount].Add(m);
                        return;
                    }
                }
            }

            throw new MemberNotFoundException("Member Not Found");
        }
    }
}
