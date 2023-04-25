using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ZadatakZaVijezbu
{
    public class Dessert
    {
        string name;
        double weight;
        int calories;

        public string Name { get => name; set => name = value; }
        public double Weight { get => weight; set => weight = value; }
        public int Calories { get => calories; set => calories = value; }

        public string getName() {
            return Name;
        }

        public override string ToString()
        {
            return "Ime desserta je " + Name + ", ima " + Calories + " kalorije s težinom " + Weight + "kg";
        }
        public string getDessertType()
        {
            return "dessert";
        }
        public Dessert(string N, double W, int C)
        {
            Name = N;
            Weight = W;
            Calories = C;
        }
        public Dessert() { }
    }
    public class Cake : Dessert
    {
        bool containsGluten;
        string cakeType;

        public bool ContainsGluten { get => containsGluten; set => containsGluten = value; }
        public string CakeType { get => cakeType; set => cakeType = value; }

        public override string ToString()
        {
            string Output = "Ime torta je " + Name + ", " + CakeType + " je vrsta torta, ima " + Calories + " kalorije s težinom " + Weight + "kg i ";
            if (ContainsGluten == false)
            {
                Output += "nema gluten";
            } else
            {
                Output += "ima gluten";
            }
            return Output;
        }
        public string getDessertType()
        {
            return "torta";
        }
        public Cake(string N, double W, int C, bool CG, string CT)
        {
            Name = N;
            Weight = W;
            Calories = C;
            ContainsGluten = CG;
            CakeType = CT;
        }
        public Cake() { }
    }
    public class IceCream : Dessert
    {
        string flavour, color;

        public string Flavour { get => flavour; set => flavour = value; }
        public string Color { get => color; set => color = value; }

        public override string ToString()
        {
            return "Ime sladoled je " + Name + ", " + Color + " je boja s okusom" + Flavour + ", ima " + Calories + " kalorije s težinom " + Weight + "kg";
        }
        public string getDessertType()
        {
            return "sladoled";
        }
        public IceCream(string N, double W, int C, string F, string CO)
        {
            Name = N;
            Weight = W;
            Calories = C;
            Flavour = F;
            Color = CO;
        }
        public IceCream() { }
    }
    public class Person
    {
        string name, surname;
        int age;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Age { get => age; set => age = value; }

        public override string ToString()
        {
            return "Čovjek s imenom " + Name + " " + Surname + ", ima " + Age + " godina";
        }

        public Person(string N, string S, int A)
        {
            Name = N;
            Surname = S;
            Age = A;
        }
        public Person() { }

        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   Name == person.Name &&
                   Surname == person.Surname &&
                   Age == person.Age;
        }
    }
    public class Student : Person
    {
        string studentId;
        short academicYear; //short int

        public string StudentId { get => studentId; set => studentId = value; }
        public short AcademicYear { get => academicYear; set => academicYear = value; }

        public override string ToString()
        {
            return "Student s imenom " + Name + " " + Surname + ", ima " + Age + " godina, oni su " + academicYear + " razred , ima ID: " + StudentId;
        }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   //base.Equals(obj) &&
                   StudentId == student.StudentId;
        }

        public Student(string N, string S, int A, string SID, short AY)
        {
            Name = N;
            Surname = S;
            Age = A;
            StudentId = SID;
            AcademicYear = AY;
        }
        public Student() { }
    }
    public class Teacher : Person
    {
        string email, subject;
        double salary;

        public string Email { get => email; set => email = value; }
        public string Subject { get => subject; set => subject = value; }
        public double Salary { get => salary; set => salary = value; }

        public override string ToString()
        {
            return "Učitelji s imenom " + Name + " " + Surname + ", ima " + Age + " godina, uči " + Subject + " s email-om " + Email + " i imaju plaču " + Salary + " euro.";
        }

        public Teacher(string N, string S, int A, string E, string SU, double SA)
        {
            Name = N;
            Surname = S;
            Age = A;
            Email = E;
            Subject = SU;
            Salary = SA;
        }
        public Teacher() { }
        public void increaseSalary(int IncSal)
        {
            Salary *= IncSal / 100 + 1;
        }
        public void increaseSalaryStatic(int IncSal, Teacher teach)
        {
            teach.salary *= IncSal / 100 + 1;
        }

        public override bool Equals(object obj)
        {
            return obj is Teacher teacher &&
                   //base.Equals(obj) &&
                   Email == teacher.Email;
        }
    }
    public class CompetitionEntry
    {
        Teacher teach;
        Dessert desse;
        Student[] stud = new Student[3];
        int amount=0;
        float grade;
        internal Teacher Teach { get => teach; set => teach = value; }
        internal Dessert Desse { get => desse; set => desse = value; }
        internal Student[] Stud { get => stud; set => stud = value; }
        public float Grade { get => grade; set => grade = value; }
        public int Amount { get => amount; set => amount = value; }

        public CompetitionEntry(Teacher T, Dessert D)
        {
            teach = T;
            desse = D;
        }
        public string addRating(Student S, int G)
        {
            bool YN = true;
            foreach (Student ST in stud)
            {
                if (ST == S)
                {
                    YN = false;
                }
            }
            if (YN == true)
            {
                Stud[amount] = S;
                Grade += G;
                amount++;
                return "Radi";
            } else
            {
                return "Neradi";
            }
        }
        public float getRating()
        {
            float g = 0;
            if (amount != 0) {
            g = (Grade / amount);
            }
            return g;
        }
    }
    public class UniMasterChef {
        CompetitionEntry[] compEn = new CompetitionEntry[2];
        int ceAmont = -1;

        public CompetitionEntry[] CompEn { get => compEn; set => compEn = value; }
        public int CeAmont { get => ceAmont; set => ceAmont = value; }

        public void addEntry(CompetitionEntry CE) {
            CeAmont += 1;
            CompEn[CeAmont] = CE; 
        } //Crash?

        public CompetitionEntry getBestDessert()
        {
            CompetitionEntry BestEntry = compEn[0];
            foreach(CompetitionEntry CE in CompEn)
            {
                if (BestEntry.getRating() < CE.getRating()) {
                    BestEntry = CE;
                }
            }
            return BestEntry;
        }
        public Person[] getInvolvedPeople(CompetitionEntry CE)
        {
            Person[] people = new Person[4];
            people[0] = CE.Teach;
            int i = 0;
            foreach (Student s in CE.Stud)
            {
                i++;
                people[i] = s;
            }
            return people;
        }
        public UniMasterChef(int Size)
        {
            //
        }
    }
    public class Vehicle
    {
        string regNo;
        string model;
        int year;
        double price;
        double cargoSpace;

        public string RegNo { get => regNo; set => regNo = value; }
        public string Model { get => model; set => model = value; }
        public int Year { get => year; set => year = value; }
        public double Price { get => price; set => price = value; }
        public double CargoSpace { get => cargoSpace; set => cargoSpace = value; }

        public override string ToString()
        {
            return "Vozilo " + Model + " ima regresirani broj: " + RegNo + " i od godine " + Year + " cijena za Vozilo je: " + Price;
        }

        public Vehicle(string rN, string m, int y, double p, double cS)
        {
            RegNo = rN;
            Model = m;
            Year = y;
            Price = p;
            CargoSpace = cS;
        }
        public Vehicle() { }

        public double getPricePerDay()
        {
            return price * 24;
        }
        public double getPricePerMonth() //final
        {
            return 30 * getPricePerDay();
        }
        public static Vehicle getNewestVehicle(Vehicle[] ve)
        {
            Vehicle VeV = ve[0];
            foreach (Vehicle Ve in ve)
            {
                if (Ve.Year > VeV.Year)
                {
                    VeV = Ve;
                }
            }
            return VeV;
        }
        public static string printAllVehiclesWithCargoSpaceGreaterThan(double p, Vehicle[] ve)
        {
            string txt = "Vozila s prtljažnim prostorom većim od 500,0 litara";
            foreach (Vehicle Ve in ve)
            {
                if (Ve.CargoSpace >= 500)
                {
                    txt += "\r\n\t - "+Ve.Model+": " +Ve.CargoSpace;
                }
            }
            return  txt ;
        }
    }
    public class Car : Vehicle
    {
        string carType;

        public string CarType { get => carType; set => carType = value; }

        public Car()
        {

        }
        public Car(string rN, string m, int y, double p, string cT, double cS)
        {
            RegNo = rN;
            Model = m;
            Year = y;
            Price = p;
            CarType = cT;
            CargoSpace = cS;
        }
    }
    public class Van : Vehicle
    {
        double height;
        int noOfSeats;

        public double Height { get => height; set => height = value; }
        public int NoOfSeats { get => noOfSeats; set => noOfSeats = value; }
        public Van()
        {

        }
        public Van(string rN, string m, int y, double p, double h, int nOS, double cS)
        {
            RegNo = rN;
            Model = m;
            Year = y;
            Price = p;
            Height = h;
            NoOfSeats = nOS;
            CargoSpace= cS;
        }
    }
    public class Limo : Vehicle
    {
        double length;
        bool miniBar;
        bool sunRoof;

        public double Length { get => length; set => length = value; }
        public bool MiniBar { get => miniBar; set => miniBar = value; }
        public bool SunRoof { get => sunRoof; set => sunRoof = value; }
        public Limo()
        {

        }
        public Limo(string rN, string m, int y, double p, double l, bool mB, bool sR)
        {
            RegNo = rN;
            Model = m;
            Year = y;
            Price = p;
            Length = l;
            SunRoof = mB;
            sunRoof = sR;
        }
    }
    public class PassengerVan : Van
    {
        int noOfPassengers;

        public int NoOfPassengers { get => noOfPassengers; set => noOfPassengers = value; }
        public PassengerVan() { }
        public PassengerVan(string rN, string m, int y, double p, double h, int nOS, int nOP)
        {
            RegNo = rN;
            Model = m;
            Year = y;
            Price = p;
            Height = h;
            NoOfSeats = nOS;
            NoOfPassengers = nOP;
            CargoSpace = nOP;
        }
        public double getPricePerDay()
        {
            return Price * 1.1 * 24;
        }
    }
    public class CargoVan : Van
    {
        double maxLoad;

        public double MaxLoad { get => maxLoad; set => maxLoad = value; }
        public CargoVan() { }
        public CargoVan(string rN, string m, int y, double p, double h, int nOS, double mL)
        {
            RegNo = rN;
            Model = m;
            Year = y;
            Price = p;
            Height = h;
            NoOfSeats = nOS;
            MaxLoad = mL;
            CargoSpace = mL;
        }
        public double getPricePerDay()
        {
            return Price * 1.5 * 24;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dessert genericDessert = new Dessert("Chocolate Mousse", 120, 300);
            Cake cake = new Cake("Raspberry chocolate cake #3", 350.5, 400, false, "birthday");
            Teacher t1 = new Teacher("Dario", "Tušek", 42, "dario.tusek@fer.hr", "OOP", 10000);
            Teacher t2 = new Teacher("Doris", "Bezmalinović", 43, "doris.bezmalinovic@fer.hr", "OOP", 10000);
            Student s1 = new Student("Janko", "Horvat", 18, "0036312123", (short)1);
            Student s2 = new Student("Ana", "Kovač", 19, "0036387656", (short)2);
            Student s3 = new Student("Ivana", "Stanić", 19, "0036392357", (short)1);
            UniMasterChef competition = new UniMasterChef(2);
            CompetitionEntry e1 = new CompetitionEntry(t1, genericDessert);
            competition.addEntry(e1);
            Console.WriteLine("Entry 1 rating: " + e1.getRating());
            e1.addRating(s1, 4);
            e1.addRating(s2, 5);
            Console.WriteLine("Entry 1 rating: " + e1.getRating());
            CompetitionEntry e2 = new CompetitionEntry(t2, cake);
            e2.addRating(s1, 4);
            e2.addRating(s3, 5);
            e2.addRating(s2, 5);
            competition.addEntry(e2);
            Console.WriteLine("Entry 2 rating: " + e2.getRating());
            Console.WriteLine("Best dessert is: " + competition.getBestDessert().Desse.Name);
            Person[] e2persons = new Person[3];
            e2persons = competition.getInvolvedPeople(e2);

            foreach (Person p in e2persons) {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine("\r\n\r\n ");

            Vehicle v = new Car("DA1234AA", "Renault Clio", 2001, 20, "coupe", 200);
            Car car = new Car("DA8818BB", "Renault Megane Grandtour", 2007, 25, "caravan", 800);
            Van van1 = new CargoVan("DA0009PO", "Volkswagen Transporter", 2018, 28, 2, (short)3, 4500);
            PassengerVan van2 = new PassengerVan("DA6282EA", "IMV 1600", 1978, 35, 2, (short)3, 0);
            Vehicle limo = new Limo("DA2238AB", "Zastava 750 LE", 1983, 220, 3.2, false, false);
            Console.WriteLine(v.Model + " price per day: " + v.getPricePerDay());
            Console.WriteLine(van1.Model + " price per day: " + van1.getPricePerDay());
            Console.WriteLine(van2.Model + " price per month: " + van2.getPricePerMonth());

            Vehicle[] VL = new Vehicle[5];
            VL[0] = v;
            VL[1] = car;
            VL[2] = van1;
            VL[3] = van2;
            VL[4] = limo;

            Vehicle newest = Vehicle.getNewestVehicle(VL);
            Console.WriteLine("Newest: " + newest.Model + ", " + newest.Year);
            Console.WriteLine(Vehicle.printAllVehiclesWithCargoSpaceGreaterThan(500, VL));

            Console.ReadKey();
        }
    }
}
