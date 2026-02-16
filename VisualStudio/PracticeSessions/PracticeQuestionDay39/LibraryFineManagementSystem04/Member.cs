namespace LibraryFineManagementSystem04
{
    public class Member
    {
        public string MemberId { get; set; }
        public string Name { get; set; }
        public int FineAmount { get; set; }

        public Member(string memberId, string name, int fineAmount)
        {
            if (fineAmount < 0)
                throw new InvalidFineException("Invalid Fine");

            MemberId = memberId;
            Name = name;
            FineAmount = fineAmount;
        }
    }
}
