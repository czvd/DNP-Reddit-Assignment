using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class ManagePostsView : BaseView
{
    private readonly IUserRepository _users;
    private readonly IPostRepository _posts;
    private readonly ICommentRepository _comments;
    
    public ManagePostsView(IUserRepository users, IPostRepository posts, ICommentRepository comments)
    {
        _users = users; _posts = posts; _comments = comments;
    }
    
    public async Task ShowAsync()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Posts & Comments");
            Console.WriteLine("1) Create post");
            Console.WriteLine("2) List posts (id, title)");
            Console.WriteLine("3) View a post (title, body, comments)");
            Console.WriteLine("4) Add comment to post");
            Console.WriteLine("0) Back");
            Console.Write("Select: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await new CreatePostView(_users,_posts).ShowAsync();
                    break;
                case "2":
                    await new ListPostsView(_posts).ShowAsync();
                    break;
                case "3":
                    await new SinglePostsView(_users, _posts, _comments).ShowAsync();
                    break;
                case "4":
                    await new AddCommentView(_users, _posts, _comments).ShowAsync();
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
