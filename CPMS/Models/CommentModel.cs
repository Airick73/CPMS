using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS.Models
{
    public class CommentModel
    {
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string FileName { get; set; }
        public string Title { get; set; }
        public string ContentComments { get; set; }
        public string WrittenDocumentComments { get; set; }
        public string PotentialForOralPresentationComments { get; set; }
        public string OverallRatingComments { get; set; }


    }
}
