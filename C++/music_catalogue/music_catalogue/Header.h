#pragma once
#include <iostream>
#include <fstream>
using namespace std;

struct Song
{
    char* text = new char[250]{};
    char* name = new char[15]{};
    char* author = new char[15]{};
    int year{};

    Song() // Default
    {
        cout << "Enter text of music: " << endl;
        cin.getline(text, 150);

        cout << "Enter name of song: " << endl;
        cin.getline(name, 15);

        cout << "Enter name of author: " << endl;
        cin.getline(author, 15);

        cin.ignore();

        cout << "Enter year: " << endl;
        cin >> year;
    }

    void print()
    {
        cout << "Name: " << name << "Author: " << author << "Year: " << year << "Text of song: " << text << endl;
    }
};

void print_song(Song*);
void delete_song(Song*&);
void edit(Song*&);
void search_author(Song*);
void search_word(Song*);
void save_as(Song*);
void add_song(Song*&);
