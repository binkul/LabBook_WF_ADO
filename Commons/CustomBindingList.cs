using System.Collections.Generic;
using System.ComponentModel;

namespace LabBook.Commons
{
    public class CustomBindingList<T> : BindingList<T>
    {
        public CustomBindingList(IList<T> list) : base(list)
        {
        }


        public void Change(T item, int index)
        {
            bool raiseListChangedEvents = this.RaiseListChangedEvents;
            try
            {
                this.RaiseListChangedEvents = false;
                int oldIndex = IndexOf(item);
                this.Remove(item);
                this.InsertItem(index, item);
                this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, index, oldIndex));
            }
            finally
            {
                this.RaiseListChangedEvents = raiseListChangedEvents;
            }
        }
    }
}
