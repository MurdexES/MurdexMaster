#include <iostream>
using namespace std;

int pl(int num1, int num2)
{
    return num1 + num2;
}

int mi(int num1, int num2)
{
    return num1 - num2;
}

int product(int num1, int num2)
{
    return num1 * num2;
}

int division(int num1, int num2)
{
    return num1 / num2;
}

int* summ(int* arr1, int* arr2, int*& arr3, int len)
{
    for (size_t i = 0; i < len; i++)
    {
        *(arr3 + i) = *(arr1 + i) + *(arr2 + i);
    }

    return arr3;
}

int main()
{
    int* arr1 = new int[5]{ 1, 2, 3, 4, 5 };
    int* arr2 = new int[5]{ 1, 2, 3, 4, 5 };
    int* arr3 = new int[5]{};

    summ(arr1, arr2, arr3, 5);

    int(*foo_funcs[])(int, int) = { pl, mi, product, division };
    int k = 0;
    int num1{};
    int num2{};

    cout << "Enter number 1 , number 2 and number of operator: ";
    cin >> num1;
    cin >> num2;
    cin >> k;

    cout << foo_funcs[k - 1](num1, num2);;

    return 0;
}
