#include <iostream>
using namespace std;

//Declaration
template <typename T>
T* copy(T*&, T*&);
int* reverse(int*&);


int main()
{
	int length{};

	cout << "Enter length of array: ";
	cin >> length;

	int* arr1 = new int[5]{ 1, 2, 3, 4, 5 };
	int* arr2 = new int[length] {};
}

template <typename T>
T* copy(T*& arr, T*& arr2)
{
	int length = sizeof(arr2);
	for (size_t i = 0; i < length; i++)
	{
		*(arr2 + i) = *(arr + i);
	}
}

int* reverse(int*& arr)
{
	int len = sizeof(arr);
	int* tmp_arr = new int[len] {};

	for (size_t i = 0; i < len; i++)
	{
		for (size_t j = len; j > 0; j--)
		{
			*(tmp_arr + i) = *(arr + j);
		}
	}

	delete[] arr;

	for (size_t i = 0; i < len; i++)
	{
		*(arr + i) = *(tmp_arr + i);
	}
}


int* copy_reverse(int* arr, int* arr2)
{
	int len = sizeof(arr);

	for (size_t i = 0; i < len; i++)
	{
		for (size_t j = len; j > 0; j--)
		{
			*(arr2 + i) = *(arr + j);
		}
	}
}


