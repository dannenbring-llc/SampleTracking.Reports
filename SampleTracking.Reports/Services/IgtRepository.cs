using Rogison.Web.Helpers;
using SampleTracking.Reports.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace SampleTracking.Reports.Services
{
    public class IgtRepository
    {
        public List<ClearMiniRecord> GetClearMiniData(string patId, string logNumber)
        {
            var samples = new List<ClearMiniRecord>();

            var sqlQuery = $@" SELECT `Patients`.`ABO`, `Samples`.`LogNumber`, `Samples`.`SampleDate`, `Patients`.`HospitalID`, `Patients`.`LastName`, `Patients`.`FirstName`, `Samples`.`ABS`, `Samples`.`PatID`
                                FROM   `Samples` `Samples` LEFT OUTER JOIN `Patients` `Patients` ON `Samples`.`PatID`=`Patients`.`PatID`
                                WHERE  `Samples`.`LogNumber`='{logNumber}' AND `Samples`.`PatID`='{patId}'


";

            var cnn = new OdbcConnection(@"Driver={Microsoft Access Driver (*.mdb)};DBQ=c:\Data\igt.mdb;");
            try
            {
                cnn.Open();
                var cmd = new OdbcCommand(sqlQuery, cnn);
                var reader = cmd.ExecuteReader();
                var igtPstSample = new ClearMiniRecord();
                while (reader.Read())
                {
                    igtPstSample.ABO = Helper.GetValue<string>(reader["ABO"]);
                    igtPstSample.LogNumber = Helper.GetValue<string>(reader["LogNumber"]);
                    igtPstSample.SampleDate = Helper.GetValue<DateTime>(reader["SampleDate"]);
                    igtPstSample.HospitalID = Helper.GetValue<string>(reader["HospitalID"]);
                    igtPstSample.LastName = Helper.GetValue<string>(reader["LastName"]);
                    igtPstSample.FirstName = Helper.GetValue<string>(reader["FirstName"]);
                    igtPstSample.ABS = Helper.GetValue<bool>(reader["ABS"]);
                    igtPstSample.PatID = Helper.GetValue<string>(reader["PatID"]);

                    samples.Add(igtPstSample);
                    Console.WriteLine("Record");
                }

                cnn.Close();
                //Thread.Sleep(TimeSpan.FromSeconds(5));
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, $"Update Samples Repository {ex.Message}");
                throw;
            }

            return samples;
        }


        //public List<Patient> GetPatient(string patId)
        //{
        //    var patients = new List<Patient>();

        //    var sqlQuery = $@" SELECT `Patients`.`ABO`, `Patients`.`HospitalID`, `Patients`.`LastName`, `Patients`.`FirstName`
        //                        From `Patients`
        //                        WHERE  `Patients`.`PatID`='{patId}'";

        //    var cnn = new OdbcConnection(@"Driver={Microsoft Access Driver (*.mdb)};DBQ=c:\Data\igt.mdb;");
        //    try
        //    {
        //        cnn.Open();
        //        var cmd = new OdbcCommand(sqlQuery, cnn);
        //        var reader = cmd.ExecuteReader();
        //        var patient = new Patient();
        //        while (reader.Read())
        //        {
        //            patient.ABO = Helper.GetValue<string>(reader["ABO"]);
        //            patient.HospitalId = Helper.GetValue<string>(reader["HospitalID"]);
        //            patient.LastName = Helper.GetValue<string>(reader["LastName"]);
        //            patient.FirstName = Helper.GetValue<string>(reader["FirstName"]);

        //            patients.Add(patient);
        //            Console.WriteLine("Record");
        //        }

        //        cnn.Close();
        //        //Thread.Sleep(TimeSpan.FromSeconds(5));
        //    }
        //    catch (Exception ex)
        //    {
        //        //_logger.LogError(ex, $"Update Samples Repository {ex.Message}");
        //        throw;
        //    }

        //    return patients;
        //}

        public DataTable GetPatient(string patId)
        {
            var patient = new DataTable();
            var sqlQuery = $@" SELECT `Patients`.`ABO`, `Patients`.`HospitalID`, `Patients`.`LastName`, `Patients`.`FirstName`
                                From `Patients`
                                WHERE  `Patients`.`PatID`='{patId}'";

            var cnn = new OdbcConnection(@"Driver={Microsoft Access Driver (*.mdb)};DBQ=c:\Data\igt.mdb;");
            try
            {
                cnn.Open();
                var cmd = new OdbcCommand(sqlQuery, cnn);
                patient.Load( cmd.ExecuteReader());
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw;
            }

            return patient;
        }

        public DataTable GetSample(string logNumber)
        {
            var sample = new DataTable();
            var sqlQuery = $@" SELECT `Samples`.`LogNumber`, `Samples`.`SampleDate`, `Samples`.`ABS`, `Samples`.`PatID`
                                FROM   `Samples` `Samples`
                                WHERE  `Samples`.`LogNumber`='{logNumber}'";

            var cnn = new OdbcConnection(@"Driver={Microsoft Access Driver (*.mdb)};DBQ=c:\Data\igt.mdb;");
            try
            {
                cnn.Open();
                var cmd = new OdbcCommand(sqlQuery, cnn);
                sample.Load(cmd.ExecuteReader());
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw;
            }

            return sample;
        }

    }
}