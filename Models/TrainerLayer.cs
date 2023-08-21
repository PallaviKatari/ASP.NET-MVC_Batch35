using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Batch35.Models
{
    public class TrainerLayer
    {
        public Trainer GetTrainerDetails(int tid)
        {
            Trainer trainer = new Trainer()
            {
                Id = tid,
                Name="John",
                Skill="Angular",
                Contact="759873434"

            };
            return trainer;

        }
    }
}