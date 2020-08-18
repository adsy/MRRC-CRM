using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRRCManagement;
using static System.Console;


namespace MRRCConsole
{
    class Program
    {
        static void Main()
        {
            List<Customer> customers = new List<Customer>();
            List<Vehicle> vehicles = new List<Vehicle>();

            ////Create new economy class car
            //Vehicle.EconomyClass newEconomyCar = new Vehicle.EconomyClass("AAAA", Vehicle.EconomyClass.VehicleClass.Economy, "MAZDA", "ASX", 2000);
            ////Check economy car ToString function
            //WriteLine(newEconomyCar.ToString());
            ////Check economy car GetAttributesList function
            //newEconomyCar.GetAttributesList();

            ////Create new family class car
            //Vehicle.FamilyClass newFamilyCar = new Vehicle.FamilyClass("AAAB", Vehicle.FamilyClass.VehicleClass.Family, "KIA", "RIO", 2016);
            ////Check family car ToString function
            //WriteLine(newFamilyCar.ToString());
            ////Check family car GetAttibutesList function
            //newFamilyCar.GetAttributesList();


            ////Create new luxury class car
            //Vehicle.LuxuryClass newLuxuryCar = new Vehicle.LuxuryClass("AAAC", Vehicle.LuxuryClass.VehicleClass.Luxury, "KIA", "RIO", 2016);
            ////Check luxury car ToString function
            //WriteLine(newLuxuryCar.ToString());
            ////Check luxury car GetAttibutesList function
            //newLuxuryCar.GetAttributesList();


            ////Create new commercial class car
            //Vehicle.CommercialClass newCommercialCar = new Vehicle.CommercialClass("AAAD", Vehicle.CommercialClass.VehicleClass.Commercial,
            //"hitachi", "digger", 2006);
            ////Check commercial car ToString function
            //WriteLine(newCommercialCar.ToString());
            ////Check commercial car GetAttributesList function
            //newCommercialCar.GetAttributesList();
            ////Check commercial car SetVehicleClass function
            //newCommercialCar.SetVehicleClass();
            ////Check to see if SetVehicleClass function works.
            //newCommercialCar.GetAttributesList();
            //newCommercialCar.SetDailyRate();
            //newCommercialCar.GetAttributesList();

            ////Create new customer
            //Customer newCustomer = new Customer(1);
            ////Check customer ToString function
            //WriteLine(newCustomer.ToString());
            ////Check customer SetGender function
            //newCustomer.SetGender();
            ////Check to see if SetGender function works
            //WriteLine(newCustomer.ToString());



            Fleet newfleet = new Fleet();

            newfleet.ReturnCar("123HCB");

            
            
            

            ReadKey();



        }
    }
}


