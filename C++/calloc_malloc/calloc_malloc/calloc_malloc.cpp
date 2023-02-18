#include <iostream>
using namespace std;

int main()
{
    int* ptr1{};
    int* ptr2{};

    int* si{};
    int* unsi{};

    int len1{};
    int len2{};

    cout << "Enter length of both arrays: " << endl;
    cin >> len1;
    cin >> len2;
    
    ptr1 = (int*)malloc(len1 * sizeof(int));
    ptr2 = (int*)malloc(len2 * sizeof(int));

    for (size_t i = 0; i < len1; i++)
    {
        cout << "Enter element of ptr1: ";
        cin >> *(ptr1 + i);
    }

    for (size_t i = 0; i < len2; i++)
    {
        cout << "Enter element of ptr2: ";
        cin >> *(ptr2 + i);
    }

    si = (int*)malloc(len1 *sizeof(int));
    unsi = (int*)malloc(len1 * sizeof(int));

    free(si);
    free(unsi);

    for (size_t i = 0; i < len1; i++)
    {
        si[i] = 0;
        unsi[i] = 0;
    }
    
    /*
    for (size_t i = 0; i < len1; i++)
    {
        if (ptr1[i] == ptr2[i])
        {
            si[i] = ptr1[i];
        }
    }

    for (size_t i = 0; i < len1; i++)
    {
        if (ptr1[i] != ptr2[i])
        {
            unsi[i] = ptr1[i];
        }
    }
    */

    for (size_t i = 0; i < sizeof(si); i++)
    {
        cout << si[i] << ',';
    }

    cout << endl;

    for (size_t i = 0; i < sizeof(unsi); i++)
    {
        cout << unsi[i] << ',';
    }
    return 0;
}
