#include <iostream>
#include <time.h>
using namespace std;

void cols(int**& main)
{
    int** tmp_main = new int*[sizeof(main)]{};
    int index{};
    int rowse = sizeof(* (main));

    int* tmp_arr = new int[5]{};

    cout << "Enter index : ";
    cin >> index;

    for (size_t i = 0; i < 3; i++)
    {
        cout << "Enter element: ";
        cin >> *(tmp_arr + i);
    }

    for (size_t i = 0; i < sizeof(main); i++)
    {
        *(tmp_main + i) = new int[rowse] {};
    }

    for (size_t i = 0; i < sizeof(main); i++)
    {
        for (size_t j = 0; j < index; j++)
        {
            *(*(tmp_main + i) + j) = *(*(main + i) + j);
        }
    }

    for (size_t i = 0; i < sizeof(main); i++)
    {
        *(*(tmp_main + i) + index) = *(tmp_arr + i);
    }

    for (size_t i = 0; i < sizeof(main); i++)
    {
        for (size_t j = index; j < sizeof(*(main)); j++)
        {
            *(*(tmp_main + i) + j + 1) = *(*(main + i) + j);
        }
    }

    delete[] main;

    for (size_t i = 0; i < sizeof(tmp_main); i++)
    {
        *(main + i) = new int[rowse] {};
    }

    for (size_t i = 0; i < sizeof(main); i++)
    {
        *(main + i) = *(tmp_main + i);
    }

    for (size_t i = 0; i < sizeof(main); i++)
    {
        for (size_t j = 0; j < sizeof(*(main)); j++)
        {
            *(*(main + i) + j) = *(*(tmp_main + i) + j);
        }
    }
}

void delete_cols(int**& main)
{
    int** tmp_main = new int* [sizeof(main)]{};
    int index{};
    int rowse = sizeof(*(main)) - 1;

    int* tmp_arr = new int[5]{};

    cout << "Enter index : ";
    cin >> index;

    for (size_t i = 0; i < sizeof(main); i++)
    {
        *(tmp_main + i) = new int[rowse] {};
    }

    for (size_t i = 0; i < sizeof(main); i++)
    {
        for (size_t j = 0; j < index; j++)
        {
            *(*(tmp_main + i) + j) = *(*(main + i) + j);
        }
    }

    for (size_t i = 0; i < sizeof(main); i++)
    {
        for (size_t j = index; j < sizeof(*(main)); j++)
        {
            *(*(tmp_main + i) + j) = *(*(main + i) + j + 1);
        }
    }

    delete[] main;

    for (size_t i = 0; i < sizeof(tmp_main); i++)
    {
        *(main + i) = new int[rowse] {};
    }

    for (size_t i = 0; i < sizeof(main); i++)
    {
        *(main + i) = *(tmp_main + i);
    }

    for (size_t i = 0; i < sizeof(main); i++)
    {
        for (size_t j = 0; j < sizeof(*(main)); j++)
        {
            *(*(main + i) + j) = *(*(tmp_main + i) + j);
        }
    }
}

void cycle(int**& main)
{
    int* tmp_arr = new int[sizeof(*(main))]{};

    int shift{};

    cout << "Enter times of shift and position of array: ";
    cin >> shift;

    if (shift > sizeof(main))
    {
        if (shift / sizeof(main) > 2)
        {
            shift -= sizeof(main) * (shift / sizeof(main));
        }
        else
        {
            shift -= sizeof(main);
        }
    }
    for (size_t cycle = 0; cycle < shift; cycle++)
    { 
        for (size_t i = 0; i < sizeof(main); i++)
        {
            tmp_arr = *(main + i + 1);
            *(main + i + 1) = *(main + i);
            *(main + i + 2) = tmp_arr;
        }

        *(main) = tmp_arr;

    }
    
}

int main()
{
    srand(time(0));

    int rows = 3;
    int** main = new int* [5]{};

    for (size_t i = 0; i < sizeof(main); i++)
    {
        *(main + i) = new int[rows] {};
    }

    for (size_t i = 0; i < sizeof(main); i++)
    {
        for (size_t j = 0; j < rows; j++)
        {
            *(*(main + i) + j) = rand() % 10;
        }
        
    }

    return 0;
}
