#include <iostream>
#include "book.h"
#include "shelf.h"

using namespace std;

int main()
{	
	bool key = true;
	int selec{};

	Shelf* sh = new Shelf();

	while (key)
	{
		cout << "Enter your choice: " << endl
			<< "1. Add" << endl
			<< "2. Delete" << endl
			<< "3. Change" << endl
			<< "4. Update Capacity" << endl
			<< "5. Search" << endl
			<< "6. Sort" << endl
			<< "7. Exit" << endl;
		cin >> selec;

		switch (selec)
		{
		case 1:
			cout << "Add book: ";
			sh->addBook();

			break;
		case 2:
			sh->deleteBook();

			break;
		case 3:
			sh->changeBook();

			break;
		case 4:
			sh->updateCapacity();

			break;
		case 5:
			sh->searchBook();

			break;
		case 6:
			sh->sortBook();

			break;
		case 7:
			key = false;

			break;
		default:
			cout << "ERROR";
			break;
		}
	}

	return 0;
}