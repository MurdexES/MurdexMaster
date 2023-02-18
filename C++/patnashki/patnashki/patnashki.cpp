#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <time.h> 
#include <iostream>
using namespace std;
typedef unsigned short u_short;
typedef unsigned int u_int;
typedef enum Direction { up, down, right, left } Direction;
u_short barr[4][4];
u_short CurX, CurY;

//create field 
void CreateField() {
	u_short arr[16], n, i, buf, k = 0;
	bool flag = false;
	srand(time(NULL));
	for (n = 0; n < 16; ) {
		flag = false;
		buf = rand() % 16 + 1;
		for (i = 0; i < n; i++) {
			if (arr[i] == buf) {
				flag = true;
				break;
			}
		}
		if (!flag) {
			arr[n] = buf;
			n++;
		}
	}
	for (n = 0; n < 4; n++)
		for (i = 0; i < 4; i++) {
			barr[n][i] = arr[k];
			k++;
		}
	barr[3][3] = 0;
	CurX = 3; CurY = 3;
	return;
}

// movement
void Move(Direction dir) {
	switch (dir) {
	case up:
		if (CurY > 0)
		{
			barr[CurY][CurX] = barr[CurY - 1][CurX];
			barr[CurY - 1][CurX] = 0;
			CurY--;
		}
		else
			cout << "VI VIXODITE S POLYA: DISKVALIFIKACIYA! \n\n";
		break;
	case down:
		if (CurY < 3)
		{
			barr[CurY][CurX] = barr[CurY + 1][CurX];
			barr[CurY + 1][CurX] = 0;
			CurY++;
		}
		else
			cout << "VI VIXODITE S POLYA: DISKVALIFIKACIYA! \n\n";
		break;
	case right:
		if (CurX < 3)
		{
			barr[CurY][CurX] = barr[CurY][CurX + 1];
			barr[CurY][CurX + 1] = 0;
			CurX++;
		}
		else
			printf("VI VIXODITE S POLYA: DISKVALIFIKACIYA! \n\n");
		break;
	case left:
		if (CurX > 0)
		{
			barr[CurY][CurX] = barr[CurY][CurX - 1];
			barr[CurY][CurX - 1] = 0;
			CurX--;
		}
		else
			cout << "VI VIXODITE S POLYA: DISKVALIFIKACIYA! \n\n";
		break;
	}
}

//print field
void coutArr() {
	for (u_int i = 0; i < 4; i++) {
		for (u_int j = 0; j < 4; j++) {
			printf("\t%d ", barr[i][j]);
		}
		printf("\n\n");
	}
	return;
}

//Win check
bool total() {
	u_short k = 1;
	bool flag = true;
	for (u_short i = 0; i < 4; i++) {
		for (u_short j = 0; j < 4; i++) {
			if (barr[i][j] != k % 16)
				flag = true;
			else {
				flag = false;
				break;
			}
			k++;
		}
	}
	return flag;
}

int main() {
	CreateField();
	coutArr();
	printf("Viberite napravleniye: w,a,s,d \n");
	while (!total()) {
		char key = getchar();
		switch (key)
		{
		case 119:
			Move(up);
			break;
		case 115:
			Move(down);
			break;
		case 100:
			Move(right);
			break;
		case 97:
			Move(left);
			break;
		case 27:
			printf("Silna\n");
			return 0;
			break;
		}
		coutArr();
	}
	printf(" ====MALADEC!NAJMI Esc CHOB VIYTI====  ");
	return 0;
}