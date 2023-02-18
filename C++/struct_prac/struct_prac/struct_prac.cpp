#include <iostream>
using namespace std;

struct Washing_machine
{
    char* make = new char[15]{"Samsung"};
    char* color = new char[15]{"Black"};
    int width = 600;
    int len = 600;
    int height = 850;
    int power = 2000;
    int speed_pushup = 1400;
    int temprature = 30;

    void print()
    {
        cout << "Make: " << make << ". Color: " << color << ". WxLxH: " << width << 'x' << len << 'x' << height << ". Power consumption: " << power << ". Spin resolutions: " << speed_pushup << ". Temprature: " << temprature << endl;
    }

};

struct Iron
{
    char* make = new char[15]{ "Bosch" };
    char* model = new char[15]{ "Steam 6" };
    char* color = new char[15]{ "Silver" };
    int power = 2400;
    int temprature_min = 30;
    int temptature_max = 90;
    bool steam = 1;



    void print()
    {
        cout << "Make: " << make << ". Model: " << model << ". Color: " << color << ". Power: " << power << ". Temprature min and max: " << temprature_min << ' ' << temptature_max << ". Steam:" << steam << endl;
    }

};

struct Boiler
{
    char* make = new char[15]{ "Bosch" };
    char* color = new char[15]{ "Silver" };
    int power = 2400;
    int temprature = 30;
    int volume = 30;

    	Car () // Constructor, Default constructor
	{
		cout << "Enter make: " << endl;
		cin.getline(make, 30);
		cout << "Enter model: " << endl;
		cin.getline(model, 30);
		cout << "Enter year: " << endl;
		cin >> year;
	}

    void print()
    {
        cout << "Make: " << make << ". Color: " << color << ". Power: " << power << ". Temprature: " << temprature << ". Volume: " << volume << endl;
    }

};

struct animal
{
    char* name {};
    char* kind {};
    char* sound{};

    animal() 
    {
        cout << "Enter name: " << endl;
        cin.getline(name, 30);
        cout << "Enter kind: " << endl;
        cin.getline(kind, 30);
        cout << "Enter sound: " << endl;
        cin.getline(sound, 30);
    }

    void print()
    {
        cout << "Name: " << name << ". Kind: " << kind << ". Sound: " << sound << endl;
    }

    void sound()
    {
        cout << sound << endl;
    }
};

int main()
{
    Washing_machine wm1;
    wm1.print();
    
    Iron ir;
    ir.print();

    Boiler bl;
    bl.print();


    return 0;
}
