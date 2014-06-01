using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DropZone.Models;

namespace DropZone.Repository
{
    /// <summary>
    /// Responsible for loading a sample data set to be used in the application. 
    /// Also simulates delay when saving/loading data. Real repository coming soon ...
    /// </summary>
    public class FakeRepository : IRepository
    {
        /// <summary>
        /// Saves the specified jump.
        /// </summary>
        public async Task Save(IJump jump)
        {
            await Task.Delay(1000);
        }

        /// <summary>
        /// Loads a list of all the jumps.
        /// </summary>
        public async Task<IEnumerable<IJump>> LoadAllJumps()
        {
            await Task.Delay(1000);

            return new List<IJump>
            {
                new Jump(1, DateTime.Now.AddDays(-5), "Parakai", "XL-SDF", 13000, string.Empty, 50, 0, "Telesis 260", "Excellent clib out - goodexit count."),
                new Jump(2, DateTime.Now.AddDays(-4), "Parakai", "XL-SDF", 12000, string.Empty, 50, 0, "Telesis 260", "Good. Good. Good. Good. Good. Good."),
                new Jump(3, DateTime.Now.AddDays(-3), "Parakai", "XL-SDF", 13500, string.Empty, 50, 0, "Telesis 260", "Could be better. Could be better. Could be better. Could be better."),
                new Jump(4, DateTime.Now.AddDays(-2), "Parakai", "XL-SDF", 12500, string.Empty, 50, 0, "Telesis 260", "Minor hesitation. Minor hesitation. Minor hesitation."),
                new Jump(5, DateTime.Now.AddDays(-1), "Parakai", "XL-SDF", 12200, string.Empty, 50, 0, "Telesis 260", "Great jump. Great jump. Great jump. ")
            };
        }
    }
}