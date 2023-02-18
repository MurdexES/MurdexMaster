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

class Complex
{
public:
    Complex() = default;

    Complex(int real_part, int imagenary_number, char imagenary_part)
    {
        this->real_part = real_part;
        this->imagenary_number = imagenary_number;
        this->imagenary_part = imagenary_part;
    }

    void input()
    {
        cout << "Enter real part: ";
        cin >> this->real_part;

        cout << "Enter imagenary number: ";
        cin >> this->imagenary_number;

        cout << "Enter imagenary part: ";
        cin >> this->imagenary_part;
    }

    void print()
    {
        if (real_part == 0 || imagenary_number == 0)
        {
            cout << '0';
        }
        else 
        {
            if (imagenary_number > 0)
            {
                cout << this->real_part << '+' << this->imagenary_number << this->imagenary_part;
            }

            else
            {
                cout << this->real_part << this->imagenary_number << this->imagenary_part;
            }
        }

    }

    Complex operator + (Complex& cplx)
    {
        Complex tmp{};

        tmp.real_part = real_part + cplx.real_part;
        
        tmp.imagenary_number = imagenary_number + cplx.imagenary_number;

        tmp.imagenary_part = imagenary_part;

        return tmp;
    }

    Complex operator - (Complex& cplx)
    {
        Complex tmp{};

        tmp.real_part = real_part - cplx.real_part;

        tmp.imagenary_number = imagenary_number - cplx.imagenary_number;

        tmp.imagenary_part = imagenary_part;

        return tmp;
    }

    Complex operator * (Complex& cplx)
    {
        Complex tmp{};

        tmp.real_part = ((real_part * cplx.real_part) - (imagenary_number * cplx.imagenary_number));

        tmp.imagenary_number = ((real_part * cplx.imagenary_number) + (imagenary_number * cplx.real_part));

        tmp.imagenary_part = cplx.imagenary_part;

        return tmp;
    }

    Complex operator / (Complex& cplx)
    {
        Complex tmp{};

        tmp.real_part = (((real_part) * (cplx.real_part)) + ((imagenary_number) * (cplx.imagenary_number))) / (pow(cplx.real_part, 2) + pow(cplx.imagenary_number, 2));
        tmp.imagenary_number = (((cplx.real_part) * (imagenary_number)) - ((real_part) * (cplx.imagenary_number))) / (pow(cplx.real_part, 2) + pow(cplx.imagenary_number, 2));

        tmp.imagenary_part = imagenary_part;

        return tmp;
    }
private:
    int real_part{};
    int imagenary_number{};
    char imagenary_part{};
};

int main()
{
    Complex f{};

    return EXIT_SUCCESS;
}
