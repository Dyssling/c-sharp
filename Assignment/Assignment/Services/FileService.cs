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
        private JsonSerializerSettings _settings = new JsonSerializerSettings //Använder JsonSerializerSettings eftersom jag senare Deserializar en lista av typen interface
        {
            TypeNameHandling = TypeNameHandling.Objects
        };

        private List<IContact>? _contactList;

        public FileService() //Tom constructor för att dependency injection ska funka i WPF applikationen
        {
            
        }
        public FileService(List<IContact> contactList) //Constructor för konsolapplikationen, där man matar in listan
        {
            _contactList = contactList;
        }

        public List<IContact> ReadFile(string path)
        {
            if (File.Exists(path)) //Först kollar programmet om filen med kontaktlistan ens finns
            {
                using (var sr = new StreamReader(path))
                {
                    try
                    {
                        _contactList = JsonConvert.DeserializeObject<List<IContact>>(sr.ReadToEnd(), _settings)!;
                        if (_contactList == null) //Om kontaktlistan är tom så skapas en ny tom lista, bara för att undvika null-värden i resten av koden
                        {
                            _contactList = new List<IContact>();
                        }
                        return _contactList;
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

        public void SaveContactList(string path)
        {
            using (var sw = new StreamWriter(path))
            {
                try
                {
                    sw.WriteLine(JsonConvert.SerializeObject(_contactList, _settings));
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
    }
}
