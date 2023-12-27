using System.Collections.ObjectModel;

namespace Assignment.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Reads and returns the list of contacts from file.
        /// </summary>
        /// <returns></returns>
        List<IContact> ReadFile(string path);

        /// <summary>
        /// Returns an ObservableCollection of contacts.
        /// </summary>
        /// <returns></returns>
        ObservableCollection<IContact> GetContacts();

        /// <summary>
        /// Saves and overwrites the list of contacts to file.
        /// </summary>
        /// <param name="contactList"></param>
        void SaveContactList(string path);

    }
}
