using CLI.UI.ManagePosts;
using RepositoryContracts;

namespace CLI.UI;

public class CliApp : BaseView
{
    private readonly IUserRepository _users;
    private readonly ICommentRepository _comments;
    private readonly IPostRepository _posts;

    public CliApp(IUserRepository users, ICommentRepository comments, IPostRepository posts)
    {
        _users = users;
        _comments = comments;
        _posts = posts;
    }

    public async Task StartAsync()
    {
        Console.Clear();
        Console.WriteLine("=== Simple Blog CLI ===\n");

        while (true)
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("1) Manage Users");
            Console.WriteLine("2) Manage Posts & Comments");
            Console.WriteLine("0) Exit");
            Console.Write("Select: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await new ManageUsers.ManageUsersView(_users).ShowAsync();
                    break;
                case "2":
                    await new ManagePostsView(_users, _posts, _comments).ShowAsync();
                    break;
                case "0":
                    Console.WriteLine("\nGoodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}