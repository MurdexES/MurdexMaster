#pragma once
#include <iostream>

using namespace std;

struct Book
{
	char* name = new char[30]{};
	char* author = new char[30]{};
	int number{};

	void print();
	Book* create_book();

	Book();
};
