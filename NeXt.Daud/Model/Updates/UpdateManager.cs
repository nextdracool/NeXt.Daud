using System.Collections.ObjectModel;

namespace NeXt.Daud.Model.Updates
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class UpdateManager
    {
        public UpdateManager()
        {
            Items = new ObservableCollection<IUpdateAction>();
        }

        public void Add(IUpdateAction item) => Items.Add(item);

        public ObservableCollection<IUpdateAction> Items { get; set; }

        public void Execute()
        {
            foreach (var update in Items)
            {
                update.Run();
            }
        }
    }
}
