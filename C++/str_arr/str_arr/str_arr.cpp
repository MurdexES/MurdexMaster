#include <iostream>
#include "dec.h"

using namespace std;


int main()
{
   char* text = new char[60]{};
   char* word = new char[10]{};
   char* sen = new char[25]{};
   
   cin.getline(text, 40); 

   cout << endl << "Enter word you want to search: ";
   cin.getline(word, 10);

   cout << endl << "Enter sentence you want to search: ";
   cin.getline(sen, 10);

   str_count(text, word);


}
