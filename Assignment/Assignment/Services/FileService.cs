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
                        if (contactList == null) //Om kontaktlistan är tom så säger programmet till via en WriteLine
                        {
                            Console.WriteLine("Kontaktlistan är tom.");
                            return null!;
                        }
                        else
                        {
                            return contactList;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error");
                        Debug.WriteLine(ex);
                        return null!;
                    }
                }
            }
            else //Om filen inte finns så säger programmet till via en WriteLine
            {
                Console.WriteLine("Kontaktlistan existerar inte.");
                return null!;
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
                    Console.WriteLine("Error");
                    Debug.WriteLine(ex);
                }
            }
        }
    }
}
