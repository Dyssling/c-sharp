using Assignment.Interfaces;
using Assignment.Services;

namespace Assignment.Tests
{
    public class FileService_Tests
    {
        [Fact]
        public void ReadFileShould_ReadContentFromFile_ThenReturnListWithContent() //Inför detta integrationstestet har jag skapat en test-fil som heter contactList_Test.json. Filen kommer aldrig ändras, eftersom detta testet bara går ut på att läsa informationen.
        {
            List<IContact> contactList = null!;
            IFileService fileService = new FileService(contactList); //Arrange. Jag förbereder helt enkelt min FileService, så att jag sedan kan använda mig av dess funktionalitet.

            contactList = fileService.ReadFile(@"c:\Education\c-sharp\Assignment\contactList_Test.json"); //Act. Jag skapar en lista som kommer bestå av innehållet i filen.

            Assert.True(contactList[0].FirstName == "Olle"); //Assert. Här kollar jag om listan har lästs in som den ska genom att kolla det första objektets FirstName property, eftersom jag vet vad test-filen innehåller.

        }

        [Fact]
        public void ReadFileShould_Fail_ReturnEmptyList() //Detta testet kollar om en ny tom lista skapas när filen inte lyckas läsas in som den ska
        {
            List<IContact> contactList = null!;
            IFileService fileService = new FileService(contactList); //Arrange

            contactList = fileService.ReadFile(""); //Act. Jag sätter en tom FilePath, vilket den alltså inte kommer hitta.

            Assert.Empty(contactList); //Assert. Kollar om en ny tom lista har lyckats skapas.
            Assert.NotNull(contactList); //Dubbelkollar även att listan inte är null.

        }
    }
}
