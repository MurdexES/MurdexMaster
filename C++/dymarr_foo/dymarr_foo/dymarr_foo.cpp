#include <iostream>
using namespace std;

void delete_index(int*& arr, int len)
{
	size_t index{};
	int* tmp_arr = new int[len - 1];
	
	cout << "Enter index of element you want to delete: ";
	cin >> index;

	for (size_t i = 0; i < len; i++)
	{
		if (index != i) {
			*(tmp_arr + i) = *(arr + i);
		}
	}
}

void delete_value(int*& arr, int len)
{
	int value = 0;
	int* tmp_arr = new int[len - 1];

	cout << "Enter value: ";
	cin >> value;

	for (size_t i = 0; i < len; i++)
	{
		if (value != *(arr + i))
		{
			*(tmp_arr + i) = *(arr + i);
		}
	}
}

void delete_range(int*& arr, int len)
{
	int start = 0;
	int end = 0;
	int n = 0;
	int* tmp_arr = new int[len - 1];

	cout << "Enter start and end: ";
	cin >> start;
	cin >> end;

	for (size_t i = 0; i < len; i++)
	{
		for (size_t j = start; j < end; j++)
		{
			if (i < start || i > end)
			{
				*(tmp_arr + n) = *(arr + i);
			}
		}
		n++;
	}
}

int main()
{
	int len{};

	cout << "Enter length of array: ";
	cin >> len;

	int* arr = new int[len] {};

	for (size_t i = 0; i < len; i++)
	{
		cout << "Enter element of array: ";
		cin >> arr[i];
		cout << endl;
	}

	return 0;
}
