#include <iostream>
using namespace std;

struct phone
{
	enum processor { Exynos, Snapdragon, MediaTec, Bionic }; // definition of data type

	char* make{};
	char* model{};
	uint16_t RAM{};
	processor cpu{}; // usage of data type
}*maga;


char* write_phone(phone* p)
{
	char* make = p->make;
	char* model = p->model;
	char* ram = new char[2]{};
	_itoa_s(p->RAM, ram, 3, 10);
	char* result = new char[1024]{};

	int i = 0;
	for (int j = 0; i < strlen(make); ++i, ++j)
	{
		result[i] = make[j];
	}
	result[i] = ' ';
	++i;


	for (int j = 0; j < strlen(model); ++i, ++j)
	{
		result[i] = model[j];
	}
	result[i] = ' ';
	++i;

	for (int j = 0; j < strlen(ram); ++i, ++j)
	{
		result[i] = ram[j];
	}
	return result;
}

int main()
{
	phone* p1 = new phone{ new char[10] {"Iphone"},new char[3] {"13"}, 4, phone::Bionic };

	FILE* file;

	fopen_s(&file, "data.txt", "w");

	if (file)
	{
		fputs(write_phone(p1), file);
	}

	if (file)
	{
		fclose(file);
	}


	fopen_s(&file, "data.txt", "r");

	char* buffer = new char[1024]{};

	fgets(buffer, 1024, file);

	cout << buffer;

	char* make_get = new char[10]{};
	char* model_get = new char[4]{};
	char ram_get;
	char enum_get;

	for (size_t i = 0, j = 0; i < 1024; i++, j++)
	{
		while (buffer[i] != '\0' && buffer[i] != ' ')
		{
			make_get[j] = buffer[i];
		}

		j = 0;
		i++;

		while (buffer[i] != '\0' && buffer[i] != ' ')
		{
			model_get[j] = buffer[i];
		}

		j = 0;
		i++;

		while (buffer[i] != '\0' && buffer[i] != ' ')
		{
			ram_get = buffer[i];
		}

		j = 0;
		i++;

		while (buffer[i] != '\0' && buffer[i] != ' ')
		{
			enum_get = buffer[i];
		}
	}

	uint16_t ram_get_int = ram_get - '0';
	int enum_get_int = enum_get - '0';

	phone* p_get = new phone{};

	switch (enum_get_int)
	{
	case 0:
		p_get = new phone{ make_get, model_get, ram_get_int, phone::Exynos };
		break;
	case 1:
		p_get = new phone{ make_get, model_get, ram_get_int, phone::Snapdragon };
		break;
	case 2:
		p_get = new phone{ make_get, model_get, ram_get_int, phone::MediaTec };
		break;
	case 3:
		p_get = new phone{ make_get, model_get, ram_get_int, phone::Bionic };
		break;
	default:
		cout << "ERROR" << endl;
		break;

	}

	cout << p_get;

	fopen_s(&file, "data.txt", "w");

	if (file)
	{
		fputs(write_phone(p_get), file);
	}

	if (file)
	{
		fclose(file);
	}

	return 0;
}
