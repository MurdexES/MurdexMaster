#include <iostream>
#include <string.h>
#include <iterator>
#include <map>
using namespace std;

class Product
{
public:
    string name{};
    float price{};

    Product() = default;
    Product(string name, float price)
    {
        this->name = name;
        this->price = price;
    }
};

int main()
{
    map<int, Product> items_list;
    map<int, Product>::iterator it;

    int len{};

    cout << "Enter length: ";
    cin >> len;

    items_list.insert(pair<int, Product>(1, "Cola"));
    items_list.insert(pair<int, Product>(2, "Snikers"));
    items_list.insert(pair<int, Product>(3, "Nestle"));

    it = items_list.find('b');

    if (it == items_list.end())
        cout << "Key-value pair not present in map";
    else
        cout << "Key-value pair present : "
        << it->first << "->" << it->second.name;

    return 0;
}

