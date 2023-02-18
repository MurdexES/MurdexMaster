#include <iostream>
#include "Header.h"
using namespace std;

int main()
{
    char* login = new char[10]{};
    char* password = new char[10]{};
    int len = 0;

    char** name_list = new char* [len] {};
    float* price_list = new float[len] {};
    int* number = new int[len] {};

    int option = 0;
    bool key = 1;
    bool key_cashier = 1;
    int position = 0;
    int num{};
    int cashier_check = 0;
    float long_long_total_price = 0;
    int sale = 0;

    cout << "Enter login and password: ";
    
    cin.getline(login, 10);
    cout << endl;
    cin.getline(password, 10);

    if (log_in(login, password) != 2)
    {
        if (log_in(login, password) == 0)
        {
            cout << "Welcome Admin";

            while (key)
            {
                cout << endl << "Enter number of products: ";
                cin >> len;

                for (size_t i = 0; i < len; i++)
                {
                    *(name_list + i) = new char[15]{};
                }

                for (size_t i = 0; i < len; i++)
                {
                    cout << "Enter name of product: ";
                    cin.getline(*(name_list + i), 15);
                    cout << endl;
                }

                for (size_t i = 0; i < len; i++)
                {
                    cout << "Enter price of product: ";
                    cin >> *(price_list + i);
                    cout << endl;
                }

                for (size_t i = 0; i < len; i++)
                {
                    cout << "Enter number of product: ";
                    cin >> *(number + i);
                    cout << endl;
                }

                cout << "What you want to do: " << endl
                    << "1 - Add" << endl
                    << "2 - Delete" << endl
                    << "3 - Edit" << endl
                    << "4 - Leave" << endl;
                cin >> option;

                if (option == 1)
                {
                    append(name_list, price_list, number);
                }
                else if (option == 2)
                {
                    delete_index(name_list, price_list, number);
                }
                else if (option == 3)
                {
                    edit(price_list, number);
                }
                else if (option == 4)
                {
                    cout << endl << "Bye";
                    key = 0;
                }
            }
        }



        if (log_in(login, password) == 1)
        {
            cout << "Welcome Cashier";
            while (key_cashier)
            {
                for (size_t i = 0; i < sizeof(name_list); i++)
                {
                    cout << i + 1 << " - " << *(name_list + i) << ' ' << *(price_list + i) << ' ' << *(number + i) << endl;
                }

                cout << "Enter position of product you want to select and number you want: ";
                cin >> position;
                cin >> num;

                *(number + position) -= num;

                long_long_total_price += (num * *(price_list + position));

                cout << "Do you want to continue: " << endl
                    << "1 - Yes" << endl
                    << "2 - No" << endl;
                cin >> cashier_check;

                if (cashier_check == 2)
                {
                    cout << "Enter sale you have: ";
                    cin >> sale;
                    cout << "This is total price you have to pay: " << long_long_total_price * (sale / 100);
                    key_cashier = 0;
                }
            }
        }
    }
    return 0;
}
