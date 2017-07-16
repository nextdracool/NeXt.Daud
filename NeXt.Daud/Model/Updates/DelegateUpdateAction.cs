using System;

namespace NeXt.Daud.Model.Updates
{
    /// <summary>
    /// Base class that Update actions can inherit from
    /// </summary>
    public abstract class UpdateActionBase : IUpdateAction
    {
        protected UpdateActionBase(string displayText, string reason, string description)
        {
            DisplayText = displayText;
            Reason = reason;
            Description = description;
            Done = false;
        }

        /// <inheritdoc />
        public string DisplayText { get; }
        /// <inheritdoc />
        public string Description { get; }
        /// <inheritdoc />
        public string Reason { get; }

        /// <inheritdoc />
        public bool Done { get; private set; }

        /// <inheritdoc />
        public abstract void Run();

        void IUpdateAction.Run()
        {
            Run();
            Done = true;
        }
    }

    public class DelegateUpdateAction : UpdateActionBase
    {
        public DelegateUpdateAction(Action action, string displayText, string reason, string description)
            : base(displayText, reason, description)
        {
            this.action = action;
        }
        private readonly Action action;
        public override void Run() => action();
    }
}