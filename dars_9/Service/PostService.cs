using dars_9.Models;

namespace dars_9.Service;

public class PostService
{
      private List<Post> posts;

      public PostService()
      {
            posts = new List<Post>();
      }

      public Post AddPost(Post post)
      {
            post.Id = Guid.NewGuid();
            posts.Add(post);
            
            return post;
      }

      public Post GetById(Guid postId)
      {
            foreach (var post in posts)
            {
                  if (post.Id == postId)
                  {
                        return post;
                  }
            }

            return null;
      }

      public bool DeletePost(Guid postId)

      {
            var postFromDb = GetById(postId);
            if (postFromDb is null)
            {
                  return false;
            }

            posts.Remove(postFromDb);
            return true;
      }

      public bool UpdatePost(Post post)
      {
            var postFromDb = GetById(post.Id);
            if (postFromDb is null)
            {
                  return false;
            }

            var index = posts.IndexOf(postFromDb);
            posts[index] = post;

            return true;
      }

      public List<Post> Getposts()
      {
            return posts;
      }

      public Post GetMostViewedPost()
      {
            var reponsePost = new Post();
            foreach (var post in posts)
            {
                  if (reponsePost.ViewerNames.Count < post.ViewerNames.Count)
                  {
                        reponsePost = post;
                  }
            }

            return reponsePost;
      }

      public Post GetMostLikedPost()
      {
            var reponsePost = new Post();
            foreach (var post in posts)
            {
                  if (reponsePost.Quantitylikes < post.Quantitylikes)
                  {
                        reponsePost = post;
                  }
            }

            return reponsePost;
      }

      public Post GetMostCommentedPost()
      {
            var reponsePost = new Post();
            foreach (var post in posts)
            {
                  if (reponsePost.Comments.Count < post.Comments.Count)
                  {
                        reponsePost = post;
                  }
            }

            return reponsePost;
      }

      public List<Post> GetPostsByComment(string comment)
      {
            var reponsePosts = new List<Post>();
            foreach (var post in posts)
            {
                  if (post.Comments.Contains(comment) is true)
                  {
                        reponsePosts.Add(post);
                  }
            }

            return reponsePosts;
      }

      public bool AddCommentToPost(Guid postId, string comment)
      {
            var post = GetById(postId);
            if (post is null)
            {
                  return false;
            }

            post.Comments.Add(comment);
            return true;
      }

      public bool AddViwerNameToPost(Guid postId, string viwerName)
      {
            var post = GetById(postId);

            if (post is null)
            {
                  return false;
            }

            post.ViewerNames.Add(viwerName);
            return true;
      }

      public bool AddLikeToPost(Guid postId)
      {
            var post = GetById(postId);
            if (post is null)
            {
                  return false;
            }

            post.Quantitylikes++;
            return true;
      }
}