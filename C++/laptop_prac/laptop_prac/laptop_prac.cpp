#include <iostream>
using namespace std;

struct Laptop
{
    char* make = new char[10]{};
    char* model = new char[20]{};
    char* CPU = new char[25]{};
    char* GPU = new char[25]{};
    char* ssd = new char[25]{};
};

struct Class
{
    int laptop_count{};
    char* laptop_name = new char[30]{};
};

Laptop create_laptop()
{
	Laptop tmp{};

	cout << "Enter make of Laptop: ";
	cin >> tmp.make;

	cout << "Enter model of Laptop: ";
	cin >> tmp.model;

	cout << "Enter CPU of Laptop: ";
	cin >> tmp.CPU;

	cout << "Enter GPU of Laptop: ";
	cin >> tmp.GPU;

	cout << "Enter SSD of Laptop: ";
	cin >> tmp.ssd;

	return tmp;
}

void add_to_class(Class* classroom, Laptop* list, int len)
{
	for (size_t i = 0; i < len; i++)
	{
		classroom[i].laptop_name = list[i].model;
		classroom[i].laptop_count = len;
	} 

	FILE* file;

	fopen_s(&file, "class.txt", "a");
	
	for (size_t i = 0; i < len; i++)
	{
		if (file)
		{
			fputs(classroom[i].laptop_name, file);
		}
	}

	if (file)
	{
		fclose(file);
	}
}

int main()
{
	int lap_count{};
	Laptop* list = new Laptop[lap_count]{};
	Class* classroom = new Class[lap_count]{};

	cout << "Enter number of laptops in class: " << endl;
	cin >> lap_count;

	for (size_t i = 0; i < lap_count; i++)
	{
		list[i] = create_laptop();
	}

	add_to_class(classroom, list, lap_count);

    return 0;
}
