using System.Collections.ObjectModel;

namespace Assignment.Interfaces
{
    public interface IContactService
    {
        /// <summary>
        /// Removes all contacts with the given email.
        /// </summary>
        /// <param name="contactList"></param>
        /// <param name="emailInput"></param>
        /// <returns></returns>
        ObservableCollection<IContact> RemoveByEmail(ObservableCollection<IContact> contactList, string emailInput);
    }
}
