using DatabaseLibrary;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;

namespace CovidTrackerApp
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel(MainWindow window)
        {
            Window = window;
        }
        public MainWindow Window;

        public ObservableCollection<Citizen> Citizens
        {
            get
            {
                ObservableCollection<Citizen> citizens;
                using (var context = new TrackerContext())
                {
                    citizens = new ObservableCollection<Citizen>(
                        context
                            .Citizens
                            .ToList()
                    );
                }


                return citizens;
            }
        }

        public ObservableCollection<TestCenterManagement> Managements
        {
            get
            {
                ObservableCollection<TestCenterManagement> managements;
                using (var context = new TrackerContext())
                {
                    managements = new ObservableCollection<TestCenterManagement>(
                        context
                            .TestCenterManagements
                            .ToList()
                    );
                }


                return managements;
            }
        }

        public ObservableCollection<TestCenter> TestCenters
        {
            get
            {
                ObservableCollection<TestCenter> testCenters;
                using (var context = new TrackerContext())
                {
                    testCenters = new ObservableCollection<TestCenter>(
                        context
                            .TestCenters
                            .ToList()
                    );
                }


                return testCenters;
            }
        }

        public ObservableCollection<MunicipalityCase> MunicipalityCaseList
        {
            get
            {
                ObservableCollection<MunicipalityCase> municipalityCaseList = new ObservableCollection<MunicipalityCase>();
                List<Municipality> municipalities = new List<Municipality>();
                using (var context = new TrackerContext())
                {
                    municipalities = context
                        .Municipalities
                        .ToList();
                }

                foreach (Municipality municipality in municipalities)
                {
                    MunicipalityCase municipalityCase = new MunicipalityCase();
                    municipalityCase.Name = municipality.Name;
                    municipalityCase.Population = municipality.Population;
                    using (var context = new TrackerContext())
                    {
                        municipalityCase.PositiveTests = context.CitizenTestedAtTestCenters
                            .Where(cttc => cttc.TestedCitizen.MunicipalityName == municipality.Name)
                            .Count(cttc => cttc.Result == "Positive");
                    }
                    using (var context = new TrackerContext())
                    {
                        municipalityCase.ActiveCases = context.CitizenTestedAtTestCenters
                            .Where(cttc => cttc.TestedCitizen.MunicipalityName == municipality.Name)
                            .Where(cttc => cttc.Date > DateTime.Now.AddDays(-14))
                            .Count(cttc => cttc.Result == "Positive");
                    }
                    using (var context = new TrackerContext())
                    {
                        municipalityCase.TotalTests = context.CitizenTestedAtTestCenters
                            .Count(cttc => cttc.TestedCitizen.MunicipalityName == municipality.Name);
                    }
                    municipalityCaseList.Add(municipalityCase);
                }

                return municipalityCaseList;
            }
        }

        public ObservableCollection<SexCase> SexCaseList
        {
            get
            {
                ObservableCollection<SexCase> sexCaseList = new ObservableCollection<SexCase>();
                sexCaseList.Add(new SexCase(){Sex = "Male"});
                sexCaseList.Add(new SexCase(){Sex = "Female"});
                sexCaseList.Add(new SexCase(){Sex = "Other"});

                SexCase sexCase = new SexCase();

                using (var context = new TrackerContext())
                {
                    //GET TOTAL AMOUNT OF REGISTERED PEOPLE OF ALL GENDERS
                    sexCaseList[0].RegisteredPeople = context.Citizens
                        .Count(c => c.Sex == 'M');
                    sexCaseList[1].RegisteredPeople = context.Citizens
                        .Count(c => c.Sex == 'F');
                    sexCaseList[2].RegisteredPeople = context.Citizens
                        .Count(c => c.Sex == 'O');

                    //GET ACTIVE CASES BY GENDER
                    sexCaseList[0].ActiveCases = context.CitizenTestedAtTestCenters
                        .Where(cttc => cttc.TestedCitizen.Sex == 'M')
                        .Where(cttc => cttc.Result == "Positive")
                        .Count(cttc => cttc.Date > DateTime.Now.AddDays(-14));

                    sexCaseList[1].ActiveCases = context.CitizenTestedAtTestCenters
                        .Where(cttc => cttc.TestedCitizen.Sex == 'F')
                        .Where(cttc => cttc.Result == "Positive")
                        .Count(cttc => cttc.Date > DateTime.Now.AddDays(-14));

                    sexCaseList[2].ActiveCases = context.CitizenTestedAtTestCenters
                        .Where(cttc => cttc.TestedCitizen.Sex == 'O')
                        .Where(cttc => cttc.Result == "Positive")
                        .Count(cttc => cttc.Date > DateTime.Now.AddDays(-14));

                    //GET POSITIVE TESTS
                    sexCaseList[0].PositiveTests = context.CitizenTestedAtTestCenters
                        .Where(cttc => cttc.TestedCitizen.Sex == 'M')
                        .Count(cttc => cttc.Result == "Positive");

                    sexCaseList[1].PositiveTests = context.CitizenTestedAtTestCenters
                        .Where(cttc => cttc.TestedCitizen.Sex == 'F')
                        .Count(cttc => cttc.Result == "Positive");

                    sexCaseList[2].PositiveTests = context.CitizenTestedAtTestCenters
                        .Where(cttc => cttc.TestedCitizen.Sex == 'O')
                        .Count(cttc => cttc.Result == "Positive");

                    //GET TOTAL TESTS
                    sexCaseList[0].TotalTests = context.CitizenTestedAtTestCenters
                        .Count(cttc => cttc.TestedCitizen.Sex == 'M');

                    sexCaseList[1].TotalTests = context.CitizenTestedAtTestCenters
                        .Count(cttc => cttc.TestedCitizen.Sex == 'F');

                    sexCaseList[2].TotalTests = context.CitizenTestedAtTestCenters
                        .Count(cttc => cttc.TestedCitizen.Sex == 'O');
                }

                return sexCaseList;
            }
        }

        public ObservableCollection<AgeCase> AgeCaseList
        {
            get
            {
                ObservableCollection<AgeCase> ageCaseList = new ObservableCollection<AgeCase>();

                for (int i = 0; i < 100; i += 10)
                {
                    ageCaseList.Add(new AgeCase());

                    ageCaseList[i / 10].AgeGroup = String.Format($"{i} - {i + 9}");

                    using (var context = new TrackerContext())
                    {
                        ageCaseList[i / 10].RegisteredPeople = context.Citizens
                            .Count(c => (c.Age >= i && c.Age < (i + 10)));

                        ageCaseList[i / 10].ActiveCases = context.CitizenTestedAtTestCenters
                            .Where(cttc => (cttc.TestedCitizen.Age >= i && cttc.TestedCitizen.Age < (i + 10)))
                            .Where(cttc => cttc.Result == "Positive")
                            .Count(cttc => cttc.Date > DateTime.Now.AddDays(-14));

                        ageCaseList[i / 10].PositiveTests = context.CitizenTestedAtTestCenters
                            .Where(cttc => (cttc.TestedCitizen.Age >= i && cttc.TestedCitizen.Age < (i + 10)))
                            .Count(cttc => cttc.Result == "Positive");

                        ageCaseList[i / 10].TotalTests = context.CitizenTestedAtTestCenters
                            .Count(cttc => (cttc.TestedCitizen.Age >= i && cttc.TestedCitizen.Age < (i + 10)));
                    }
                }

                return ageCaseList;
            }
        }

        public ObservableCollection<PossibleInfection> PossibleInfectionList
        {
            get
            {
                ObservableCollection<PossibleInfection> possibleInfectionList = new ObservableCollection<PossibleInfection>();
                using (var context = new TrackerContext())
                {
                    // Step one - Find all "infected visits"
                    List<CitizenWasAtLocation> infectedVisits = context.CitizenWasAtLocations
                        .Include(cwal => cwal.VisitedLocation)
                        .Include(cwal => cwal.VisitingCitizen)
                        .Where(cwal => cwal.VisitingCitizen.Tests.Any(cttc => cttc.Result == "Positive" && cwal.DateOfVisit > cttc.Date.AddDays(-3) && cwal.DateOfVisit < cttc.Date.AddDays(14)))
                        .ToList();

                    //Step two - Find all infections by an infected visit
                    foreach (CitizenWasAtLocation visit in infectedVisits)
                    {
                        List<CitizenWasAtLocation> infecteeList = context.CitizenWasAtLocations
                            .Include(cwal => cwal.VisitedLocation)
                            .Include(cwal => cwal.VisitingCitizen)
                            .Where(cwal => cwal.VisitedLocation.Address == visit.VisitedLocation.Address)
                            .ToList();
                        foreach (CitizenWasAtLocation infectee in infecteeList)
                        {
                            if (visit.DateOfVisit.ToShortDateString() == infectee.DateOfVisit.ToShortDateString() && visit.VisitingCitizenSSN != infectee.VisitingCitizenSSN)
                            {
                                possibleInfectionList.Add(new PossibleInfection() { DateOfInfection = infectee.DateOfVisit.ToShortDateString(), Infectee = infectee.VisitingCitizen.FullName, Infector = visit.VisitingCitizen.FullName, LocationOfInfection = infectee.VisitedLocationAddress });
                            }
                        }
                    }


                    
                }
                return possibleInfectionList;
            }
        }

        public ObservableCollection<Municipality> Municipalities
        {
            get
            {
                ObservableCollection<Municipality> municipalities;
                using (var context = new TrackerContext())
                {
                    municipalities = new ObservableCollection<Municipality>(
                        context
                            .Municipalities
                            .ToList()
                        );
                }


                return municipalities;
            }
        }

        public ObservableCollection<Location> Locations
        {
            get
            {
                ObservableCollection<Location> locations;
                using (var context = new TrackerContext())
                {
                    locations = new ObservableCollection<Location>(
                        context
                            .Locations
                            .ToList()
                    );
                }


                return locations;
            }
        }

        private CitizenWasAtLocation citizenWasAtLocationUnderCreation = new CitizenWasAtLocation();

        public CitizenWasAtLocation CitizenWasAtLocationUnderCreation
        {
            get
            {
                return citizenWasAtLocationUnderCreation;
            }
            set
            {
                citizenWasAtLocationUnderCreation = value;
                RaisePropertyChanged();
            }
        }

        private ICommand citizenWasAtLocationSaveCommand;

        public ICommand CitizenWasAtLocationSaveCommand
        {
            get
            {
                return citizenWasAtLocationSaveCommand ?? (citizenWasAtLocationSaveCommand = new DelegateCommand(CitizenWasAtLocationSaveCommandHandler));
            }
        }

        public async void CitizenWasAtLocationSaveCommandHandler()
        {
            bool verificationFailed = false;
            if (CitizenWasAtLocationUnderCreation.VisitedLocationAddress == string.Empty)
            {
                Window.LocationVisitLocationRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.LocationVisitLocationRequired.Visibility = Visibility.Hidden;
            }
            if (CitizenWasAtLocationUnderCreation.VisitingCitizenSSN == string.Empty)
            {
                Window.LocationVisitCitizenRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.LocationVisitCitizenRequired.Visibility = Visibility.Hidden;
            }

            if (CitizenWasAtLocationUnderCreation.DateOfVisit == default)
            {
                Window.LocationVisitDateRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.LocationVisitDateRequired.Visibility = Visibility.Hidden;
            }

            if (verificationFailed)
            {
                return;
            }
            else
            {
                try
                {
                    using (var context = new TrackerContext())
                    {
                        context.Add(CitizenWasAtLocationUnderCreation);
                        await context.SaveChangesAsync();
                        CitizenWasAtLocationUnderCreation = new CitizenWasAtLocation();
                    }
                    RaisePropertyChanged("Locations");
                }
                catch (Exception e)
                {
                    StringBuilder exceptionString = new StringBuilder();
                    while (e != null)
                    {
                        exceptionString.AppendLine(e.Message);
                        e = e.InnerException;
                    }
                    MessageBox.Show(exceptionString.ToString());
                }
            }

        }

        private CitizenTestedAtTestCenter testCaseUnderCreation = new CitizenTestedAtTestCenter();

        public CitizenTestedAtTestCenter TestCaseUnderCreation
        {
            get
            {
                return testCaseUnderCreation;
            }
            set
            {
                testCaseUnderCreation = value;
                RaisePropertyChanged();
            }
        }

        private ICommand testCaseSaveCommand;

        public ICommand TestCaseSaveCommand
        {
            get
            {
                return testCaseSaveCommand ?? (testCaseSaveCommand = new DelegateCommand(TestCaseSaveCommandHandler));
            }
        }

        private async void TestCaseSaveCommandHandler()
        {
            bool verificationFailed = false;
            if (TestCaseUnderCreation.TestCenterName == string.Empty)
            {
                Window.TestCaseTestCenterRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.TestCaseTestCenterRequired.Visibility = Visibility.Hidden;
            }

            if (TestCaseUnderCreation.CitizenSSN == string.Empty)
            {
                Window.TestCaseCitizenRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.TestCaseCitizenRequired.Visibility = Visibility.Hidden;
            }

            if (TestCaseUnderCreation.Status == string.Empty)
            {
                Window.TestCaseStatusRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.TestCaseStatusRequired.Visibility = Visibility.Hidden;
            }

            if (TestCaseUnderCreation.Date == default)
            {
                Window.TestCaseDateRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.TestCaseDateRequired.Visibility = Visibility.Hidden;
            }

            if (verificationFailed)
            {
                return;
            }
            else
            {
                try
                {
                    using (var context = new TrackerContext())
                    {
                        context.Add(TestCaseUnderCreation);
                        await context.SaveChangesAsync();
                        TestCaseUnderCreation = new CitizenTestedAtTestCenter();
                    }
                    RaisePropertyChanged("TestCases");
                }
                catch (Exception e)
                {
                    StringBuilder exceptionString = new StringBuilder();
                    while (e != null)
                    {
                        exceptionString.AppendLine(e.Message);
                        e = e.InnerException;
                    }
                    MessageBox.Show(exceptionString.ToString());
                }
            }
        }

        private TestCenter testCenterUnderCreation = new TestCenter();

        public TestCenter TestCenterUnderCreation
        {
            get
            {
                return testCenterUnderCreation;
            }
            set
            {
                testCenterUnderCreation = value;
                RaisePropertyChanged();
            }
        }

        private TestCenterManagement testCenterManagementUnderCreation = new TestCenterManagement();

        public TestCenterManagement TestCenterManagementUnderCreation
        {
            get
            {
                return testCenterManagementUnderCreation;
            }
            set
            {
                testCenterManagementUnderCreation = value;
                RaisePropertyChanged();
            }
        }


        private ICommand testCenterSaveCommand;

        public ICommand TestCenterSaveCommand
        {
            get
            {
                return testCenterSaveCommand ?? (testCenterSaveCommand = new DelegateCommand(TestCenterSaveCommandHandler));
            }
        }

        private async void TestCenterSaveCommandHandler()
        {
            bool verificationFailed = false;
            if (TestCenterUnderCreation.LocationAddress == string.Empty)
            {
                Window.TestCenterLocationRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.TestCenterLocationRequired.Visibility = Visibility.Hidden;
            }

            if (TestCenterUnderCreation.Name == string.Empty)
            {
                Window.TestCenterNameRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.TestCenterNameRequired.Visibility = Visibility.Hidden;
            }

            if (TestCenterUnderCreation.Hours == string.Empty)
            {
                Window.TestCenterHoursRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.TestCenterHoursRequired.Visibility = Visibility.Hidden;
            }

            if (TestCenterUnderCreation.ManagementName == string.Empty)
            {
                Window.TestCenterManagementRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.TestCenterManagementRequired.Visibility = Visibility.Hidden;
            }

            if (verificationFailed)
            {
                return;
            }
            else
            {
                try
                {
                    using (var context = new TrackerContext())
                    {
                        context.Add(TestCenterUnderCreation);
                        await context.SaveChangesAsync();
                        TestCenterUnderCreation = new TestCenter();
                        RaisePropertyChanged("TestCenters");

                    }
                }
                catch (Exception e)
                {
                    StringBuilder exceptionString = new StringBuilder();
                    while (e != null)
                    {
                        exceptionString.AppendLine(e.Message);
                        e = e.InnerException;
                    }
                    MessageBox.Show(exceptionString.ToString());
                }
            }

        }

        private ICommand testCenterManagementSaveCommand;

        public ICommand TestCenterManagementSaveCommand
        {
            get
            {
                return testCenterManagementSaveCommand ?? (testCenterManagementSaveCommand = new DelegateCommand(TestCenterManagementSaveCommandHandler));
            }
        }

        private async void TestCenterManagementSaveCommandHandler()
        {
            bool verificationFailed = false;
            if (TestCenterManagementUnderCreation.Email == string.Empty)
            {
                Window.TestCenterManagementEmailRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.TestCenterManagementEmailRequired.Visibility = Visibility.Hidden;
            }

            if (TestCenterManagementUnderCreation.PhoneNumber == 0)
            {
                Window.TestCenterManagementPhoneNumberRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.TestCenterManagementPhoneNumberRequired.Visibility = Visibility.Hidden;
            }

            if (TestCenterManagementUnderCreation.Name == string.Empty)
            {
                Window.TestCenterManagementNameRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.TestCenterManagementNameRequired.Visibility = Visibility.Hidden;
            }

            if (verificationFailed)
            {
                return;
            }
            else
            {
                try
                {
                    using (var context = new TrackerContext())
                    {
                        context.Add(TestCenterManagementUnderCreation);
                        await context.SaveChangesAsync();
                        TestCenterManagementUnderCreation = new TestCenterManagement();
                        RaisePropertyChanged("TestCenterManagements");
                    }
                }
                catch (Exception e)
                {
                    StringBuilder exceptionString = new StringBuilder();
                    while (e != null)
                    {
                        exceptionString.AppendLine(e.Message);
                        e = e.InnerException;
                    }
                    MessageBox.Show(exceptionString.ToString());
                }
            }

        }


        private Location locationUnderCreation = new Location();

        public Location LocationUnderCreation
        {
            get
            {
                return locationUnderCreation;
            }
            set
            {
                locationUnderCreation = value;
                RaisePropertyChanged();
            }
        }

        private ICommand locationSaveCommand;

        public ICommand LocationSaveCommand
        {
            get
            {
                return locationSaveCommand ?? (locationSaveCommand = new DelegateCommand(LocationSaveCommandHandler));
            }
        }

        private async void LocationSaveCommandHandler()
        {
            bool verificationFailed = false;
            if (LocationUnderCreation.Address == string.Empty)
            {
                Window.AddressRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.AddressRequired.Visibility = Visibility.Hidden;
            }

            if (LocationUnderCreation.MunicipalityName == string.Empty)
            {
                Window.LocationMunicipalityRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.LocationMunicipalityRequired.Visibility = Visibility.Hidden;
            }

            if (verificationFailed)
            {
                return;
            }

            try
            {
                using (var context = new TrackerContext())
                {
                    context.Add(LocationUnderCreation);
                    await context.SaveChangesAsync();
                    LocationUnderCreation = new Location();
                    RaisePropertyChanged("Locations");
                }
            }
            catch (Exception e)
            {
                StringBuilder exceptionString = new StringBuilder();
                while (e != null)
                {
                    exceptionString.AppendLine(e.Message);
                    e = e.InnerException;
                }
                MessageBox.Show(exceptionString.ToString());
            }
        }



        private Citizen citizenUnderCreation = new Citizen();

        public Citizen CitizenUnderCreation
        {
            get
            {
                return citizenUnderCreation;
            }
            set
            {
                citizenUnderCreation = value;
                RaisePropertyChanged();
            }
        }

        private ICommand citizenSaveCommand;

        public ICommand CitizenSaveCommand
        {
            get
            {
                return citizenSaveCommand ?? (citizenSaveCommand = new DelegateCommand(CitizenSaveCommandHandler));
            }
        }

        async void CitizenSaveCommandHandler()
        {
            bool verificationFailed = false;
            if (CitizenUnderCreation.FirstName == string.Empty)
            {
                Window.FirstNameRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.FirstNameRequired.Visibility = Visibility.Hidden;
            }

            if (CitizenUnderCreation.LastName == string.Empty)
            {
                Window.LastNameRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.LastNameRequired.Visibility = Visibility.Hidden;
            }

            if (CitizenUnderCreation.Sex == '\0')
            {
                Window.SexRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.SexRequired.Visibility = Visibility.Hidden;
            }

            if (CitizenUnderCreation.MunicipalityName == string.Empty)
            {
                Window.MunicipalityRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.MunicipalityRequired.Visibility = Visibility.Hidden;
            }

            if (CitizenUnderCreation.SSN == string.Empty)
            {
                Window.SSNRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.SSNRequired.Visibility = Visibility.Hidden;
            }

            if (CitizenUnderCreation.Age == -1)
            {
                Window.AgeRequired.Visibility = Visibility.Visible;
                verificationFailed = true;
            }
            else
            {
                Window.AgeRequired.Visibility = Visibility.Hidden;
            }

            if (verificationFailed)
            {
                return;
            }

            try
            {
                using (var context = new TrackerContext())
                {
                    context.Add(CitizenUnderCreation);
                    await context.SaveChangesAsync();
                    CitizenUnderCreation = new Citizen();
                    RaisePropertyChanged("Citizens");
                }
            }
            catch (Exception e)
            {
                StringBuilder exceptionString = new StringBuilder();
                while (e != null)
                {
                    exceptionString.AppendLine(e.Message);
                    e = e.InnerException;
                }
                MessageBox.Show(exceptionString.ToString());
            }
        }
    }

    public class MunicipalityCase
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int ActiveCases { get; set; }
        public int PositiveTests { get; set; }
        public int TotalTests { get; set; }
    }

    public class SexCase
    {
        public string Sex { get; set; }
        public int RegisteredPeople { get; set; }
        public int ActiveCases { get; set; }
        public int PositiveTests { get; set; }
        public int TotalTests { get; set; }
    }

    public class AgeCase
    {
        public string AgeGroup { get; set; }
        public int RegisteredPeople { get; set; }
        public int ActiveCases { get; set; }
        public int PositiveTests { get; set; }
        public int TotalTests { get; set; }
    }

    public class PossibleInfection
    {
        public string Infectee { get; set; }
        public string Infector { get; set; }
        public string LocationOfInfection { get; set; }
        public string DateOfInfection { get; set; }
    }
}
