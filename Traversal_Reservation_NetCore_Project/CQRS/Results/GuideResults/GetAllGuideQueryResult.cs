namespace Traversal_Reservation_NetCore_Project.CQRS.Results.GuideResults
{
    public class GetAllGuideQueryResult
    {
        public int GuideID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
