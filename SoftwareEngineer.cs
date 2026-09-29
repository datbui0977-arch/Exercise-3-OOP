using System;

namespace Lab03_04_Overloading
{
    // Tạo class nhân viên kỹ thuật kế thừa từ class nhân viên
    public class SoftwareEngineer : Employee
    {
        private string primaryLanguage;
        private double technicalAllowance;

        // Constructor 1
        public SoftwareEngineer(
            string id,
            string fullName,
            string primaryLanguage)
            : base(id, fullName)
        {
            if (string.IsNullOrWhiteSpace(primaryLanguage))
                throw new ArgumentException(
                    "Primary language cannot be empty."
                );

            this.primaryLanguage = primaryLanguage;
            technicalAllowance = 0;
        }

        // Constructor 2
        public SoftwareEngineer(
            string id,
            string fullName,
            double baseSalary,
            string primaryLanguage,
            double technicalAllowance)
            : base(id, fullName, baseSalary)
        {
            if (string.IsNullOrWhiteSpace(primaryLanguage))
                throw new ArgumentException(
                    "Primary language cannot be empty."
                );

            if (technicalAllowance < 0)
                throw new ArgumentException(
                    "Technical allowance cannot be negative."
                );

            this.primaryLanguage = primaryLanguage;
            this.technicalAllowance = technicalAllowance;
        }

        public string PrimaryLanguage
        {
            get { return primaryLanguage; }
        }

        public double TechnicalAllowance
        {
            get { return technicalAllowance; }
        }

        // Override tính lương tháng có thêm phụ cấp
        public override double CalculateMonthlyCost()
        {
            return BaseSalary + technicalAllowance;
        }

        // Override hiển thị lại thông tin
        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"Software Engineer: ID={Id}, " +
                $"Name={FullName}, " +
                $"Base Salary={BaseSalary:N0}, " +
                $"Language={primaryLanguage}, " +
                $"Technical Allowance={technicalAllowance:N0}, " +
                $"Monthly Cost={CalculateMonthlyCost():N0}"
            );
        }

        // Destrutor giải phóng bộ nhớ
        ~SoftwareEngineer()
        {
            Console.WriteLine(
                $"[Finalizer] SoftwareEngineer {Id} is being destroyed."
            );
        }
    }
}