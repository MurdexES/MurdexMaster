#include <iostream>
#include "Header.h"
#include <ctime>
#include <string>
using namespace std;

int main()
{
    int option{};

    Queue* list = new Queue{};

    Do tmp{};

    cout << "What do you want to do: " << endl
        << "1 - Add" << endl
        << "2 - Delete" << endl
        << "3 - Edit" << endl
        << "4 - Print" << endl;

    cin >> option;

    switch (option)
    {
    case 1:
        tmp.input();
        list->append_add(tmp);
        break;
    case 2:
        list->pop_back_delete();
        break;
    case 3:
        list->edit();
        break;
    case 4:
        list->print_queue();
        break;
    default:
        cout << "ERROR" << endl;
        break;
    }


    cout << "YOU`RE GOD DAMN RIGHT" << endl;

    return 0;
}
