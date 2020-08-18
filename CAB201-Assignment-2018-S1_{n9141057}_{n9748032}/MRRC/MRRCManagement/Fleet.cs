using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MRRCManagement;
using System.Collections;
using static MRRCManagement.Vehicle;
using System.Windows.Forms;

namespace MRRCManagement
{
    public class Fleet /*Completed by Adam Brittain */
    {
        //Private data members for Fleet Class
        private List<Vehicle> vehicles = new List<Vehicle>();
        private List<Vehicle> rentedVehicles = new List<Vehicle>();

        private List<string> rentalInformation = new List<string>();
        private List<string> vehicleRegosRegistered = new List<string>();
        private List<string> customerIDRegistered = new List<string>();

        private string fleetFile = @"..\..\..\Data\fleet.csv";
        private string rentalFile = @"..\..\..\Data\rentals.csv";


        //Methods for Fleet class

        //Constructor for the Fleet class.
        public Fleet()
        {
            //Local data members for Fleet consutrctor
            string[] values;
            string[] rentalValues;

            string line;
            string rentalLine;

            List<Vehicle> vehicle = new List<Vehicle>();
            List<string> info = new List<string>();
            List<string> vehicleRegos = new List<string>();
            List<string> rentalInfo = new List<string>();


            //Load the Fleet File
            //Check if the file exists first
            if (File.Exists(fleetFile))
            {
                try
                {
                    //Use StreamReader and close once done.
                    using (StreamReader inFile = new StreamReader(fleetFile))
                    {
                        line = inFile.ReadLine();
                        //While the current line is not null.
                        while ((line != null))
                        {
                            //Place each indivual cell into its seperate element in values array
                            values = line.Split(',');
                            for (int i = 0; i < values.Count(); i++)
                            {
                                //If it is the first column, add it to vehicleRegos list.
                                if (i % 12 == 0)
                                    vehicleRegos.Add(values[i]);
                                //Add each element into the new list 'info'
                                info.Add(values[i]);
                            }

                            //Read next line.
                            line = inFile.ReadLine();
                        }

                    }
                }
                //Return File not Found error if not found
                catch (FileNotFoundException exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            else //File does not exists
            {
                //Create a new instance of FileInfo and create the csv file and dispose of it.
                FileInfo newFile = new FileInfo(fleetFile);
                newFile.Create().Dispose();
                //Write into the file.
                using (StreamWriter input = new StreamWriter(fleetFile))
                {
                    //Add lines into the excel spreadsheet for columns
                    input.WriteLine("Rego" + "," + "VehicleClass" + "," + "Make" + "," + "Model" + "," +
                        "Year" + "," + "NumSeats" + "," + "Transmission" + "," + "Fuel" + "," + "GPS" + "," +
                        "SunRoof" + "," + "DailyRate" + "," + "Colour");
                }
            }
            //Starting at row 2, use the information from each row to populate a new vehicle object.
            for (int i = 12; i < info.Count(); i += 12)
            {
                //Economy Class
                if (info[i + 1] == "Economy")
                {
                    if (info[i + 6] == "Automatic")
                    {
                        if (info[i + 7] == "Petrol")
                        {
                            Vehicle newCar = new Vehicle(info[i], VehicleClass.Economy, info[i + 2], info[i + 3], int.Parse(info[i + 4]),
                                int.Parse(info[i + 5]), Vehicle.TransmissionType.Automatic, Vehicle.FuelType.Petrol,
                                bool.Parse(info[i + 8]), bool.Parse(info[i + 9]), double.Parse(info[i + 10]), info[i + 11]);
                            vehicle.Add(newCar);
                        }
                        else
                        {
                            Vehicle newCar = new Vehicle(info[i], VehicleClass.Economy, info[i + 2], info[i + 3], int.Parse(info[i + 4]),
                                int.Parse(info[i + 5]), Vehicle.TransmissionType.Automatic, Vehicle.FuelType.Diesel,
                                bool.Parse(info[i + 8]), bool.Parse(info[i + 9]), double.Parse(info[i + 10]), info[i + 11]);
                            vehicle.Add(newCar);
                        }
                    }
                    else
                    {
                        if (info[i + 7] == "Petrol")
                        {
                            Vehicle newCar = new Vehicle(info[i], VehicleClass.Economy, info[i + 2], info[i + 3], int.Parse(info[i + 4]),
                                int.Parse(info[i + 5]), Vehicle.TransmissionType.Manual, Vehicle.FuelType.Petrol,
                                bool.Parse(info[i + 8]), bool.Parse(info[i + 9]), double.Parse(info[i + 10]), info[i + 11]);
                            vehicle.Add(newCar);
                        }
                        else
                        {
                            Vehicle newCar = new Vehicle(info[i], VehicleClass.Economy, info[i + 2], info[i + 3], int.Parse(info[i + 4]),
                                int.Parse(info[i + 5]), Vehicle.TransmissionType.Manual, Vehicle.FuelType.Diesel,
                                bool.Parse(info[i + 8]), bool.Parse(info[i + 9]), double.Parse(info[i + 10]), info[i + 11]);
                            vehicle.Add(newCar);
                        }

                    }
                }
                //Family Class
                if (info[i + 1] == "Family")
                {
                    if (info[i + 6] == "Automatic")
                    {
                        if (info[i + 7] == "Petrol")
                        {
                            Vehicle newCar = new Vehicle(info[i], VehicleClass.Family, info[i + 2], info[i + 3], int.Parse(info[i + 4]),
                                int.Parse(info[i + 5]), Vehicle.TransmissionType.Automatic, Vehicle.FuelType.Petrol,
                                bool.Parse(info[i + 8]), bool.Parse(info[i + 9]), double.Parse(info[i + 10]), info[i + 11]);
                            vehicle.Add(newCar);
                        }
                        else
                        {
                            Vehicle newCar = new Vehicle(info[i], VehicleClass.Family, info[i + 2], info[i + 3], int.Parse(info[i + 4]),
                                int.Parse(info[i + 5]), Vehicle.TransmissionType.Automatic, Vehicle.FuelType.Diesel,
                                bool.Parse(info[i + 8]), bool.Parse(info[i + 9]), double.Parse(info[i + 10]), info[i + 11]);
                            vehicle.Add(newCar);
                        }
                    }
                    else
                    {
                        if (info[i + 7] == "Petrol")
                        {
                            Vehicle newCar = new Vehicle(info[i], VehicleClass.Family, info[i + 2], info[i + 3], int.Parse(info[i + 4]),
                                int.Parse(info[i + 5]), Vehicle.TransmissionType.Manual, Vehicle.FuelType.Petrol,
                                bool.Parse(info[i + 8]), bool.Parse(info[i + 9]), double.Parse(info[i + 10]), info[i + 11]);
                            vehicle.Add(newCar);
                        }
                        else
                        {
                            Vehicle newCar = new Vehicle(info[i], VehicleClass.Family, info[i + 2], info[i + 3], int.Parse(info[i + 4]),
                                int.Parse(info[i + 5]), Vehicle.TransmissionType.Manual, Vehicle.FuelType.Diesel,
                                bool.Parse(info[i + 8]), bool.Parse(info[i + 9]), double.Parse(info[i + 10]), info[i + 11]);
                            vehicle.Add(newCar);
                        }

                    }
                }
                //Luxury Class
                if (info[i + 1] == "Luxury")
                {
                    if (info[i + 6] == "Automatic")
                    {
                        if (info[i + 7] == "Petrol")
                        {
                            Vehicle newCar = new Vehicle(info[i], VehicleClass.Luxury, info[i + 2], info[i + 3], int.Parse(info[i + 4]),
                                int.Parse(info[i + 5]), Vehicle.TransmissionType.Automatic, Vehicle.FuelType.Petrol,
                                bool.Parse(info[i + 8]), bool.Parse(info[i + 9]), double.Parse(info[i + 10]), info[i + 11]);
                            vehicle.Add(newCar);
                        }
                        else
                        {
                            Vehicle newCar = new Vehicle(info[i], VehicleClass.Luxury, info[i + 2], info[i + 3], int.Parse(info[i + 4]),
                                int.Parse(info[i + 5]), Vehicle.TransmissionType.Automatic, Vehicle.FuelType.Diesel,
                                bool.Parse(info[i + 8]), bool.Parse(info[i + 9]), double.Parse(info[i + 10]), info[i + 11]);
                            vehicle.Add(newCar);
                        }
                    }
                    else
                    {
                        if (info[i + 7] == "Petrol")
                        {
                            Vehicle newCar = new Vehicle(info[i], VehicleClass.Luxury, info[i + 2], info[i + 3], int.Parse(info[i + 4]),
                                int.Parse(info[i + 5]), Vehicle.TransmissionType.Manual, Vehicle.FuelType.Petrol,
                                bool.Parse(info[i + 8]), bool.Parse(info[i + 9]), double.Parse(info[i + 10]), info[i + 11]);
                            vehicle.Add(newCar);
                        }
                        else
                        {
                            Vehicle newCar = new Vehicle(info[i], VehicleClass.Luxury, info[i + 2], info[i + 3], int.Parse(info[i + 4]),
                                int.Parse(info[i + 5]), Vehicle.TransmissionType.Manual, Vehicle.FuelType.Diesel,
                                bool.Parse(info[i + 8]), bool.Parse(info[i + 9]), double.Parse(info[i + 10]), info[i + 11]);
                            vehicle.Add(newCar);
                        }
                    }
                }
                //Commercial Class
                if (info[i + 1] == "Commercial")
                {
                    if (info[i + 6] == "Automatic")
                    {
                        if (info[i + 7] == "Petrol")
                        {
                            Vehicle newCar = new Vehicle(info[i], VehicleClass.Commercial, info[i + 2], info[i + 3], int.Parse(info[i + 4]),
                                int.Parse(info[i + 5]), Vehicle.TransmissionType.Automatic, Vehicle.FuelType.Petrol,
                                bool.Parse(info[i + 8]), bool.Parse(info[i + 9]), double.Parse(info[i + 10]), info[i + 11]);
                            vehicle.Add(newCar);
                        }
                        else
                        {
                            Vehicle newCar = new Vehicle(info[i], VehicleClass.Commercial, info[i + 2], info[i + 3], int.Parse(info[i + 4]),
                                int.Parse(info[i + 5]), Vehicle.TransmissionType.Automatic, Vehicle.FuelType.Diesel,
                                bool.Parse(info[i + 8]), bool.Parse(info[i + 9]), double.Parse(info[i + 10]), info[i + 11]);
                            vehicle.Add(newCar);
                        }
                    }
                    else
                    {
                        if (info[i + 7] == "Petrol")
                        {
                            Vehicle newCar = new Vehicle(info[i], VehicleClass.Commercial, info[i + 2], info[i + 3], int.Parse(info[i + 4]),
                                int.Parse(info[i + 5]), Vehicle.TransmissionType.Manual, Vehicle.FuelType.Petrol,
                                bool.Parse(info[i + 8]), bool.Parse(info[i + 9]), double.Parse(info[i + 10]), info[i + 11]);
                            vehicle.Add(newCar);
                        }
                        else
                        {
                            Vehicle newCar = new Vehicle(info[i], VehicleClass.Commercial, info[i + 2], info[i + 3], int.Parse(info[i + 4]),
                                int.Parse(info[i + 5]), Vehicle.TransmissionType.Manual, Vehicle.FuelType.Diesel,
                                bool.Parse(info[i + 8]), bool.Parse(info[i + 9]), double.Parse(info[i + 10]), info[i + 11]);
                            vehicle.Add(newCar);
                        }

                    }
                }
            }
            //Populate the private class List<Vehicle> 'vehicles' with the local customer list.
            vehicles.AddRange(vehicle);


            //Populate the private class List<string> 'VehicleRegosRegistered' with the local rego list.
            for (int i = 1; i < vehicleRegos.Count; i++)
                vehicleRegosRegistered.Add(vehicleRegos[i]);


            //Load the rental File
            if (File.Exists(rentalFile))
            {
                try
                {
                    //Use StreamReader and close once done.
                    using (StreamReader rentalLines = new StreamReader(rentalFile))
                    {
                        rentalLine = rentalLines.ReadLine();
                        //While the current line is not null.
                        while ((rentalLine != null))
                        {
                            //Place each indivual cell into its seperate element in values array
                            rentalValues = rentalLine.Split(',');
                            for (int i = 0; i < rentalValues.Count(); i++)
                                //Add each element into the local dictionary 'rental'
                                rentalInfo.Add(rentalValues[i]);
                            //Read next line.
                            rentalLine = rentalLines.ReadLine();
                        }
                    }
                }
                //Return File not Found error if not found
                catch (FileNotFoundException exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            else //File does not exists
            {
                //Create a new instance of FileInfo and create the csv file and dispose of it.
                FileInfo newFile = new FileInfo(rentalFile);
                newFile.Create().Dispose();
                //Write into the file.
                using (StreamWriter input = new StreamWriter(rentalFile))
                {
                    //Add lines into the excel spreadsheet for columns
                    input.WriteLine("Vehicle" + "," + "Customer");
                }
            }


            //Transfer the local rental information into the private list for the general class.
            rentalInformation.AddRange(rentalInfo);

        }

        //Method adds Vehicle into the Vehicle List assuming the vehicle rego does not exist already.
        //Returns true if successful and false if otherwise.
        public bool AddVehicle(Vehicle vehicle)
        {
            if ((vehicles.Contains(vehicle)) == false)
            {
                //Open the StreamWriter and close it once finished.
                using (StreamWriter inFile = new StreamWriter(fleetFile, true))
                {
                    //Write the CSV representation of the new vehicle into the CSV file,
                    inFile.WriteLine(vehicle.ToCSVString());
                }
                //Add to the Fleet class vehicle list.
                vehicles.Add(vehicle);
                return true;
            }
            else
            {
                return false;
            }
        }

        //Method removes Vehicle from the Vehicle List if it is not currently rented.
        //Returns true if successful and false if otherwise
        public bool RemoveVehicle(Vehicle vehicle)
        {
            bool check = false;
            //Starting at the location of 
            for (int i = 2; i < rentalInformation.Count; i += 2)
            {
                //If it is true.
                if (rentalInformation[i] == vehicle.VehicleRegoProp)
                {
                    check = false;
                }
                else //False.
                {
                    //RemoveVehicleCSV(vehicles[i]);
                    vehicles.Remove(vehicle);
                    check = true;
                }
            }
            return check;
        }

        //Remove the Vehicle from the CSV Fleet file.
        public void RemoveVehicleCSV(Vehicle vehicle)
        {
            //Removes the parameter vehicle from the Fleet class vehicles list.
            vehicles.Remove(vehicle);

            //Opens up the fleetfile and closes onces its done saving it.
            using (StreamWriter Writer = new StreamWriter(fleetFile, false))
            {
                //Write in the columns.
                Writer.WriteLine("Rego" + "," + "VehicleClass" + "," + "Make" + "," + "Model" + "," + "Year" + "," + "NumSeats" +
                     "," + "Transmission" + "," + "Fuel" + "," + "GPS" + "," + "SunRoof" + "," + "DailyRate" + "," + "Colour");
                //For each line of vehicle in Vehicle list, write the information in.
                for (int i = 0; i < vehicles.Count(); i++)
                {
                    Writer.WriteLine(vehicles[i]);
                }
            }
        }

        //Method removes Vehicle from the Vehicle List based on its vehicleRego if it is not currently rented.
        //Returns true if successful and false if otherwise
        public bool RemoveVehicle(string vehicleRego)
        {
            bool holder = false;
            bool check = false;

            //For each rego in rentalInformation list
            for (int i = 2; i < rentalInformation.Count; i += 2)
            {
                //checks to see if the vehicle is currently registered as rented.
                holder = IsRented(vehicleRego);

                //if its true.
                if (holder == true)
                {
                    check = false;
                    break;
                }
                else
                {
                    //For each vehicle in list of vehicles
                    for (int j = 0; j < vehicles.Count; j++)
                    {
                        //If the vehicle rego matches that vehicle objects rego property, remove if from the csv file for fleet.
                        if (vehicleRego == vehicles[j].VehicleRegoProp)
                        {
                            RemoveVehicleCSV(vehicles[j]);
                        }
                    }
                    check = true;
                }

            }

            return check;
        }

        //Returns the Fleet within a list
        public List<Vehicle> GetFleet()
        {
            return vehicles;
        }

        //Returns the rental information within a list
        public List<String> GetRentals()
        {
            return rentalInformation;
        }

        //Returns the dailyRate for the vehicle 
        public double GetDailyRate(string vehicleRego)
        {
            double dailyRate = 0.0;

            //For each vehicle in list of vehicles.
            for (int i = 0; i < vehicles.Count; i++)
            {
                //If the vehicle rego parameter matches that vehicle objects rego property, the dailyRate variable is 
                //equal to that vehicle objects daily rate property.
                if (vehicleRego == vehicles[i].VehicleRegoProp)
                {
                    dailyRate = vehicles[i].VehicleDRProp;
                }
            }

            return dailyRate;
        }

        //Method to check if the current vehicle is being rented already.
        public bool IsRented(string vehicleRego)
        {
            bool check = false;
            //For each rego in rentalInformation list
            for (int i = 2; i < rentalInformation.Count; i += 2)
            {
                //If it matches the vehicleRego parameter, return true, if not return false.
                if (vehicleRego == rentalInformation[i])
                    check = true;
                else
                    check = false;
            }

            return check;
        }

        //Method to check if the current customer is already renting a vehicle.
        public bool IsRenting(int customerID)
        {
            int count = 0;
            bool check = false;

            //For each customerID in rentalInformation list
            for (int i = 3; i < rentalInformation.Count; i += 2)
            {
                //If there is a match, increment the count variable.
                if (rentalInformation[i].Contains(customerID.ToString()))
                    count++;
            }

            //If there were no matches return false, otherwise return true if there where.
            if (count == 0)
            {
                check = false;
            }
            else
                check = true;

            return check;
        }

        //Method to check who the car is currently being rented by.
        public int RentedBy(string vehicleRego)
        {
            int rentedBy = 0;

            //For each rego in rentalInformation List
            for (int i = 2; i < rentalInformation.Count; i += 2)
            {
                //If that element matches the vehicleRego parameter
                if (rentalInformation[i].Contains(vehicleRego))
                {
                    //rentedBy variable takes the value of the corresponding customerID of that rental
                    //and returns that variable.
                    rentedBy = int.Parse(rentalInformation[i + 1]);
                    break;
                }
                else
                {
                    //Return -1 if it is not rented by anyone.
                    rentedBy = -1;
                }
            }

            return rentedBy;
        }

        //Method to rewrite the CSVfile for vehicles with the new list of vehicles.
        public void ReWriteCSVFile(List<Vehicle> vehicle)
        {
            //Open the fleetFile path and close it once done to save.
            using (StreamWriter inFile = new StreamWriter(fleetFile))
            {
                //Write in column headings.
                inFile.WriteLine("Rego" + "," + "VehicleClass" + "," + "Make" + "," + "Model" + "," + "Year" + "," + "NumSeats" +
                     "," + "Transmission" + "," + "Fuel" + "," + "GPS" + "," + "SunRoof" + "," + "DailyRate" + "," + "Colour");

                //Foe each vehicle in vehicle list, write the information into the list.
                for (int i = 0; i < vehicle.Count(); i++)
                    inFile.WriteLine(vehicle[i].ToCSVString());
            }
        }

        //Method to rewrite the CSVfile for rentals with the new list of rentals.
        public void ReWriteCSVRentalFile(List<string> rentalInformation)
        {
            //Open the fleetFile path and close it once done to save.
            using (StreamWriter inFile = new StreamWriter(rentalFile))
            {
                //For each line in rentalInformation.
                for (int i = 0; i < rentalInformation.Count(); i += 2)
                {
                    //Write in that value + the value next to it from the list.
                    inFile.WriteLine(rentalInformation[i] + "," + rentalInformation[i + 1]);
                }
            }
        }

        //Method to rent car out.
        public bool RentCar(string vehicleRego, int customerID)
        {
            //Add the customers details into the rentalInformation list.
            rentalInformation.Add(vehicleRego);
            rentalInformation.Add((customerID-1).ToString());

            //Write into the rentalFile the new information and close it once done to save.
            using (StreamWriter inFile = new StreamWriter(rentalFile))
            {
                //Write in columns headings.
                inFile.WriteLine("Vehicle" + "," + "Customer");

                //for each line in rentalInformation list, write it into the csv file.
                for (int i = 2; i < rentalInformation.Count(); i += 2)
                    inFile.WriteLine(rentalInformation[i] + "," + rentalInformation[i + 1]);
            }

            return true;
        }

        //Method to return the car.
        public bool ReturnCar(string vehicleRego)
        {
            bool check = false;

            //For each line in rentalInformation list
            for (int i = 2; i < rentalInformation.Count; i += 2)
            {
                //If vehicleRego parameter matches that value in rentalInformation.
                if (vehicleRego == rentalInformation[i])
                {
                    //Remove the rego and corresponding customerID out of the file.
                    rentalInformation.RemoveAt(i + 1);
                    rentalInformation.RemoveAt(i);
                    //Rewrite the new rentalInformation list to file.
                    ReWriteCSVRentalFile(rentalInformation);

                    check = true;
                }
                else
                    check = false;
            }

            return check;
        }

        //Method to compare registrations to see if there is one already currently in the list.
        public bool CompareRegistrations(string vehicleRego)
        {
            //If the registration is already in the list return turn, otherwise return false.
            if (vehicleRegosRegistered.Contains(vehicleRego))
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        //These functions are done auotmatically using the USING statement.
        public void SaveToFile()
        {

        }

        //These functions are done auotmatically using the USING statement.
        public void LoadFromFile()
        {

        }

    }
}
