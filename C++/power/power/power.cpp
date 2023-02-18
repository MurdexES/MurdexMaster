#include <iostream>
using namespace std;

char* longest_surname(char** names)
{
    char* tmp{};
    for (size_t i = 0; i < sizeof(names); i++)
    {
        if (strlen(*names + i) > strlen(*(names + i + 1)))
        {
            tmp = *(names + i + 1);
            *(names + i + 1) = *(names + i);
            *(names + i) = tmp;
        }
    }
    

    return *(names + (sizeof(names) - 1));
}

int** divide(int* arr1, int length)
{

    int** arr2 = new int* [2];
    *(arr2 + 0) = new int[length / 2];
    *(arr2 + 1) = new int[length / 2];
    for (size_t i = 0; i < length / 2; i++)
    {
        *(*(arr2 + 0) + i) = *(arr1 + i);
    }

    for (size_t i = length / 2; i < length; i++)
    {
        if (length % 2 != 0)
            if (i == length - 1) {
                *(*(arr2 + 0) + i) = 0;
                break;
            }
        *(*(arr2 + 1) + i) = *(arr1 + i);
    }
    return arr2;
}

int main()
{
    char** names = new char*[5]{};

    for (size_t i = 0; i < sizeof(names); i++)
    {
        *(names + i) = new char[10]{};
    }

    for (size_t i = 0; i < sizeof(names); i++)
    {
        cin >> *(*(names + i));
    }

    longest_surname(names);

    return 0;
}
