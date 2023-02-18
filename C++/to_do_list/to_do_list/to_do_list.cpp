#include <iostream>
#include <ctime>
#include "Header.h"
using namespace std;

int main()
{
    int len{};
    int option{};

    cout << "Enter the start number of Dos: ";
    cin >> len;

    Do* list = new Do[len]{};

    for (size_t i = 0; i < len; i++)
    {
        list[i];
    }

    cout << "What do you want to do: " << endl
        << "1 - Add" << endl
        << "2 - Delete" << endl
        << "3 - Edit" << endl
        << "4 - Search" << endl
        << "5 - Print" << endl;
    cin >> option;

    switch (option)
    {
    case 1:
        add(list);
        break;
    case 2:
        delete_do(list);
        break;
    case 3:
        edit(list);
        break;
    case 4:
        search(list);
        break;
    case 5:
        print_date(list);
        break;
    default:
        cout << "ERROR" << endl;
        break;
    }


    cout << "YOU`RE GOD DAMN RIGHT" << endl;


    return 0;
}
