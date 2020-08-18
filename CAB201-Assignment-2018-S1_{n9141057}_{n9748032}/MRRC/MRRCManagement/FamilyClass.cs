using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MRRCManagement
{
    public class FamilyClass
    {
        //private data types
        private string vehicleRego;
        private string make;
        private string model;
        private int year;
        private VehicleClass vehicleClass;
        private int numSeats;
        private TransmissionType transmissionType;
        private FuelType fuelType;
        private bool gps;
        private bool sunRoof;
        private double dailyRate;
        private string colour;

        //Vehicle Class enum
        public enum VehicleClass
        {
            Economy, Family, Luxury, Commercial
        }

        //Fuel type enum
        public enum FuelType
        {
            Petrol, Diesel
        }

        //Transmission type enum
        public enum TransmissionType
        {
            Automatic, Manual
        }

        //Default Constructor
        public FamilyClass()
        {

        }

        //Constructor with 5 params
        public FamilyClass(string vehicleRegoC, VehicleClass vehicleClassC, string makeC,
            string modelC, int yearC)
        {
            vehicleRego = vehicleRegoC;
            vehicleClass = VehicleClass.Economy;
            make = makeC;
            model = modelC;
            year = yearC;
            numSeats = 4;
            transmissionType = TransmissionType.Automatic;
            fuelType = FuelType.Petrol;
            gps = false;
            sunRoof = false;
            colour = "black";
            dailyRate = 80;

        }

        //Constructor with all of the params
        public FamilyClass(string vehicleRegoC, VehicleClass vehicleClassC, string makeC,
            string modelC, int yearC, int numSeatsC, TransmissionType transmissionTypeC,
            FuelType fuelTypeC, bool gpsC, bool sunRoofC, double dailyRateC, string colourC)
        {
            vehicleRego = vehicleRegoC;
            vehicleClass = vehicleClassC;
            make = makeC;
            model = modelC;
            year = yearC;
            numSeats = numSeatsC;
            transmissionType = transmissionTypeC;
            fuelType = fuelTypeC;
            gps = gpsC;
            sunRoof = sunRoofC;
            dailyRate = dailyRateC;
            colour = colourC;
        }

        public override string ToString()
        {
            return "\nFamily Class Car Details:" +
                "\nVehicle Rego: " + vehicleRego.ToString() + "\nVehicle Class: " + vehicleClass.ToString()
                + "\nMake: " + make.ToString() + "\nModel: " + model.ToString() + "\nYear: " + year.ToString()
                + "\nNumber of seats: " + numSeats.ToString() + "\nTransmission Type: " + transmissionType.ToString()
                + "\nFuel Type: " + fuelType.ToString() + "\nGPS: " + gps.ToString() + "\nsunRoof: " + sunRoof.ToString()
                + "\nDaily Rate: " + dailyRate.ToString("C2") + "\nColour: " + colour.ToString() + "\n\n";

        }
        public void GetAttributesList()
        {
            List<string> infoList = new List<string>();
            infoList.Add("The Vehicle is registered under " + vehicleRego + ".");
            infoList.Add("The class the Vehcile falls under is " + vehicleClass + ".");
            infoList.Add("The Company that makes this type of vehicle is " + make + ".");
            infoList.Add("The model of the car is " + model + ".");
            infoList.Add("The year the car was created in was " + year + ".");
            infoList.Add("The car is a " + numSeats + " seater.");
            infoList.Add("The type of transmission in that car is" + transmissionType + ".");
            infoList.Add("The type of fuel that the vehicle uses is " + fuelType + ".");
            if (gps == true)
            {
                infoList.Add("The car contains GPS.");
            }
            if (sunRoof == true)
            {
                infoList.Add("The car contains a sunroof.");
            }
            infoList.Add("The car costs $" + dailyRate + " a day to rent out from MRRC.");
            infoList.Add("The cars colour is " + colour + ".\n\n");

            foreach (string Txt in infoList)

            {

                WriteLine(Txt);

            }
        }
    }
}
