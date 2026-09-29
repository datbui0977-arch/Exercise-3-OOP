using System;
using System.Collections.Generic; // thư viện dùng để sử dụng list

namespace Lab03_04_Overloading
{
    // Tạo class dự án
    public class ProjectTeam
    {
        private string projectCode;
        private string projectName;

        // Reference không sở hữu Employee
        private Employee leader;

        // Danh sách reference đến Employee
        private List<Employee> members;

        // Constructor 1
        public ProjectTeam(
            string projectCode,
            string projectName)
        {
            if (string.IsNullOrWhiteSpace(projectCode))
                throw new ArgumentException(
                    "Project code cannot be empty."
                );

            if (string.IsNullOrWhiteSpace(projectName))
                throw new ArgumentException(
                    "Project name cannot be empty."
                );

            this.projectCode = projectCode;
            this.projectName = projectName;
            leader = null;
            members = new List<Employee>();
        }

        // Constructor 2
        public ProjectTeam(
            string projectCode,
            string projectName,
            Employee leader)
            : this(projectCode, projectName)
        {
            if (leader == null)
                throw new ArgumentNullException(nameof(leader));

            this.leader = leader;
            members.Add(leader); // tự động thêm trưởng nhóm là thành viên
        }

    //getter
        public string ProjectCode
        {
            get { return projectCode; }
        }

        public string ProjectName
        {
            get { return projectName; }
        }

        public Employee Leader
        {
            get { return leader; }
        }

        // Kiểm tra nhân sự có trong nhóm hay chưa
        public bool Contains(string employeeId)
        {
            if (string.IsNullOrWhiteSpace(employeeId))
                return false;

            foreach (Employee employee in members)
            {
                if (employee.Id == employeeId)
                    return true;
            }

            return false;
        }
        // Method thêm nhân viên
        // Overloading 1
        public bool AddMember(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (Contains(employee.Id))
                return false;

            members.Add(employee);
            return true;
        }

        // Overloading 2
        public bool AddMember(Employee employee, bool makeLeader)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (Contains(employee.Id))
                return false;

            members.Add(employee);

            if (makeLeader)
            {
                leader = employee;
            }

            return true;
        }

        // Xóa thành viên
        public bool RemoveMember(string employeeId)
        {
            if (string.IsNullOrWhiteSpace(employeeId))
                return false;

            // Không được xóa trưởng nhóm
            if (leader != null && leader.Id == employeeId)
            {
                Console.WriteLine(
                    "Cannot remove the current leader."
                );

                return false;
            }

            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].Id == employeeId)
                {
                    members.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        // Đổi trưởng nhóm
        public bool ChangeLeader(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            // Nếu chưa có trong nhóm thì tự động thêm
            if (!Contains(employee.Id))
            {
                members.Add(employee);
            }

            leader = employee;

            return true;
        }

        // Tính tổng chi phí
        public double CalculateTotalMonthlyCost()
        {
            double total = 0;

            foreach (Employee employee in members)
            {
                total += employee.CalculateMonthlyCost();
            }

            return total;
        }

        // Hiển thị nhóm
        public void DisplayTeam()
        {
            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine($"Project Code: {projectCode}");
            Console.WriteLine($"Project Name: {projectName}");

            if (leader == null)
                Console.WriteLine("Leader: None");
            else
                Console.WriteLine(
                    $"Leader: {leader.FullName} ({leader.Id})"
                );

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Members:");

            if (members.Count == 0)
            {
                Console.WriteLine("No members.");
            }
            else
            {
                foreach (Employee employee in members)
                {
                    // Gọi đa hình
                    employee.DisplayInfo();
                }
            }

            Console.WriteLine("----------------------------------------");
            Console.WriteLine(
                $"Total Monthly Cost: " +
                $"{CalculateTotalMonthlyCost():N0}"
            );

            Console.WriteLine("========================================");
        }

        // ProjectTeam không hủy Employee mà chỉ hùy list
        ~ProjectTeam()
        {
            Console.WriteLine(
                $"[Finalizer] ProjectTeam {projectCode} is being destroyed."
            );
        }
    }
}