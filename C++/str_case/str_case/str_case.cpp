#include <iostream>
using namespace std;

int mystrcmp(const char* str1, const char* str2)
{
    int count = 0;
    for (size_t i = 0; i < sizeof(str1); i++)
    {
        for (size_t j = 0; j < sizeof(str2); j++)
        {
            if (*(str1 + i) == *(str2 + j))
            {
                count++;
            }
        }
    }

    if (count == sizeof(str2))
    {
        return 0;
    }
    else if (count > sizeof(str2))
    {
        return 1;
    }
    else if (count < sizeof(str2))
    {
        return -1;
    }

}

void bubbleSort(char arr[], int len)
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
}

void IntToChar(int number, int len, char* arr)
{
    int temp = 48;
    int multy = 10;

    for (size_t i = 0; i < len - 1; i++)
    {
        int factor = number % 10;
        cout << factor;
        *(arr + i) = factor + temp;
        number /= 10;
    }

    bubbleSort(arr, len);

    for (size_t i = 0; i < len - 1; i++)
    {
        cout << *(arr + i) << " ";
    }

}

int chartoint(char* arr, const int len)
{
    int temp = 48;
    int num_res = 0;
    int multy = 10;

    for (size_t i = 0; i < len - 1; i++)
    {
        num_res += *(arr + i) - temp;
        num_res *= multy;
    }

    num_res /= 10;

    return num_res;
}

char* Uppercase(char*& str1)
{
    char* tmp_arr = new char[strlen(str1)]{};

    for (size_t i = 0; i < strlen(str1); i++)
    {
        *(tmp_arr + i) = *(str1 + i) - 32;
    }
}

char* Lowercase(char*& str1)
{
    char* tmp_arr = new char[strlen(str1)]{};

    for (size_t i = 0; i < strlen(str1); i++)
    {
        *(tmp_arr + i) = *(str1 + i) + 32;
    }
}

char* mystrrev(char*& str)
{
    char* tmp_arr = new char[strlen(str)]{};

    for (size_t i = 0, int j = strlen(str); i < strlen(str), j > 0; i++, i--)
    {
        *(tmp_arr + i) = *(str + j);
    }

    delete[] str;

    for (size_t i = 0; i < strlen(str); i++)
    {
        *(str + i) = *(tmp_arr + i);
    }
}

int main()
{


    return 0;
}
