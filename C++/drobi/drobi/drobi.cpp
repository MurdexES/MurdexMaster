#include <iostream>
using namespace std;

class Fraction
{
public:
    Fraction() = default;

    Fraction(int numerator, int denominator)
    {
        this->numerator = numerator;
        this->denominator = denominator;
    }

    void print()
    {
        if (numerator == 0 || denominator == 0)
        {
            cout << '0';
        }
        else
        {
            cout << this->numerator << '/' << this->denominator;
        }
        
    }

    Fraction operator + (Fraction& frac)
    {
        Fraction tmp{};

        if (denominator == frac.denominator)
        {
            tmp.numerator = numerator + frac.numerator;
            tmp.denominator = denominator;
        }
        else if (denominator != frac.denominator)
        {
            tmp.denominator = denominator * frac.denominator;
            tmp.numerator = (numerator * frac.denominator) + (frac.numerator * denominator);
        }

        return tmp;
    }

    Fraction operator - (Fraction& frac)
    {
        Fraction tmp{};

        if (denominator == frac.denominator)
        {
            tmp.numerator = numerator - frac.numerator;
            tmp.denominator = denominator;
        }
        else if (denominator != frac.denominator)
        {
            tmp.denominator = denominator * frac.denominator;
            tmp.numerator = (numerator * frac.denominator) - (frac.numerator * denominator);
        }

        return tmp;
    }

    Fraction operator * (Fraction& frac)
    {
        Fraction tmp{};

        tmp.numerator = numerator * frac.numerator;
        tmp.denominator = denominator * frac.denominator;

        return tmp;
    }

    Fraction operator / (Fraction& frac)
    {
        Fraction tmp{};

        tmp.numerator = numerator * frac.denominator;
        tmp.denominator = denominator * frac.numerator;

        return tmp;
    }
private:
    int numerator{};
    int denominator{};
};


int main()
{
    Fraction fr1(1, 2);
    Fraction fr2(4, 8);

    fr1 = fr1 - fr2;

    fr1.print();

    return EXIT_SUCCESS;
}
