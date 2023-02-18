#pragma once
#include <iostream>
#include <string>
using namespace std;

enum Difficulty{Easy = 1, Medium, Hard};

struct Date
{
	int dd{};
	int mm{};
	int yy{};

	int* date = new int[3]{ dd, mm, yy };

    void input()
    {
        cout << "Enter day, month, year of deadline respectively: ";
        
        cin >> this->dd;
        cin >> this->mm;
        cin >> this->yy;
    }

    void print()
    {
        cout << "Date of deadline: " << endl
            << "Day - " << this->dd << endl
            << "Month - " << this->mm << endl
            << "Year - " << this->yy << endl;
    }
};

class Do
{
public:
    Do() = default;

	void input()
	{
        int selec{};

		cout << "Enter name: ";
        getline(cin, this->name);

		cout << "Enter description: ";
        getline(cin, this->description);

		cin.ignore();

        switch (selec)
        {
        case Easy:
            this->priority = Difficulty :: Easy;
            cout << "Easy";
            break;
        case Medium:
            this->priority = Difficulty::Medium;
            cout << "Medium";
            break;
        case Hard:
            this->priority = Difficulty::Hard;
            cout << "Hard";
            break;
        default:
            cout << "ERROR";
            break;
        }

        this->deadline->input(); 

        cout << "Enter 1 - if task is urgent and 0 if not: ";
        cin >> this->isUrgent;
	}

	void print()
	{
		cout << "Name: " << name << ' ' << "Description: " << description << ' ' << "Priority: " << priority << ' ' << "Deadline - DD:MM:YY: " << this->deadline->dd << '.' << this->deadline->mm << '.' << this->deadline->dd << "Is urgent: " << this->isUrgent << endl;
	}

	string name{};
	string description{};
	Difficulty priority{};
	Date* deadline = new Date{};
    bool isUrgent{};
};


class Queue
{
public:
    Queue() = default;
    Queue(uint16_t length)
    {
        this->length = length;
    }
    Queue(initializer_list<Do> list)
    {
        this->length = list.size();
        this->arr = new Do[this->length]{};

        int j = 0;
        for (auto i = list.begin(); i < list.end(); ++i, ++j)
        {
            arr[j] = *i;
        }
    }

    uint16_t get_len()
    {
        return  this->length;
    }
    void print_queue()
    {
        for (int i = 0; i < this->length; ++i)
        {
            arr[i].print();
        }
        cout << endl;
    }
    Do pop_back_delete()
    {
        if (this->length >= 1)
        {

            uint16_t new_length = this->length - 1;

            Do result = this->arr[new_length];

            Do* tmp = new Do[new_length];

            for (int i = 0; i < new_length; ++i)
            {
                tmp[i] = this->arr[i];
            }

            delete[]this->arr;

            this->arr = new Do[new_length] {};

            for (int i = 0; i < new_length; ++i)
            {
                this->arr[i] = tmp[i];
            }

            delete[] tmp;
            this->length = new_length;

            return result;
        }
    }

    Do append_add(Do item)
    {
        uint16_t new_length = this->length + 1;

        Do* tmp = new Do[new_length];

        for (int i = 0; i < this->length; ++i)
        {
            tmp[i] = this->arr[i];
        }

        for (int i = 0; i < new_length; i++)
        {
            if (i == new_length - 1)
            {
                tmp[i] = item;
                break;
            }
        }

        delete[]this->arr;

        this->arr = new Do[new_length] {};

        for (int i = 0; i < new_length; ++i)
        {
            this->arr[i] = tmp[i];
        }

        delete[] tmp;
        this->length = new_length;

        return item;
    }

    void edit()
    {
        int choice{};
        int index{};

        cout << "Enter index of task you want to edit: ";
        cin >> index;

        cout << "Enter what you want to change: " << endl
            << "1. Name" << endl
            << "2. Description" << endl
            << "3. Priority" << endl
            << "4. Date" << endl
            << "5. Urgency" << endl;

        cin >> choice;

        switch (choice)
        {
        case 1:
            cout << "Enter new name of Do: ";
            getline(cin, this->arr[index - 1].name);
            break;
        case 2:
            cout << "Enter new description of Do: ";
            getline(cin, this->arr[index - 1].description);
            break;
        case 3:
            int selec{};

            cout << "Enter new level of priority: ";
            
            switch (selec)
            {
            case Easy:
                this->arr[index - 1].priority = Difficulty::Easy;
                cout << "Easy";
                break;
            case Medium:
                this->arr[index - 1].priority = Difficulty::Medium;
                cout << "Medium";
                break;
            case Hard:
                this->arr[index - 1].priority = Difficulty::Hard;
                cout << "Hard";
                break;
            default:
                cout << "ERROR";
                break;
            }

            break;
        case 4:
            this->arr[index - 1].deadline->input();
            break;
        case 5:
            cout << "Enter 1 - if task is urgent and 0 if not: ";
            cin >> this->arr[index - 1].isUrgent;
        default:
            cout << "ERROR";
            break;
        }
    }

    uint16_t length{ 5 };
    Do* arr = new Do[length]{};
};

