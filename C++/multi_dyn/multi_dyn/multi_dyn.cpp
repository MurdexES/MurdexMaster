#include <iostream>
#include <time.h>
using namespace std;

void delete_zeros(int**& arr)
{
	int** tmp_arr = new int* [sizeof(arr)]{};
	int count = 0;

	for (size_t i = 0; i < sizeof(arr); i++)
	{
		for (size_t j = 0; j < sizeof(arr); j++)
		{
			if (*(*(arr + i) + j) == 0)
			{
				count++;
			}
		}

		if (count = 0)
		{
			*(tmp_arr + i) = *(arr + i);
		}
	}

	delete[] arr;

	for (size_t i = 0; i < sizeof(tmp_arr); i++)
	{
		*(arr + i) = *(tmp_arr + i);
	}
}

void sum(int** arr1, int** arr2, int** arr3)
{
	for (size_t i = 0; i < sizeof(arr1); i++)
	{
		for (size_t j = 0; j < sizeof(*arr1); j++)
		{
			*(*(arr3 + i) + j) = *(*(arr1 + i) + j) + *(*(arr2 + i) + j);
		}
	}
}

void product(int** arr1, int** arr2, int** arr3)
{
	for (size_t i = 0; i < sizeof(arr1); i++)
	{
		for (size_t j = 0; j < sizeof(*arr1); j++)
		{
			*(*(arr3 + i) + j) = *(*(arr1 + i) + j) * *(*(arr2 + i) + j);
		}
	}
}


int main()
{
	srand(time(0));

	int cols = 0;
	int rows = 2;

	cout << "Enter number of cols : ";
	cin >> cols;

	int** main = new int* [rows]{};
	int** main2 = new int* [rows] {};
	int** main3 = new int* [rows] {};
	
	*main = new int[cols]{};
	*(main + 1) = new int[cols]{};

	*main2 = new int[cols] {};
	*(main2 + 1) = new int[cols] {};

	*main3 = new int[cols] {};
	*(main3 + 1) = new int[cols] {};


	for (size_t i = 0; i < cols; i++)
	{
		**(main + i) = rand() % 10;
		*(*(main + 1) + i) = rand() % 10;

		**(main2 + i) = rand() % 10;
		*(*(main2 + 1) + i) = rand() % 10;
	}
	


	return 0;
}