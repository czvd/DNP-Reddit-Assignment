namespace CLI.UI.ManageUsers;

public sealed class ListUsersView : BaseView
{
    private readonly IUserRepository _users;
    public ListUsersView(IUserRepository users) => _users = users;

    public async Task ShowAsync()
    {
        Console.WriteLine();
        Console.WriteLine("All Users (id, username)");

        var query = _users.GetManyAsync();         

        if (!query.Any())
        {
            Console.WriteLine("(no users yet)");
            await PauseAsync();
            return;
        }

        foreach (var u in query.OrderBy(u => u.Id))
            Console.WriteLine($"{u.Id,3}  {u.Username}");

        await PauseAsync();
    }
}