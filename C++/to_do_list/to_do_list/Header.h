#pragma once
#include <iostream>
#include <ctime>
using namespace std;

struct Do 
{
	char* name = new char[15]{};
	char* description = new char[50]{};
	int priority{};
	
	int dd{};
	int mm{};
	int yy{};

	int* date = new int[3]{ dd, mm, yy };

	Do() // default
	{
		cout << "Enter name: ";
		cin.getline(name, 15);

		cout << "Enter description: ";
		cin.getline(description, 50);

		cin.ignore();

		cout << "Enter the level of priority (higher number - higher priority): ";
		cin >> priority;

		cout << "Enter day, month and year of action: " << endl
			<< "DD: ";
		cin >> dd;
		cout << "MM: ";
		cin >> mm;
		cout << "YY: ";
		cin >> yy;
	}

	void print()
	{
		cout << "Name: " << name << ' ' << "Description: " << description << ' ' << "Priority: " << priority << ' ' << "Date - DD:MM:YY: " << dd << '.' << mm << '.' << yy << endl;
	}
};

struct Timem
{
	time_t now = time(0);

	tm* ltm = localtime(&now);

	int year = 1900 + ltm->tm_year;
	int month = 1 + ltm->tm_mon;
	int day = ltm->tm_mday;
	int hour = 5 + ltm->tm_hour;
	int minute = 30 + ltm->tm_min;
	int second = ltm->tm_sec;

	void print() 
	{
		cout << "Year:" << 1900 + ltm->tm_year << endl;
		cout << "Month: " << 1 + ltm->tm_mon << endl;
		cout << "Day: " << ltm->tm_mday << endl;
		cout << "Time: " << 5 + ltm->tm_hour << ":";
		cout << 30 + ltm->tm_min << ":";
		cout << ltm->tm_sec << endl;
	}
};

void add(Do*&);
void delete_do(Do*&);
void edit(Do*&);
void search(Do*);
void print_date(Do*);
void sort_by(Do*);
