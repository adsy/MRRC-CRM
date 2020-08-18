using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRRCManagement
{
    public class Customer /*Completed by Adam Brittain 60%, Eric Chin 40%*/
    {
        //Private data types for Customer Class
        private int customerID;
        private string title;
        private string firstNames;
        private string lastName;
        private Gender gender;
        private DateTime dateOfBirth;

        //Customer gender enum
        public enum Gender
        {
            Not_Specified, Female, Male
        }

        //Constructor for Customer class with 0 parameters
        public Customer()
        {

        }

        //Constructor for Customer Class with 1 parameter
        public Customer(int cID)
        {
            customerID = cID;
        }

        //Constructor for Customer Class with 3 parameters
        public Customer(int cID, string fNames, string lName)
        {
            customerID = cID;
            firstNames = fNames;
            lastName = lName;
        }

        //Constructor for Customer Class with all attributes
        public Customer(int cID, string custTitle, string fNames, string lName, Gender gen, DateTime dob)
        {
            customerID = cID;
            title = custTitle;
            firstNames = fNames;
            lastName = lName;
            gender = gen;
            dateOfBirth = dob;
        }

        //Public ToCSVString method for the Customer Class
        public string ToCSVString()
        {
            return customerID + "," + title + "," + firstNames + "," + lastName + "," + gender + "," + dateOfBirth.ToShortDateString();
        }

        //Public override of the ToString method for the Customer Class
        public override string ToString()
        {
            return customerID + title + firstNames + lastName + gender + dateOfBirth.ToShortDateString();
        }

        //Public Property for Customer ID
        public int CustomerIDProp
        {
            get
            {
                return customerID;
            }
            set
            {
                customerID = value;
            }
        }

        //Public Property for Customer title
        public string CustomerTitleProp
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        //Public Property for Customer first names
        public string CustomerFNameProp
        {
            get
            {
                return firstNames;
            }
            set
            {
                firstNames = value;
            }
        }

        //Public Property for Customer last name
        public string CustomerLNameProp
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        //Public Property for Customer gender
        public Gender CustomerGenderProp
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        //Public Property for Customer date of birth
        public DateTime CustomerDOBProp
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
            }
        }
    }
}
