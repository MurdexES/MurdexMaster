#include "tunning.h"
#include <iostream>
#include "car.h"
#include "menu.h"
#include "showroom.h"

using namespace std;

void tunned::menuTunned(Car* cars)
{
	FILE* f;

	system("cls");

	int index{};
	char* file_path = new char[100]{};
	char* file_read = new char[100]{};

	cout << "Enter index of car you want to tun: ";
	cin >> index;

	origin = cars[index];

	int selec{};
	int opt{};
	bool key = true;

	while (key)
	{
		cout << "Enter your what you want to change: " << endl
			<< "1 - Engine" << endl
			<< "2 - Rim" << endl
			<< "3 - Stage" << endl
			<< "4 - Color" << endl
			<< "5 - Toning Stage" << endl
			<< "6 - EXIT" << endl
			<< "7 - Read from file" << endl
			<< "Your choice: ";
		cin >> selec;

		switch (selec)
		{
		case 1:
			cout << "Which engine you want: " << endl
				<< "1 - GM LS Series" << endl
				<< "2 - Toyota 2JZ (Supra)" << endl
				<< "3 - Mazda 13B (RX-7)" << endl
				<< "Enter: ";
			cin >> opt;

			switch (opt)
			{
			case 1:
				origin.volume = 8000;
				cout << "Volume: V8";
				origin.HP *= 1.2;
				cout << "HP: " << origin.HP;
				break;
			case 2:
				origin.volume = 3000;
				cout << "Volume: V3";
				origin.HP *= 1.2;
				cout << "HP: " << origin.HP;
				break;
			case 3:
				origin.volume = 1300;
				cout << "Volume: V1.3";
				origin.HP *= 1.2;
				cout << "HP: " << origin.HP;
				break;
			default:
				cout << "Wrong";
				break;
			}

			opt = 0;

			break;
		case 2:
			cout << "Which rims you want: " << endl
				<< "1 - Volk Racing TE37" << endl
				<< "2 - American Racing Torq Thrust" << endl
				<< "3 - Enkei RP03" << endl
				<< "4 - BBS Super RS" << endl
				<< "5 - Konig Hypergram" << endl
				<< "Enter: ";
			cin >> opt;

			switch (opt)
			{
			case 1:
				this->rim = new char[35]{ "Volk Racing TE37" };
				cout << "Installed";
				break;
			case 2:
				this->rim = new char[35]{ "American Racing Torq Thrust" };
				cout << "Installed";
				break;
			case 3:
				this->rim = new char[35]{ "Enkei RP03" };
				cout << "Installed";
				break;
			case 4:
				this->rim = new char[35]{ "BBS Super RS" };
				cout << "Installed";
				break;
			case 5:
				this->rim = new char[35]{ "Konig Hypergram" };
				cout << "Installed";
				break;
			default:
				cout << "Wrong";
				break;
			}

			opt{};

			break;
		case 3:
			cout << "Which rims you want: " << endl
				<< "1 - Stage 1" << endl
				<< "2 - Stage 2" << endl
				<< "3 - Stage 3" << endl
				<< "Enter: ";
			cin >> opt;

			switch (opt)
			{
			case 1:
				this->stage = 1;
				origin.HP *= 1.25;
				cout << "Installed";
				break;
			case 2:
				this->stage = 2;
				origin.HP *= 1.45;
				cout << "Installed";
				break;
			case 3:
				this->stage = 3;
				origin.HP *= 1.65;
				cout << "Installed";
				break;
			default:
				cout << "Wrong";
				break;
			}

			opt = 0;

			break;
		case 4:
			cout << "Enter name of the color you want you car to be: " << endl;
			cin.getline(this->color, 15);

			cout << "Successfully installed!!";

			break;
		case 5:
			cout << "Enter level of toning: " << endl
				<< "1. Low" << endl
				<< "2. Medium" << endl
				<< "3. Max" << endl
				<< "Your choice: ";
			cin >> opt;

			this->toning_stage = opt;
			cout << "Car`s windows successfully toned.";

			break;
		case 6:
			cout << "LEAVING...";

			fopen_s(&f, "data.txt", "w");
			
			if (f)
			{
	 			fputs("Hello World", f);
			}

			if (f)
			{
				fclose(f);
			}

			key = false;

			break;
		case 7:
			cout << "Enter path to file: " << endl;
			cin.getline(file_path, 100);

			fopen_s(&f, "read.txt", "r");

			if (f)
			{
				fgets(file_read, 100, f);
			}
				
			if (f)
			{
				fclose(f);
			}
		default:
			cout << "ERROR";
			break;
		}
	}
}
