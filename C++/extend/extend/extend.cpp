#include <iostream>
using namespace std;

void zeros(int arr[])
{
    int len = sizeof(arr);

    for (size_t i = 0; i < len; i++)
    {
        if (arr[i] == 0)
        {
            arr[i] = -1;
        }
    }
}

void sort(int arr[], int arr2[])
{
    int arr_res[10]{};
    int len = 5;
    int n{};

    for (size_t i = 0; i < len; i++)
    {
        for (size_t j = 0; j < len; j++)
        {
            if (arr[i] > 0)
            {
                arr_res[n++];
            }
            if (arr2[j] > 0)
            {
                arr_res[n++];
            }
        }
    }

    for (size_t i = 0; i < len; i++)
    {
        for (size_t j = 0; j < len; j++)
        {
            if (arr[i] = 0)
            {
                arr_res[n++];
            }
            if (arr2[j] = 0)
            {
                arr_res[n++];
            }
        }
    }

    for (size_t i = 0; i < len; i++)
    {
        for (size_t j = 0; j < len; j++)
        {
            if (arr[i] < 0)
            {
                arr_res[n++];
            }
            if (arr2[j] < 0)
            {
                arr_res[n++];
            }
        }
    }
}

int main()
{
    int arr[10] = { 1, 2, 3, 4, 5, 6, 0, 8, 0, 10 };
    int arr1[5] = { 1, 2, 0, 7, -1 };
    int arr2[5] = { 1, -2, 0, 9, 10 };
}