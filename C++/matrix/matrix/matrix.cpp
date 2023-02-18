#include <iostream>
using namespace std;

template <typename T>
void square_matrix(int len, T type)
{
    int A[len][len];
    for (int i = 0; i < len; i++) {
        for (int j = 0; j < len; j++) {
            cin >> A[i][j];
        }
    }

    for (int i = 0; i < len; i++) {
        for (int j = 0; j < len; j++) {
            cout << A[i][j] << " ";
        }
    }
}

template <typename T>
void min_max_matrix(T a[][5], int len, T type)
{
    int min = a[0][0];
    int max = a[len - 1][len - 1];
    for (int i = 0, int j = 0; i < n, j < m; ++i, ++j)
    {
        if (a[i][j] < min)
            min = a[i][j];
        if (a[i][j] > max)
            max = a[i][j];
    }

    cout << "Max: " << max << " " << "Min: " << min << endl;
}

template <typename T>
void sort_matrix(T a[][5], int len, T type)
{
    int tmp = 0;
    for (int i = 0; i < len; i++)
    {
        for (int j = 0; j < len; j++)
        {
            if (a[i][j] < a[i][j - 1])
            {
                int tmp = a[i][j];
                a[i][j] = a[i][j - 1];
                a[i][j - 1] = tmp;
            }
            cout << i << ":" << a[i][j] << '\t';
        }
        cout << '\n';
    }
}

int nod(int num1, int num2)
{
    if (num2 == 0)
        return num1;
    if (num1 > num2)
        return nod(num2, num1 % num2);
    else
        return nod(num1, num2 % num1);
}

int main()
{
    int len = 0;

    cout << "Enter len of it: ";
    cin >> len;

    int num1 = 0;
    int num2 = 0;

    cout << "Enter 2 numbers: ";
    cin >> num1;
    cin >> num2;

    cout << "This is nod: " << nod(num1, num2);

    return 0;
}