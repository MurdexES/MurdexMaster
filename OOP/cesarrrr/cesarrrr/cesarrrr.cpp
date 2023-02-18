#include <iostream>
#include <fstream>
#include <string>
using namespace std;

#define step 5

string shrifting(string before)
{
	for (char i : before)
	{
		char(i) = char(int(char(i)) + step);
	}

	return before;
}

string unshrifting(string after)
{
	for (char i : after)
	{
		char(i) = char(int(char(i)) - step);
	}

	return after;
}

int main()
{
	string text_before;

	cout << "Enter text for cesar shrift: " << endl;
	getline(cin, text_before);

	string after = shrifting(text_before);
	cout << after;

	fstream write_file("data.txt", ios::out);
	write_file << after;

	fstream read_file("data.txt", ios::in);

	/*while (getline(read_file, text_after))
	{
		cout << text_after << endl;
	}*/

	

    return 0;
}
