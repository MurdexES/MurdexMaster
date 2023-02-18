#pragma once
#include <iostream>
#include <string>
using namespace std;

struct epl
{
	char* name = new char[15] {};
	char* surname = new char[25]{};
	uint16_t age{};

	epl(); // Default
	epl(char*, char*, uint16_t); // with parameters

	void print();
};

epl* create_epl();

struct List
{
	uint16_t amount{10};
	uint16_t free_amount{10};
	epl* epls = new epl[amount]{};

	void add();
	void del();
	void edit();
	void search();
	void print_all();
};

void save_as(List );
void open_as();



