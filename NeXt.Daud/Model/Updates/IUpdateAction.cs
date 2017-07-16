namespace NeXt.Daud.Model.Updates
{
    /// <summary>
    /// Represents an update that will be executed later
    /// </summary>
    public interface IUpdateAction
    {
        void Run();

        /// <summary>
        /// Short display text of the action
        /// </summary>
        string DisplayText { get; }

        /// <summary>
        /// Detailed description of the action
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Describes why this action is necessary
        /// </summary>
        string Reason { get; }

        /// <summary>
        /// Whether the action was executed or not
        /// </summary>
        bool Done { get; }
    }
}
