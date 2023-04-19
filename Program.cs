using System;
using System.Collections.Generic;
using System.Linq;
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
        Student[] stud;
        int grade;
        internal Teacher Teach { get => teach; set => teach = value; }
        internal Dessert Desse { get => desse; set => desse = value; }
        internal Student[] Stud { get => stud; set => stud = value; }
        public int Grade { get => grade; set => grade = value; }


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
                Grade += G;
                return "Radi";
            } else
            {
                return "Neradi";
            }
        }
        public int getRating()
        {
            return (Grade / stud.Length);
        }
    }
    public class UniMasterChef {
        CompetitionEntry[] compEn;
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
            return CE.Stud;
        }
        public UniMasterChef(int Size)
        {
            //
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
            Person[] e2persons = competition.getInvolvedPeople(e2);
            foreach(Person p in e2persons)
                Console.WriteLine(p);

            Console.ReadKey();
        }
    }
}
