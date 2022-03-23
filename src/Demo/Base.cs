using System.ComponentModel;
using PostSharp.Patterns.Model;

namespace Demo
{
    [NotifyPropertyChanged]
    public abstract class Base
    {
        public bool IsDirty { get; private set;}

        public DatabaseStatus RecordStatus { get; private set; }

        protected Base()
        {
            ((INotifyPropertyChanged)this).PropertyChanged += OnPropertyChanged;
            RecordStatus = DatabaseStatus.New;
        }

        public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(IsDirty) && e.PropertyName != nameof(RecordStatus))
            {
                IsDirty = true;

                if (RecordStatus == DatabaseStatus.Saved)
                {
                    RecordStatus = DatabaseStatus.Modified;
                }
            }
        }

        public void ResetDirty() => IsDirty = false;

        public void SetDatabaseStatus(DatabaseStatus status)
        {
            RecordStatus = status;
        }
    }
}
