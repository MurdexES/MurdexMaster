#pragma once
#include "book.h"

struct Shelf
{
	int capacity = 10;
	int free_space = 10;

	Book* books = new Book[capacity]{};

	void showAll();

	void addBook();
	void deleteBook();
	void changeBook();
	void updateCapacity();
	void searchBook();
	void sortBook();
};
