using System;
using System.Collections.Generic;
using System.Linq;
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
        private static Aircraft[] _allAircraft;
        private static IEnumerable<IJumpType> _jumpTypes;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeRepository"/> class.
        /// </summary>
        public FakeRepository()
        {
            _allAircraft = CreateTestAircraft();
            _jumpTypes = CreateJumpTypes();
            _jumps = CreateTestJumps();
        }

        private static Aircraft[] CreateTestAircraft()
        {
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

        private static IEnumerable<IJumpType> CreateJumpTypes()
        {
            return new[]
            {
                new JumpType("BASE"), 
                new JumpType("Belly/RW"), 
                new JumpType("Freefly"), 
                new JumpType("Hop and Pop"), 
                new JumpType("Hybrid"), 
                new JumpType("Skysurfing"), 
                new JumpType("Tandem"), 
                new JumpType("Tracking"), 
                new JumpType("Wingsuit")
            };
        }

        private static IList<IJump> CreateTestJumps()
        {
            return new List<IJump>
            {
                new Jump("AFF Level 1", DateTime.Now.AddDays(-5), "76 Green Rd, Helensville, Parakai, New Zealand", _allAircraft.First(), 13000, _jumpTypes.Skip(1).First(), 50, 0, "Telesis 260", "Excellent clib out - goodexit count.", new Uri("https://skydivesandiego.com/wp-content/uploads/2009/09/soloJumping1.jpg")),
                new Jump("AFF Level 2", DateTime.Now.AddDays(-4), "76 Green Rd, Helensville, Parakai, New Zealand", _allAircraft.First(), 12000, _jumpTypes.Skip(1).First(), 50, 0, "Telesis 260", "Good. Good. Good. Good. Good. Good.", new Uri("http://i.vimeocdn.com/video/298414933_640.jpg")),
                new Jump("AFF Level 3", DateTime.Now.AddDays(-3), "76 Green Rd, Helensville, Parakai, New Zealand", _allAircraft.First(), 13500, _jumpTypes.Skip(1).First(), 50, 0, "Telesis 260", "Could be better. Could be better. Could be better. Could be better.", new Uri("http://i.vimeocdn.com/video/267802283_640.jpg")),
                new Jump("AFF Level 4", DateTime.Now.AddDays(-2), "76 Green Rd, Helensville, Parakai, New Zealand", _allAircraft.Skip(1).First(), 12500, _jumpTypes.Skip(1).First(), 50, 0, "Telesis 260", "Minor hesitation. Minor hesitation. Minor hesitation.", new Uri("http://i.vimeocdn.com/video/468821994_640.jpg")),
                new Jump("AFF Level 5", DateTime.Now.AddDays(-1), "76 Green Rd, Helensville, Parakai, New Zealand", _allAircraft.Skip(1).First(), 12200, _jumpTypes.Skip(1).First(), 50, 0, "Telesis 260", "Great jump. Great jump. Great jump. ", new Uri("http://i.vimeocdn.com/video/443254475_640.jpg")),
                                                                           
                new Jump("AFF Level 6", DateTime.Now.AddDays(-5), "76 Green Rd, Helensville, Parakai, New Zealand", _allAircraft.Skip(2).First(), 13000, _jumpTypes.Skip(2).First(), 50, 0, "Telesis 260", "Excellent clib out - goodexit count.", new Uri("https://skydivesandiego.com/wp-content/uploads/2009/09/soloJumping1.jpg")),
                new Jump("AFF Level 7", DateTime.Now.AddDays(-4), "76 Green Rd, Helensville, Parakai, New Zealand", _allAircraft.Skip(3).First(), 12000, _jumpTypes.Skip(2).First(), 50, 0, "Telesis 260", "Good. Good. Good. Good. Good. Good.", new Uri("http://i.vimeocdn.com/video/298414933_640.jpg")),
                new Jump("AFF Level 8", DateTime.Now.AddDays(-3), "Skydive Queenstown", _allAircraft.Skip(3).First(), 13500, _jumpTypes.Skip(3).First(), 50, 0, "Telesis 260", "Could be better. Could be better. Could be better. Could be better.", new Uri("http://i.vimeocdn.com/video/267802283_640.jpg")),
                new Jump("AFF Level 9", DateTime.Now.AddDays(-2), "Skydive Sydney North Coast", _allAircraft.Skip(4).First(), 12500, _jumpTypes.Skip(3).First(), 50, 0, "Telesis 260", "Minor hesitation. Minor hesitation. Minor hesitation.", new Uri("http://i.vimeocdn.com/video/468821994_640.jpg")),
                new Jump("AFF Level 10", DateTime.Now.AddDays(-1), "Skydive Sydney North Coast", _allAircraft.Skip(5).First(), 12200, _jumpTypes.Skip(3).First(), 50, 0, "Telesis 260", "Great jump. Great jump. Great jump. ", new Uri("http://i.vimeocdn.com/video/443254475_640.jpg"))
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
        /// Loads all jump types.
        /// </summary>
        public async Task<IEnumerable<IJumpType>> LoadAllJumpTypes()
        {
            await Task.Delay(0);
            return _jumpTypes;
        }

        /// <summary>
        /// Loads all aircraft.
        /// </summary>
        public async Task<IEnumerable<IAircraft>> LoadAllAircraft()
        {
            await Task.Delay(0);
            return _allAircraft;
        }
    }
}