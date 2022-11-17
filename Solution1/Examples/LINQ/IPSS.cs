using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//https://docs.microsoft.com/en-us/dotnet/csharp/linq/group-query-results
namespace Examples.LINQ
{
    class Patient
    {
        public string Name { get; set; }
        public List<ClinicVisit> ClinicVisits { get; set; }
        public Method Method { get; set; }
    }

    public class ClinicVisit
    {
        public int Qol { get; set; }
    }
    enum Method
    {
        Urolift,
        Rezume
    }
    class GroupExample
    {
        public static void Main(string[] args)
        {
            List<Patient> patients = new List<Patient>
            {
                new Patient{Name="Aeron", Method=Method.Urolift, ClinicVisits = new List<ClinicVisit>{new ClinicVisit { Qol=1}, new ClinicVisit { Qol=2} }},
                new Patient{Name="Bill", Method=Method.Urolift, ClinicVisits = new List<ClinicVisit>{new ClinicVisit { Qol=1}, new ClinicVisit { Qol=2} }},
                new Patient{Name="Charlie", Method=Method.Rezume, ClinicVisits = new List<ClinicVisit>{new ClinicVisit { Qol=2}, new ClinicVisit { Qol=3} }},
                new Patient{Name="Dawn", Method=Method.Rezume, ClinicVisits = new List<ClinicVisit>{new ClinicVisit { Qol=4}, new ClinicVisit { Qol=6} }}
            };

            //query syntax. 
            //IGrouping represents a collection of objects that have a common key
            IEnumerable<IGrouping<Method,Patient>> groupedPatients=
                from patient in patients
                group patient by patient.Method into patientGroup
                orderby patientGroup.Key.ToString()
                select patientGroup;

            //method syntax
            IEnumerable<IGrouping<Method, Patient>> groupedPatients2 =
                patients.GroupBy(p => p.Method).OrderBy(ig=>ig.Key.ToString());


            foreach (var methodGroup in groupedPatients2)
            {
                Console.WriteLine($"Key: {methodGroup.Key}");
                Console.WriteLine(methodGroup.Average(p=>p.ClinicVisits.Average(cv=>cv.Qol)));
            }

            //patients.GroupBy(p => p.Method).OrderBy(ig => ig.Key.ToString()).ToList().ForEach(mg => Console.WriteLine($"{mg.Key} Average QOL {mg.Average(p => p.ClinicVisits.Average(cv => cv.Qol))}"));
        }
    }

}
