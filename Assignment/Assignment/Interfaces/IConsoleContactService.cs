namespace Assignment.Interfaces
{
    public interface IConsoleContactService
    {
        /// <summary>
        /// Prints the list of contacts.
        /// </summary>
        /// <param name="contactList"></param>
        void ShowContacts(List<IContact> contactList);

        /// <summary>
        /// Adds a contact to the list and saves it to file.
        /// </summary>
        /// <param name="contactList"></param>
        void AddContact(List<IContact> contactList);

        /// <summary>
        /// Starts the "choose contact" menu. Returns an integer.
        /// </summary>
        /// <param name="contactList"></param>
        /// <returns></returns>
        int ChooseContact(List<IContact> contactList);

        /// <summary>
        /// Prints the properties of an individual contact. Needs the integer for the contact.
        /// </summary>
        /// <param name="contactList"></param>
        void ViewContactInformation(List<IContact> contactList, int contactInteger);

        /// <summary>
        /// Removes a contact from the list by its email address.
        /// </summary>
        /// <param name="contactList"></param>
        void RemoveContact(List<IContact> contactList);
    }
}
