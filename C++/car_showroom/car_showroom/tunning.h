#pragma once
#include <iostream>
#include "car.h"
#include "menu.h"
#include "showroom.h"

struct tunned
{
	Car origin{};

	char* engine = new char[25]{};
	char* rim = new char[35]{};
	char* platform = new char[25]{};
	int stage{};
	char* color = new char[10]{};
	int toning_stage{};

	void menuTunned(Car* cars);
};
