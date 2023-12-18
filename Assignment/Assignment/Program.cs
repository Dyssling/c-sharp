using Assignment.Interfaces;
using Assignment.Models;
using Assignment.Services;

IContact contact = new Contact("Olle", "Brundin", "123", "olle@domain.com", "gata");
IContact contact2 = new Contact("Sven", "Brundin", "456", "sven@domain.com", "gata2");
List<IContact> contactList = new List<IContact>();
contactList.Add(contact);
contactList.Add(contact2);
IFileService fileService = new FileService();
//fileService.SaveContactList(contactList);
List<IContact> contactList2 = fileService.ReadFile();
//foreach (var x in contactList2)
//{
//    Console.WriteLine(x.FirstName);
//}
Console.ReadKey();


