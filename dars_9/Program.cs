using dars_9.Models;
using dars_9.Service;

namespace dars_9;

class Program
{
      static void Main(string[] args)
      {
            {
                  FrontEnd();
            }

            public static void FrontEnd()
            {
                  var postService = new PostService();

                  while (true)
                  {
                        Console.WriteLine("1. Add a posts");
                        Console.WriteLine("2. Type ");
                        Console.WriteLine("3. Discription");
                        Console.WriteLine("4. Posted date");
                        Console.WriteLine("5. Quantity likes");
                        Console.WriteLine("6. Comments");
                        Console.WriteLine("6. View Names");
                        Console.Write("Option : ");
                        var Option = Console.ReadLine();


                        if (Option == "1")
                        {
                              var post = new Post();
                              Console.Write("Enter Owner name : ");
                              post.OwnerName = Console.ReadLine();
                              Console.Write("Enter Type : ");
                              post.Type = Console.ReadLine();
                              Console.Write("Enter discription : ");
                              post.Description = Console.ReadLine();
                              Console.Write("Enter posteddate : ");
                              post.PostedTime = DateTime.Parse(Console.ReadLine());
                              Console.Write("Enter quantity likes : ");
                              post.Quantitylikes = int.Parse(Console.ReadLine());
                              Console.Write("Enter comments : "); 
                              var comment = Console.ReadLine();
                              Console.Write("Enter view names : ");
                              var viewName = Console.ReadLine();

                              postService.Add(post);
                        }
                  }
            }