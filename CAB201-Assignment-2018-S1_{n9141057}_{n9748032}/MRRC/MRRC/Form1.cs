using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MRRCManagement;

namespace MRRC
{
    public partial class Form1 : Form /*Program code completed 70% by Adam Brittain, 30% by Eric Chin */ 
    {                                 /*GUI completed 95% by Eric Chin, 5% by Adam Brittain*/
        //Instantiate classes
        CRM newCRM = new CRM();
        Fleet newFleet = new Fleet();

        //Create lists of objects and strings.
        List<Customer> customerList = new List<Customer>();
        List<Vehicle> vehicleList = new List<Vehicle>();
        List<String> rentalList = new List<string>();
        List<String> freeCars = new List<string>();

        //Create datatables for datagrids
        DataTable customerDT = new DataTable();
        DataTable vehicleDT = new DataTable();
        DataTable rentalDT = new DataTable();
        DataTable availableCars = new DataTable();

        public void StartDataTable()
        {
            //Columns for Vehicle DataTable
            vehicleDT.Columns.Add("Vehicle Rego");
            vehicleDT.Columns.Add("Vehicle Class");
            vehicleDT.Columns.Add("Vehicle Make");
            vehicleDT.Columns.Add("Vehicle Model");
            vehicleDT.Columns.Add("Vehicle Year");
            vehicleDT.Columns.Add("Number of Seats");
            vehicleDT.Columns.Add("Transmission Type");
            vehicleDT.Columns.Add("Fuel Type");
            vehicleDT.Columns.Add("GPS");
            vehicleDT.Columns.Add("Sun Roof");
            vehicleDT.Columns.Add("Daily Rate");
            vehicleDT.Columns.Add("Vehicle Colour");

            //Columns for Customer DataTable
            customerDT.Columns.Add("Customer ID");
            customerDT.Columns.Add("Customer Title");
            customerDT.Columns.Add("Customer First Name");
            customerDT.Columns.Add("Customer Last Name");
            customerDT.Columns.Add("Customer Gender");
            customerDT.Columns.Add("Customer DOB");

            //Columns for rental DataTable
            rentalDT.Columns.Add("Vehicle Rego");
            rentalDT.Columns.Add("Customer ID");
            rentalDT.Columns.Add("Daily Rate");

            //Columns for available cars DataTable
            availableCars.Columns.Add("Vehicle Rego");
            availableCars.Columns.Add("Vehicle Class");
            availableCars.Columns.Add("Vehicle Make");
            availableCars.Columns.Add("Vehicle Model");
            availableCars.Columns.Add("Vehicle Year");
            availableCars.Columns.Add("Number of Seats");
            availableCars.Columns.Add("Transmission Type");
            availableCars.Columns.Add("Fuel Type");
            availableCars.Columns.Add("GPS");
            availableCars.Columns.Add("Sun Roof");
            availableCars.Columns.Add("Daily Rate");
            availableCars.Columns.Add("Vehicle Colour");

            //Disable manual input on comboboxes.
            this.comboBoxTitle.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxVehicleClass.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxVehicleFuel.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxVehicleTransmission.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Prepare the dataTable when the form loads.
            StartDataTable();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tabPage10_Click(object sender, EventArgs e)
        {

        }

        private void labelModifySunroom_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonModifySunTrue_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonModifySunFalse_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBoxModifyColour_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelModifyColour_Click(object sender, EventArgs e)
        {

        }

        private void textBoxModifyDailyRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelModifyDailyRate_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labelCustomerID_Click(object sender, EventArgs e)
        {

        }

        private void labelVehicleMake_Click(object sender, EventArgs e)
        {

        }

        private void labelVehicleModel_Click(object sender, EventArgs e)
        {

        }

        private void labelVehicleClass_Click(object sender, EventArgs e)
        {

        }

        private void labelVehicleYear_Click(object sender, EventArgs e)
        {

        }

        private void labelVehicleRego_Click(object sender, EventArgs e)
        {

        }

        private void buttonCustomerSubmit_Click(object sender, EventArgs e)
        {
            string title;
            string fName;
            string lName;
            DateTime dob;

            //Check to see if everything has been entered correctly.
            int verifyCustomer = 0;

            //If Customer title is empty:
            if (comboBoxTitle.Text == "")
            {
                labelCustomerErrorTitle.Visible = true;
            }
            else
            {
                labelCustomerErrorTitle.Visible = false;
                verifyCustomer = (verifyCustomer + 1);
            }

            //If Customer first name is empty.
            if (textBoxCustomerFirstName.Text == "")
            {
                labelCustomerErrorFirstName.Visible = true;
            }
            else
            {
                labelCustomerErrorFirstName.Visible = false;
                verifyCustomer = (verifyCustomer + 1);
            }

            //If Customer last name is empty:
            if (textBoxCustomerLastName.Text == "")
            {
                labelCustomerErrorLastName.Visible = true;
            }
            else
            {
                labelCustomerErrorLastName.Visible = false;
                verifyCustomer = (verifyCustomer + 1);
            }

            //If Customer Gender is empty:
            if (comboBoxGender.Text == "")
            {
                labelCustomerErrorGender.Visible = true;
            }
            else
            {
                labelCustomerErrorGender.Visible = false;
                verifyCustomer = (verifyCustomer + 1);
            }

            //If Customer DOB is empty:
            if (dateTimePicker1.Text == "")
            {
                labelCustomerErrorDOB.Visible = true;
            }
            else
            {
                labelCustomerErrorDOB.Visible = false;
                verifyCustomer = (verifyCustomer + 1);
            }

            //Customer id presented is the List of customers +1 so no 0 index is showed.
            int cID = 1;
            if (customerList.Count == 0)
                cID = 1;
            else
            {
                //for each item in customer.
                for (int i = 0; i < customerList.Count; i++)
                {
                    //if the customerID is less than the evaluated customerID, it is equal to that cID.
                    if (cID < customerList[i].CustomerIDProp)
                        cID = customerList[i].CustomerIDProp;
                }
                //increment by 1
                cID++;
            }

            //If everything has been entered correctly add them in.
            if (verifyCustomer == 5)
            {
                //Hide and show buttons.
                groupBoxModifyVehicle.Visible = false;
                buttonCustomerModify.Enabled = true;
                buttonCustomerRemove.Enabled = true;
                buttonCustomerAdd.Enabled = true;

                //assign the values from the gui into local variables
                title = comboBoxTitle.Text;
                fName = textBoxCustomerFirstName.Text;
                lName = textBoxCustomerLastName.Text;
                dob = dateTimePicker1.Value;

                //If the ComboBox is female
                if (comboBoxGender.Text == "Female")
                {
                    customerDT.Rows.Add(cID, title, fName, lName, Customer.Gender.Female, dob.ToShortDateString());
                    Customer newCustomer = new Customer(cID - 1, title, fName, lName, Customer.Gender.Female, dob);
                    newCRM.AddCustomer(newCustomer);
                }

                //If the ComboBox is male
                if (comboBoxGender.Text == "Male")
                {
                    customerDT.Rows.Add(cID, title, fName, lName, Customer.Gender.Male, dob.ToShortDateString());
                    Customer newCustomer = new Customer(cID - 1, title, fName, lName, Customer.Gender.Male, dob);
                    newCRM.AddCustomer(newCustomer);
                }

                //If the ComboBox is other
                if (comboBoxGender.Text == "Other")
                {
                    customerDT.Rows.Add(cID, title, fName, lName, "Other", dob.ToShortDateString());
                    Customer newCustomer = new Customer(cID - 1, title, fName, lName, Customer.Gender.Not_Specified, dob);
                    newCRM.AddCustomer(newCustomer);
                }
            }
        }

        private void buttonCustomerCancel_Click(object sender, EventArgs e)
        {
            //Hide + show buttons
            groupBoxModifyVehicle.Visible = false;
            buttonCustomerModify.Enabled = true;
            buttonCustomerRemove.Enabled = true;
            buttonCustomerAdd.Enabled = true;
        }

        private void labelLastName_Click(object sender, EventArgs e)
        {

        }

        private void groupBoxModifyCustomer_Enter(object sender, EventArgs e)
        {
            //groupBoxCustomerModifyCustomers.Enabled = false;
            //
            //GroupBox groupBoxModifyCustomer = new GroupBox();
            //GroupBox.Visibility = System.Visibility.Hidden;
        }

        private void labelCustomerID_Click_1(object sender, EventArgs e)
        {

        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }

        private void labelFirstName_Click(object sender, EventArgs e)
        {

        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSearchQuery_TextChanged(object sender, EventArgs e)
        {
            buttonSearchSearch.Enabled = true;
        }

        private void labelSearchRentDuration_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxSearchCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownSearchRentDuration_ValueChanged(object sender, EventArgs e)
        {
            string vehicleCost = dataGridView4.SelectedRows[0].Cells[10].Value.ToString();
            int vehicleCostint = int.Parse(vehicleCost);
            int vehicleDays = Int32.Parse(numericUpDownSearchRentDuration.Value.ToString());
            int totalCost = vehicleCostint * vehicleDays;
            labelSearchTotalCost.Text = "Total Cost: $" + totalCost;
        }

        private void buttonCustomerModify_Click(object sender, EventArgs e)
        {
            //Hide + Show buttons
            groupBoxModifyVehicle.Visible = true;
            buttonCustomerModify.Enabled = false;
            buttonCustomerRemove.Enabled = false;
            buttonCustomerAdd.Enabled = false;
            buttonCustomerSubmit.Enabled = false;
            buttonCustomerModify2.Enabled = true;

        }

        private void buttonVehicleSubmit_Click(object sender, EventArgs e)
        {
            //Check to see if everything has been entered correctly.
            int verifyVehicle = 0;

            //Regex expression to catch for [3 digits] [3 letters] + [3 letters] [3 digits]
            Regex regex = new Regex(@"[1-9]{3}[a-zA-Z]{3}");
            Regex regex2 = new Regex(@"[a-zA-Z]{3}[1-9]{3}");
            Match match = regex.Match(textBoxVehicleRego.Text);
            Match match2 = regex.Match(textBoxVehicleRego.Text);

            //If match was succesful:
            if (match.Success | match2.Success)
            {
                //If there is no match
                if ((newFleet.CompareRegistrations(textBoxVehicleRego.Text) == false))
                {
                    labelVehicleErrorRego.Visible = false;
                    verifyVehicle = (verifyVehicle + 1);
                }
                else
                {
                    labelVehicleErrorRego.Visible = true;
                }
            }
            else
            {
                labelVehicleErrorRego.Visible = true;
            }

            //If vehicle Make is empty:
            if (textBoxVehicleMake.Text == "")
            {
                labelVehicleErrorMake.Visible = true;
            }
            else
            {
                labelVehicleErrorMake.Visible = false;
                verifyVehicle = (verifyVehicle + 1);
            }

            //If vehicle Model is empty:
            if (textBoxVehicleModel.Text == "")
            {
                labelVehicleErrorModel.Visible = true;
            }
            else
            {
                labelVehicleErrorModel.Visible = false;
                verifyVehicle = (verifyVehicle + 1);
            }

            //If vehicle class is empty:
            if (comboBoxVehicleClass.Text == "")
            {
                labelVehicleErrorClass.Visible = true;
            }
            else
            {
                labelVehicleErrorClass.Visible = false;
                verifyVehicle = (verifyVehicle + 1);
            }

            //If vehicle year is empty:
            int year;
            if (int.TryParse(textBoxVehicleYear.Text, out year))
            {
                //Checks if year is between 1800 and 2018
                if (year < 1800 || year > 2018)
                {
                    labelVehicleErrorYear.Visible = true;
                }
                else
                {
                    labelVehicleErrorYear.Visible = false;
                    verifyVehicle = (verifyVehicle + 1);
                }
            }
            else
            {
                labelVehicleErrorYear.Visible = true;
            }

            //If vehicle transmission is empty:
            if (comboBoxVehicleTransmission.Text == "")
            {
                labelVehicleErrorTrans.Visible = true;
            }
            else
            {
                labelVehicleErrorTrans.Visible = false;
                verifyVehicle = (verifyVehicle + 1);
            }

            //If vehicle fuel type is empty:
            if (comboBoxVehicleFuel.Text == "")
            {
                labelVehicleErrorFuel.Visible = true;
            }
            else
            {
                labelVehicleErrorFuel.Visible = false;
                verifyVehicle = (verifyVehicle + 1);
            }

            //If vehicle number of seats is empty:
            if (numericUpDownVehicleSeats.Text == "0")
            {
                labelVehicleErrorSeats.Visible = true;
            }
            else
            {
                labelVehicleErrorSeats.Visible = false;
                verifyVehicle = (verifyVehicle + 1);
            }

            //If vehicle colour is empty:
            if (textBoxVehicleColour.Text == "")
            {
                labelVehicleErrorColour.Visible = true;
            }
            else
            {
                labelVehicleErrorColour.Visible = false;
                verifyVehicle = (verifyVehicle + 1);
            }

            //If vehicle daily rate is empty:
            int dailyrate;
            if (int.TryParse(numericUpDownVehicleDailyRate.Text, out dailyrate))
            {
                //Daily rate must be atleast 1 or above.
                if (dailyrate <= 0)
                {
                    labelVehicleErrorDailyRate.Visible = true;
                }
                else
                {
                    labelVehicleErrorDailyRate.Visible = false;
                    verifyVehicle = (verifyVehicle + 1);
                }
            }
            else
            {
                labelVehicleErrorDailyRate.Visible = true;
            }

            //If all of them are checked properly
            if (verifyVehicle == 10)
            {
                //declare local variables for method to use.
                string vehicleRego;
                string make;
                string model;
                int yearC;
                int numSeats;
                bool gps = false;
                bool sunRoof = false;
                double dailyRate;
                string colour;

                //Assign the values in the gui to the variables.
                vehicleRego = textBoxVehicleRego.Text;
                make = textBoxVehicleMake.Text;
                model = textBoxVehicleModel.Text;
                yearC = int.Parse(textBoxVehicleYear.Text);
                numSeats = (int)numericUpDownVehicleSeats.Value;
                if (checkBoxVehicleGPS.Checked)
                    gps = true;
                if (checkBoxVehicleSunroof.Checked)
                    sunRoof = true;
                dailyRate = (int)numericUpDownVehicleDailyRate.Value;
                colour = textBoxVehicleColour.Text;

                //If the vehicle is economy class.
                if (comboBoxVehicleClass.Text == "Economy")
                {
                    if (comboBoxVehicleTransmission.Text == "Automatic")
                    {
                        if (comboBoxVehicleFuel.Text == "Petrol")
                        {
                            //Add vehicle to DataTable
                            vehicleDT.Rows.Add(vehicleRego, Vehicle.VehicleClass.Economy, make, model,
                                year, numSeats, Vehicle.TransmissionType.Automatic,
                                Vehicle.FuelType.Petrol, gps, sunRoof, dailyRate, colour);

                            //Create a new object of vehicle using input data.
                            Vehicle newVehicle = new Vehicle(vehicleRego, Vehicle.VehicleClass.Economy, make,
                                model, year, numSeats, Vehicle.TransmissionType.Automatic,
                                Vehicle.FuelType.Petrol, gps, sunRoof, dailyRate, colour);

                            //Add the new vehicle to the current Fleet
                            newFleet.AddVehicle(newVehicle);

                        }
                        else // Diesel
                        {
                            //Add vehicle to DataTable
                            vehicleDT.Rows.Add(vehicleRego, Vehicle.VehicleClass.Economy, make, model,
                                year, numSeats, Vehicle.TransmissionType.Automatic,
                                Vehicle.FuelType.Diesel, gps, sunRoof, dailyRate, colour);

                            //Create a new object of vehicle using input data.
                            Vehicle newVehicle = new Vehicle(vehicleRego, Vehicle.VehicleClass.Economy, make,
                                model, year, numSeats, Vehicle.TransmissionType.Automatic,
                                Vehicle.FuelType.Diesel, gps, sunRoof, dailyRate, colour);

                            //Add the new vehicle to the current Fleet
                            newFleet.AddVehicle(newVehicle);
                        }
                    }
                    else // Manual
                    {
                        if (comboBoxVehicleFuel.Text == "Petrol")
                        {
                            //Add vehicle to DataTable
                            vehicleDT.Rows.Add(vehicleRego, Vehicle.VehicleClass.Economy, make, model,
                                year, numSeats, Vehicle.TransmissionType.Manual,
                                Vehicle.FuelType.Petrol, gps, sunRoof, dailyRate, colour);

                            //Create a new object of vehicle using input data.
                            Vehicle newVehicle = new Vehicle(vehicleRego, Vehicle.VehicleClass.Economy, make,
                                model, year, numSeats, Vehicle.TransmissionType.Manual,
                                Vehicle.FuelType.Petrol, gps, sunRoof, dailyRate, colour);

                            //Add the new vehicle to the current Fleet
                            newFleet.AddVehicle(newVehicle);
                        }
                        else // Diesel
                        {
                            //Add vehicle to DataTable
                            vehicleDT.Rows.Add(vehicleRego, Vehicle.VehicleClass.Economy, make, model,
                                year, numSeats, Vehicle.TransmissionType.Manual,
                                Vehicle.FuelType.Diesel, gps, sunRoof, dailyRate, colour);

                            //Create a new object of vehicle using input data.
                            Vehicle newVehicle = new Vehicle(vehicleRego, Vehicle.VehicleClass.Economy, make,
                                model, year, numSeats, Vehicle.TransmissionType.Manual,
                                Vehicle.FuelType.Diesel, gps, sunRoof, dailyRate, colour);

                            //Add the new vehicle to the current Fleet
                            newFleet.AddVehicle(newVehicle);
                        }
                    }
                }

                //If the vehicle is family class.
                if (comboBoxVehicleClass.Text == "Family")
                {
                    if (comboBoxVehicleTransmission.Text == "Automatic")
                    {
                        if (comboBoxVehicleFuel.Text == "Petrol")
                        {
                            //Add vehicle to DataTable
                            vehicleDT.Rows.Add(vehicleRego, Vehicle.VehicleClass.Family, make, model,
                                year, numSeats, Vehicle.TransmissionType.Automatic,
                                Vehicle.FuelType.Petrol, gps, sunRoof, dailyRate, colour);

                            //Create a new object of vehicle using input data.
                            Vehicle newVehicle = new Vehicle(vehicleRego, Vehicle.VehicleClass.Family, make,
                                model, year, numSeats, Vehicle.TransmissionType.Automatic,
                                Vehicle.FuelType.Petrol, gps, sunRoof, dailyRate, colour);

                            //Add the new vehicle to the current Fleet
                            newFleet.AddVehicle(newVehicle);
                        }
                        else // Diesel
                        {
                            //Add vehicle to DataTable
                            vehicleDT.Rows.Add(vehicleRego, Vehicle.VehicleClass.Family, make, model,
                                year, numSeats, Vehicle.TransmissionType.Automatic,
                                Vehicle.FuelType.Diesel, gps, sunRoof, dailyRate, colour);

                            //Create a new object of vehicle using input data.
                            Vehicle newVehicle = new Vehicle(vehicleRego, Vehicle.VehicleClass.Family, make,
                                model, year, numSeats, Vehicle.TransmissionType.Automatic,
                                Vehicle.FuelType.Diesel, gps, sunRoof, dailyRate, colour);

                            //Add the new vehicle to the current Fleet
                            newFleet.AddVehicle(newVehicle);
                        }
                    }
                    else // Manual
                    {
                        if (comboBoxVehicleFuel.Text == "Petrol")
                        {
                            //Add vehicle to DataTable
                            vehicleDT.Rows.Add(vehicleRego, Vehicle.VehicleClass.Family, make, model,
                                year, numSeats, Vehicle.TransmissionType.Manual,
                                Vehicle.FuelType.Petrol, gps, sunRoof, dailyRate, colour);

                            //Create a new object of vehicle using input data.
                            Vehicle newVehicle = new Vehicle(vehicleRego, Vehicle.VehicleClass.Family, make,
                                model, year, numSeats, Vehicle.TransmissionType.Manual,
                                Vehicle.FuelType.Petrol, gps, sunRoof, dailyRate, colour);

                            //Add the new vehicle to the current Fleet
                            newFleet.AddVehicle(newVehicle);
                        }
                        else // Diesel
                        {
                            //Add vehicle to DataTable
                            vehicleDT.Rows.Add(vehicleRego, Vehicle.VehicleClass.Family, make, model,
                                year, numSeats, Vehicle.TransmissionType.Manual,
                                Vehicle.FuelType.Diesel, gps, sunRoof, dailyRate, colour);

                            //Create a new object of vehicle using input data.
                            Vehicle newVehicle = new Vehicle(vehicleRego, Vehicle.VehicleClass.Family, make,
                                model, year, numSeats, Vehicle.TransmissionType.Manual,
                                Vehicle.FuelType.Diesel, gps, sunRoof, dailyRate, colour);

                            //Add the new vehicle to the current Fleet
                            newFleet.AddVehicle(newVehicle);
                        }
                    }
                }

                //If the vehicle is Luxury class.
                if (comboBoxVehicleClass.Text == "Luxury")
                {
                    if (comboBoxVehicleTransmission.Text == "Automatic")
                    {
                        if (comboBoxVehicleFuel.Text == "Petrol")
                        {
                            //Add vehicle to DataTable
                            vehicleDT.Rows.Add(vehicleRego, Vehicle.VehicleClass.Luxury, make, model,
                                year, numSeats, Vehicle.TransmissionType.Automatic,
                                Vehicle.FuelType.Petrol, gps, sunRoof, dailyRate, colour);

                            //Create a new object of vehicle using input data.
                            Vehicle newVehicle = new Vehicle(vehicleRego, Vehicle.VehicleClass.Luxury, make,
                                model, year, numSeats, Vehicle.TransmissionType.Automatic,
                                Vehicle.FuelType.Petrol, gps, sunRoof, dailyRate, colour);

                            //Add the new vehicle to the current Fleet
                            newFleet.AddVehicle(newVehicle);
                        }
                        else // Diesel
                        {
                            //Add vehicle to DataTable
                            vehicleDT.Rows.Add(vehicleRego, Vehicle.VehicleClass.Luxury, make, model,
                                year, numSeats, Vehicle.TransmissionType.Automatic,
                                Vehicle.FuelType.Diesel, gps, sunRoof, dailyRate, colour);

                            //Create a new object of vehicle using input data.
                            Vehicle newVehicle = new Vehicle(vehicleRego, Vehicle.VehicleClass.Luxury, make,
                                model, year, numSeats, Vehicle.TransmissionType.Automatic,
                                Vehicle.FuelType.Diesel, gps, sunRoof, dailyRate, colour);

                            //Add the new vehicle to the current Fleet
                            newFleet.AddVehicle(newVehicle);
                        }
                    }
                    else // Manual
                    {
                        if (comboBoxVehicleFuel.Text == "Petrol")
                        {
                            //Add vehicle to DataTable
                            vehicleDT.Rows.Add(vehicleRego, Vehicle.VehicleClass.Luxury, make, model,
                                year, numSeats, Vehicle.TransmissionType.Manual,
                                Vehicle.FuelType.Petrol, gps, sunRoof, dailyRate, colour);

                            //Create a new object of vehicle using input data.
                            Vehicle newVehicle = new Vehicle(vehicleRego, Vehicle.VehicleClass.Luxury, make,
                                model, year, numSeats, Vehicle.TransmissionType.Manual,
                                Vehicle.FuelType.Petrol, gps, sunRoof, dailyRate, colour);

                            //Add the new vehicle to the current Fleet
                            newFleet.AddVehicle(newVehicle);
                        }
                        else // Diesel
                        {
                            //Add vehicle to DataTable
                            vehicleDT.Rows.Add(vehicleRego, Vehicle.VehicleClass.Luxury, make, model,
                                year, numSeats, Vehicle.TransmissionType.Manual,
                                Vehicle.FuelType.Diesel, gps, sunRoof, dailyRate, colour);

                            //Create a new object of vehicle using input data.
                            Vehicle newVehicle = new Vehicle(vehicleRego, Vehicle.VehicleClass.Luxury, make,
                                model, year, numSeats, Vehicle.TransmissionType.Manual,
                                Vehicle.FuelType.Diesel, gps, sunRoof, dailyRate, colour);

                            //Add the new vehicle to the current Fleet
                            newFleet.AddVehicle(newVehicle);
                        }
                    }
                }

                //If the vehicle is Commercial class.
                if (comboBoxVehicleClass.Text == "Commercial")
                {
                    if (comboBoxVehicleTransmission.Text == "Automatic")
                    {
                        if (comboBoxVehicleFuel.Text == "Petrol")
                        {
                            //Add vehicle to DataTable
                            vehicleDT.Rows.Add(vehicleRego, Vehicle.VehicleClass.Commercial, make, model,
                                year, numSeats, Vehicle.TransmissionType.Automatic,
                                Vehicle.FuelType.Petrol, gps, sunRoof, dailyRate, colour);

                            //Create a new object of vehicle using input data.
                            Vehicle newVehicle = new Vehicle(vehicleRego, Vehicle.VehicleClass.Commercial, make,
                                model, year, numSeats, Vehicle.TransmissionType.Automatic,
                                Vehicle.FuelType.Petrol, gps, sunRoof, dailyRate, colour);

                            //Add the new vehicle to the current Fleet
                            newFleet.AddVehicle(newVehicle);
                        }
                        else // Diesel
                        {
                            //Add vehicle to DataTable
                            vehicleDT.Rows.Add(vehicleRego, Vehicle.VehicleClass.Commercial, make, model,
                                year, numSeats, Vehicle.TransmissionType.Automatic,
                                Vehicle.FuelType.Diesel, gps, sunRoof, dailyRate, colour);

                            //Create a new object of vehicle using input data.
                            Vehicle newVehicle = new Vehicle(vehicleRego, Vehicle.VehicleClass.Commercial, make,
                                model, year, numSeats, Vehicle.TransmissionType.Automatic,
                                Vehicle.FuelType.Diesel, gps, sunRoof, dailyRate, colour);

                            //Add the new vehicle to the current Fleet
                            newFleet.AddVehicle(newVehicle);
                        }
                    }
                    else // Manual
                    {
                        if (comboBoxVehicleFuel.Text == "Petrol")
                        {
                            //Add vehicle to DataTable
                            vehicleDT.Rows.Add(vehicleRego, Vehicle.VehicleClass.Commercial, make, model,
                                year, numSeats, Vehicle.TransmissionType.Manual,
                                Vehicle.FuelType.Petrol, gps, sunRoof, dailyRate, colour);

                            //Create a new object of vehicle using input data.
                            Vehicle newVehicle = new Vehicle(vehicleRego, Vehicle.VehicleClass.Commercial, make,
                                model, year, numSeats, Vehicle.TransmissionType.Manual,
                                Vehicle.FuelType.Petrol, gps, sunRoof, dailyRate, colour);

                            //Add the new vehicle to the current Fleet
                            newFleet.AddVehicle(newVehicle);
                        }
                        else // Diesel
                        {
                            //Add vehicle to DataTable
                            vehicleDT.Rows.Add(vehicleRego, Vehicle.VehicleClass.Commercial, make, model,
                                year, numSeats, Vehicle.TransmissionType.Manual,
                                Vehicle.FuelType.Diesel, gps, sunRoof, dailyRate, colour);

                            //Create a new object of vehicle using input data.
                            Vehicle newVehicle = new Vehicle(vehicleRego, Vehicle.VehicleClass.Commercial, make,
                                model, year, numSeats, Vehicle.TransmissionType.Manual,
                                Vehicle.FuelType.Diesel, gps, sunRoof, dailyRate, colour);

                            //Add the new vehicle to the current Fleet
                            newFleet.AddVehicle(newVehicle);
                        }
                    }
                }

                //Reset the buttons and fields.
                groupBoxVehicleModifyVehicle.Visible = false;
                buttonVehicleModify.Enabled = true;
                buttonVehicleRemove.Enabled = true;
                buttonVehicleAdd.Enabled = true;
            }
        }

        private void buttonCustomerAdd_Click(object sender, EventArgs e)
        {
            //Hides + Shows buttons
            groupBoxModifyVehicle.Visible = true;
            buttonCustomerModify.Enabled = false;
            buttonCustomerRemove.Enabled = false;
            buttonCustomerAdd.Enabled = false;
        }

        private void buttonCustomerAdd_Click_2(object sender, EventArgs e)
        {
            //Hides + Shows buttons
            groupBoxModifyVehicle.Visible = true;
            buttonCustomerModify.Enabled = false;
            buttonCustomerRemove.Enabled = false;
            buttonCustomerAdd.Enabled = false;
            buttonCustomerSubmit.Enabled = true;
            buttonCustomerModify2.Enabled = false;
        }

        private void buttonVehicleModify_Click(object sender, EventArgs e)
        {
            //Hides + Shows buttons
            groupBoxVehicleModifyVehicle.Visible = true;
            buttonVehicleModify.Enabled = false;
            buttonVehicleRemove.Enabled = false;
            buttonVehicleAdd.Enabled = false;
            buttonVehicleSubmit.Enabled = false;
            buttonVehicleModify2.Enabled = true;
        }

        private void buttonVehicleAdd_Click(object sender, EventArgs e)
        {
            //Hides + Shows buttons
            buttonVehicleModify2.Enabled = false;
            buttonVehicleSubmit.Enabled = true;
            groupBoxVehicleModifyVehicle.Visible = true;
            buttonVehicleModify.Enabled = false;
            buttonVehicleRemove.Enabled = false;
            buttonVehicleAdd.Enabled = false;
        }

        private void buttonVehicleCancel_Click(object sender, EventArgs e)
        {
            //Hides + Shows buttons
            groupBoxVehicleModifyVehicle.Visible = false;
            buttonVehicleModify.Enabled = true;
            buttonVehicleRemove.Enabled = true;
            buttonVehicleAdd.Enabled = true;
        }

        private void buttonSearchSearch_Click(object sender, EventArgs e)
        {
            //Enables a groupbox.
            groupBoxSearchCreateRental.Enabled = true;
        }

        private void buttonSearchShowAll_Click(object sender, EventArgs e)
        {

            //Changes the label + repopulates the comboBox with the customerIDS.
            buttonSearchShowAll.Text = "Refresh available cars";
            comboBoxSearchCustomer.Items.Clear();
            
            //Clears the current datatable incase changes have been made.
            availableCars.Clear();
            
            //Must load the available data first.
            if (dataGridView2.DataSource != vehicleDT)
            {
                MessageBox.Show("You must load the available data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int count;
                //Loop through the vehicle list.
                for (int i = 0; i < vehicleList.Count; i++)
                {
                    //Start count at 0 each time vehicle is tested against the regos in the rental list.
                    count = 0;
                    for (int j = 2; j < rentalList.Count; j += 2)
                    {
                        //if its a match, add a value to count.
                        if (vehicleList[i].VehicleRegoProp == rentalList[j])
                            count++;
                    }
                    //if there were no matches, add it the to dataTable.
                    if (count == 0)
                    {
                        availableCars.Rows.Add(vehicleList[i].VehicleRegoProp, vehicleList[i].VehicleClassProp,
                        vehicleList[i].VehicleMakeProp, vehicleList[i].VehicleModelProp, vehicleList[i].VehicleYearProp,
                        vehicleList[i].VehicleSeatsProp, vehicleList[i].VehicleTransmissionProp, vehicleList[i].VehicleFuelProp,
                        vehicleList[i].VehicleGPSProp, vehicleList[i].SunRoofProp, vehicleList[i].VehicleDRProp, vehicleList[i].VehicleColourProp);
                    }
                }
                //Set up the source for the datagrid.
                dataGridView4.DataSource = availableCars;

                //enable the create rental box.
                groupBoxSearchCreateRental.Enabled = true;

                //Add the names into the comboBox at the bottom to display cID and names.
                foreach (Customer customer in customerList)
                {
                    comboBoxSearchCustomer.Items.Add(customer.CustomerIDProp+1 + " - " + customer.CustomerFNameProp + " " + customer.CustomerLNameProp);
                }
            }
        }

        private void buttonSearchRent_Click(object sender, EventArgs e)
        {
            //Checks if a customer is selected.
            if (comboBoxSearchCustomer.Text == "")
                MessageBox.Show("You must choose a customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //Checks if the rent duration is a valid amount.
            else if (numericUpDownSearchRentDuration.Text == "0")
                MessageBox.Show("You must enter a valid amount of days.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                //User has to click into the dataGrid before function will do anything
                if (dataGridView4.SelectedRows.Count > 0)
                {
                    //declare variabels to hold index, rego and total cost.
                    int firstRowIndex = dataGridView4.SelectedRows.Count - 1;
                    string vehicleRego = dataGridView4.SelectedRows[firstRowIndex].Cells[0].Value.ToString();
                    string vehicleCost = dataGridView4.SelectedRows[firstRowIndex].Cells[10].Value.ToString();
                    int vehicleCostint = int.Parse(vehicleCost);
                    int vehicleDays = Int32.Parse(numericUpDownSearchRentDuration.Value.ToString());
                    int totalCost = vehicleCostint * vehicleDays;
                    //gets customer ID and vehicle rego.
                    int customerID = int.Parse(comboBoxSearchCustomer.Text.Substring(0, 1));
                    string rego = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();

                    //Checks to see if that customer is currently renting and returns the result.
                    bool result = newFleet.IsRenting(customerID-1);

                    //If theyre not currently renting.
                    if (result == false)
                    {
                        if (MessageBox.Show("Do you want to rent vehicle " + vehicleRego + " to customer " + comboBoxSearchCustomer.Text +
                                                " for a total cost of $" + totalCost + "?", "Rental confirmation", MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            //Rent Vehicle

                            //Removes car from the rentable list
                            dataGridView4.Rows.RemoveAt(this.dataGridView4.SelectedRows[0].Index);

                            //Adds the car and customer to the rented list
                            rentalDT.Rows.Add(rego, (customerID), vehicleCostint);

                            //Writes to rentals.csv
                            newFleet.RentCar(vehicleRego, customerID);

                            //Display total vehicles rented.
                            int rows = dataGridView3.RowCount;
                            labelReportVehiclesRented.Text = "Total Vehicles Rented: " + (rows - 1);

                            //Display the daily rate.
                            int sum = 0;

                            //Displays the new daily rental charge going through each column totaling the daily rate.
                            for (int i = 0; i < dataGridView3.Rows.Count; ++i)
                            {
                                sum += Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value);
                            }
                            labelReportDailyRental.Text = "Total Daily Rental Charge: $" + sum;
                        }
                    }
                    else
                    {
                        MessageBox.Show("A customer cannot rent out more than one car at the same time!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonCustomerRemove_Click_1(object sender, EventArgs e)
        {
            //int noOfCust = customerList.Count;
            //User must click into the row to do something.
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int firstRowIndex = dataGridView1.SelectedRows.Count - 1;
                string customerID = dataGridView1.SelectedRows[firstRowIndex].Cells[0].Value.ToString();
                string customerfName = dataGridView1.SelectedRows[firstRowIndex].Cells[2].Value.ToString();
                string customerlName = dataGridView1.SelectedRows[firstRowIndex].Cells[3].Value.ToString();
                int customerIndex = dataGridView1.CurrentCell.RowIndex;

                //Display warning message.
                if (MessageBox.Show("Are you sure you want to remove Customer: " + customerID + " - " + customerfName + " " + customerlName,
                    "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (newCRM.RemoveCustomer(customerList[customerIndex], newFleet) == true) //the customer is not currently renting a vehicle.
                    {
                        //Remove entire row at this section.
                        dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                    }
                    else //the customer is currently renting a vehicle.
                    {
                        MessageBox.Show("You cannot delete a customer who is currently renting a vehicle.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void textBoxVehicleRego_TextChanged(object sender, EventArgs e)
        {
            //Converts all letters to uppercase.
            textBoxVehicleRego.CharacterCasing = CharacterCasing.Upper;
        }

        private void numericUpDownVehicleDailyRate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            //Prepares the dataTables for customers, vehicles and rentals.
            StartDataTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labelReportVehiclesRented_Click(object sender, EventArgs e)
        {

        }


        private void buttonVehicleRemove_Click(object sender, EventArgs e)
        {
            //User has to click into the dataGrid before function will do anything
            if (dataGridView2.SelectedRows.Count > 0)
            {

                //declare variabels to hold index and rego.
                int firstRowIndex = dataGridView2.SelectedRows.Count - 1;
                string vehicleRego = dataGridView2.SelectedRows[firstRowIndex].Cells[0].Value.ToString();
                int vehicleIndex = dataGridView2.CurrentCell.RowIndex;

                //Display warning, check if they press yes.
                if (MessageBox.Show("Are you sure you want to remove Vehicle: " + vehicleRego,
                    "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (newFleet.RemoveVehicle(vehicleRego) == true) //the Vehicle is currently rented out.
                    {
                        //remove selected row
                        dataGridView2.Rows.RemoveAt(this.dataGridView2.SelectedRows[0].Index);
                    }
                    else //the customer is currently renting a vehicle
                    {
                        MessageBox.Show("You cannot delete a Vehicle that is currently being rented out.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonCustomerModify2_Click_1(object sender, EventArgs e)
        {
            //Declare local variables to hold input
            string title;
            string fName;
            string lName;
            DateTime dob;

            //Check to see if everything has been entered correctly.
            int verifyCustomer = 0;

            //User must fill in input or else error is displayed.
            if (comboBoxTitle.Text == "")
            {
                labelCustomerErrorTitle.Visible = true;
            }
            else
            {
                labelCustomerErrorTitle.Visible = false;
                verifyCustomer = (verifyCustomer + 1);
            }

            //User must fill in input or else error is displayed.
            if (textBoxCustomerFirstName.Text == "")
            {
                labelCustomerErrorFirstName.Visible = true;
            }
            else
            {
                labelCustomerErrorFirstName.Visible = false;
                verifyCustomer = (verifyCustomer + 1);
            }

            //User must fill in input or else error is displayed.
            if (textBoxCustomerLastName.Text == "")
            {
                labelCustomerErrorLastName.Visible = true;
            }
            else
            {
                labelCustomerErrorLastName.Visible = false;
                verifyCustomer = (verifyCustomer + 1);
            }

            //User must fill in input or else error is displayed.
            if (comboBoxGender.Text == "")
            {
                labelCustomerErrorGender.Visible = true;
            }
            else
            {
                labelCustomerErrorGender.Visible = false;
                verifyCustomer = (verifyCustomer + 1);
            }

            //User must fill in input or else error is displayed.
            if (dateTimePicker1.Text == "")
            {
                labelCustomerErrorDOB.Visible = true;
            }
            else
            {
                labelCustomerErrorDOB.Visible = false;
                verifyCustomer = (verifyCustomer + 1);
            }

            //Customer ID displayed is the count of current customers + 1 so 0 is not displayed.
            int cID = customerList.Count + 1;

            //If everything has been entered correctly add them in.
            if (verifyCustomer == 5)
            {

                int firstRowIndex = dataGridView1.SelectedRows.Count - 1;
                string customerID = dataGridView1.SelectedRows[firstRowIndex].Cells[0].Value.ToString();
                int customerIndex = int.Parse(customerID) - 1;

                //assign the values from the gui into local variables
                title = comboBoxTitle.Text;
                fName = textBoxCustomerFirstName.Text;
                lName = textBoxCustomerLastName.Text;
                dob = dateTimePicker1.Value;

                //Change the properties of that object
                customerList[customerIndex].CustomerTitleProp = comboBoxTitle.Text;
                customerList[customerIndex].CustomerFNameProp = textBoxCustomerFirstName.Text;
                customerList[customerIndex].CustomerLNameProp = textBoxCustomerLastName.Text;
                customerList[customerIndex].CustomerDOBProp = dateTimePicker1.Value;

                //Set gender to female
                if (comboBoxGender.Text == "Female")
                {
                    customerList[customerIndex].CustomerGenderProp = Customer.Gender.Female;
                }
                //Set gender to male
                if (comboBoxGender.Text == "Male")
                {
                    customerList[customerIndex].CustomerGenderProp = Customer.Gender.Male;
                }
                //Set gender to other
                if (comboBoxGender.Text == "Other")
                {
                    customerList[customerIndex].CustomerGenderProp = Customer.Gender.Not_Specified;
                }

                //Change the data in the rows.
                customerDT.Rows[customerIndex].SetField(1, comboBoxTitle.Text);
                customerDT.Rows[customerIndex].SetField(2, textBoxCustomerFirstName.Text);
                customerDT.Rows[customerIndex].SetField(3, textBoxCustomerLastName.Text);
                customerDT.Rows[customerIndex].SetField(4, comboBoxGender.Text);
                customerDT.Rows[customerIndex].SetField(5, dateTimePicker1.Value.ToShortDateString());

                //Rewrite the csv file.
                newCRM.ReWriteCSVFile(customerList);

                //Resets buttons and group box to original state
                groupBoxModifyVehicle.Visible = false;
                buttonCustomerModify.Enabled = true;
                buttonCustomerRemove.Enabled = true;
                buttonCustomerAdd.Enabled = true;
            }
        }

        //Method for once everything has been entered and the user wants to change the data in the row.
        private void buttonVehicleModify2_Click(object sender, EventArgs e)
        {
            int verifyVehicle = 0;

            //Regex expression to catch for [3 digits] [3 letters] + [3 letters] [3 digits]
            Regex regex = new Regex(@"[1-9]{3}[a-zA-Z]{3}");
            Regex regex2 = new Regex(@"[a-zA-Z]{3}[1-9]{3}");
            Match match = regex.Match(textBoxVehicleRego.Text);
            Match match2 = regex.Match(textBoxVehicleRego.Text);

            //If match was succesful:
            if (match.Success | match2.Success )
            {

                labelVehicleErrorRego.Visible = false;
                verifyVehicle = (verifyVehicle + 1);
            }
            else
            {
                labelVehicleErrorRego.Visible = true;
            }

            //If vehicle Make is empty:
            if (textBoxVehicleMake.Text == "")
            {
                labelVehicleErrorMake.Visible = true;
            }
            else
            {
                labelVehicleErrorMake.Visible = false;
                verifyVehicle = (verifyVehicle + 1);
            }

            //If vehicle Model is empty:
            if (textBoxVehicleModel.Text == "")
            {
                labelVehicleErrorModel.Visible = true;
            }
            else
            {
                labelVehicleErrorModel.Visible = false;
                verifyVehicle = (verifyVehicle + 1);
            }

            //If vehicle class is empty:
            if (comboBoxVehicleClass.Text == "")
            {
                labelVehicleErrorClass.Visible = true;
            }
            else
            {
                labelVehicleErrorClass.Visible = false;
                verifyVehicle = (verifyVehicle + 1);
            }

            //If vehicle year is empty:
            int year;
            if (int.TryParse(textBoxVehicleYear.Text, out year))
            {
                //Checks if year is between 1800 and 2018
                if (year < 1800 || year > 2018)
                {
                    labelVehicleErrorYear.Visible = true;
                }
                else
                {
                    labelVehicleErrorYear.Visible = false;
                    verifyVehicle = (verifyVehicle + 1);
                }
            }
            else
            {
                labelVehicleErrorYear.Visible = true;
            }

            //If vehicle transmission is empty:
            if (comboBoxVehicleTransmission.Text == "")
            {
                labelVehicleErrorTrans.Visible = true;
            }
            else
            {
                labelVehicleErrorTrans.Visible = false;
                verifyVehicle = (verifyVehicle + 1);
            }

            //If vehicle fiuel type is empty:
            if (comboBoxVehicleFuel.Text == "")
            {
                labelVehicleErrorFuel.Visible = true;
            }
            else
            {
                labelVehicleErrorFuel.Visible = false;
                verifyVehicle = (verifyVehicle + 1);
            }

            //If vehicle number of seats is empty:
            if (numericUpDownVehicleSeats.Text == "0")
            {
                labelVehicleErrorSeats.Visible = true;
            }
            else
            {
                labelVehicleErrorSeats.Visible = false;
                verifyVehicle = (verifyVehicle + 1);
            }

            //If vehicle colour is empty:
            if (textBoxVehicleColour.Text == "")
            {
                labelVehicleErrorColour.Visible = true;
            }
            else
            {
                labelVehicleErrorColour.Visible = false;
                verifyVehicle = (verifyVehicle + 1);
            }

            //If vehicle daily rate is empty:
            int dailyrate;
            if (int.TryParse(numericUpDownVehicleDailyRate.Text, out dailyrate))
            {
                if (dailyrate <= 0)
                {
                    labelVehicleErrorDailyRate.Visible = true;
                }
                else
                {
                    labelVehicleErrorDailyRate.Visible = false;
                    verifyVehicle = (verifyVehicle + 1);
                }
            }
            else
            {
                labelVehicleErrorDailyRate.Visible = true;
            }

            //If all of them are checked properly
            if (verifyVehicle == 10)
            {
                buttonVehicleModify2.Visible = true;

                //declare local variables for method to use.
                string vehicleRego;
                string make;
                string model;
                int yearC;
                int numSeats;
                bool gps = false;
                bool sunRoof = false;
                double dailyRate;
                string colour;

                //Assign the values in the gui to the variables.
                vehicleRego = textBoxVehicleRego.Text;
                make = textBoxVehicleMake.Text;
                model = textBoxVehicleModel.Text;
                yearC = int.Parse(textBoxVehicleYear.Text);
                numSeats = (int)numericUpDownVehicleSeats.Value;
                if (checkBoxVehicleGPS.Checked)
                    gps = true;
                if (checkBoxVehicleSunroof.Checked)
                    sunRoof = true;
                dailyRate = (int)numericUpDownVehicleDailyRate.Value;
                colour = textBoxVehicleColour.Text;

                int index = dataGridView2.CurrentCell.RowIndex;

                //Assign the variables to that objectrs properties
                vehicleList[index].VehicleRegoProp = vehicleRego;
                vehicleList[index].VehicleMakeProp = make;
                vehicleList[index].VehicleModelProp = model;
                vehicleList[index].VehicleYearProp = yearC;
                vehicleList[index].VehicleSeatsProp = numSeats;
                vehicleList[index].VehicleGPSProp = gps;
                vehicleList[index].SunRoofProp = sunRoof;
                vehicleList[index].VehicleDRProp = dailyRate;
                vehicleList[index].VehicleColourProp = colour;

                //Economy Class
                if (comboBoxVehicleClass.Text == "Economy")
                {
                    if (comboBoxVehicleFuel.Text == "Petrol")
                    {
                        if (comboBoxVehicleTransmission.Text == "Automatic")
                        {
                            vehicleList[index].VehicleClassProp = Vehicle.VehicleClass.Economy;
                            vehicleList[index].VehicleFuelProp = Vehicle.FuelType.Petrol;
                            vehicleList[index].VehicleTransmissionProp = Vehicle.TransmissionType.Automatic;
                        }
                        else // Manual
                        {
                            vehicleList[index].VehicleClassProp = Vehicle.VehicleClass.Economy;
                            vehicleList[index].VehicleFuelProp = Vehicle.FuelType.Petrol;
                            vehicleList[index].VehicleTransmissionProp = Vehicle.TransmissionType.Manual;
                        }
                    }
                    else //Diesel
                    {
                        if (comboBoxVehicleTransmission.Text == "Automatic")
                        {
                            vehicleList[index].VehicleClassProp = Vehicle.VehicleClass.Economy;
                            vehicleList[index].VehicleFuelProp = Vehicle.FuelType.Diesel;
                            vehicleList[index].VehicleTransmissionProp = Vehicle.TransmissionType.Automatic;
                        }
                        else // Manual
                        {
                            vehicleList[index].VehicleClassProp = Vehicle.VehicleClass.Economy;
                            vehicleList[index].VehicleFuelProp = Vehicle.FuelType.Diesel;
                            vehicleList[index].VehicleTransmissionProp = Vehicle.TransmissionType.Manual;
                        }
                    }
                }

                //Family Class
                if (comboBoxVehicleClass.Text == "Family")
                {
                    if (comboBoxVehicleFuel.Text == "Petrol")
                    {
                        if (comboBoxVehicleTransmission.Text == "Automatic")
                        {
                            vehicleList[index].VehicleClassProp = Vehicle.VehicleClass.Family;
                            vehicleList[index].VehicleFuelProp = Vehicle.FuelType.Petrol;
                            vehicleList[index].VehicleTransmissionProp = Vehicle.TransmissionType.Automatic;
                        }
                        else // Manual
                        {
                            vehicleList[index].VehicleClassProp = Vehicle.VehicleClass.Family;
                            vehicleList[index].VehicleFuelProp = Vehicle.FuelType.Petrol;
                            vehicleList[index].VehicleTransmissionProp = Vehicle.TransmissionType.Manual;
                        }
                    }
                    else //Diesel
                    {
                        if (comboBoxVehicleTransmission.Text == "Automatic")
                        {
                            vehicleList[index].VehicleClassProp = Vehicle.VehicleClass.Family;
                            vehicleList[index].VehicleFuelProp = Vehicle.FuelType.Diesel;
                            vehicleList[index].VehicleTransmissionProp = Vehicle.TransmissionType.Automatic;
                        }
                        else // Manual
                        {
                            vehicleList[index].VehicleClassProp = Vehicle.VehicleClass.Family;
                            vehicleList[index].VehicleFuelProp = Vehicle.FuelType.Diesel;
                            vehicleList[index].VehicleTransmissionProp = Vehicle.TransmissionType.Manual;
                        }
                    }
                }

                //Luxury Class
                if (comboBoxVehicleClass.Text == "Luxury")
                {
                    if (comboBoxVehicleFuel.Text == "Petrol")
                    {
                        if (comboBoxVehicleTransmission.Text == "Automatic")
                        {
                            vehicleList[index].VehicleClassProp = Vehicle.VehicleClass.Luxury;
                            vehicleList[index].VehicleFuelProp = Vehicle.FuelType.Petrol;
                            vehicleList[index].VehicleTransmissionProp = Vehicle.TransmissionType.Automatic;
                        }
                        else // Manual
                        {
                            vehicleList[index].VehicleClassProp = Vehicle.VehicleClass.Luxury;
                            vehicleList[index].VehicleFuelProp = Vehicle.FuelType.Petrol;
                            vehicleList[index].VehicleTransmissionProp = Vehicle.TransmissionType.Manual;
                        }
                    }
                    else //Diesel
                    {
                        if (comboBoxVehicleTransmission.Text == "Automatic")
                        {
                            vehicleList[index].VehicleClassProp = Vehicle.VehicleClass.Luxury;
                            vehicleList[index].VehicleFuelProp = Vehicle.FuelType.Diesel;
                            vehicleList[index].VehicleTransmissionProp = Vehicle.TransmissionType.Automatic;
                        }
                        else // Manual
                        {
                            vehicleList[index].VehicleClassProp = Vehicle.VehicleClass.Luxury;
                            vehicleList[index].VehicleFuelProp = Vehicle.FuelType.Diesel;
                            vehicleList[index].VehicleTransmissionProp = Vehicle.TransmissionType.Manual;
                        }
                    }
                }

                //Commercial Class
                if (comboBoxVehicleClass.Text == "Commercial")
                {
                    if (comboBoxVehicleFuel.Text == "Petrol")
                    {
                        if (comboBoxVehicleTransmission.Text == "Automatic")
                        {
                            vehicleList[index].VehicleClassProp = Vehicle.VehicleClass.Commercial;
                            vehicleList[index].VehicleFuelProp = Vehicle.FuelType.Petrol;
                            vehicleList[index].VehicleTransmissionProp = Vehicle.TransmissionType.Automatic;
                        }
                        else // Manual
                        {
                            vehicleList[index].VehicleClassProp = Vehicle.VehicleClass.Commercial;
                            vehicleList[index].VehicleFuelProp = Vehicle.FuelType.Petrol;
                            vehicleList[index].VehicleTransmissionProp = Vehicle.TransmissionType.Manual;
                        }
                    }
                    else //Diesel
                    {
                        if (comboBoxVehicleTransmission.Text == "Automatic")
                        {
                            vehicleList[index].VehicleClassProp = Vehicle.VehicleClass.Commercial;
                            vehicleList[index].VehicleFuelProp = Vehicle.FuelType.Diesel;
                            vehicleList[index].VehicleTransmissionProp = Vehicle.TransmissionType.Automatic;
                        }
                        else // Manual
                        {
                            vehicleList[index].VehicleClassProp = Vehicle.VehicleClass.Commercial;
                            vehicleList[index].VehicleFuelProp = Vehicle.FuelType.Diesel;
                            vehicleList[index].VehicleTransmissionProp = Vehicle.TransmissionType.Manual;
                        }
                    }
                }
                
                //Set the values in the datatable
                vehicleDT.Rows[index].SetField(0, vehicleRego);
                vehicleDT.Rows[index].SetField(1, vehicleList[index].VehicleClassProp);
                vehicleDT.Rows[index].SetField(2, make);
                vehicleDT.Rows[index].SetField(3, model);
                vehicleDT.Rows[index].SetField(4, year);
                vehicleDT.Rows[index].SetField(5, numSeats);
                vehicleDT.Rows[index].SetField(6, vehicleList[index].VehicleTransmissionProp);
                vehicleDT.Rows[index].SetField(7, vehicleList[index].VehicleFuelProp);
                vehicleDT.Rows[index].SetField(8, gps);
                vehicleDT.Rows[index].SetField(9, sunRoof);
                vehicleDT.Rows[index].SetField(10, dailyRate);
                vehicleDT.Rows[index].SetField(11, colour);

                //rewrite the csvFile.
                newFleet.ReWriteCSVFile(vehicleList);

                //Resets buttons and group box to original state
                groupBoxVehicleModifyVehicle.Visible = false;
                buttonVehicleModify.Enabled = true;
                buttonVehicleRemove.Enabled = true;
                buttonVehicleAdd.Enabled = true;
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            //Fills in the information with the selected customer
            comboBoxTitle.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBoxCustomerFirstName.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBoxCustomerLastName.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBoxGender.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            //Fills in the information with the selected vehicle
            textBoxVehicleRego.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            textBoxVehicleMake.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            textBoxVehicleModel.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
            comboBoxVehicleClass.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            textBoxVehicleYear.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
            comboBoxVehicleTransmission.Text = dataGridView2.SelectedRows[0].Cells[6].Value.ToString();
            comboBoxVehicleFuel.Text = dataGridView2.SelectedRows[0].Cells[7].Value.ToString();
            if (dataGridView2.SelectedRows[0].Cells[9].Value.ToString() == "True")
            {
                checkBoxVehicleSunroof.Checked = true;
            }
            else if (dataGridView2.SelectedRows[0].Cells[9].Value.ToString() == "False")
            {
                checkBoxVehicleSunroof.Checked = false;
            }
            if (dataGridView2.SelectedRows[0].Cells[8].Value.ToString() == "True")
            {
                checkBoxVehicleGPS.Checked = true;
            }
            else if (dataGridView2.SelectedRows[0].Cells[8].Value.ToString() == "False")
            {
                checkBoxVehicleGPS.Checked = false;
            }
            numericUpDownVehicleSeats.Text = dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
            textBoxVehicleColour.Text = dataGridView2.SelectedRows[0].Cells[11].Value.ToString();
            numericUpDownVehicleDailyRate.Text = dataGridView2.SelectedRows[0].Cells[10].Value.ToString();
        }

        private void buttonReportReturnVehicle_Click(object sender, EventArgs e)
        {
            //User has to click into datagrid before function will do anything.
            if (dataGridView3.SelectedRows.Count > 0)
            {
                int firstRowIndex = dataGridView3.SelectedRows.Count - 1;
                string vehicleRego = dataGridView3.SelectedRows[firstRowIndex].Cells[0].Value.ToString();

                if (MessageBox.Show("Are you sure you want to return Vehicle: " + vehicleRego,
                    "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    //Removes the row that is selected.
                    dataGridView3.Rows.RemoveAt(this.dataGridView3.SelectedRows[0].Index);
                    //Returns the car to the fleet so it is able to be rented again.
                    newFleet.ReturnCar(vehicleRego);
                    //Display total vehicles rented.
                    int rows = dataGridView3.RowCount;
                    //Update display count.
                    labelReportVehiclesRented.Text = "Total Vehicles Rented: " + (rows - 1);

                    //Start sum at 0 again.
                    int sum = 0;
                    //Update new daily rate displayed.
                    for (int i = 0; i < dataGridView3.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value);
                    }
                    labelReportDailyRental.Text = "Total Daily Rental Charge: $" + sum; 
                }
            }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            
            btnLoadData.Text = "RELOAD DATA";

            //Empties the dataTables incase they are populated so they can be refreshed.
            customerDT.Clear();
            vehicleDT.Clear();
            rentalDT.Clear();
            availableCars.Clear();

            //Loads in the data from the customerList into the dataTable.
            customerList = newCRM.GetCustomers();

            //For each customer in the customer list, add each property into the corresponding row for that object.
            for (int i = 0; i < customerList.Count; i++)
            {
                customerDT.Rows.Add(customerList[i].CustomerIDProp + 1, customerList[i].CustomerTitleProp,
                    customerList[i].CustomerFNameProp, customerList[i].CustomerLNameProp,
                    customerList[i].CustomerGenderProp, customerList[i].CustomerDOBProp.ToShortDateString());
            }
            //connect datagrid to the datasource
            dataGridView1.DataSource = customerDT;


            //Loads in the data from the vehicleList into the dataTable.
            vehicleList = newFleet.GetFleet();

            //For each vehicle in the vehicle list, add each property into the corresponding row for that object.
            for (int i = 0; i < vehicleList.Count; i++)
            {
                vehicleDT.Rows.Add(vehicleList[i].VehicleRegoProp, vehicleList[i].VehicleClassProp,
                    vehicleList[i].VehicleMakeProp, vehicleList[i].VehicleModelProp, vehicleList[i].VehicleYearProp,
                    vehicleList[i].VehicleSeatsProp, vehicleList[i].VehicleTransmissionProp, vehicleList[i].VehicleFuelProp,
                    vehicleList[i].VehicleGPSProp, vehicleList[i].SunRoofProp, vehicleList[i].VehicleDRProp, vehicleList[i].VehicleColourProp);
            }
            //connect datagrid to the datasource
            dataGridView2.DataSource = vehicleDT;

            //Loads the data from the rentalList into the dataTable for rentals.
            rentalList = newFleet.GetRentals();

            //For each rental in the rental list, add each property into the corresponding row for that object.
            for (int i = 2; i < rentalList.Count; i += 2)
            {
                rentalDT.Rows.Add(rentalList[i], int.Parse(rentalList[i + 1]) + 1, (newFleet.GetDailyRate(rentalList[i])));
            }
            //connect datagrid to the datasource
            dataGridView3.DataSource = rentalDT;

            //Display total vehicles rented.
            labelReportVehiclesRented.Text = "Total Vehicles Rented: " + ((rentalList.Count / 2) - 1);

            //Display the daily rate.
            int sum = 0;
            for (int i = 0; i < dataGridView3.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value);
            }
            labelReportDailyRental.Text = "Total Daily Rental Charge: $" + sum;
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
