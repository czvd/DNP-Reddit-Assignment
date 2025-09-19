using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class SinglePostsView : BaseView
{
    private readonly IUserRepository _users;
    private readonly IPostRepository _posts;
    private readonly ICommentRepository _comments;

    public SinglePostsView(IUserRepository users, IPostRepository posts, ICommentRepository comments)
    {
        _users = users;
        _posts = posts;
        _comments = comments;
    }

    public async Task ShowAsync()
    {
        Console.WriteLine();
        Console.WriteLine("View Post");

        int id = InputHelper.ReadIntRequired("Post Id: ");

        Entities.Post post;
        try
        {
            post = await _posts.GetSingleAsync(id);   // your repos throw if not found
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Post not found.");
            await PauseAsync();
            return;
        }

        Console.WriteLine($"\n[{post.Id}] {post.Title}");
        Console.WriteLine($"By user {post.UserId}\n");
        Console.WriteLine(post.Body);
        Console.WriteLine("\nComments:");
        
        var comments = _comments.GetManyAsync()
            .Where(c => c.PostId == post.Id)
            .OrderBy(c => c.Id)
            .ToList();

        if (comments.Count == 0)
        {
            Console.WriteLine("(none yet)");
        }
        else
        {
            foreach (var c in comments)
                Console.WriteLine($"- ({c.Id}) u{c.UserId}: {c.Body}");
        }

        await PauseAsync();
    }
}