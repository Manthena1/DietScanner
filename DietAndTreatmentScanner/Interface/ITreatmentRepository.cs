using DietAndTreatmentScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietAndTreatmentScanner.Interface
{
    public interface ITreatmentRepository
    {
        List<DietScheduleModel> GetDietScheduleActivitiesList(long appId, DateTime date);
        List<PatientScheduleModel> GetPatientSchedule(long appId, DateTime date);
    }
}
