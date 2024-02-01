using static System.Net.Mime.MediaTypeNames;

namespace Lab2Inheritance
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Read employee data from file
            List<IEmployee> employees = ReadDataFromFile("C:\\myVSCode\\CPRG-211_OOP2\\Lab2Inheritance\\res\\employees.txt");

            //Calculate and display the average weekly pay for all employees
            double averagePay = CalculateAveragePay(employees);
            Console.WriteLine($"Average Weekly Pay for All Employees: \n{averagePay:C}");

            //Find and display the employee with the highest weekly pay among wage employees
            var highestWageEmployee = GetHighestWageEmployee(employees);
            Console.WriteLine($"\nHighest Weekly Pay for Wage Employee: \n{highestWageEmployee.Name} with {highestWageEmployee.GetPay():C}");

            //Find and display the salaried employee with the lowest salary
            var lowestSalariedEmployee = GetLowestSalariedEmployee(employees);
            Console.WriteLine($"\nLowest Salary for Salaried Employee: \n{lowestSalariedEmployee.Name} with {lowestSalariedEmployee.GetPay():C}");

            //Calculate and display the percentage of employees in each category
            var percentageByCategory = GetPercentageByCategory(employees);
            Console.WriteLine("\nPercentage of Employees in Each Category:");
            Console.WriteLine($"Salaried: {percentageByCategory.Salaried:P}");
            Console.WriteLine($"Wage: {percentageByCategory.Wage:P}");
            Console.WriteLine($"Part-Time: {percentageByCategory.PartTime:P}");
        }

        //Read data from the file and create a list of IEmployee objects
        static List<IEmployee> ReadDataFromFile(string filePath)
        {
            List<IEmployee> employees = new List<IEmployee>();

            //Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);

            //Process each line and create employee objects based on their category
            foreach (string line in lines)
            {
                string[] data = line.Split(':');
                string id = data[0];
                string name = data[1];
                string address = data[2];
                string phone = data[3];
                long sin = long.Parse(data[4]);
                string dob = data[5];
                string dept = data[6];

                if (id.StartsWith("0") || id.StartsWith("1") || id.StartsWith("2") || id.StartsWith("3") || id.StartsWith("4"))
                {
                    double salary = double.Parse(data[7]);
                    employees.Add(new Salaried(id, name, address, phone, sin, dob, dept, salary));
                }
                else if (id.StartsWith("5") || id.StartsWith("6") || id.StartsWith("7"))
                {
                    double rate = double.Parse(data[7]);
                    double hours = double.Parse(data[8]);
                    employees.Add(new Wages(id, name, address, phone, sin, dob, dept, rate, hours));
                }
                else if (id.StartsWith("8") || id.StartsWith("9"))
                {
                    double rate = double.Parse(data[7]);
                    double hours = double.Parse(data[8]);
                    employees.Add(new PartTime(id, name, address, phone, sin, dob, dept, rate, hours));
                }
            }

            return employees;
        }

        //Calculate and return the average weekly pay for all employees
        static double CalculateAveragePay(List<IEmployee> employees)
        {
            return employees.Average(employee => employee.GetPay());
        }

        //Find and return the employee with the highest weekly pay among wage employees
        static IEmployee GetHighestWageEmployee(List<IEmployee> employees)
        {
            var wageEmployees = employees.OfType<IWages>();
            return wageEmployees.OrderByDescending(e => e.GetPay()).FirstOrDefault();
        }

        //Find and return the salaried employee with the lowest salary
        static IEmployee GetLowestSalariedEmployee(List<IEmployee> employees)
        {
            var salariedEmployees = employees.OfType<ISalaried>();
            return salariedEmployees.OrderBy(e => e.GetPay()).FirstOrDefault();
        }

        //Calculate and return the percentage of employees in each category
        static (double Salaried, double Wage, double PartTime) GetPercentageByCategory(List<IEmployee> employees)
        {
            int totalEmployees = employees.Count;

            //Count employees in each category
            int salariedCount = employees.OfType<ISalaried>().Count();
            int wageCount = employees.OfType<IWages>().Count();
            int partTimeCount = employees.OfType<IPartTime>().Count();

            // Calculate percentages
            double percentageSalaried = (double)salariedCount / totalEmployees;
            double percentageWage = (double)wageCount / totalEmployees;
            double percentagePartTime = (double)partTimeCount / totalEmployees;

            return (percentageSalaried, percentageWage, percentagePartTime);
        }
    }
}
