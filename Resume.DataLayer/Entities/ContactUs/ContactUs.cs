namespace Resume.DataLayer.Entities.ContactUs;

public class ContactUs:BaseEntity<int>
{
    #region Properties

    public string Title { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? Answer { get; set; }
    #endregion
}
