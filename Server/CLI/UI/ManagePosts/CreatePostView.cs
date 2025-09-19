using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class CreatePostView : BaseView
{
    private readonly IPostRepository _posts;
    private readonly IUserRepository _users;
    public CreatePostView(IUserRepository users, IPostRepository posts)
    {
        _users = users; _posts = posts;
    }

    public async Task ShowAsync()
    {
        Console.WriteLine();
        Console.WriteLine("Create Post");

        string title = InputHelper.ReadRequired("Title: ");
        string body = InputHelper.ReadRequired("Body: ");
        int userId = InputHelper.ReadIntRequired("User Id: ");

        try
        {
            _ = await _users.GetSingleAsync(userId); 
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("User not found.");
            await PauseAsync();
            return;
        }

        var created = await _posts.AddAsync(new Post { Title = title, Body = body, UserId = userId });
        Console.WriteLine($"Created Post {created.Id}.");
        await PauseAsync();
    }
}