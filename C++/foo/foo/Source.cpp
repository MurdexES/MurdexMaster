#include <iostream>
using namespace std;

int power(int base, int pow)
{
	int temp = base;
	for (size_t i = 0; i < pow - 1; i++)
	{
		base *= temp;
	}

	return base;
}

int sum_range(int start, int end)
{
	int sum = 0;

	for (size_t i = start; i < end; i++)
	{
		sum += i;
	}

	return sum;
}

void number_range(int start, int end)
{
	int sum = 0;

	for (size_t i = start; i < end; ++i)
	{
		for (size_t j = i; j > 0; j--)
		{
			if (i % j == 0)
			{
				sum += j;
			}
		}

		if (sum == i)
		{
			cout << sum << endl;
		}
	}
	
}

void happy_num(int number)
{
	int temp1 = 0;
	int temp2 = 0;
	
	temp1 = number / 1000;
	temp2 = number - ((number /= 1000) * 1000);

	if (temp1 == temp2)
	{
		cout << "Happy number";
	}
	else
	{
		cout << "It is not happy number";
	}
}

int main()
{
	int number = 0;
	int pow = 0;
	int happy_number = 0;
	int start = 0;
	int end = 0;

	cout << "Enter number and power: ";
	cin >> number;
	cin >> pow;

	cout << power(number, pow) << endl;

	cout << "Enter start and end: ";
	cin >> start;
	cin >> end;

	cout << sum_range(start, end) << endl;
	number_range(start, end);

	cout << "Enter number to check if it is happy: ";
	cin >> happy_number;

	cout << endl;
	happy_num(happy_number);

	return 0;
}