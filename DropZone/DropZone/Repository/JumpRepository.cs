using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DropZone.DependencyService;
using DropZone.Models;

namespace DropZone.Repository
{
    /// <summary>
    /// Responsible for saving and loading jump log entries for the application.
    /// </summary>
    public class JumpRepository : IRepository
    {
        private static Aircraft[] _allAircraft;
        private static IEnumerable<IJumpType> _jumpTypes;
        private readonly AzureJumpMobileService _mobileService;

        /// <summary>
        /// Initializes a new instance of the <see cref="JumpRepository"/> class.
        /// </summary>
        public JumpRepository()
        {
            _allAircraft = CreateAircraft();
            _jumpTypes = CreateJumpTypes();
            // TODO: pass in dependency service.
            _mobileService = new AzureJumpMobileService(Xamarin.Forms.DependencyService.Get<IAzureJumpMobileServiceClient>());
        }

        /// <summary>
        /// Saves the specified jump.
        /// </summary>
        public async Task Save(IJump jump)
        {
            await _mobileService.Save(new JumpItem(jump));
        }

        /// <summary>
        /// Loads a list of all the jumps.
        /// </summary>
        public async Task<IEnumerable<IJump>> LoadAllJumps()
        {
            IEnumerable<JumpItem> loadedJumps = await _mobileService.LoadAllJumps();
            IList<IJump> jumps = new List<IJump>();

            foreach (JumpItem jump in loadedJumps)
            {
                Aircraft aircraft = _allAircraft.First(craft => craft.Name == jump.Aircraft);
                IJumpType jumpType = _jumpTypes.First(type => type.Name == jump.JumpType);

                jumps.Add(new Jump(jump.Id, jump.JumpNumber, jump.JumpDate, jump.Location, aircraft, 
                    jump.Altitude, jumpType, jump.FreefallDelay, jump.TotalTime, jump.Container, 
                    jump.Description, jump.ThumbnailImage));
            }

            return jumps;
        }

        /// <summary>
        /// Loads all jump types.
        /// </summary>
        public IEnumerable<IJumpType> LoadAllJumpTypes()
        {
            return _jumpTypes;
        }

        /// <summary>
        /// Loads a list of aircraft.
        /// </summary>
        public IEnumerable<IAircraft> LoadAllAircraft()
        {
            return _allAircraft;
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
                new JumpType("Wingsuit"),
                new JumpType("Other")
            };
        }

        private static Aircraft[] CreateAircraft()
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
                new Aircraft("Technoavia SMG-92 - Turbo Finist"),
                new Aircraft("Other")
            };
        }
    }
}