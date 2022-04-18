using System.ComponentModel;
using PostSharp.Patterns.Model;
using System;

namespace Demo
{
    [NotifyPropertyChanged]
    public abstract class Base
    {
        [IgnoreAutoChangeNotification]
        public bool IsDirty { get; private set;}

        [IgnoreAutoChangeNotification]
        public DatabaseStatus RecordStatus { get; private set; }

        protected Base()
        {
            ((INotifyPropertyChanged)this).PropertyChanged += OnPropertyChanged;
            RecordStatus = DatabaseStatus.New;
        }

        public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            IsDirty = true;

            if (RecordStatus == DatabaseStatus.Saved)
            {
                RecordStatus = DatabaseStatus.Modified;
            }
        }

        public void ResetDirty() => IsDirty = false;

        public void SetDatabaseStatus(DatabaseStatus status)
        {
            RecordStatus = status;
        }
    }
}
