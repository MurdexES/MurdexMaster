#include <iostream>
#include <time.h>
using namespace std;

//Func
template <typename T>
void new_create(T* &arr, int &length, T type)
{
	int len = 0;
	cout << "Enter new length: ";
	cin >> len;
	
	T* temp_arr = new T[len] {};

	for (size_t i = 0; i < length; i++)
	{
		*(temp_arr + i) = *(arr + i);
	}

	for (size_t i = length; i < len; i++)
	{
		*(temp_arr + i) = rand() % 10;
	}

	delete[] arr;
	arr = temp_arr;

}

template <typename T>
void delete_type(T*& arr, int length, T type)
{
	bool type_checker {};
	cout << "Enter 1 if you want delete even numbers and 0 if odd ";
	cin >> type_checker;

	T* arr_deleted = new T[length]{};

	for (size_t i = 0; i < length; i++)
	{
		*(arr_deleted + i) = *(arr + i);
	}
	delete[] arr;

	for (size_t i = 0; i < length; i++)
	{
		if (type_checker == 0)
		{
			if (*(arr_deleted + i) % 2 != 0)
			{
				delete (arr_deleted + i);
			}
		}
		else if (type_checker == 1)
		{
			if (*(arr_deleted + i) % 2 == 0)
			{
				delete (arr_deleted + i);
			}
		}
	}

}

template <typename T>
void delete_zero(T*& arr, int length, T type)
{
	T* arr_zero = new T[length]{};

	for (size_t i = 0; i < length; i++)
	{
		*(arr_zero + i) = *(arr + i);
	}
	delete[] arr;

	for (size_t i = 0; i < length; i++)
	{
		if (*(arr_zero + i) == 0)
		{
			delete (arr_zero + i);
		}
	}

}

template <typename T>
void print_massive(T*& arr, int length)
{
	for (size_t i = 0; i < length; i++)
	{
		cout << *(arr + i) << " ";
	}

	cout << endl;
}

int main()
{
	srand(time(0));
	int length{};

	cout << "Enter length: ";
	cin >> length;

	int* arr = new int[length] {};

	for (size_t i = 0; i < length; i++)
	{
		*(arr + i) = rand() % 10;
	}

	new_create(arr, length, 6);

	print_massive(arr, sizeof(arr));


	int length2{};

	cout << "Enter length: ";
	cin >> length2;

	int* arr2 = new int[length2] {};

	for (size_t i = 0; i < length2; i++)
	{
		*(arr2 + i) = rand() % 10;
	}

	delete_type(arr2, length2, 666);

	return 0;
}
