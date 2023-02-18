#include <iostream>
using namespace std;

struct Book
{
    char* name = new char[15]{};
    char* author = new char[15]{};
    char* publisher = new char[15]{};
    char* genre = new char[10]{};

    Book()
    {
        cout << "Enter name of book: " << endl;
        cin.getline(name, 15);

        cout << "Enter name of author: " << endl;
        cin.getline(author, 15);

        cout << "Enter publisher: " << endl;
        cin.getline(publisher, 15);

        cout << "Enter genre of book: " << endl;
        cin.getline(genre, 10);

        cin.ignore();
    }

    void print()
    {
        cout << this->name << ' ' << this->author << ' ' << this->publisher << ' ' << this->genre << '\n';
    }
};

void print_book(Book* lib)
{
    for (size_t i = 0; i < 10; i++)
    {
        (lib + i)->print();
    }
}

Book search_author(Book* lib)
{
    char* author_by = new char[15]{};
    cin.getline(author_by, 15);


    int len_author = strlen(author_by);
    int count = 0;

    for (size_t i = 0; i < 10; i++)
    {
        for (size_t j = 0; j < len_author; j++)
        {
            if (author_by[j] = (lib[i].author)[j])
            {
                count++;
            }
        }

        if (len_author == count)
        {
            return lib[i];
        }
    }
}

Book search_name(Book* lib)
{
    char* name_by = new char[15]{};
    cin.getline(name_by, 15);


    int len_name = strlen(name_by);
    int count = 0;

    for (size_t i = 0; i < 10; i++)
    {
        for (size_t j = 0; j < len_name; j++)
        {
            if (name_by[j] = (lib[i].name)[j])
            {
                count++;
            }
        }

        if (len_name == count)
        {
            return lib[i];
        }
    }
}

void edit(Book*& lib)
{
    int choice{};
    int index{};

    cout << "Enter index of book you want to edit: ";
    cin >> index;

    cout << "Enter what you want to change: " << endl
        << "1. Name" << endl
        << "2. Author" << endl
        << "3. Publisher" << endl
        << "4. Genre" << endl;

    cin >> choice;

    switch (choice)
    {
    case 1:
        cout << "Enter new name of book: ";
        cin.getline(lib[index - 1].name, 15);
        break;
    case 2:
        cout << "Enter new author of book: ";
        cin.getline(lib[index - 1].author, 15);
        break;
    case 3:
        cout << "Enter new publisher of book: ";
        cin.getline(lib[index - 1].publisher, 15);
        break;
    case 4:
        cout << "Enter new genre of book: ";
        cin.getline(lib[index - 1].genre, 10);
        break;
    }
}

void sort_name(Book*& lib)
{
    char* temp = new char[15]{};

    for (size_t i = 10; i >= 0; i--)                  
    {
        for (size_t j = 0; j <= i; j++)
        {
            if (strcmp(lib[j].name, lib[j + 1].name) > 0)
            {
                temp = lib[j].name;
                lib[j].name = lib[j + 1].name;
                lib[j + 1].name = temp;
            }
        }
    }
}

void sort_author(Book*& lib)
{
    char* temp = new char[15]{};

    for (size_t i = 10; i >= 0; i--)
    {
        for (size_t j = 0; j <= i; j++)
        {
            if (strcmp(lib[j].author, lib[j + 1].author) > 0)
            {
                temp = lib[j].author;
                lib[j].author = lib[j + 1].author;
                lib[j + 1].author = temp;
            }
        }
    }
}

void sort_publisher(Book*& lib)
{
    char* temp = new char[15]{};

    for (size_t i = 10; i >= 0; i--)
    {
        for (size_t j = 0; j <= i; j++)
        {
            if (strcmp(lib[j].publisher, lib[j + 1].publisher) > 0)
            {
                temp = lib[j].publisher;
                lib[j].publisher = lib[j + 1].publisher;
                lib[j + 1].publisher = temp;
            }
        }
    }
}

int main()
{
    int option{};
    Book* libr = new Book[10]{};


    for (size_t i = 0; i < 10; i++)
    {
        libr + i;
    }


    cout << "what you want to do: " << endl
        << "1. Print all" << endl
        << "2. Edit" << endl
        << "3. Search Author" << endl
        << "4. Search Name" << endl
        << "5. Sort by Name" << endl
        << "6. Sort by Author" << endl
        << "7. Sort by Publisher" << endl;
    cin >> option;

    switch (option)
    {
    case 1:
        print_book(libr);
        break;
    case 2:
        edit(libr);
        break;
    case 3:
        search_author(libr);
        break;
    case 4:
        search_name(libr);
        break;
    case 5:
        sort_name(libr);
        break;
    case 6:
        sort_author(libr);
        break;
    case 7:
        sort_publisher(libr);
        break;
    default:
        cout << "ERROR";
        break;
    }

    return 0;
}
