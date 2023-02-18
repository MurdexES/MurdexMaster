#pragma once
#include <iostream>
#include <string>
using namespace std;

enum class Races{Human = 1, Elf, Dark_Elf, Ork};
enum class Categories{ Warrior = 1, Magician, Archer, Healer};

class Character
{
public:
	Character() = default;

	Character(Races race, Categories category, uint8_t health, uint8_t damage, uint8_t shield, string name)
	{
		this->race = race;
		this->category = category;
		this->health = health;
		this->damage = damage;
		this->shield = shield;
		this->name = name;
	}

	void input()
	{
		cout << endl;

		cout << "Enter the name of character: " << endl;
		cin >> this->name;

		int selec{};

		//Race
		cout << endl << "Enter race number of character: " << endl
			<< "1 - Human" << endl
			<< "2 - Elf" << endl
			<< "3 - Dark Elf" << endl
			<< "4 - Ork" << endl;
		cin >> selec;

		switch (selec)
		{
		case 1:
			this->race = Races::Human;
			cout << "Human";
			this->health += 10;
			break;
		case 2:
			this->race = Races::Elf;
			cout << "Elf";
			break;
		case 3:
			this->race = Races::Dark_Elf;
			cout << "Dark Elf";
			break;
		case 4:
			this->race = Races::Ork;
			cout << "Ork";
			this->health += 25;
			break;
		default:
			break;
		}

		//Category
		cout << endl << "Enter category number of character: " << endl
			<< "1 - Warrior" << endl
			<< "2 - Magician" << endl
			<< "3 - Archer" << endl
			<< "4 - Healer" << endl;
		cin >> selec;

		switch (selec)
		{
		case 1:
			this->category = Categories::Warrior;
			cout << "Warrior";
			break;
		case 2:
			this->category = Categories::Magician;
			cout << "Magician";
			break;
		case 3:
			this->category = Categories::Archer;
			cout << "Archer";
			this->health;
			break;
		case 4:
			this->category = Categories::Healer;
			cout << "Healer";
			break;
		default:
			break;
		}
	}

	void print_charac()
	{
		cout << this->name << endl;

		//Race cout
		switch (this->race)
		{
		case Races::Human:
			cout << "Race: Human";
			break;
		case Races::Elf:
			cout << "Race: Elf";
			break;
		case Races::Dark_Elf:
			cout << "Race: Dark Elf";
			break;
		case Races::Ork:
			cout << "Race: Ork";
			break;
		default:
			break;
		}

		cout << endl;

		//Category cout
		switch (this->category)
		{
		case Categories::Warrior:
			cout << "Category: Warrior";
			break;
		case Categories::Magician:
			cout << "Category: Magician";
			break;
		case Categories::Archer:
			cout << "Category: Archer";
			this->health;
			break;
		case Categories::Healer:
			cout << "Category: Healer";
			break;
		}

		//Stats cout
		cout << endl << "HP: " << this->health << endl
			<< "DP: " << this->damage << endl
			<< "ShP: " << this->shield << endl;

		cout << endl << endl;
	}
	
	//Stats
	Races race{};
	Categories category{};
	uint8_t health = 90;
	uint8_t damage = 20;
	uint8_t shield = 15;
	string name{};
};

struct Team
{
	Character* team = new Character[4]{};
	string name{};

	void input()
	{
		cout << "\t\t<Create team>" << endl;

		cout << "Enter name of Team: ";
		cin >> this->name;

		for (size_t i = 0; i < 4; i++)
		{
			this->team[i].input();
		}

		system("cls");
	}

	void print()
	{
		cout << "Team " << this->name << endl
			<< "Number of players: 4" << endl
			<< "Players list: " << endl << endl;

		for (size_t i = 0; i < 4; i++)
		{
			this->team[i].print_charac();
		}
	}
};

void fight(Team, Team);
