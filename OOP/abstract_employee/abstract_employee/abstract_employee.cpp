#include <iostream>
using namespace std;

// Task 1
class Employee
{
public:
    Employee() = default;

    Employee(char* name, char* surname, int age)
    {
        this->name = name;
        this->surname = surname;
        this->age = age;
    }

    ~Employee()
    {
        delete[] this->name;
        delete[] this->surname;
    }

    void virtual print();

private:
    char* name = new char[15] {};
    char* surname = new char[25]{};
    int age{};
};

class President :Employee
{
public:
    President() = default;

    President(char* name, char* surname, int age)
    {
        this->name = name;
        this->surname = surname;
        this->age = age;
    }

    ~President()
    {
        delete[] this->name;
        delete[] this->surname;
    }

    void print() override
    {
        cout << "I am President" << endl;

    }

private:
    char* name = new char[15]{};
    char* surname = new char[25]{};
    int age{};
};

class Manager :Employee
{
public:
    Manager() = default;

    Manager(char* name, char* surname, int age)
    {
        this->name = name;
        this->surname = surname;
        this->age = age;
    }

    ~Manager()
    {
        delete[] this->name;
        delete[] this->surname;
    }

    void print() override
    {
        cout << "I am Manager" << endl;

    }

private:
    char* name = new char[15]{};
    char* surname = new char[25]{};
    int age{};
};

class Worker :Employee
{
public:
    Worker() = default;

    Worker(char* name, char* surname, int age)
    {
        this->name = name;
        this->surname = surname;
        this->age = age;
    }

    ~Worker()
    {
        delete[] this->name;
        delete[] this->surname;
    }

    void print() override
    {
        cout << "I am Worker" << endl;

    }

private:
    char* name = new char[15]{};
    char* surname = new char[25]{};
    int age{};
};

// Task 2

class Figure
{
public:
    Figure() = default;
    Figure(int measure)
    {
        this->measure = measure;
    }

    ~Figure();

    float virtual area();

private:
    int measure{};
};

class Rectangle :Figure
{
public:
    Rectangle() = default;
    Rectangle(int length, int width)
    {
        this->length = length;
        this->width = width;
    }

    ~Rectangle();

    float area() override
    {
        int S{};

        S = this->length * this->width;

        return S;
    }

private:
    int length{};
    int width{};
};

class Circle :Figure
{
public:
    Circle() = default;
    Circle(int radius)
    {
        this->radius = radius;
    }

    ~Circle();

    float area() override
    {
        float S{};

        S = (this->radius * this->radius) * 3.14;

        return S;
    }

private:
    int radius{};
};

class Triangle :Figure
{
public:
    Triangle() = default;
    Triangle(int katet1, int katet2)
    {
        this->katet1 = katet1;
        this->katet2 = katet2;
    }

    ~Triangle();

    float area() override
    {
        float S{};

        S = (this->katet1 * this->katet2) / 2;

        return S;
    }

private:
    int katet1{};
    int katet2{};
};

class Trapezoid :Figure
{
public:
    Trapezoid() = default;
    Trapezoid(int a, int b, int h)
    {
        this->a = a;
        this->b = b;
        this->h = h;
    }

    ~Trapezoid();

    float area() override
    {
        float S{};

        S = (a + b) * (h / 2);

        return S;
    }

private:
    int a{};
    int b{};
    int h{};
};

int main()
{
    return 0;
}
