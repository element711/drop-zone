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
                new Jump("AFF Level 1", DateTime.Now.AddDays(-5), "Parakai", "XL-SDF", 13000, string.Empty, 50, 0, "Telesis 260", "Excellent clib out - goodexit count.", new Uri("https://skydivesandiego.com/wp-content/uploads/2009/09/soloJumping1.jpg")),
                new Jump("AFF Level 2", DateTime.Now.AddDays(-4), "Parakai", "XL-SDF", 12000, string.Empty, 50, 0, "Telesis 260", "Good. Good. Good. Good. Good. Good.", new Uri("http://i.vimeocdn.com/video/402211206_640.jpg")),
                new Jump("AFF Level 3", DateTime.Now.AddDays(-3), "Parakai", "XL-SDF", 13500, string.Empty, 50, 0, "Telesis 260", "Could be better. Could be better. Could be better. Could be better.", new Uri("http://i.vimeocdn.com/video/267802283_640.jpg")),
                new Jump("AFF Level 4", DateTime.Now.AddDays(-2), "Parakai", "XL-SDF", 12500, string.Empty, 50, 0, "Telesis 260", "Minor hesitation. Minor hesitation. Minor hesitation.", new Uri("http://i.vimeocdn.com/video/468821994_640.jpg")),
                new Jump("AFF Level 5", DateTime.Now.AddDays(-1), "Parakai", "XL-SDF", 12200, string.Empty, 50, 0, "Telesis 260", "Great jump. Great jump. Great jump. ", new Uri("http://i.vimeocdn.com/video/443254475_640.jpg")),

                new Jump("AFF Level 6", DateTime.Now.AddDays(-5), "Parakai", "XL-SDF", 13000, string.Empty, 50, 0, "Telesis 260", "Excellent clib out - goodexit count.", new Uri("https://skydivesandiego.com/wp-content/uploads/2009/09/soloJumping1.jpg")),
                new Jump("AFF Level 7", DateTime.Now.AddDays(-4), "Parakai", "XL-SDF", 12000, string.Empty, 50, 0, "Telesis 260", "Good. Good. Good. Good. Good. Good.", new Uri("http://i.vimeocdn.com/video/402211206_640.jpg")),
                new Jump("AFF Level 8", DateTime.Now.AddDays(-3), "Parakai", "XL-SDF", 13500, string.Empty, 50, 0, "Telesis 260", "Could be better. Could be better. Could be better. Could be better.", new Uri("http://i.vimeocdn.com/video/267802283_640.jpg")),
                new Jump("AFF Level 9", DateTime.Now.AddDays(-2), "Parakai", "XL-SDF", 12500, string.Empty, 50, 0, "Telesis 260", "Minor hesitation. Minor hesitation. Minor hesitation.", new Uri("http://i.vimeocdn.com/video/468821994_640.jpg")),
                new Jump("AFF Level 10", DateTime.Now.AddDays(-1), "Parakai", "XL-SDF", 12200, string.Empty, 50, 0, "Telesis 260", "Great jump. Great jump. Great jump. ", new Uri("http://i.vimeocdn.com/video/443254475_640.jpg"))
            };
        }
    }
}