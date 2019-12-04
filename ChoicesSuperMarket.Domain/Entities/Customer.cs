namespace ChoicesSuperMarket.Domain.Entities
{
    public class Customer
    {
        public Customer(string name, string email)
        {
            Name = name;
            Email = email;
        }

        protected Customer()
        {
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public void ChangeUserName(string name)
        {
            Name = name;
        }

        public void ChangeUserEmail(string email)
        {
            Email = email;
        }
    }
}