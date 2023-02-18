#include "Header.h"
#include <iostream>
#include <string>
using namespace std;

epl::epl() = default;

epl::epl(char* name, char* surname, uint16_t age)
{
	this->name = name;
	this->surname = surname;
	this->age = age;
}

void epl::print()
{
	system("cls");

	cout << "Name: " << this->name << endl
		<< "Surname: " << this->surname << endl
		<< "Age: " << this->age << endl;

}

epl* create_epl()
{
	system("cls");

	epl* tmp = new epl();

	cout << "Enter name of employee: ";
	cin.getline(tmp->name, 15);

	cout << "Enter surname of employee: ";
	cin.getline(tmp->surname, 25);

	cout << "Ente age of employee: ";
	cin >> tmp->age;

	return tmp;
}

void List::add()
{
	system("cls");

	cout << "There are " << this->free_amount << " free vacancies." << endl;
	this->epls[this->amount - this->free_amount] = *create_epl();
	free_amount--;
}

void List::del()
{
	system("cls");

	uint8_t index{};
	epl* tmp = new epl[this->amount]{};

	cout << "Enter index of employee you want to delete: ";
	cin >> index;

	for (size_t i = 0; i < index; i++)
	{
		tmp[i] = epls[i];
	}

	for (size_t i = index; i < amount; i++)
	{
		tmp[i] = epls[i + 1];
	}

	delete[] epls;

	epls = tmp;

	free_amount++;
}
void List::edit()
{
	system("cls");

	int selection{};
	int index{};
	bool key = true;

	while (key)
	{
		cout << "Enter your choice for editing and index of employee you want to edit: " << endl
			<< "1.Edit Name" << endl
			<< "2.Edit Surname" << endl
			<< "3.Edit Age" << endl;

		cin >> selection;
		cin >> index;

		switch (selection)
		{
		case 1:
			system("cls");

			cout << "Enter new name: ";
			cin >> this->epls[index].name;

			break;
		case 2:
			system("cls");

			cout << "Enter new surname: ";
			cin >> this->epls[index].surname;

			break;
		case 3:
			system("cls");

			cout << "Enter new age: ";
			cin >> this->epls[index].age;

			break;
		default:
			cout << "ERROR";
			break;
		}

		cout << "Do you want to continue editing or leave this menu (1 - continue, 0 - leave): ";
		cin >> key;
	}
}

void List::search()
{
	system("cls");

	char* search_surname = new char[25]{};
	int count{};
	epl tmp{};

	cout << "Enter surname for searching employee: " << endl;
	cin.getline(search_surname, 25);

	cout << endl << "This all matched employees: " << endl;

	for (size_t j = 0; j < amount; j++)
	{
		for (size_t i = 0; i < 25; i++)
		{
			if (search_surname[i] = epls[j].surname[i])
			{
				count++;
			}
		}

		if (count = sizeof(search_surname))
		{
			tmp = epls[j];
		}

		tmp.print();
		cout << endl;
	}
}

void List::print_all()
{
	system("cls");

	int age_prt{};
	char first_letter{};
	bool select{};

	cout << "Enter first letter of surname of employees you want to print or age of employees you want to ptint (0 - first letter, 1 - age): ";
	
	if (select)
	{
		cout << "Enter first letter: ";
		cin >> first_letter;

		for (size_t i = 0; i < amount; i++)
		{
			if (epls[i].surname[0] = first_letter)
			{
				epls[i].print();
			}
		}
	}

	else if (select = 0)
	{
		cout << "Enter age: ";
		cin >> age_prt;

		for (size_t i = 0; i < amount; i++)
		{
			if (epls[i].age = age_prt)
			{
				epls[i].print();
			}
		}
	}
}

void save_as(List list)
{
	FILE* file;

	fopen_s(&file, "data.cpp", "w");

	char* txt_epl_name = new char[15]{};
	char* txt_epl_surname = new char[25]{};

	epl* tmp_epls = new epl[list.amount]{};

	tmp_epls = list.epls;

	if (file)
	{
		for (size_t i = 0; i < list.amount; i++)
		{
			string tmp = to_string(tmp_epls[i].age);
			char const* num_char = tmp.c_str();

			fputs(tmp_epls[i].name, file);
			fputs(tmp_epls[i].surname, file);
			fputs(num_char, file);
		}
	}

	if (file)
	{
		fclose(file);
	}
}

void open_as()
{
	FILE* file;

	char* file_name = new char[100]{};

	cout << "Enter path to file: " << endl;
	cin.getline(file_name, 100);

	fopen_s(&file, file_name, "r");

	char* file_data = new char[500]{};
}
