namespace Assignment.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Reads and returns the list of contacts from file.
        /// </summary>
        /// <returns></returns>
        List<IContact> ReadFile();

        /// <summary>
        /// Saves and overwrites the list of contacts to file.
        /// </summary>
        /// <param name="contactList"></param>
        void SaveContactList(List<IContact> contactList);

    }
}
