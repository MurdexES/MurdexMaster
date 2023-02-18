#include <iostream>
#include "Header.h"
using namespace std;

void fight(Team team1, Team team2)
{
	//Alive number
	int alive_team1{ 4 };
	int alive_team2{ 4 };

	//Team Show
	team1.print();
	team2.print();

	//Fight 
	for (size_t i = 0; i < 4; i++)
	{
		//Fight stats
		while (team1.team[i].health != 0 || team2.team[i].health != 0)
		{
			team1.team[i].health += team1.team[i].shield;
			team1.team[i].health -= team2.team[i].damage;

			team2.team[i].health += team2.team[i].shield;
			team2.team[i].health -= team1.team[i].damage;
		}

		//Fight comments
		if (team1.team[i].health == 0 && team2.team[i].health == 0)
		{
			cout << "No one won the battle. " << team1.team[i].name << " and " << team2.team[i].name << " killed each other." << endl;
			alive_team1 -= 1;
			alive_team2 -= 1;
		}

		else if (team1.team[i].health == 0)
		{
			cout << "Team 2`s player won battle. " << team2.team[i].name << " killed " << team1.team[i].name << endl;
			alive_team1 -= 1;
		}

		else if (team2.team[i].health == 0)
		{
			cout << "Team 1 won first battle. " << team1.team[i].name << " killed " << team2.team[i].name << endl;
			alive_team2 -= 1;
		}
	}
	
	//Results overall
	if (alive_team1 == 0 && alive_team2 == 0)
	{
		cout << "\t\t<<DRAW>>" << endl;

		cout << "No one alive.";
	}

	else if (alive_team1 == 0)
	{
		cout << endl << "\t\t<<TEAM 2 WON>>" << endl;

		cout << "Alive from the winner team: " << endl;

		for (size_t i = 4 - alive_team2; i < 4; i++)
		{
			team2.team[i].print_charac();
		}
	}

	else if (alive_team2 == 0)
	{
		cout << endl << "\t\t<<TEAM 1 WON>>" << endl;

		cout << "Alive from the winner team: " << endl;

		for (size_t i = 4 - alive_team1; i < 4; i++)
		{
			team1.team[i].print_charac();
		}
	}
}
