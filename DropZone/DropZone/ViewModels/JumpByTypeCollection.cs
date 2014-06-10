using System;
using System.Collections;
using System.Collections.Generic;
using DropZone.Annotations;
using DropZone.Models;

namespace DropZone.ViewModels
{
    /// <summary>
    /// Represents a list of jumps for a given jump type.
    /// </summary>
    public class JumpByTypeCollection : IEnumerable<JumpViewModel>
    {
        private readonly IJumpType _jumpType;
        private readonly IEnumerable<JumpViewModel> _viewModelsForJumpType;

        /// <summary>
        /// Initializes a new instance of the <see cref="JumpByTypeCollection"/> class.
        /// </summary>
        public JumpByTypeCollection([NotNull] IJumpType jumpType,
            [NotNull] IEnumerable<JumpViewModel> viewModelsForJumpType)
        {
            if (jumpType == null) throw new ArgumentNullException("jumpType");
            if (viewModelsForJumpType == null) throw new ArgumentNullException("viewModelsForJumpType");

            _jumpType = jumpType;
            _viewModelsForJumpType = viewModelsForJumpType;
        }

        /// <summary>
        /// Gets the name of the jump type.
        /// </summary>
        public string JumpTypeName
        {
            get { return _jumpType.Name; }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        public IEnumerator<JumpViewModel> GetEnumerator()
        {
            return _viewModelsForJumpType.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}