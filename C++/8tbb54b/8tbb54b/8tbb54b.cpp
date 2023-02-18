#include <iostream>
using namespace std;

char* space(char*& str)
{
	char* tmp_arr = new char[strlen(str)]{};

	for (size_t i = 0; i < strlen(str); i++)
	{
		if (*(str + i) = '\t')
		{
			*(tmp_arr + i) = *(str + i) - 23;
		}
		else
		{
			*(tmp_arr + i) = *(str + i);
		}
	}

	delete[] str;

	for (size_t i = 0; i < strlen(tmp_arr); i++)
	{
		*(str + i) = *(tmp_arr + i);
	}

	return tmp_arr;
}

void count(char* str)
{
	int count_letter = 0;
	int count_num = 0;
	int count_other = 0;
	for (size_t i = 0; i < strlen(str); i++)
	{
		if (*(str + i) >= 65 && *(str + i) <= 90)
		{
			count_letter++;
		}
		else if (*(str + i) >= 97 && *(str + i) <= 122)
		{
			count_letter++;
		}
		else if (*(str + i) >= 48 && *(str + i) <= 57)
		{
			count_num++;
		}
		else
		{
			count_other++;
		}
	}

	cout << count_letter << ' ' << count_num << ' ' << count_other;
}

void count_word(char* str)
{
	int count = 1;

	for (size_t i = 0; i < strlen(str); i++)
	{
		if (*(str + i) = ' ')
		{
			count++;
		}
	}


	cout << count;
}

int chartoint(char* arr, const int len)
{
	int temp = 48;
	int num_res = 0;
	int multy = 10;

	for (size_t i = 0; i < len - 1; i++)
	{
		num_res += *(arr + i) - temp;
		num_res *= multy;
	}

	num_res /= 10;

	return num_res;
}

void palidrom(char* str)
{
	int len = strlen(str);
	int num_str = chartoint(str, len);
	int count = 0;

	if (len % 2 == 0)
	{
		for (size_t i = 0, j = len; i < len / 2, j > len / 2; i++, j--)
		{
			if (*(str + i) = *(str + j))
			{
				count++;
			}
		}
	}

	for (size_t i = 0; i < len; i++)
	{
		cout << *(str + i) << ' ';
	}

	cout << endl;

	if (count = len / 2)
	{
		cout << "Paledrom";
	}
	else
	{
		cout << "Not palidrom";
	}

}

int main()
{
	char* str = new char[5]{};
	char* num = new char[7]{"123321"};

	palidrom(num);

	return 0;
}
