#include <iostream>
#include <string>
using namespace std;

class User
{
public:
    User() = default;

    User(string username, string password)
    {
        this->username = username;
        this->password = password;
    }

    string getUsername(string client_username)
    {
        client_username = this->username;
    }

    string getUserData(string client_password, string client_username)
    {
        client_password = this->password;
        client_username = this->username;
    }

    void regist(User** database)
    {
        bool key = false;

        string username{};
        string password{};
        string confirm_password{};

        do
        {
            cout << "For Registration: " << endl
                << "Enter username : ";
            cin >> username;

            if (sizeof(database) != 0)
            {
                for (size_t i = 0; i < sizeof(database); i++)
                {
                    if (username == database[i]->username)
                    {
                        throw exception("Change username, this one already took!");
                        key = true;
                    }
                    else
                    {
                        key = false;
                    }
                }
            }
            
            else
            {
                key = false;
            }
        }
        while (key);

        cout << "Enter password: ";
        cin >> password;

        do
        {
            cout << "Confirm password by entering again: ";
            cin >> confirm_password;

            if (password == confirm_password)
            {
                system("cls");
                cout << "You Successfully registered";
                key = false;
            }
            else
            {
                throw exception("Passwords not identical re-enter password!");
                key = true;
            }
        } 
        while (key);

        this->password = password;
        this->username = username;
        
    }


    void login(User** database)
    {
        bool key = false;

        string username{};
        string password{};

        getUserData(username, password);

        if (sizeof(database) != 0)
        {
            do
            {
                cout << "For Login: " << endl
                    << "Enter username : ";
                cin >> username;

                for (size_t i = 0; i < sizeof(database); i++)
                {
                    if (username == database[i]->username)
                    {
                        key = false;
                    }
                    else
                    {
                        throw exception("No valid username");
                        key = true;
                    }
                }
            } 
            while (key);

            do
            {
                cout << "Enter password: ";
                cin >> password;

                for (size_t i = 0; i < sizeof(database); i++)
                {
                    if (password == database[i]->password)
                    {
                        system("cls");
                        cout << "You Successfully Logined";
                        key = false;
                    }
                    else
                    {
                        throw exception("Password is wrong!");
                        key = true;
                    }
                }

            } while (key);
        }

        else
        {
            throw exception("There are not any users for login");
            return;
        }

    }

private:
    string username{};
    string password{};
};

int main()
{
    User** database = new User*[5]{};

    int choice{};

    string username_check{};
    string username{};

    cout << "1. Register" << endl
        << "2. Login" << endl
        << "Enter your choice : ";
    cin >> choice;

    switch (choice)
    {
    case 1:
        for (size_t i = 0; sizeof(database); i++)
        {
            if (database[i] == 0)
            {
                database[i]->regist(database);
                break;
            }
        }
        
        break;
    case 2:
        cout << "Enter username: ";
        cin >> username_check;
        
        for (size_t i = 0; sizeof(database); i++)
        {
            username = database[i]->getUsername(username);
            if (username_check == username)
            {
                database[i]->login(database);
                break;
            }
        }

        break;
    default:
        cout << "Error";
        break;
    }

    return 0;
}