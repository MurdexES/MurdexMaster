#include "shelf.h"
#include "book.h"
#include <iostream>

using namespace std;

void Shelf::showAll()
{
	for (size_t i = 0; i < this->capacity; i++)
	{
		if (this->books[i].number != 0)
		{
			cout << i + 1 << " . " << this->books[i].name << endl;
		}
	}
}

void Shelf::addBook()
{
	system("cls");

	for (size_t i = 0; i < this->capacity; i++)
	{
		if (this->books[i].number != 0)
		{
			this->books[i].create_book();
			this->free_space--;
			break;
		}
	}
}

void Shelf::deleteBook()
{
	system("cls");

	int index{};

	Book* tmp = new Book[this->capacity]{};

	showAll();

	cout << "Enter index of book you want to delete: ";
	cin >> index;

	index -= 1;

	for (size_t i = 0; i < index; i++)
	{
		tmp[i] = this->books[i];
	}

	for (size_t i = index; i < this->capacity; i++)
	{
		tmp[i] = this->books[i + 1];
	}

	delete[] this->books;

	this->books = new Book[sizeof(tmp)]{};

	for (size_t i = 0; i < this->capacity; i++)
	{
		this->books[i] = tmp[i];
	}

	this->free_space++;

	delete[] tmp;
}

void Shelf::changeBook()
{
	system("cls");

	int index{};

	showAll();

	Book tmp{};

	cout << "Enter index of book you want to change: ";
	cin >> index;

	index -= 1;

	tmp.create_book();

	this->books[index] = tmp;
}

void Shelf::updateCapacity()
{
	system("cls");

	uint16_t new_capacity{};

	cout << "Enter new capacity: ";
	cin >> new_capacity;

	if (new_capacity >= this->capacity - this->free_space)
	{
		Book* tmp_books = new Book[new_capacity];
		uint16_t count = 0;

		for (size_t i = 0; i < this->capacity - this->free_space; i++)
		{
			tmp_books[i] = this->books[i];
			count++;
		}

		delete[] this->books;

		this->capacity = new_capacity;

		this->books = new Book[new_capacity];

		for (size_t i = 0; i < count; i++)
		{
			this->books[i] = tmp_books[i];
		}
		this->free_space = this->capacity - count;

		delete[] tmp_books;
	}
	else {
		this->updateCapacity();
	}
}

void Shelf::searchBook()
{
	system("cls");

	char* tmp = new char[30]{};

	cout << "Enter name of book you want to find: ";
	cin.getline(tmp, 30);

	int count{};

	cout << "All results: " << endl;

	for (size_t i = 0; i < this->capacity; i++)
	{
		for (size_t j = 0; j < 30; j++)
		{
			if (tmp[j] = this->books[i].name[j])
			{
				count++;
			}
		}

		if (count == 30)
		{
			this->books[i].print();
		}
	}
}

void Shelf::sortBook()
{
	system("cls");

	Book tmp{};

	for (size_t i = 0; i < this->capacity; i++)
	{
		if (this->books[i].name[0] >= this->books[i + 1].name[0])
		{
			tmp = this->books[i + 1];
			this->books[i + 1] = this->books[i];
			this->books[i] = tmp;
		}
	}
}
