#include <iostream>
#include "decloration.h"
using namespace std;

int main()
{
    char* word = new char[6]{"Murad"};
    mystrchr(word);

    char* sentence1 = new char[51]{};
    char* sentence2 = new char[26]{};

    cout << "Enter sentence you want: \n";
    cin >> sentence1;

    cout << "\nEnter second fragment sentence: ";
    cin >> sentence2;

    mystrstr(sentence1, sentence2);
}