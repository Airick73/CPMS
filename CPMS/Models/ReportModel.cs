namespace CPMS.Models
{
    public class ReportModel
    {
        public string Title { get; set; }
        public int PaperID { get; set; }
        public int NumReviews { get; set; }
        public float total_score_AppropriatnessOfTopic { get; set; }
        public float total_score_TimelinessOfTopic { get; set; }
        public float total_score_SupportiveEvidence { get; set; }
        public float total_score_TechnicalQuality { get; set; }
        public float total_score_ScopeOfCoverage { get; set; }
        public float total_score_CitationOfPreviousWork { get; set; }
        public float total_score_Originality { get; set; }
        public float total_score_OrganizationOfPaper { get; set; }
        public float total_score_ClarityOfMainMessage { get; set; }
        public float total_score_Mechanics { get; set; }
        public float total_score_SuitabilityForPresentation { get; set; }
        public float total_score_PotentialInterestInTopic { get; set; }
        public float total_score_OverallRating { get; set; }
        public string FileName { get; set; }
        public float WeightedScore { get; set; }
        

    }
}