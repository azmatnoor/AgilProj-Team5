
namespace AgiltProjektarbete
{
    public class RestaurantReview
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public string Message { get; set; }
    }
}
