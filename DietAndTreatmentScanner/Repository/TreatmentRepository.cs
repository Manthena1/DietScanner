using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using DietAndTreatmentScanner.Models;
using System.Configuration;

namespace DietAndTreatmentScanner.Repository
{
    public class TreatmentRepository
    { private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConsTr"].ConnectionString;
        public List<DietScheduleModel> GetDietScheduleActivitiesList(long appId, DateTime date)
        {
            List<DietScheduleModel> dietScheduleList = new List<DietScheduleModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GET_DIETSCHEDULE_Mobile", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VID", appId);
                    cmd.Parameters.AddWithValue("@DATE", date);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dietScheduleList.Add(new DietScheduleModel
                            {
                                Time = reader["Time"].ToString(),
                                Activity = reader["Activity"].ToString(),
                                Type = reader["Type"].ToString(),
                                QTY = reader["QTY"].ToString()
                            });
                        }
                    }
                }
            }
            return dietScheduleList;
        }

        public List<PatientScheduleModel> GetPatientSchedule(long appId, DateTime date)
        {
            List<PatientScheduleModel> scheduleList = new List<PatientScheduleModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GET_PATIENTSCHEDULE_Mobile", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VID", appId);
                    cmd.Parameters.AddWithValue("@DATE", date);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            scheduleList.Add(new PatientScheduleModel
                            {
                                Time = reader["Time"]?.ToString() ?? "N/A",
                                Activity = reader["Activity"]?.ToString() ?? "N/A",
                                Type = reader["Type"]?.ToString() ?? "N/A"
                            });
                        }
                    }
                }
            }
            return scheduleList;
        }
    }
}