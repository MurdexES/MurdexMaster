#include <iostream>
#include "dec.h"
using namespace std;

void str_count(char* text, char* word)
{
	int count = 0;
	int count1 = 0;
	bool key{};

	for (int i = 0, j = 0; i < strlen(text); i++)
	{
		if (*(word + j) == *(text + i))
		{
			count++;
			j++;
			key = true;
		}

		if (key)
		{
			if (count == strlen(word))
			{
				count1++;
				key = false;
				count = 0;
				j = 0;
			}
		}

	}

	if (!key)
	{
		cout << count1;
	}
}

void str_sen(char* text, char* sen) 
{
	int count = 0;
	int count1 = 0;
	bool key{};

	for (int i = 0, j = 0; i < strlen(text); i++)
	{
		if (*(sen + j) == *(text + i))
		{
			count++;
			j++;
			key = true;
		}

		if (key)
		{
			if (count == strlen(sen))
			{
				count1++;
				key = false;
				count = 0;
				j = 0;
			}
		}

	}

	if (!key)
	{
		cout << count1;
	}
}

void str_punc(char* text)
{
	char dot = '.';
	char comma = ',';

	int count = 0;

	for (size_t i = 0; i < strlen(text); i++)
	{
		if (*(text + i) == dot || *(text + i) == comma)
		{
			count++;
		}
	}

	cout << count;
}

void reverse_str(char*& text)
{
	char* tmp_arr = new char[sizeof(text)]{};

	for (size_t i = strlen(text), j = 0; i > 0; i--, j++)
	{
		*(tmp_arr + j) = *(text + i);
	}

	delete[] text;

	for (size_t i = 0; i < strlen(tmp_arr); i++)
	{
		*(text + i) = *(tmp_arr + i);
	}
}
