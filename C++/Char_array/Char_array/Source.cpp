#include "decloration.h"
#include <iostream>
using namespace std;

unsigned short getLength(char* data)
{
	unsigned short length = 0;
	int i = 0;

	while (*(data + i) != '\0')
	{
		i++;
		length++;
	}
	return length;
}

void mystrchr(char*& str)
{
	auto len = getLength(str);
	for (size_t i = 0; i < len; i++)
	{
		if (*(str + i) == 's' || *(str + i) == 'S')
		{
			cout << (int *)(str + i);
		}
		else
			cout << 0;
	}
}

void mystrstr(char* sen1, char* sen2)
{
	auto len1 = getLength(sen1);
	auto len2 = getLength(sen2);
	auto len_check = len2;

	char* tmp{};

	for (size_t i = 0; i < len1; i++)
	{
		for (size_t j = 0; j < len2; j++)
		{
			if (*(sen1 + i) == *sen2)
			{
				tmp = sen1 + i;
				while (*(tmp + i) == *(sen2 + i) && len_check != 0)
				{
					--len_check;
				}
			}
		}
	}

	if (len_check == 0)
	{
		cout << (int*)(tmp);
	}
	else
		cout << 0;

}