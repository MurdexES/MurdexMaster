#include <iostream>
using namespace std;

void factorial(int arr[], const int len)
{
	int fact = 1;

	for (size_t i = 0; i < len; i++)
	{
		for (size_t j = 1; j <= arr[i]; j++)
		{
			fact *= j;
		}
		cout << fact << endl;
		fact = 1;
	}
}

void bubble_sort(int arr[], const int len)
{	
	int temp = 0;
	for (size_t i = 0; i < len - 1; i++)
	{
		for (size_t j = 0; j < len - i - 1; j++)
		{
			if (arr[j] > arr[j + 1])
			{
				temp = arr[j];
				arr[j] = arr[j + 1];
				arr[j + 1] = temp;
			}
		}
	}

	for (size_t i = 0; i < len; i++)
	{
		cout << arr[i] << " ";
	}
	cout << endl;
}

void insertion_sort(int arr[], const int len)
{
	for (int i = 1; i < len; i++)
	{
		int temp = arr[i];
		int j = i - 1;
		while (j >= 0 && temp <= arr[j])
		{
			arr[j + 1] = arr[j];
			j = j - 1;
		}
		arr[j + 1] = temp;
	}

	for (size_t i = 0; i < len; i++)
	{
		cout << arr[i] << " ";
	}
	cout << endl;
}

void sum_factor(int arr[], const int len)
{
	int sum = 0;

	for (size_t i = 0; i < len; i++)
	{
		sum += arr[i];
	}

	cout << sum << endl;

	for (size_t i = 0; i < len; i++)
	{
		if (sum % arr[i] == 0)
		{
			cout << arr[i] << " ";
			continue;
		}
		else
		{
			cout << "-1";
		}
	}
}

void same_elements_count(int arr1[], int arr2[], const int len)
{
	int count = 0;

	for (size_t i = 0; i < len; i++)
	{
		for (size_t j = 0; j < len; j++)
		{
			if (arr1[i] == arr2[j])
			{
				count++;
			}
		}
	}
}

void arr_with_same(int arr1, int arr2, const int len)
{
	const int len = same_elements_count(arr1, arr2, len);
}

int main()
{
	int arr[5] = { 1, 2, 3, 4, 5 };
	int arr2[5] = { 8, 2, 3, 4, 9 };

	factorial(arr, 5);
	bubble_sort(arr, 5);
	insertion_sort(arr, 5);
	sum_factor(arr, 5);


	return 0;
}