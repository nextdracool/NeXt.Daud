using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeXt.Daud.Model.Updates
{
    /// <summary>
    /// An update action that performs multiple other update actions when executed
    /// </summary>
    public class GroupUpdateAction : UpdateActionBase
    {
        public GroupUpdateAction(IEnumerable<IUpdateAction> updates, string displayText, string reason, string description)
            : base(displayText, reason, description)
        {
            this.updates = updates;
        }

        private readonly IEnumerable<IUpdateAction> updates;

        /// <inheritdoc />
        public override void Run()
        {
            foreach (var update in updates)
            {
                update.Run();
            }
        }
    }
}
