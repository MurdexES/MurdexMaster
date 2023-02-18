#include <iostream>
#include <string>
#include <fstream>
#include <sstream>
using namespace std;

class Admin
{
    void delete_stud(Student*& group)
    {
        Student* tmp_group = new Student[sizeof(group) - 1];

        int tmp_id{};

        cout << "Enter id of student to delete: ";
        cin >> tmp_id;

        for (size_t i = 0; i < sizeof(group); i++)
        {
            if (tmp_id == group[i].id)
            {
                for (size_t j = 0; j < i; j++)
                {
                    tmp_group[j] = group[j];
                }

                for (size_t j = i + 1; j < sizeof(group); j++)
                {
                    tmp_group[j] = group[j];
                }
            }
        }

        delete[] group;

        group = new Student[sizeof(tmp_group)]{};

        for (size_t i = 0; i < sizeof(tmp_group); i++)
        {
            group[i] = tmp_group[i];
        }

        delete[] tmp_group;
    }

    void add_stud(Student*& group, Student stud)
    {
        Student* tmp_group = new Student[sizeof(group) + 1];

        for (size_t i = 0; i < sizeof(group); i++)
        {
            tmp_group[i] = group[i];
        }

        tmp_group[sizeof(group)] = stud;

        delete[] group;

        group = new Student[sizeof(tmp_group)]{};

        for (size_t i = 0; i < sizeof(tmp_group); i++)
        {
            group[i] = tmp_group[i];
        }

        delete[] tmp_group;
    }
};

class Student:public Admin
{
public:
    Student() = default;

    Student(string name, string surname)
    {
        this->name = name;
        this->surname = surname;
    }

    string writing()
    {
        string all = this->name + ' ' + this->surname;
        
        return all;
    }

    static int _id;
    int id = ++_id;

protected:
    int fee_num = strike_num / 4;
    int strike_num{};

    string name{};
    string surname{};

};

int Student::_id = 0;

int main()
{
    Student* group = new Student[5]{};

    string name{};
    string surname{};

    for (size_t i = 0; i < sizeof(group); i++)
    {
        cout << "Enter name and surname of student: " << endl;
        cin >> name;
        cin >> surname;

        Student(name, surname);
    }

    fstream write_file("data.txt", ios::out);
    for (size_t i = 0; i < sizeof(group); i++)
    {
        write_file << group[i].writing();
    }

    return 0;
}
