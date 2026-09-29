using System;

namespace Lab03_04_Overloading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("========================================");
            Console.WriteLine("   PROJECT TEAM MANAGEMENT - C#");
            Console.WriteLine("========================================");

            // =========================================
            // 1. Tạo hai Employee bằng hai constructor
            // =========================================

            Console.WriteLine("\n[1] CREATE EMPLOYEES");

            Employee emp1 = new Employee(
                "E001",
                "Nguyen Van An"
            );

            Employee emp2 = new Employee(
                "E002",
                "Tran Thi Binh",
                12000000
            );

            emp1.DisplayInfo();
            emp2.DisplayInfo();


            // =========================================
            // 2. Tạo hai SoftwareEngineer
            // =========================================

            Console.WriteLine("\n[2] CREATE SOFTWARE ENGINEERS");

            SoftwareEngineer eng1 = new SoftwareEngineer(
                "SE001",
                "Le Van Cuong",
                "C#"
            );

            SoftwareEngineer eng2 = new SoftwareEngineer(
                "SE002",
                "Pham Thi Dung",
                18000000,
                "Java",
                3000000
            );

            eng1.DisplayInfo();
            eng2.DisplayInfo();


            // =========================================
            // 3. Tăng lương bằng số tiền cố định
            // =========================================

            Console.WriteLine(
                "\n[3] INCREASE SALARY BY FIXED AMOUNT"
            );

            emp1.IncreaseSalary(2000000);

            emp1.DisplayInfo();


            // =========================================
            // 4. Tăng lương theo phần trăm
            // =========================================

            Console.WriteLine(
                "\n[4] INCREASE SALARY BY PERCENTAGE"
            );

            emp2.IncreaseSalary(10, true);

            emp2.DisplayInfo();


            // =========================================
            // 5. Tạo nhóm không có trưởng nhóm
            // =========================================

            Console.WriteLine(
                "\n[5] CREATE PROJECT WITHOUT LEADER"
            );

            ProjectTeam team1 = new ProjectTeam(
                "P001",
                "E-Commerce System"
            );

            team1.DisplayTeam();


            // =========================================
            // 6. Thêm Employee bằng addMember(employee)
            // =========================================

            Console.WriteLine(
                "\n[6] ADD MEMBER"
            );

            bool result = team1.AddMember(emp1);

            Console.WriteLine(
                $"Add {emp1.FullName}: {result}"
            );


            // =========================================
            // 7. Thêm engineer và đặt làm leader
            // =========================================

            Console.WriteLine(
                "\n[7] ADD ENGINEER AS LEADER"
            );

            result = team1.AddMember(eng1, true);

            Console.WriteLine(
                $"Add {eng1.FullName} as leader: {result}"
            );

            team1.DisplayTeam();


            // =========================================
            // 8. Thử thêm thành viên đã tồn tại
            // =========================================

            Console.WriteLine(
                "\n[8] ADD DUPLICATE MEMBER"
            );

            result = team1.AddMember(emp1);

            Console.WriteLine(
                $"Add duplicate {emp1.FullName}: {result}"
            );


            // =========================================
            // 9. Hiển thị bằng lời gọi đa hình
            // =========================================

            Console.WriteLine(
                "\n[9] POLYMORPHISM"
            );

            team1.DisplayTeam();

            /*
             * members có kiểu Employee
             * nhưng object thực tế có thể là:
             *
             * Employee
             * SoftwareEngineer
             *
             * Vì DisplayInfo() là virtual/override
             * nên C# sẽ gọi đúng phiên bản.
             */


            // =========================================
            // 10. Tính tổng chi phí hàng tháng
            // =========================================

            Console.WriteLine(
                "\n[10] TOTAL MONTHLY COST"
            );

            double totalCost =
                team1.CalculateTotalMonthlyCost();

            Console.WriteLine(
                $"Total cost = {totalCost:N0}"
            );


            // =========================================
            // 11. Thử xóa trưởng nhóm
            // =========================================

            Console.WriteLine(
                "\n[11] TRY TO REMOVE CURRENT LEADER"
            );

            result = team1.RemoveMember(eng1.Id);

            Console.WriteLine(
                $"Remove leader: {result}"
            );


            // =========================================
            // 12. Đổi trưởng nhóm rồi xóa leader cũ
            // =========================================

            Console.WriteLine(
                "\n[12] CHANGE LEADER THEN REMOVE OLD LEADER"
            );

            team1.ChangeLeader(emp1);

            Console.WriteLine(
                $"New leader: {team1.Leader.FullName}"
            );

            result = team1.RemoveMember(eng1.Id);

            Console.WriteLine(
                $"Remove old leader: {result}"
            );

            team1.DisplayTeam();


            // =========================================
            // 13. Tạo team thứ hai
            //     dùng lại employee ở team 1
            // =========================================

            Console.WriteLine(
                "\n[13] CREATE SECOND PROJECT TEAM"
            );

            ProjectTeam team2 = new ProjectTeam(
                "P002",
                "Mobile Application"
            );

            result = team2.AddMember(emp1);

            Console.WriteLine(
                $"Add {emp1.FullName} to Team 2: {result}"
            );

            team2.DisplayTeam();


            // =========================================
            // 14. Hủy team thứ hai
            // =========================================

            Console.WriteLine(
                "\n[14] DESTROY SECOND TEAM"
            );

            {
                ProjectTeam temporaryTeam =
                    new ProjectTeam(
                        "P003",
                        "Temporary Project"
                    );

                temporaryTeam.AddMember(eng2);

                temporaryTeam.DisplayTeam();

                Console.WriteLine(
                    "End of local block..."
                );
            }

            // GC được yêu cầu để minh họa vòng đời.
            GC.Collect();
            GC.WaitForPendingFinalizers();


            // =========================================
            // 15. Employee vẫn tồn tại
            // =========================================

            Console.WriteLine(
                "\n[15] EMPLOYEE STILL EXISTS"
            );

            eng2.DisplayInfo();

            Console.WriteLine(
                "\nSoftwareEngineer still exists " +
                "after ProjectTeam was destroyed."
            );


            // =========================================
            // Kết thúc
            // =========================================

            Console.WriteLine(
                "\n========================================"
            );

            Console.WriteLine(
                "Program finished."
            );

            Console.WriteLine(
                "========================================"
            );

            Console.ReadKey();
        }
    }
}