#include <iostream>
#include "Header.h"
using namespace std;


int log_in(char* login, char* password)
{
	char* admin = new char[10]{ "admin" };
	char* cashier = new char[10]{ "cashier" };

	int count_log = 0;
	int count_pass = 0;

	for (size_t i = 0; i < strlen(login); i++)
	{
		if (*(login + i) == *(admin + i))
		{
			count_log++;
		}
		else if (*(login + i) == *(cashier + i))
		{
			count_log++;
		}
	}

	for (size_t i = 0; i < strlen(password); i++)
	{
		if (*(password + i) == *(admin + i))
		{
			count_pass++;
		}
		else if (*(password + i) == *(cashier + i))
		{
			count_pass++;
		}
	}

	if (count_log == strlen(admin) && count_pass == strlen(admin))
	{
		return 0;
	}

	else if (count_log == strlen(cashier) && count_pass == strlen(cashier))
	{
		return 1;
	}

	else
	{
		cout << "Error";
		return 2;
	}
}


void append(char**& names, float*& prices, int*& number)
{
	char** tmp_name = new char*[sizeof(names) + 1]{};
	float* tmp_price = new float[sizeof(names) + 1]{};
	int* tmp_number = new int[sizeof(names) + 1]{};
	
	char* element = new char[15]{};
	float price {};
	int num{};

	cout << "Enter name of product you want to append, its price and number: ";
	cin >> element;
	cin >> price;
	cin >> num;

	for (size_t i = 0; i < sizeof(names); i++)
	{
		*(tmp_name + i) = *(names + i);
	}

	for (size_t i = 0; i < sizeof(names); i++)
	{
		*(tmp_price + i) = *(prices + i);
	}

	for (size_t i = 0; i < sizeof(names); i++)
	{
		*(tmp_number + i) = *(number + i);
	}

	delete[] names;
	delete[] prices;
	delete[] number;

	names = new char* [sizeof(tmp_name)]{};
	prices = new float[sizeof(tmp_name)]{};
	number = new int[sizeof(tmp_name)]{};

	*(tmp_name + (sizeof(tmp_name) - 1)) = element;
	*(tmp_price + (sizeof(tmp_price) - 1)) = price;
	*(tmp_number + (sizeof(tmp_number) - 1)) = num;

	for (size_t i = 0; i < sizeof(tmp_name); i++)
	{
		*(names + i) = *(tmp_name + i);
	}

	for (size_t i = 0; i < sizeof(tmp_name); i++)
	{
		*(prices + i) = *(tmp_price + i);
	}

	for (size_t i = 0; i < sizeof(tmp_name); i++)
	{
		*(number + i) = *(tmp_number + i);
	}

	cout << endl << "Finished" << endl;
}


void delete_index(char**& names, float*& prices, int*& number)
{
	char* tmp_name = new char[sizeof(names) - 1]{};
	float* tmp_price = new float[sizeof(names) - 1]{};
	int* tmp_number = new int[sizeof(names) - 1]{};
	char* element = new char[15]{};
	int index{};

	cout << "Enter element you want to delete and position in order: ";
	cin >> element;
	cin >> index;

	for (size_t i = 0; i < index; i++)
	{
		*(tmp_name + i) = *(*(names + i) + i);
	}

	for (size_t i = 0; i < index; i++)
	{
		*(tmp_price + i) = *(prices + i);
	}

	for (size_t i = 0; i < index; i++)
	{
		*(tmp_number + i) = *(number + i);
	}



	for (size_t i = index; i < sizeof(names); i++)
	{
		*(tmp_name + i) = *(*(names + (i + 1)) + i);
	}

	for (size_t i = index; i < sizeof(names); i++)
	{
		*(tmp_price + i) = *(prices + (i + 1));
	}

	for (size_t i = index; i < sizeof(names); i++)
	{
		*(tmp_number + i) = *(number + (i + 1));
	}

	delete[] names;
	delete[] prices;
	delete[] number;

	names = new char* [sizeof(tmp_name)]{};
	prices = new float[sizeof(tmp_name)]{};
	number = new int[sizeof(tmp_name)]{};

	for (size_t i = 0; i < sizeof(tmp_name); i++)
	{
		*(*(names + i) + i) = *(tmp_name + i);
	}

	for (size_t i = 0; i < sizeof(tmp_name); i++)
	{
		*(prices + i) = *(tmp_price + i);
	}

	for (size_t i = 0; i < sizeof(tmp_name); i++)
	{
		*(number + i) = *(tmp_number + i);
	}

	cout << endl << "Finished" << endl;
}

void edit(float*& prices, int*& number)
{	
	float new_price{};
	int new_number{};
	int index{};
	int check = 0;

	cout << "What you want to edit: " << endl
		<< "1 - price" << endl
		<< "2 - number" << endl;
	cin >> check;


	if (check == 1)
	{
		cout << "Enter position of element you want to edit and its new price: ";
		cin >> index;
		cin >> new_price;

		*(prices + index) = new_price;
	}

	else if (check == 2)
	{
		cout << "Enter position of element you want to edit and its new number: ";
		cin >> index;
		cin >> new_number;

		*(number + index) = new_number;
	}


	cout << endl << "Finished" << endl;
}
