using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class ListPostsView : BaseView
{
    private readonly IPostRepository _posts;
    public ListPostsView(IPostRepository posts) => _posts = posts;
    
    public async Task ShowAsync()
    {
        Console.WriteLine();
        Console.WriteLine("Posts (id, title)");

        var list = _posts.GetManyAsync().OrderBy(p => p.Id).ToList();

        if (list.Count == 0)
        {
            Console.WriteLine("(no posts yet)");
        }
        else
        {
            foreach (var p in list)
                Console.WriteLine($"{p.Id,3}  {p.Title}");
        }

        await PauseAsync();
    }
}