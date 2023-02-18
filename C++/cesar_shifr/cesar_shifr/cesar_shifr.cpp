#include <iostream>
using namespace std;

int main()
{
	FILE* file;
	
	fopen_s(&file, "data.txt", "w");

	char text[100]{};

	cout << "Enter what you want to change: " << endl;
	cin.getline(text, 100);

	int len = strlen(text) + 1;
	
	if (file)
	{
		fputs(text, file);
	}
	
	if (file)
	{
		fclose(file);
	}

	//Read
	fopen_s(&file, "data.txt", "r");
	
	char* text_read = new char[len]{};
	
	if (file)
	{
		fgets(text_read, len, file);
	}
	
	if (file)
	{
	 	fclose(file);
	}


	cout << "Original: " << text_read << endl;

	for (size_t i = 0; i < len; i++)
	{
		int value = text_read[i];

		if (text_read[i] != '\0')
		{
			value += 2;
		}

		text_read[i] = value;
	}

	cout << text_read;

	//Append
	fopen_s(&file, "data.txt", "a");

	if (file)
	{
		fputs(text_read, file);
	}

	if (file)
	{
		fclose(file);
	}

	return 0;
}
