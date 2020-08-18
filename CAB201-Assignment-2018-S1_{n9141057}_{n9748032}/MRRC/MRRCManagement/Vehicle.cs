using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRRCManagement
{
    public class Vehicle /*Completed by Adam Brittain 60%, Eric Chin 40%*/
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

        //Vehicle type enum
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
        public Vehicle()
        {

        }

        //Constructor with 5 parameters
        public Vehicle(string vehicleRegoC, VehicleClass vehicleClassC, string makeC,
                string modelC, int yearC)
        {
            vehicleRego = vehicleRegoC;

            //If the vehicle Class selected is Economy.
            if (vehicleClassC == VehicleClass.Economy)
            {
                vehicleClass = VehicleClass.Economy;
                numSeats = 4;
                transmissionType = TransmissionType.Automatic;
                fuelType = FuelType.Petrol;
                gps = false;
                sunRoof = false;
                dailyRate = 50;
                colour = "black";
            }

            //If the vehicle Class selected is Family.
            if (vehicleClassC == VehicleClass.Family)
            {
                vehicleClass = VehicleClass.Family;
                numSeats = 4;
                if (transmissionType == TransmissionType.Automatic)
                {
                    transmissionType = TransmissionType.Automatic;
                }
                else
                {
                    transmissionType = TransmissionType.Manual;
                }
                fuelType = FuelType.Petrol;
                gps = false;
                sunRoof = false;
                dailyRate = 80;
                colour = "black";
            }

            //If the vehicle Class selected is Luxury.
            if (vehicleClassC == VehicleClass.Luxury)
            {
                vehicleClass = VehicleClass.Luxury;
                numSeats = 4;
                transmissionType = TransmissionType.Automatic;
                fuelType = FuelType.Petrol;
                gps = true;
                sunRoof = true;
                dailyRate = 120;
                colour = "black";
            }

            //If the vehicle Class selected is Commercial.
            if (vehicleClassC == VehicleClass.Commercial)
            {
                vehicleClass = VehicleClass.Commercial;
                numSeats = 4;
                transmissionType = TransmissionType.Automatic;
                fuelType = FuelType.Petrol;
                gps = false;
                sunRoof = false;
                dailyRate = 80;
                colour = "black";
            }
            make = makeC;
            model = modelC;
            year = yearC;
        }

        //Constructor with all of the params
        public Vehicle(string vehicleRegoC, VehicleClass vehicleClassC, string makeC,
            string modelC, int yearC, int numSeatsC, TransmissionType transmissionTypeC,
            FuelType fuelTypeC, bool gpsC, bool sunRoofC, double dailyRateC, string colourC)
        {

            vehicleRego = vehicleRegoC;

            //If the vehicle Class selected is Economy.
            if (vehicleClassC == VehicleClass.Economy)
            {
                vehicleClass = VehicleClass.Economy;
                numSeats = numSeatsC;
                transmissionTypeC = TransmissionType.Automatic;
                if (fuelTypeC == FuelType.Petrol)
                {
                    fuelType = FuelType.Petrol;
                }
                else
                {
                    fuelType = FuelType.Diesel;
                }
                gps = gpsC;
                sunRoof = sunRoofC;
                dailyRate = dailyRateC;
                colour = colourC;
            }

            //If the vehicle Class selected is Family.
            if (vehicleClassC == VehicleClass.Family)
            {
                vehicleClass = VehicleClass.Family;
                numSeats = numSeatsC;
                if (transmissionTypeC == TransmissionType.Automatic)
                {
                    transmissionType = TransmissionType.Automatic;
                }
                else
                {
                    transmissionType = TransmissionType.Manual;
                }
                if (fuelTypeC == FuelType.Petrol)
                {
                    fuelType = FuelType.Petrol;
                }
                else
                {
                    fuelType = FuelType.Diesel;
                }
                gps = gpsC;
                sunRoof = sunRoofC;
                dailyRate = dailyRateC;
                colour = colourC;
            }

            //If the vehicle Class selected is Luxury.
            if (vehicleClassC == VehicleClass.Luxury)
            {
                vehicleClass = VehicleClass.Luxury;
                numSeats = numSeatsC;
                if (transmissionTypeC == TransmissionType.Automatic)
                {
                    transmissionType = TransmissionType.Automatic;
                }
                else
                {
                    transmissionType = TransmissionType.Manual;
                }
                if (fuelTypeC == FuelType.Petrol)
                {
                    fuelType = FuelType.Petrol;
                }
                else
                {
                    fuelType = FuelType.Diesel;
                }
                gps = gpsC;
                sunRoof = sunRoofC;
                dailyRate = dailyRateC;
                colour = colourC;
            }

            //If the vehicle Class selected is Commercial.
            if (vehicleClassC == VehicleClass.Commercial)
            {
                vehicleClassC = VehicleClass.Commercial;
                numSeats = numSeatsC;
                if (transmissionTypeC == TransmissionType.Automatic)
                {
                    transmissionType = TransmissionType.Automatic;
                }
                else
                {
                    transmissionType = TransmissionType.Manual;
                }
                if (fuelTypeC == FuelType.Petrol)
                {
                    fuelType = FuelType.Petrol;
                }
                else
                {
                    fuelType = FuelType.Diesel;
                }
                gps = gpsC;
                sunRoof = sunRoofC;
                dailyRate = dailyRateC;
                colour = colourC;
            }
            make = makeC;
            model = modelC;
            year = yearC;
        }

        //Override the ToString function
        public override string ToString()
        {
            return vehicleRego + "," + vehicleClass + "," + make + "," + model + "," +
                year + "," + numSeats + "," + transmissionType + "," + fuelType + "," +
                gps + "," + sunRoof + "," + dailyRate + "," + colour;

        }

        //ToCSVString function
        public string ToCSVString()
        {
            return vehicleRego + "," + vehicleClass + "," + make + "," + model + "," +
                year + "," + numSeats + "," + transmissionType + "," + fuelType + "," +
                gps + "," + sunRoof + "," + dailyRate + "," + colour;
        }

        //Return a attribute list of car object.
        public List<string> GetAttributesList()
        {
            //Create a new list and populate it with information about the objects information.
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

            return infoList;
        }

        //Public property for Vehicle Rego
        public string VehicleRegoProp
        {
            get
            {
                return vehicleRego;
            }
            set
            {
                vehicleRego = value;
            }
        }

        //Public property for Vehicle year
        public int VehicleYearProp
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

        //Public property for Vehicle Make
        public string VehicleMakeProp
        {
            get
            {
                return make;
            }
            set
            {
                make = value;
            }
        }

        //Public property for Vehicle model
        public string VehicleModelProp
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }

        //Public property for Vehicle  Class
        public VehicleClass VehicleClassProp
        {
            get
            {
                return vehicleClass;
            }
            set
            {
                vehicleClass = value;
            }
        }

        //Public property for number of Seats
        public int VehicleSeatsProp
        {
            get
            {
                return numSeats;
            }
            set
            {
                numSeats = value;
            }
        }

        //Public property for transmission
        public TransmissionType VehicleTransmissionProp
        {
            get
            {
                return transmissionType;
            }
            set
            {
                transmissionType = value;
            }
        }

        //Public property for fuel type
        public FuelType VehicleFuelProp
        {
            get
            {
                return fuelType;
            }
            set
            {
                fuelType = value;
            }
        }

        //Public property for Vehicle GPS
        public bool VehicleGPSProp
        {
            get
            {
                return gps;
            }
            set
            {
                gps = value;
            }
        }

        //Public property for Vehicle sun roof
        public bool SunRoofProp
        {
            get
            {
                return sunRoof;
            }
            set
            {
                sunRoof = value;
            }
        }

        //Public property for vehicle daily rate
        public double VehicleDRProp
        {
            get
            {
                return dailyRate;
            }
            set
            {
                dailyRate = value;
            }
        }

        //Public property for Vehicle object colour
        public string VehicleColourProp
        {
            get
            {
                return colour;
            }
            set
            {
                colour = value;
            }
        }
    }
}

