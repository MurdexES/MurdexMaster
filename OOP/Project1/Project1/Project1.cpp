#include <iostream>
using namespace std;

template <typename T>
class List
{
public:
	void print_stack()
	{
		for (int i = 0; i < this->length; ++i)
		{
			std::cout << arr[i] << ' ';
		}
		std::cout << std::endl;
	}
private:

};

int main()
{
    return 0;
}
