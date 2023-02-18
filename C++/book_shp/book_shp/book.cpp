#include <iostream>
#include "book.h"

using namespace std;

void Book::print()
{
	cout << " Name: " << this->name << endl
		<< " Author: " << this->author << endl
		<< " Page number: " << this->number << endl;
}

Book* Book::create_book()
{
	Book* tmp = new Book();

	cout << "Enter name of book: ";
	cin.getline(tmp->name, 30);

	cout << endl;

	cout << "Enter author of book: ";
	cin.getline(tmp->author, 30);

	cout << endl;
	cin.ignore();

	cout << "Enter number of page: ";
	cin >> tmp->number;

	return tmp;
}
