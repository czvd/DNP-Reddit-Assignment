namespace CLI.UI.ManageUsers;

public class ManageUsersView : BaseView
{
    private readonly IUserRepository _users;
    public ManageUsersView(IUserRepository users) => _users = users;

    public async Task ShowAsync()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Users");
            Console.WriteLine("1) Create user");
            Console.WriteLine("2) List users");
            Console.WriteLine("0) Back");
            Console.WriteLine("Select: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await new CreateUserView(_users).ShowAsync();
                    break;
                case "2":
                    await new ListUsersView(_users).ShowAsync();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid.");
                    break;
            }
        }
    }
}