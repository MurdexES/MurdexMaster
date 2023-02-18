#include <iostream>
using namespace std;

int factorial(int number)
{
    int fact = 1;

    for (size_t i = 1; i <= number; i++)
    {
        fact *= i;
    }

    return fact;
}

void bubbleSort(int arr[], const int len)
{
    int temp = 0;
    int i, j;
    for (i = 0; i < len - 1; i++) {
        for (j = 0; j < len - i - 1; j++) {
            if (arr[j] > arr[j + 1]) {
                temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }
    
    i = 0;
    for (i = 0; i < len; i++)
        cout << arr[i] << " ";
    cout << endl;
}

void insertionSort(int arr[], const int len)
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

    int i;
    for (i = 0; i < len; i++)
        cout << arr[i] << " ";
    cout << endl;
}

void factor_sum(int arr[], const int len)
{
    int sum = 0;
    int count = 0;

    for (size_t i = 0; i < len; i++)
    {
        sum += arr[i];
    }

    for (size_t i = 0; i < len; i++)
    {
        if (sum % arr[i] == 0)
        {
            cout << arr[i];
            ++count;
        }
    }

    if (count == 0)
    {
        cout << -1;
    }
}

void overlap(int arr1[], int arr2[], int arr3[], const int len)
{
    for (size_t i = 0; i < len; i++)
    {
        for (size_t j = 0; j < len; j++)
        {
            if (arr1[i] == arr2[j])
            {
                arr3[i] = arr1[i];
            }
        }
    }

    int i;
    for (i = 0; i < len; i++)
        cout << arr3[i] << " ";
    cout << endl;
}

void Unoverlap(int arr1[], int arr2[], int arr3[], const int len)
{
    int count{};
    size_t j = 0;
    for (size_t i = 0; i < len; i++)
    {
        while (arr1[i] != arr2[j])
        {
            count++;
            j++;
        }
        j = 0;

        if (count >= len)
        {
            arr3[i] = arr1[i];
        }
    }

    int i;
    for (i = 0; i < len; i++)
        cout << arr3[i] << " ";
    cout << endl;
}

bool inside_massive(int arr1[], int arr2[], const int len)
{
    int count = 0;
    for (size_t i = 0; i < len; i++)
    {
        if (arr1[i] == arr2[i])
        {
            ++count;
        }
    }

    if (count == len)
    {
        return true;
    }
    else
    {
        return false;
    }
}

int main()
{
    int number = 5;
    //cout << factorial(number);

    int arr[5] = { 1, 2, 7, 3, 1 };

    //bubbleSort(arr, 5);
    //insertionSort(arr, 5);
    //factor_sum(arr, 5);

    int arr2[5] = { 1, 2, 8, 9, 4 };
    int arr_res[5]{};

    //overlap(arr, arr2, arr_res, 5);
    Unoverlap(arr, arr2, arr_res, 5);

    int arr_under[3] = { 1, 2, 7 };

    //cout << inside_massive(arr, arr_under, 3);


    return 0;
}

