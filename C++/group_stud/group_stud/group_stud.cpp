#include <iostream>
using namespace std;

enum faculty { Software_development = 1, Networkand_security, Design };
int selection{};

struct Student
{
    static uint16_t _id;
    char id_tmp = static_cast<char>((++_id) + 48);
    char* name = new char[10]{};
    char* surname = new char[10]{};
    uint16_t age{};
    char* id = new char[5]{ name[0], surname[0], 'C', 'D', id_tmp };
    float GPA{};

    void Student_create()
    {
        cout << "Enter name: " << endl;
        cin.getline(this->name, 10);
        
        cout << "Enter surname: " << endl;
        cin.getline(this->surname, 15);
        
        cout << "Enter age: " << endl;
        cin >> this->age;
        
        cout << "Enter GPA: " << endl;
        cin >> this->GPA;

        cout << "Your id: " << id;
        
        cin.ignore();
    }
};
uint16_t Student::_id = 0;

struct Subject
{
    static uint16_t _id;
    char id_tmp = static_cast<char>((++_id) + 48);
    char* name = new char[10]{};
    int faculty_selec{};
    char* id = new char[5]{ name[0], char(faculty_selec + 48), 'C', 'D', id_tmp };

    void Subject_create()
    {
        cout << "Enter name: " << endl;
        cin.getline(this->name, 10);

        cout << "Enter faculty number: " << endl;
        cin >> this->faculty_selec;

        cout << "Subject id: " << id;

        cin.ignore();
    }
};
uint16_t Subject::_id = 0;

struct Teacher
{
    static uint16_t _id;
    char id_tmp = static_cast<char>((++_id) + 48);
    Subject* array = new Subject[5]{};
    char* name = new char[10]{};
    char* surname = new char[10]{};
    uint16_t age{};

    char* id = new char[5]{ name[0], surname[0], 'C', 'D', id_tmp};

    void Teacher_create()
    {
        cout << "Enter name: " << endl;
        cin.getline(this->name, 10);

        cout << "Enter surname: " << endl;
        cin.getline(this->surname, 15);

        cout << "Enter age: " << endl;
        cin >> this->age;

        cout << "Your id: " << id;

        cin.ignore();
    }
};
uint16_t Teacher::_id = 0;

struct Group
{
    static uint16_t _id;
    char id_tmp = static_cast<char>((++_id) + 48);
    char* name = new char[10]{};
    uint8_t course{};
    Subject subject{};
    int _faculty_selec{};
    Student* students = new Student[15]{};
    Teacher* teachers = new Teacher[5]{};

    char* id = new char[5]{ name[0], char(course + 48), 'C', 'D', id_tmp};

    void Group_create()
    {
        cout << "Enter name of group: " << endl;
        cin >> this->name;

        cout << "Enter faculty number: " << endl;
        cin >> this->_faculty_selec;

        cout << "Enter course: " << endl;
        cin >> course;

        cout << "Enter subject: " << endl;
        Subject tmp_subject{};
        tmp_subject.Subject_create();

        for (size_t i = 0; i < 15; i++)
        {
            this->students[i].Student_create();
        }

        for (size_t i = 0; i < 5; i++)
        {
            this->teachers[i].Teacher_create();
        }

        cout << "Your id: " << id;

        cin.ignore();

        this->subject = tmp_subject;
    }
};
uint16_t Group::_id = 0;

int main()
{
    int len{};

    cout << "Enter number of groups: ";
    cin >> len;

    Group* groups = new Group[len]{};

    for (size_t i = 0; i < len; i++)
    {
        groups[i].Group_create();
    }

    return 0;
}
