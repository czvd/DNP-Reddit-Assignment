using Entities;

namespace CLI.UI.ManageUsers;

public class CreateUserView : BaseView
{
    private readonly IUserRepository _users;
    public CreateUserView(IUserRepository users) => _users = users;

    public async Task ShowAsync()
    {
        Console.WriteLine();
        Console.WriteLine("Create User");
        string username = InputHelper.ReadRequired("Username: ");
        string password = InputHelper.ReadRequired("Password: ");

        var created = await _users.AddAsync(new User { Username = username, Password = password });
        
        Console.WriteLine($"Created user with Id {created.Id}");
        await PauseAsync();
    }

}