#include <iostream>
#include <ctime>
#include "Header.h"
using namespace std;


void add(Do*& list)
{
	int num{};

	cout << "Enter number of actions you want to add: ";
	cin >> num;

	Do* tmp_list = new Do[sizeof(list) + num]{};

	for (size_t i = 0; i < sizeof(list); i++)
	{
		tmp_list[i] = list[i];
	}

	for (size_t i = sizeof(list); i < sizeof(tmp_list); i++)
	{
		tmp_list[i];
	}

	delete[] list;

	list = tmp_list;
}

void delete_do(Do*& list)
{
	Do* tmp_list = new Do[sizeof(list)]{};

	int index{};

	cout << "Enter the index of Do you want to delete: ";
	cin >> index;

	for (size_t i = 0; i < index - 1; i++)
	{
		*(tmp_list + i) = *(list + i);
	}

	for (size_t i = index; i < sizeof(list); i++)
	{
		*(tmp_list + i) = *(list + (i + 1));
	}

	delete[] list;
	list = tmp_list;
}

void edit(Do*& list)
{
	int choice{};
	int index{};

	cout << "Enter index of Do you want to edit: ";
	cin >> index;

	cout << "Enter what you want to change: " << endl
		<< "1. Name" << endl
		<< "2. Description" << endl
		<< "3. Priority" << endl
		<< "4. Date" << endl;

	cin >> choice;

	switch (choice)
	{
	case 1:
		cout << "Enter new name of Do: ";
		cin.getline(list[index - 1].name, 15);
		break;
	case 2:
		cout << "Enter new description of Do: ";
		cin.getline(list[index - 1].description, 50);
		break;
	case 3:
		cout << "Enter new level of priority: ";
		cin >> list[index - 1].priority;
		break;
	case 4:
		cout << "Enter new date of Do: ";
		cin >> list[index - 1].date[0];
		cin >> list[index - 1].date[1];
		cin >> list[index - 1].date[2];
		break;
	}
}

void search(Do* list)
{
	char* name_by = new char[15]{};
	char* descp_by = new char[50]{};
	int priority_by{};
	int* date_by = new int[3]{};

	int choice{};

	cout << "Enter your choice: " << endl
		<< "1 - By Name" << endl
		<< "2 - By Priority" << endl
		<< "3 - By Description" << endl
		<< "4 - By Date" << endl;
	cin >> choice;

	switch (choice)
	{
	case 1:
		cout << "Enter name by which you want to search: ";
		cin.getline(name_by, 15);
		break;
	case 2:
		cout << "Enter level of priority: ";
		cin >> priority_by;
		break;
	case 3:
		cout << "Enter description for search: " << endl;
		cin.getline(descp_by, 50);
		break;
	case 4:
		cout << "Enter date for search: " << endl;
		cin >> date_by[0];
		cin >> date_by[1];
		cin >> date_by[2];
		break;
	default:
		cout << "ERROR" << endl;
		break;
	}

	int count{};
	Do* tmp_list = new Do[sizeof(list)]{};

	switch (choice)
	{
	case 1:
		for (size_t i = 0; i < sizeof(list); i++)
		{
			for (size_t j = 0; j < 15; j++)
			{
				if (name_by[j] = list[i].name[j])
				{
					count++;
				}
			}

			if (sizeof(name_by) == count)
			{
				tmp_list[i] = list[i];
			}
		}
		break;
	case 2:
		for (size_t i = 0; i < sizeof(list); i++)
		{
			if (priority_by == list[i].priority)
			{
				tmp_list[i] = list[i];
			}
		}
		break;
	case 3:
		for (size_t i = 0; i < sizeof(list); i++)
		{
			for (size_t j = 0; j < 50; j++)
			{
				if (descp_by[j] = list[i].description[j])
				{
					count++;
				}
			}

			if (sizeof(descp_by) == count)
			{
				tmp_list[i] = list[i];
			}
		}
		break;
	case 4:
		for (size_t i = 0; i < sizeof(list); i++)
		{
			if (date_by[0] == list[i].date[0] && date_by[1] == list[i].date[1] && date_by[2] == list[i].date[2])
			{
				tmp_list[i] = list[i];
			}
		}
		break;
	default:
		cout << "ERROR" << endl;
		break;
	}

	cout << "This is all results: ";

	for (size_t i = 0; i < sizeof(tmp_list); i++)
	{
		tmp_list[i].print();
	}

	delete[] tmp_list;
}

void print_date(Do* list)
{
	int opt{};

	cout << "Enter your choice: " << endl
		<< "1 - By Day" << endl
		<< "2 - By Month" << endl
		<< "3 - By Year" << endl;
	cin >> opt;

	time_t now = time(0);
	tm* ltm = localtime(&now);

	switch (opt)
	{
	case 1:
		for (size_t i = 0; i < sizeof(list); i++)
		{
			if (list[i].dd == ltm->tm_mday && list[i].mm == 1 + ltm->tm_mon && list[i].yy == 1900 + ltm->tm_year)
			{
				list[i].print();
			}
		}
		break;
	case 2:
		for (size_t i = 0; i < sizeof(list); i++)
		{
			if (list[i].mm == 1 + ltm->tm_mon && list[i].yy == 1900 + ltm->tm_year)
			{
				list[i].print();
			}
		}
		break;
	case 3:
		for (size_t i = 0; i < sizeof(list); i++)
		{
			if (list[i].yy == 1900 + ltm->tm_year)
			{
				list[i].print();
			}
		}
		break;
	default:
		cout << "ERROR" << endl;
		break;
	}

	opt = 0;

	cout << "Do you want to sort ? (Yes - 1; No - 0)";
	cin >> opt;

	if (opt == 1)
		sort_by(list);
}

void sort_by(Do* list)
{
	int opt{};
	Do temp{};

	cout << "What you want sort by: 1 - Priority; 2 - Date: " << endl;
	cin >> opt;

	switch (opt)
	{
	case 1:
		for (int i = 0; i < sizeof(list); ++i) 
		{
			for (int j = 0; i < sizeof(list) - i; ++j) 
			{
				if (list[i].priority > list[i + 1].priority) 
				{
					temp = list[i];
					list[i] = list[i + 1];
					list[i + 1] = temp;
				}
			}
		}
		break;
	case 2:
		for (int i = 0; i < sizeof(list); ++i)
		{
			for (int j = 0; i < sizeof(list) - i; ++j)
			{
				if (list[i].dd > list[i + 1].dd)
				{
					temp = list[i];
					list[i] = list[i + 1];
					list[i + 1] = temp;
				}
			}
		}

		for (int i = 0; i < sizeof(list); ++i)
		{
			for (int j = 0; i < sizeof(list) - i; ++j)
			{
				if (list[i].mm > list[i + 1].mm)
				{
					temp = list[i];
					list[i] = list[i + 1];
					list[i + 1] = temp;
				}
			}
		}

		for (int i = 0; i < sizeof(list); ++i)
		{
			for (int j = 0; i < sizeof(list) - i; ++j)
			{
				if (list[i].yy > list[i + 1].yy)
				{
					temp = list[i];
					list[i] = list[i + 1];
					list[i + 1] = temp;
				}
			}
		}
		break;
	default:
		cout << "ERROR" << endl;
		break;
	}

	for (size_t i = 0; i < sizeof(list); i++)
	{
		list[i].print();
	}
}
 