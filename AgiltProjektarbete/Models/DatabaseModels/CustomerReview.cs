
namespace AgiltProjektarbete
{
    public class CustomerReview
    {
        public string Id { get; set; }
        public virtual Restaurant Author { get; set; }
        public virtual User Customer { get; set; }
        public string Message { get; set; }
    }
}
