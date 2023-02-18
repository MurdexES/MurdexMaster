
public class Students
{ 
    public class Student
    {
        public Student(string Name, string Surname, int Age) 
        { 
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }

    List<Student> students = new();

    public Student this[int i]
    {   
        get { return students[i]; }
        set { students[i] = value; }
    }
}

