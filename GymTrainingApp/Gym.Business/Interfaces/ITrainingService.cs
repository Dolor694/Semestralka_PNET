using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Interfaces
{
	public interface ITrainingService
	{
        IReadOnlyList<TrainingDTO> GetAllTrainingsFromPlan(int idTrainingPlan);
		TrainingDTO GetTrainingById(int id);
		TrainingDTO CreateTraining(int id);
		TrainingDTO UpdateTraining(int id, IReadOnlyList<ExerciseInTrainingDTO> exercises);
		bool DeleteTraining(int id);
	}
}
