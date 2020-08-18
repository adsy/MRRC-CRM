using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace MRRCManagement
{
    public class CRM /* Completed by Adam Brittain */
    {
        //Private data members for CRM class

        private List<Customer> customers = new List<Customer>();
        private string crmFile = @"..\..\..\Data\customer.csv";
        private string testFile = @"..\..\..\Data\test.csv";


        //Methods for CRM Class    

        //Constructor for the CRM class
        public CRM()
        {
            string[] values;
            string line;
            List<string> info = new List<string>();
            List<Customer> customer = new List<Customer>();

            //If the File exists
            if (File.Exists(crmFile))
            {
                try
                {
                    //Open the StreamReader and close it once finished.
                    using (StreamReader inFile = new StreamReader(crmFile))
                    {
                        line = inFile.ReadLine();
                        //While line is not empty.
                        while ((line != null))
                        {
                            //Place each cell into an individual element in values array
                            values = line.Split(',');
                            for (int i = 0; i < values.Count(); i++)
                                //Add each element from valuess into a seperate list called info.
                                info.Add(values[i]);
                            //Read next line
                            line = inFile.ReadLine();
                        }

                    }
                    //Starting at row 2, use the information from each row to populate a new customer object.
                    for (int i = 6; i < info.Count(); i += 6)
                    {
                        //If persons gender is Female
                        if (info[i + 4] == "Female")
                        {
                            Customer newCustomer = new Customer(int.Parse(info[i]), info[i + 1], info[i + 2], info[i + 3],
                                Customer.Gender.Female, DateTime.Parse(info[i + 5]));
                            //Add customer to local method list customer
                            customer.Add(newCustomer);
                        }
                        //If persons gender is Male
                        if (info[i + 4] == "Male")
                        {
                            Customer newCustomer = new Customer(int.Parse(info[i]), info[i + 1], info[i + 2], info[i + 3],
                                Customer.Gender.Male, DateTime.Parse(info[i + 5]));
                            //Add customer to local method list customer
                            customer.Add(newCustomer);
                        }
                        //If persons gender is Not Specified
                        if (info[i + 4] == "Not Specified")
                        {
                            Customer newCustomer = new Customer(int.Parse(info[i]), info[i + 1], info[i + 2], info[i + 3],
                                Customer.Gender.Not_Specified, DateTime.Parse(info[i + 5]));
                            //Add customer to local method list customer
                            customer.Add(newCustomer);
                        }
                    }
                }
                //Return the File was not found error message.
                catch (FileNotFoundException exc)
                {
                    Console.WriteLine(exc.Message);
                }
                //Populate the private class List<Customer> 'customers' with the local customer list.
                customers.AddRange(customer);
            }
            else //File does not exists
            {
                //Create a new instance of FileInfo and create the csv file and dispose of it.
                FileInfo newFile = new FileInfo(crmFile);
                newFile.Create().Dispose();
                //Write into the file.
                using (StreamWriter input = new StreamWriter(crmFile))
                {
                    //Add lines into the excel spreadsheet for columns
                    input.WriteLine("CustomerID" + "," + "Title" + "," + "FirstName" + "," + "LastName" + "," +
                        "Gender" + "," + "DOB");
                }
            }
        }

        //Method to add customer into the csv file.
        public bool AddCustomer(Customer customer)
        {
            //if it does not contain the customer parameter return true, other false.
            if ((customers.Contains(customer)) == false)
            {
                //Open the StreamWriter and close it once finished.
                using (StreamWriter inFile = new StreamWriter(crmFile, true))
                {
                    //Add the CSV representation of customer into the file.
                    inFile.WriteLine(customer.ToCSVString());
                }
                //Add the object into the list of customer objects.
                customers.Add(customer);
                return true;
            }
            else
            {
                return false;
            }
        }

        //Method to remove customer from the CSV file
        public void RemoveCustomerCSV(Customer customer)
        {
            string[] values = File.ReadAllLines(crmFile);
            List<string> list = new List<string>(values);

            //for each value in the customer list, compare them to the customer parameter
            for (int i = 0; i < values.Count(); i++)
            {
                //if there is a match, remove from the list
                if ((customer.ToCSVString() == values[i]))
                {
                    list.RemoveAt(i);
                }
            }

            //Rewrite the customer file and close it once done saving it.
            using (StreamWriter Writer = new StreamWriter(crmFile, false))
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    Writer.WriteLine(list[i]);
                }
            }
        }

        //Method to modify the contents of the CSV file.
        public void ReWriteCSVFile(List<Customer> customers)
        {
            //Open the file and close it once done
            using (StreamWriter inFile = new StreamWriter(crmFile))
            {
                //Write in column headers,
                inFile.WriteLine("CustomerID" + "," + "Title" + "," + "FirstName" + "," + "LastName" + "," + "Gender" + "," + "DOB");

                //For each customer in the customer class
                for (int i = 0; i < customers.Count(); i++)
                    inFile.WriteLine(customers[i].ToCSVString());
            }
        }

        //Remove the customer from the List of customers.
        public bool RemoveCustomer(Customer customer, Fleet fleet)
        {
            int count = 0;
            bool check = false;
            fleet = new Fleet();
            List<string> rentals = new List<string>();

            //If the customers list contains customer.
            if (customers.Contains(customer))
            {
                //Load the data into a local list
                rentals = fleet.GetRentals();
                //Starting at the first occurence of customer ID in the list, increasing to next one
                for (int i = 3; i < rentals.Count; i += 2)
                {
                    //Add one to count if it matches
                    if (rentals[i] == customer.CustomerIDProp.ToString())
                    {
                        count++;
                    }

                }
                //If there were no matches
                if (count == 0)
                {
                    //Delete the customer
                    RemoveCustomerCSV(customer);
                    customers.Remove(customer);
                    check = true;
                }
                else
                    check = false;
            }
            //Return the value.
            return check;
        }

        //Method to remove customer from List of customers.
        public bool RemoveCustomer(int customerID, Fleet fleet)
        {
            return true;
        }

        //Method to return the list of customers.
        public List<Customer> GetCustomers()
        {
            return customers;
        }
    }
}
