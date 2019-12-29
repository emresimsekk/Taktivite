using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taktivite.Entity;

namespace Taktivite.DAL
{
    public class ExampleData:CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            User user = new User
            {
                UserName = "emresimsek",
                UserPassword = "12345678",
                Name = "Emre",
                Surname = "Şimşek",
                UserImagesName = "profilResmi.png"
               
            };
           
            Category category = new Category
            {
                CategoryName="Yemek"
            };
          
            State state = new State
            {
                StateName= "Public"
            }; 
            Participant participant = new Participant
            {
                ParticipantName="1"
            };
    


            context.Users.Add(user);
           

            context.Categorys.Add(category);
            context.States.Add(state);
            context.Participants.Add(participant);
       
            

            context.SaveChanges();
        }
    }
}
