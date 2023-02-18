#include <iostream>
#include <fstream>
#include "Header.h"
using namespace std;

int main()
{
    int len{};
    int op{};

    cout << "Enter number of songs: " << endl;
    cin >> len;

    Song* catalog = new Song[len]{};

    for (size_t i = 0; i < len; i++)
    {
        *(catalog + i);
    }
    cin >> op;
    cout << "What you want to do: " << endl
        << "1. Print all" << endl
        << "2. Edit" << endl
        << "3. Delete" << endl
        << "4. Add" << endl
        << "5. Search by Author" << endl
        << "6. Search by Word" << endl
        << "7. Save as - (Beta)" << endl;
    cin >> op;


    switch(op)
    {
    case 1:
        print_song(catalog);
        break;
    case 2:
        edit(catalog);
        break;
    case 3:
        delete_song(catalog);
        break;
    case 4:
        add_song(catalog);
        break;
    case 5:
        search_author(catalog);
        break;
    case 6:
        search_word(catalog);
        break;
    case 7:
        save_as(catalog);
        break;
    default:
        cout << "ERROR" << endl;
        break;
    }

    cout << endl << "End of program" << endl;

    return 0;
}