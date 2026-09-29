using System;

namespace Lab03_04_Overloading
{
    // Tao class employee
    public class Employee
    {
        private string id;
        private string fullName;
        private double baseSalary;

        // Constructor 1
        public Employee()
        {
            id = "UNKNOWN";
            fullName = "Unnamed employee";
            baseSalary = 0;
        }

        // Constructor 2 
        public Employee(string id, string fullName)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Employee ID cannot be empty.");

            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Employee name cannot be empty.");

            this.id = id;
            this.fullName = fullName;
            this.baseSalary = 0;
        }

        // Constructor 3 
        public Employee(string id, string fullName, double baseSalary)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Employee ID cannot be empty.");

            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Employee name cannot be empty.");

            if (baseSalary < 0)
                throw new ArgumentException("Base salary cannot be negative.");

            this.id = id;
            this.fullName = fullName;
            this.baseSalary = baseSalary;
        }

        // Getter
        public string Id
        {
            get { return id; }
        }

        public string FullName
        {
            get { return fullName; }
        }

        public double BaseSalary
        {
            get { return baseSalary; }
        }

        // Method tăng lương
        // Tăng lương một số tiền cố định
        public void IncreaseSalary(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Increase amount must be positive.");

            baseSalary += amount;
        }

        // Tăng theo phần trăm hoặc số tiền cố định
        public void IncreaseSalary(double value, bool byPercentage)
        {
            if (value <= 0)
                throw new ArgumentException("Increase value must be positive.");

            if (byPercentage)
            {
                baseSalary += baseSalary * value / 100.0;
            }
            else
            {
                baseSalary += value;
            }
        }

        // Virtual tính tiền lương tháng
        public virtual double CalculateMonthlyCost()
        {
            return baseSalary;
        }

        // Virtual hiện thông tin
        public virtual void DisplayInfo()
        {
            Console.WriteLine(
                $"Employee: ID={id}, Name={fullName}, " +
                $"Base Salary={baseSalary:N0}"
            );
        }

        // Destructor giải phóng bộ nhớ
        ~Employee()
        {
            Console.WriteLine(
                $"[Finalizer] Employee {id} is being destroyed."
            );
        }
    }
}