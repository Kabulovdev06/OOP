namespace dars_9.Models;

public class Post
{
      public Guid Id { get; set; }

      public string OwnerName { get; set; } //egasing nomi
      
      public string Type { get; set; } // turi rasm video
      
      public string Description { get; set; } // tavsif
      
      public DateTime PostedTime { get; set; } //e'lon qilingan vaqt
      
      public int Quantitylikes  { get; set; } // like lar miqdori

      public List<string> Comments { get; set; } = new List<string>(); // commentariyalar

      public List<string> ViewerNames { get; set; } = new List<string>(); // kimlar ko'rgani
      }