namespace Resume.DataLayer.Entities.Education
{
    public class Education:BaseEntity<int>
    {

        #region Property

        public int UserId { get; set; }
        public string? InstitutionName { get; set; }
        public string? Description { get; set; }
        public string? Degree { get; set; }
        public string? FieldOfStudy { get; set; }

        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        #endregion

        #region Relations

        public virtual User.User? User { get; set; }
        #endregion
    }
}
