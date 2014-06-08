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
        private static IList<IJump> _jumps;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeRepository"/> class.
        /// </summary>
        public FakeRepository()
        {
            _jumps = CreateTestJumps();
        }

        private static IList<IJump> CreateTestJumps()
        {
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

        /// <summary>
        /// Saves the specified jump.
        /// </summary>
        public async Task Save(IJump jump)
        {
            _jumps.Add(jump);
            await Task.Delay(0);
        }

        /// <summary>
        /// Loads a list of all the jumps.
        /// </summary>
        public async Task<IEnumerable<IJump>> LoadAllJumps()
        {
            await Task.Delay(0);
            return _jumps;
        }

        /// <summary>
        /// Loads all aircraft.
        /// </summary>
        public async Task<IEnumerable<IAircraft>> LoadAllAircraft()
        {
            await Task.Delay(0);
            return new[]
            {
                new Aircraft("Beech C90 - King Air"), 
                new Aircraft("Cessna 182 - Skylane"), 
                new Aircraft("Cessna 205 / 206 Skywagon"), 
                new Aircraft("Cessna 208A/ 208B - Caravan"), 
                new Aircraft("de Havilland Canada DHC-6"), 
                new Aircraft("Dornier Do-28 G92"), 
                new Aircraft("Douglas DC-3"), 
                new Aircraft("GippsAero GA8 - Airvan"), 
                new Aircraft("Pacific Aerospace P-750 XSTOL"), 
                new Aircraft("Pilatus PC-6 - Porter"), 
                new Aircraft("Quest - Kodiak"), 
                new Aircraft("Shorts SC-7 - Skyvan"), 
                new Aircraft("Technoavia SMG-92 - Turbo Finist")
            };
        }
    }
}