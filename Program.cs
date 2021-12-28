namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();
            Console.Clear();
            do
            {
                Console.WriteLine("--------------------------------- Deaprtment ----------------------------------");
                Console.WriteLine("Etmek istediyiniz emeliyyati secin");
                Console.WriteLine("1 - Departameantlerin siyahisini gostermek");
                Console.WriteLine("2 - Departamenet yaratmaq");
                Console.WriteLine("3 - Departmanetde deyisiklik etmek");
                Console.WriteLine("4 - Employee uzerinde emeliyyat");
                Console.WriteLine("5 - Sistmden cix");
                Console.Write("Daxil edin : ");
                string choose = Console.ReadLine();
                int choosenum;
                int.TryParse(choose, out choosenum);
                switch (choosenum)
                {
                    case 1:
                        Console.Clear();
                        GetDepartments(ref humanResourceManager);
                        break;
                    case 2:
                        Console.Clear();
                        AddDepartment(ref humanResourceManager);
                        break;
                    case 3:
                        Console.Clear();
                        EditDepartaments(ref humanResourceManager);
                        break;
                    case 4:
                        EmployeeOperation(ref humanResourceManager);
                        break;
                    case 5:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Duzgun reqem daxil edin...");
                        break;
                }
            } while (true);
        }
        static void EmployeeOperation(ref HumanResourceManager humanResourceManager)
        {
            Console.Clear();
            do
            {
                Console.WriteLine("----------      Employee uzerinde emeliyyatlar      ----------");
                Console.WriteLine("1 - Iscilerin siyahisini gostermek ");
                Console.WriteLine("2 - Departamentdeki iscilerin siyahisini gostermrek");
                Console.WriteLine("3 - Isci elave etmek");
                Console.WriteLine("4 - Isci uzerinde deyisiklik etmek ");
                Console.WriteLine("5 - Departamentden isci silinmesi");
                Console.WriteLine("6 - Evvelki emnyuya qayit");
                Console.Write("Daxil edin : ");
                string choose = Console.ReadLine();
                int choosenum;
                int.TryParse(choose, out choosenum);
                switch (choosenum)
                {
                    case 1:
                        Console.Clear();
                        GetEmployees(ref humanResourceManager);
                        break;
                    case 2:
                        Console.Clear();
                        GetEmployeesByDepartment(ref humanResourceManager);
                        break;
                    case 3:
                        Console.Clear();
                        AddEmployee(ref humanResourceManager);
                        break;
                    case 4:
                        Console.Clear();
                        EditEmploye(ref humanResourceManager);
                        break;
                    case 5:
                        Console.Clear();
                        RemoveEmployee(ref humanResourceManager);
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Evvelki emnyuya qayit");
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Duzgun reqem daxil edin...");
                        break;
                }
            } while (true);
        }

        
        static void AddEmployee(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Iscinin butov adini daxil edin : ");
            string fullname = Console.ReadLine();


            Console.WriteLine("Iscinin vezifesini daxil edin : ");
            string position = Console.ReadLine();
            while (position.Length < 2)
            {
                Console.WriteLine("Vezifenin adinin uzunlugu 2den az ola bilmez...");
                Console.Write("Vezifenin adini yeniden daxil edin : ");
                position = Console.ReadLine();
            }


            Console.WriteLine("Iscinin maasini daxil edin : ");
            string salaryName = Console.ReadLine();
            double salary;
            while (!double.TryParse(salaryName, out salary) || salary < 250)
            {
                Console.WriteLine("Iscinin maasi 250-den az ola bilmez...");
                Console.Write("Iscinin maasini duzgun daxil edin : ");
                salaryName = Console.ReadLine();
            }

            if (humanResourceManager.Departments.Length == 0)
            {
                Console.WriteLine("Hec bir department elave olunmayib...");
                Console.WriteLine("Ilk once department elave edin...");
                return;
            }
            else
            {
                Console.WriteLine("Mumkun ola bilen departmentler : ");
            }
            foreach (Department item in humanResourceManager.Departments)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("Iscinin departamnetini daxil edin : ");

            string department = Console.ReadLine();
            bool checkName = true;
            int count = 0;
            while (checkName)
            {
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == department.ToLower())
                    {
                        count++;
                    }
                }

                if (count == 0)
                {
                    Console.WriteLine("Daxil etdiyiniz adda department yoxdur...");
                    return;
                }
                else
                {
                    checkName = false;
                }

                count = 0;
            }

            foreach (Department item in humanResourceManager.Departments)
            {
                if (department.ToLower() == item.Name.ToLower() && item.Employese.Length > Department.WorkerLimit)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Departament tam doludur.Isci elave ede bilmezsiniz...");
                    return;
                }
            }


            humanResourceManager.AddEmployee(fullname, position, salary, department);
        }
        static void GetEmployees(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Employees.Length <= 0)
            {
                Console.WriteLine("Siyahi Bosdur. Once Daxil Edin");
                return;
            }

            foreach (Employee item in humanResourceManager.Employees)
            {
                if (item != null)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("------------------------------------");
                }
            }
            humanResourceManager.GetEmployees();
        }
        static void GetEmployeesByDepartment(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Mumkun ola bilen departmentler : ");
            foreach (Department item in humanResourceManager.Departments)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("Iscilerini gormek istediyiniz departamnetin adini daxil edin : ");
            string department = Console.ReadLine();
            bool checkName = true;
            int count = 0;
            while (checkName)
            {
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == department.ToLower())
                    {
                        count++;
                    }
                }

                if (count == 0)
                {
                    Console.WriteLine("Daxil Etdiyniz Adda Department yoxdur ");
                    Console.Write("Duzgun Ad Daxil Et: ");
                    department = Console.ReadLine();
                }
                else
                {
                    checkName = false;
                }

                count = 0;
            }
            int say = 0;
            foreach (Employee item in humanResourceManager.Employees)
            {
                if (item != null && department.ToLower() == item.DepartmentName.ToLower())
                {
                    Console.WriteLine($"{item}\n----------------");
                }
                else
                {
                    say++;
                }
            }
            if (say == humanResourceManager.Employees.Length)
            {
                Console.WriteLine("departmentn ici bosdur");
            }

            Console.WriteLine($"Umumi maas : {Employee.ortasal}");
            humanResourceManager.GetEmployeesByDepartment(department);
        }
        static void EditEmploye(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Nomreni daxil edin : ");
            string no = Console.ReadLine();

            Console.WriteLine("Iscinin vezifesini daxil edin : ");
            string position = Console.ReadLine();
            while (position.Length < 2)
            {
                Console.WriteLine("Vezifenin adinin uzunlugu 2den az ola bilmez...");
                Console.Write("Vezifenin adini yeniden daxil edin : ");
                position = Console.ReadLine();
            }

            Console.WriteLine("Iscinin maasini daxil edin : ");
            string salaryName = Console.ReadLine();
            double salary;
            while (!double.TryParse(salaryName, out salary) || salary < 250)
            {
                Console.WriteLine("Iscinin maasi 250-den az ola bilmez...");
                Console.Write("Iscinin maasini duzgun daxil edin : ");
                salaryName = Console.ReadLine();
            }

            humanResourceManager.EditEmploye(no, position, salary);
        }
        static void RemoveEmployee(ref HumanResourceManager humanResourceManager)
        {

            if (humanResourceManager.Employees.Length <= 0)
            {
                Console.WriteLine("Siyahi Bosdur. Once Daxil Edin");
                return;
            }

            foreach (Employee item in humanResourceManager.Employees)
            {
                if (item != null)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("------------------------------------");
                }
            }
            Console.WriteLine("Silmek istediyiniz iscinin nomresini daxil edin : ");
            string no = Console.ReadLine();
            bool checkMenuItemNo = true;
            int count = 0;

            while (checkMenuItemNo)
            {
                foreach (Employee item in humanResourceManager.Employees)
                {
                    if (item != null && item.No.ToLower() == no.ToLower())
                    {
                        count++;
                    }
                }

                if (count <= 0)
                {
                    Console.WriteLine("Daxil Etdiyniz Nomrede Employee Movcud Deyil");
                    return;
                }
                else
                {
                    checkMenuItemNo = false;
                }

                count = 0;
            }
            Console.WriteLine("Silmek istediyiniz iscinin departamentini daxil edin : ");
            string depart = Console.ReadLine();

            humanResourceManager.RemoveEmployee(no.ToUpper(), depart);
        }
        #endregion

        #region-Department
        static void AddDepartment(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Department adini daxil edin : ");
            string departmentName = Console.ReadLine();
            string department = departmentName;
            foreach (Department item in humanResourceManager.Departments)
            {
                if (departmentName == item.Name)
                {
                    Console.WriteLine("Bu adda department var");
                    return;
                }
            }
            while (department.Length < 2)
            {
                Console.WriteLine("Departanmentin adinin uzunlugu 2-den az ola bilmez.");
                Console.WriteLine("Duzgun daxil edin : ");
                department = Console.ReadLine();
            }

            Console.WriteLine("Maksimum ola bilecek isci sayini daxil edin : ");
            string workerlimitName = Console.ReadLine();
            int workerlimit;
            while (!int.TryParse(workerlimitName, out workerlimit) || workerlimit <= 1)
            {
                Console.WriteLine("Maksimum isci sayini duzgun daxil edin : ");
                workerlimitName = Console.ReadLine();
            }

            Console.WriteLine("Maksimum ola bilecek maas miqdarini daxil edin : ");
            string salarylimitName = Console.ReadLine();
            int salarylimit;
            while (!int.TryParse(salarylimitName, out salarylimit) || salarylimit < 250)
            {
                Console.WriteLine("Maksimum maas miqdarini duzgun daxil edin : ");
                salarylimitName = Console.ReadLine();
            }
            Console.WriteLine("Bos departamnet yaradila bilmez.Departament ucun yeni bir isci daxil edin : ");
            //Isci daxil edir
            Employee[] arr = { };
            Array.Resize(ref arr, arr.Length + 1);
            Department Department = new Department(department, workerlimit, salarylimit, arr);
            Array.Resize(ref Department.Employese, Department.Employese.Length + 1);

            Console.WriteLine("Iscinin butov adini daxil edin : ");
            string fullname = Console.ReadLine();
            Console.WriteLine("Iscinin vezifesini daxil edin : ");
            string position = Console.ReadLine();
            while (position.Length < 2)
            {
                Console.WriteLine("Vezifenin adinin uzunlugu 2-den az ola bilmez...");
                Console.Write("Vezifenin adini yeniden daxil edin : ");
                position = Console.ReadLine();
            }
            Console.WriteLine("Iscinin maasini daxil edin : ");
            string salaryName = Console.ReadLine();
            double salary;
            while (!double.TryParse(salaryName, out salary) || salary < 250)
            {
                Console.WriteLine("Iscinin maasi 250-den az ola bilmez...");
                Console.Write("Iscinin maasini duzgun daxil edin : ");
                salaryName = Console.ReadLine();
            }
            Employee employee = new Employee(fullname, position, salary, department);
            arr[arr.Length - 1] = employee;
            Department.Employese[Department.Employese.Length - 1] = employee;

            humanResourceManager.AddDepartment(department, workerlimit, salarylimit, arr);
        }
        static void EditDepartaments(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Deyisdirmek istediyiniz department adini daxil edin : ");
            string department = Console.ReadLine();
            bool checkName = true;
            int count = 0;
            while (department.Length < 2)
            {
                Console.WriteLine("Departanmentin adinin uzunlugu 2-den az ola bilmez.");
                Console.WriteLine("Duzgun daxil edin : ");
                department = Console.ReadLine();
            }
            while (checkName)
            {
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == department.ToLower())
                    {
                        count++;
                    }
                }

                if (count == 0)
                {
                    Console.WriteLine("Daxil Etdiyniz Adda Department yoxdur ");
                    //Console.Write("Duzgun Ad Daxil Et: ");
                    //department = Console.ReadLine();
                    return;
                }
                else
                {
                    checkName = false;
                }

                count = 0;
            }


            Console.WriteLine("Departamentin yeni adini daxil edin : ");
            string departmentName = Console.ReadLine();
            string newdepartment = departmentName;
            foreach (Department item in humanResourceManager.Departments)
            {
                if (departmentName == item.Name)
                {
                    Console.WriteLine("Bu adda department var");
                    return;
                }
            }
            while (department.Length < 2)
            {
                Console.WriteLine("Departanmentin adinin uzunlugu 2-den az ola bilmez.");
                Console.WriteLine("Duzgun daxil edin : ");
                department = Console.ReadLine();
            }



            humanResourceManager.EditDepartaments(department, newdepartment);
        }
        static void GetDepartments(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length == 0)
            {
                Console.WriteLine("Hec bir department elave edilmeyib...");
            }
            foreach (Department item in humanResourceManager.Departments)
            {
                Console.WriteLine(item);
            }

            Console.Write($"Umumi iscilerin sayi : {Employee.Workercount}\nOrtalama maas : {Employee.ortasal}\n");
            humanResourceManager.GetDepartments();
        }
        
    }
}
