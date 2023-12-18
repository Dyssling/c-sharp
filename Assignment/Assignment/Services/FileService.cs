using Assignment.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Assignment.Services
{
    /// <summary>
    /// Saves or reads the list of contacts from file.
    /// </summary>
    public class FileService : IFileService
    {
        private string _path = @"c:\Education\c-sharp\Assignment\contactList.json";
        private JsonSerializerSettings _settings = new JsonSerializerSettings //Använder JsonSerializerSettings eftersom jag senare Deserializar en lista av typen interface
        {
            TypeNameHandling = TypeNameHandling.Objects
        };

        public List<IContact> ReadFile()
        {
            if (File.Exists(_path)) //Först kollar programmet om filen med kontaktlistan ens finns
            {
                using (var sr = new StreamReader(_path))
                {
                    try
                    {
                        var contactList = JsonConvert.DeserializeObject<List<IContact>>(sr.ReadToEnd(), _settings)!;
                        if (contactList == null) //Om kontaktlistan är tom så skapas en ny tom lista, bara för att undvika null-värden i resten av koden
                        {
                            contactList = new List<IContact>();
                        }
                        return contactList;
                    }
                    catch (Exception ex) //Om det sker något fel så skrivs felet ut i debuggern, och en ny tom lista returneras.
                    {
                        Debug.WriteLine(ex);
                        return new List<IContact>();
                    }
                }
            }
            else //Om filen inte finns så returneras en ny tom lista.
            {
                return new List<IContact>();
            }

        }

        public void SaveContactList(List<IContact> contactList)
        {
            using (var sw = new StreamWriter(_path))
            {
                try
                {
                    sw.WriteLine(JsonConvert.SerializeObject(contactList, _settings));
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
    }
}
