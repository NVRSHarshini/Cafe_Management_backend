using FoodOrdering.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cafe.Repositories
{
    public class FeedbackRepo:IFeedbackRepo
    {
        private DBContext context;
        public FeedbackRepo(DBContext _context)
        {
            context = _context;
        }
        public string AddnewFeedback(Feedback feedback)
        {
            int count = context.Feedback.Count();
            context.Feedback.Add(feedback);
            context.SaveChanges();
            int newCount = context.Feedback.Count();
            if (newCount > count)
            {
                return "Record inserted successfully";
            }
            else
                return "oops something went wrong while inserting the record";
        }

        public List<Feedback> GetAllFeedback()
        {
            return context.Feedback.ToList();
        }


    }
}
