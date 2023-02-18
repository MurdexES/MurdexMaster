#include "car.h"
#include "showroom.h"
#include "tunning.h"


int menu() {
	system("cls");

	Showroom* sw = new Showroom();
	tunned* object = new tunned();

	sw->cars[0] = *(new Car(new char[] {"Mercedes"}, new char[] {"C200"}, 2000, 2000, 136));
	sw->free_place--;

	sw->cars[1] = *(new Car(new char[] {"Chevy"}, new char[] {"Cruze"}, 2017, 1400, 153));
	sw->free_place--;

	sw->cars[2] = *(new Car(new char[] {"BMW"}, new char[] {"M6"}, 2014, 4400, 550));
	sw->free_place--;

	int selection{};
	bool check = true;
	while (check)
	{
		std::cout
			<< "1. Add car" << std::endl
			<< "2. Edit car" << std::endl
			<< "3. Delete car" << std::endl
			<< "4. Show all" << std::endl
			<< "5. Show car" << std::endl
			<< "6. Update capacity" << std::endl
			<< "7. Tunning" << std::endl
			<< "8. Exit" << std::endl
			<< "ENTER YOUR CHOICE: " << std::endl;

		std::cin >> selection;

		switch (selection)
		{
		case 1:
			sw->addCar();
			break;
		case 2:
			sw->editCar();
			break;
		case 3:
			sw->deleteCar();
			break;
		case 4:
			sw->showAll();
			break;
		case 5:
			sw->showCar();
			break;
		case 6:
			sw->updateCapacity();
			break;
		case 7:
			object->menuTunned();
			break;
		case 8:
			return 0;
			break;
		}
	}
}