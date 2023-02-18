#include <iostream>
using namespace std;

//Func

template <typename T>
T* new_dyn(int len, T type)
{
    T* tmp_arr = new T[len] {};
    for (size_t i = 0; i < len; i++)
    {
        cout << "Enter element of dynamic array: ";
        cin >> *(tmp_arr + i);
    }

    return tmp_arr;
}

template <typename T>
T* print_dyn(T* arr)
{
    for (size_t i = 0; i < sizeof(arr); i++)
    {
        cout << *(arr + i) << ' ';
    }
}

template <typename T>
void delete_dyn(T* arr)
{
    delete[] arr;
}

template <typename T>
T* append(T*& arr)
{
    T* tmp_arr = new T[sizeof(arr) + 1]{};
    T element{};

    cout << "Enter element you want to append: ";
    cin >> element;
    
    for (size_t i = 0; i < sizeof(arr); i++)
    {
        *(tmp_arr + i) = *(arr + i);
    }

    delete[] arr;
    T* arr = new T[sizeof(tmp_arr)]{};

    *(tmp_arr + sizeof(arr)) = element;

    for (size_t i = 0; i < sizeof(tmp_arr); i++)
    {
        *(arr + i) = *(tmp_arr + i);
    }

    return arr;
}

template <typename T>
T* add(T*& arr)
{
    T* tmp_arr = new T[sizeof(arr) + 1]{};
    T element{};
    int index{};

    cout << "Enter element you want to add and index: ";
    cin >> element;
    cin >> index;

    for (size_t i = 0; i < index; i++)
    {
        *(tmp_arr + i) = *(arr + i);
    }

    *(tmp_arr + index) = element;

    for (size_t i = index; i < sizeof(arr); i++)
    {
        *(tmp_arr + (i + 1)) = *(arr + i);
    }

    delete[] arr;
    T* arr = new T[sizeof(tmp_arr)]{};

    for (size_t i = 0; i < sizeof(tmp_arr); i++)
    {
        *(arr + i) = *(tmp_arr + i);
    }

    return arr;
}

template <typename T>
T* delete_index(T*& arr)
{
    T* tmp_arr = new T[sizeof(arr) - 1]{};
    T element{};
    int index{};

    cout << "Enter element you want to delete and index: ";
    cin >> element;
    cin >> index;

    for (size_t i = 0; i < index; i++)
    {
        *(tmp_arr + i) = *(arr + i);
    }

    for (size_t i = index; i < sizeof(arr); i++)
    {
        *(tmp_arr + i) = *(arr + (i + i));
    }

    delete[] arr;
    T* arr = new T[sizeof(tmp_arr)]{};

    for (size_t i = 0; i < sizeof(tmp_arr); i++)
    {
        *(arr + i) = *(tmp_arr + i);
    }

    return arr;
}

bool prime(int number)
{
    if (number <= 1)
        return 0;

    for (int i = 2; i < number; i++)
        if (number % i == 0)
            return 0;

    return 1;
}

template <typename T>
T* no_prime(T*& arr, int len)
{
    int count = 0;

    for (size_t i = 0; i < len; i++)
    {
        if (prime(*(arr + i)) == 0)
        {
            count++;
        }
    }

    T* tmp_arr = new T[len - count]{};

    size_t j{};
    for (size_t i = 0; i < len; i++)
    {
        if (prime(*(arr + i)) != 0)
        {
            *(tmp_arr + j) = *(arr + i);
            j++;
        }
    }

    delete[] arr;
    T* arr = new T[sizeof(tmp_arr)]{};

    for (size_t i = 0; i < sizeof(tmp_arr); i++)
    {
        *(arr + i) = *(tmp_arr + i);
    }

    return arr;
}

void stat_dyn(int arr[], int len)
{
    int* dyn_positive = new int[len] {};
    int* dyn_negative = new int[len] {};
    int* dyn_zeros = new int[len] {};

    for (size_t i = 0, j = 0, k = 0, n = 0; i < len; i++)
    {
        if (arr[i] > 0)
        {
            *(dyn_positive + j) = arr[i];
            j++;
        }
        else if (arr[i] < 0)
        {
            *(dyn_negative + k) = arr[i];
            k++;
        }
        else if (arr[i] == 0)
        {
            *(dyn_zeros + n) = arr[i];
            n++;
        }
    }
}

int main()
{
    int* dyn = new int[5]{};
    int stat[5] = { 1, 2, 3, 0, -1 };

    new_dyn(15, 66);
    print_dyn(dyn);
    delete_dyn(dyn);
    append(dyn);
    add(dyn);
    delete_index(dyn);
    no_prime(dyn, 5);
    stat_dyn(stat, 5);

    return 0;
}
