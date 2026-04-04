using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Interfaces
{
    internal interface ITrainingPlanService
    {
        IReadOnlyList<TrainingPlanDTO> GetAllTrainingPlans();
        IReadOnlyList<TrainingPlanDTO> GetTrainingPlansByUserId(int idUser);
        TrainingPlanDTO GetTrainingPlanById(int id);
        TrainingPlanDTO CreateTrainingPlan(int id, string name, int trainingFrequency, int idUser, int idTrainingType, int idAimOfTraining);
        TrainingPlanDTO UpdateTrainingPlan(int id, string? name, string? description, int? idTrainingType, int? idAimOfTraining);
        bool DeleteTrainingPlan(int id);
    }
}
