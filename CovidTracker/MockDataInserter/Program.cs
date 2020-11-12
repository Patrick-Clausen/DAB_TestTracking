using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DatabaseLibrary;
using Microsoft.EntityFrameworkCore;

namespace MockDataInserter
{
    class Program
    {
        static void Main(string[] args)
        {
            //CLEAR DATABASE
            using (var context = new TrackerContext())
            {
                context.CitizenTestedAtTestCenters.RemoveRange(context.CitizenTestedAtTestCenters);
                context.CitizenWasAtLocations.RemoveRange(context.CitizenWasAtLocations);
                context.Citizens.RemoveRange(context.Citizens);
                context.TestCenters.RemoveRange(context.TestCenters);
                context.Locations.RemoveRange(context.Locations);
                context.TestCenterManagements.RemoveRange(context.TestCenterManagements);
                context.Municipalities.RemoveRange(context.Municipalities);
                context.SaveChanges();
            }


            //INSERT MUNICIPALITIES
            List<Municipality> municipalities = new List<Municipality>();
            string[] readLines = File.ReadAllLines(@"Municipality.csv");
            foreach (string line in readLines)
            {
                string[] splitLine = line.Split(',');
                Municipality municipality = new Municipality();
                municipality.Name = splitLine[1];
                municipality.Population = int.Parse(splitLine[2]);
                municipalities.Add(municipality);
            }
            using (var context = new TrackerContext())
            {
                foreach (Municipality municipality in municipalities)
                {
                    context.Add(municipality);
                }
                context.SaveChanges();
            }

            //INSERT TEST CENTER MANAGEMENT
            List<TestCenterManagement> testCenterManagements = new List<TestCenterManagement>();
            readLines = File.ReadAllLines(@"TestCenterManagementData");
            foreach (string line in readLines)
            {
                string[] splitLine = line.Split(';');
                TestCenterManagement management = new TestCenterManagement();
                management.Name = splitLine[0];
                management.PhoneNumber = int.Parse(splitLine[1]);
                management.Email = splitLine[2];
                testCenterManagements.Add(management);
            }
            using (var context = new TrackerContext())
            {
                foreach (TestCenterManagement management in testCenterManagements)
                {
                    context.Add(management);
                }
                context.SaveChanges();
            }

            //INSERT LOCATIONS
            List<Location> locations = new List<Location>();
            readLines = File.ReadAllLines(@"LocationData");
            foreach (string line in readLines)
            {
                string[] splitLine = line.Split(';');
                Location location = new Location();
                location.Address = splitLine[0];
                location.MunicipalityName = splitLine[1];
                locations.Add(location);
            }
            using (var context = new TrackerContext())
            {
                foreach (Location location in locations)
                {
                    context.Add(location);
                }
                context.SaveChanges();
            }


            //INSERT TEST CENTERS
            List<TestCenter> testCenters = new List<TestCenter>();
            readLines = File.ReadAllLines(@"TestCenterData");
            foreach (string line in readLines)
            {
                string[] splitLine = line.Split(';');
                TestCenter testCenter = new TestCenter();
                testCenter.Name = splitLine[0];
                testCenter.Hours = splitLine[1];
                testCenter.ManagementName = splitLine[2];
                testCenter.LocationAddress = splitLine[3];
                testCenters.Add(testCenter);
            }
            using (var context = new TrackerContext())
            {
                foreach (TestCenter testCenter in testCenters)
                {
                    context.Add(testCenter);
                }
                context.SaveChanges();
            }

            //INSERT CITIZENS
            List<Citizen> citizens = new List<Citizen>();
            readLines = File.ReadAllLines(@"CitizenData");
            foreach (string line in readLines)
            {
                string[] splitLine = line.Split(';');
                Citizen citizen = new Citizen();
                citizen.FirstName = splitLine[0];
                citizen.LastName = splitLine[1];
                citizen.Sex = splitLine[2][0];
                citizen.Age = int.Parse(splitLine[3]);
                citizen.SSN = splitLine[4];
                citizen.MunicipalityName = splitLine[5];
                citizens.Add(citizen);
            }
            using (var context = new TrackerContext())
            {
                foreach (Citizen citizen in citizens)
                {
                    context.Add(citizen);
                }
                context.SaveChanges();
            }

            //INSERT CITIZENVISITS
            List<CitizenWasAtLocation> citizenWasAtLocations = new List<CitizenWasAtLocation>();
            readLines = File.ReadAllLines(@"LocationVisitedData");
            foreach (string line in readLines)
            {
                string[] splitLine = line.Split(';');
                CitizenWasAtLocation citizenWasAtLocation = new CitizenWasAtLocation();
                citizenWasAtLocation.VisitingCitizenSSN = splitLine[0];
                citizenWasAtLocation.DateOfVisit = DateTime.Parse(splitLine[1]);
                citizenWasAtLocation.VisitedLocationAddress = splitLine[2];
                citizenWasAtLocations.Add(citizenWasAtLocation);
            }
            using (var context = new TrackerContext())
            {
                foreach (CitizenWasAtLocation citizenWasAtLocation in citizenWasAtLocations)
                {
                    var Location = context.Locations
                        .Include(b => b.Visits).First(b => b.Address == citizenWasAtLocation.VisitedLocationAddress);
                    Location.Visits.Add(citizenWasAtLocation);
                }
                context.SaveChanges();
            }

            //INSERT TESTS
            List<CitizenTestedAtTestCenter> citizenTestedAtTestCenters = new List<CitizenTestedAtTestCenter>();
            readLines = File.ReadAllLines(@"TestResultData");
            foreach (string line in readLines)
            {
                string[] splitLine = line.Split(';');
                CitizenTestedAtTestCenter citizenTestedAtTestCenter = new CitizenTestedAtTestCenter();
                citizenTestedAtTestCenter.CitizenSSN = splitLine[0];
                citizenTestedAtTestCenter.Date = DateTime.Parse(splitLine[1]);
                citizenTestedAtTestCenter.TestCenterName = splitLine[2];
                citizenTestedAtTestCenter.Result = splitLine[3];
                citizenTestedAtTestCenter.Status = splitLine[4];
                citizenTestedAtTestCenters.Add(citizenTestedAtTestCenter);
            }
            using (var context = new TrackerContext())
            {
                foreach (CitizenTestedAtTestCenter citizenTestedAtTestCenter in citizenTestedAtTestCenters)
                {
                    var Citizen = context.Citizens
                        .Include(b => b.Tests).First(b => b.SSN == citizenTestedAtTestCenter.CitizenSSN);
                    Citizen.Tests.Add(citizenTestedAtTestCenter);
                }
                context.SaveChanges();
            }
        }
    }
}
