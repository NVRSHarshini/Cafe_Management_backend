using FoodOrdering.Models;
using System.Collections.Generic;

namespace Cafe.Repositories
{
    public interface IFeedbackRepo
    {
        List<Feedback> GetAllFeedback();
        string AddnewFeedback(Feedback feedback);

    }
}
