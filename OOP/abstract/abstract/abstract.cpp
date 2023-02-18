#include <iostream>
#include <string>
using namespace std;

class Person
{
public:
    virtual void action() = 0;

private:
    string name{};
    string surname{};
    uint8_t age{};

};

class Worker: public Person
{
public:
    void action() override
    {
        cout << "I am Worker: ";
    }
    virtual void type();
private:
    string name{};
    string surname{};
    uint8_t age{};
};

class Teacher : Worker
{
public:
    void type() override
    {
        cout << " as Teacher." << endl;
    }
};

class Manager : public Worker
{
public:
    void type() override
    {
        cout << " as Manager." << endl;
    }
};

class Student : public Person
{
public:
    void action() override
    {
        cout << "I am Student: ";
    }
    virtual void type();
};

class Designer : public Student
{
public:
    void type() override
    {
        cout << " as Designer." << endl;
    }
};

class Programmer :public Student
{
public:
    void type() override
    {
        cout << " as Programmer." << endl;
    }
};

class Networker :public Student
{
public:
    void type() override
    {
        cout << " as Networker." << endl;
    }
};

int main()
{
    int selec{};
    int selec_type{};

    Person* p = nullptr;

    cout << "In which group you are: " << endl
        << "1. Worker" << endl
        << "2. Student" << endl
        << "Enter your choice: ";
    cin >> selec;

    switch (selec)
    {
    case 1:
         p = new Worker();

         cout << "In which type of Worker you are: " << endl
             << "1. Teacher" << endl
             << "2. Manager" << endl
             << "Enter your choice: ";
         cin >> selec_type;

         switch (selec_type)
         {
         case 1: 
             p = new Teacher();
             break;
         case 2:
             p = new Manager();
             break;
         }

         break;
    case 2:
        p = new Student();

        cout << "In which type of Student you are: " << endl
            << "1. Designer" << endl
            << "2. Programmer" << endl
            << "3. Networker" << endl
            << "Enter your choice: ";
        cin >> selec_type;

        switch (selec_type)
        {
        case 1:
            p = new Designer();
            break;
        case 2:
            p = new Programmer();
            break;
        case 3:
            p = new Networker();
            break;
        }

        break;
    }

    p->action();
    
    return EXIT_SUCCESS;
}
