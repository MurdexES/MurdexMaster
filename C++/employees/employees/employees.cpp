#include <iostream>
#include "Header.h"
using namespace std;

int main()
{
    int selec{};
    List l1{};

    cout << "Enter your choice: " << endl
        << "1. Add" << endl
        << "2. Delete" << endl
        << "3. Search" << endl
        << "4. Print all" << endl
        << "5. Save as file" << endl
        << "6. Open your file" << endl;

    switch (selec)
    {
    case 1:
        l1.add();
        break;
    case 2:
        l1.del();
        break;
    case 3:
        l1.search();
        break;
    case 4:
        l1.print_all();
        break;
    case 5:
        save_as(l1);
        break;
    case 6:
        open_as();
        break;
    default:
        cout << "ERROR" << endl;
        break;
    }

    save_as(l1);

    return 0;
}
