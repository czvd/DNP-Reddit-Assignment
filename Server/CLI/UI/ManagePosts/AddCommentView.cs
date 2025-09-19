using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class AddCommentView : BaseView
{
    private readonly IUserRepository _users;
    private readonly IPostRepository _posts;
    private readonly ICommentRepository _comments;

    public AddCommentView(IUserRepository users, IPostRepository posts, ICommentRepository comments)
    {
        _users = users;
        _posts = posts;
        _comments = comments;
    }

    public async Task ShowAsync()
    {
        Console.WriteLine();
        Console.WriteLine("Add Comment");

        int postId = InputHelper.ReadIntRequired("Post Id: ");
        int userId = InputHelper.ReadIntRequired("User Id: ");
        string body = InputHelper.ReadRequired("Comment: ");

        // validate post & user (your GetSingleAsync throws if not found)
        try { _ = await _posts.GetSingleAsync(postId); }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Post not found.");
            await PauseAsync();
            return;
        }

        try { _ = await _users.GetSingleAsync(userId); }
        catch (InvalidOperationException)
        {
            Console.WriteLine("User not found.");
            await PauseAsync();
            return;
        }

        var created = await _comments.AddAsync(new Comment
        {
            Body = body,
            PostId = postId,
            UserId = userId
        });

        Console.WriteLine($"Added comment {created.Id}.");
        await PauseAsync();
    }
}