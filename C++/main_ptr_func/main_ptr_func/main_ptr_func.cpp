#include <iostream>
using namespace std;

int minn(int* arr1, int* arr2, int len1, int len2)
{
    int min1 = *arr1;
    int min2 = *arr2;

    for (size_t i = 0; i < len1; i++)
    {
        if (*(arr1 + i) < min1)
        {
            min1 = *(arr1 + i);
        }
    }

    for (size_t i = 0; i < len2; i++)
    {
        if (*(arr2 + i) < min2)
        {
            min2 = *(arr2 + i);
        }
    }

    return min1;
    if (min1 < min2)
    {
        return min1;
    }
    else if (min2 < min1)
    {
        return min2;
    }
}

int maxx(int* arr1, int* arr2, int len1, int len2)
{
    int max1 = *(arr1 + 0);
    int max2 = *(arr2 + 0);

    for (size_t i = 0; i < len1; i++)
    {
        if (max1 > *(arr1 + i))
        {
            max1 = *(arr1 + i);
        }
    }

    for (size_t i = 0; i < len2; i++)
    {
        if (max2 > *(arr2 + i))
        {
            max2 = *(arr2 + i);
        }
    }

    if (max1 < max2)
    {
        return max2;
    }
    else if (max2 < max1)
    {
        return max1;
    }
}

int avg(int* arr1, int* arr2, int len1, int len2)
{
    int total{};
    int avg{};
    int factor = len1 + len2;

    for (size_t i = 0; i < len1; i++)
    {
        total += *(arr1 + i);
    }

    for (size_t i = 0; i < len2; i++)
    {
        total += *(arr2 + i);
    }

    avg = total / factor;

    return avg;
}

void Action(int* arr1, int* arr2, int len1, int len2)
{
    int(*foo_funcs[])(int*, int*, int, int) = { minn, maxx, avg };

    int option{};

    cout << "Enter your choice: " << endl
        << "1. Min" << endl
        << "2. Max" << endl
        << "3. Avg" << endl;
    cin >> option;

    switch (option)
    {
    case 1:
        cout << foo_funcs[0](arr1, arr2, len1, len2) << endl;
        break;
    case 2:
        cout << foo_funcs[1](arr1, arr2, len1, len2) << endl;
        break;
    case 3:
        cout << foo_funcs[2](arr1, arr2, len1, len2) << endl;
        break;
    default:
        cout << "Error choice" << endl;
    }
        
}

int main()
{
    int* arr1 = new int[5]{ 1, 2, 5, 4, 3 };
    int* arr2 = new int[5]{ 1, 2, 3, 4, 5 };

    Action(arr1, arr2, 5, 5);

    return 0;
}
