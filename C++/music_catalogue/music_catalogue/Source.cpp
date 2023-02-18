#include <iostream>
#include <fstream>
#include "Header.h"
using namespace std;

void delete_song(Song*& catalog)
{
    Song* tmp_ctlg = new Song[sizeof(catalog)]{};

    int index{};

    cout << "Enter the index of song you want to delete: ";
    cin >> index;

    for (size_t i = 0; i < index - 1; i++)
    {
        *(tmp_ctlg + i) = *(catalog + i);
    }

    for (size_t i = index; i < sizeof(catalog); i++)
    {
        *(tmp_ctlg + i) = *(catalog + (i + 1));
    }

    delete[] catalog;
    catalog = tmp_ctlg;
}

void edit(Song*& catalog)
{
    int choice{};
    int index{};

    cout << "Enter index of song you want to edit: ";
    cin >> index;

    cout << "Enter what you want to change: " << endl
        << "1. Name" << endl
        << "2. Author" << endl
        << "3. Year" << endl
        << "4. Text of Song" << endl;

    cin >> choice;

    switch (choice)
    {
    case 1:
        cout << "Enter new name of song: ";
        cin.getline(catalog[index - 1].name, 15);
        break;
    case 2:
        cout << "Enter new author of song: ";
        cin.getline(catalog[index - 1].author, 15);
        break;
    case 3:
        cout << "Enter new year: ";
        cin >> catalog[index - 1].year;
        break;
    case 4:
        cout << "Enter new text of song: ";
        cin.getline(catalog[index - 1].text, 150);
        break;
    }
}

void search_author(Song* catalog)
{
    char* author_by = new char[15]{};
    int len_author = strlen(author_by);
    int count = 0;

    Song* tmp_search = new Song[sizeof(catalog)];

    cout << "Enter author by which you want to search: ";
    cin.getline(author_by, 15);

    for (size_t i = 0; i < sizeof(catalog); i++)
    {
        for (size_t j = 0; j < len_author; j++)
        {
            if (author_by[j] = (catalog[i].author)[j])
            {
                count++;
            }
        }

        if (len_author == count)
        {
            tmp_search[i] = catalog[i];
        }
    }

    cout << "This is all results: " << endl;

    for (size_t i = 0; i < sizeof(tmp_search); i++)
    {
        if (tmp_search[i].year != 0)
        {
            tmp_search[i].print();
        }
    }
}

void search_word(Song* catalog)
{
    char* word_by = new char[15]{};
    int len_word = strlen(word_by);
    int count = 0;

    Song* tmp_search = new Song[sizeof(catalog)];

    cout << "Enter word by which you want to search: ";
    cin.getline(word_by, 15);

    for (size_t i = 0; i < sizeof(catalog); i++)
    {
        for (size_t j = 0; j < 150; j++)
        {
            if (word_by[j] = (catalog[i].text)[j])
            {
                count++;
            }

            if (len_word == count)
            {
                tmp_search[i] = catalog[i];
            }
        }
    }

    cout << "This is all results: " << endl;

    for (size_t i = 0; i < sizeof(tmp_search); i++)
    {
        if (tmp_search[i].year != 0)
        {
            tmp_search[i].print();
        }
    }
}

void print_song(Song* catalog)
{
    for (size_t i = 0; i < sizeof(catalog); i++)
    {
        (*(catalog + i)).print();
    }
}

void save_as(Song* catalog)
{
    int index{}; 

    cout << "Enter index of song you want to save as txt file: ";
    cin >> index;

    ofstream fout("song_saved.txt");
    fout << catalog[index - 1].text;
    fout.close();
}

void add_song(Song*& catalog)
{
    Song* tmp_arr = new Song[sizeof(catalog) + 1]{};

    for (size_t i = 0; i < sizeof(catalog); i++)
    {
        tmp_arr[i] = catalog[i];
    }

    tmp_arr[sizeof(catalog) + 1];

    delete[] catalog;
    catalog = tmp_arr;

}