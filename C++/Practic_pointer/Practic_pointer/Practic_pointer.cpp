#include <iostream>
using namespace std;

// Func

void num_max(int num1, int num2)
{
    int* prt_num1 = &num1;
    int* prt_num2 = &num2;

    if (*prt_num1 > *prt_num2)
    {
        cout << *prt_num1;
    }

    else if (*prt_num1 < *prt_num2)
    {
        cout << *prt_num2;
    }
}

void sign_num(int number)
{
    int* prt_number = &number;

    if (*prt_number >= 0)
    {
        cout << "+";
    }

    else if (*prt_number < 0)
    {
        cout << "-";
    }
}

void replace_pointer(int num1, int num2)
{
    int* prt_num1 = &num1;
    int* prt_num2 = &num2;
    int temp = 0;

    temp = *prt_num1;
    *prt_num1 = *prt_num2;
    *prt_num2 = temp;

    cout << *prt_num1 << endl << *prt_num2;
}

int calculator(int num1, char sign, int num2)
{
    int* prt_num1 = &num1;
    int* prt_num2 = &num2;

    char multy = 42;
    char plus = 43;
    char minus = 45;
    char divison = 47;

    if (sign == plus)
    {
        return *prt_num1 + *prt_num2;
    }
    else if (sign == minus)
    {
        return *prt_num1 - *prt_num2;
    }
    else if (sign == multy)
    {
        return *prt_num1 * *prt_num2;
    }
    else if (sign == divison)
    {
        return *prt_num1 / *prt_num2;
    }
}

void summ_pointer(int arr[], const int len)
{
    int* prt_num = &arr[0];
    int sum = 0;

    for (size_t i = 0; i < len; i++)
    {
        sum += *prt_num + i;
    }

    cout << "This is sum: " << sum;
}

int main()
{
    int num1 = 5;
    int num2 = 9;

    num_max(num1, num2);

    int num_t = 0;

    cout << endl << "Enter number: ";
    cin >> num_t;

    sign_num(num_t);
    cout << endl;
    replace_pointer(num1, num2);

    char sign = 0;
    cout << endl;
    cout << "Enter char sign: ";
    cin >> sign;
    cout << endl << calculator(num1, sign, num2);

    int arr[5] = { 1, 2, 3, 4, 5 };

    cout << endl;
    summ_pointer(arr, 5);

    return 0;
}
