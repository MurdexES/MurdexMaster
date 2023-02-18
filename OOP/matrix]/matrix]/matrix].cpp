#include <iostream>
#include <vector>
#include <time.h>
using namespace std;

template <typename T>
class Matrix
{
public:
    Matrix() = default;

    Matrix(int rows, int cols)
    {
        this->rows = rows;
        this->cols = cols;
        this->arr = arr[rows][cols];
    }

    void input()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                cout << "Enter element of matrix: ";
                cin >> this->arr[i][j];
            }
        }
    }

    void print()
    {
        for (int i = 0; i < this->rows; i++)
        {
            for (int j = 0; j < this->cols; j++)
            {
                cout << this->arr[i][j] << " ";
            }

            cout << endl;
        }
    }

    T** rand_matrix()
    {
        srand(time(0));

        cout << "Enter number of rows: ";
        cin >> this->rows;

        cout << "Enter number of cols: ";
        cin >> this->cols;

        for (int i = 0; i < this->rows; i++)
        {
            for (int j = 0; j < this->cols; j++)
            {
                this->arr[i][j] = rand() % 10;
            }
        }

        return this->arr;
    }

    void clean()
    {
        delete[] this->arr;

        cout << "Matrix successfuly deleted."
    }

    void min_max_matrix()
    {
        int min = this->arr[0][0];
        int max = this->arr[this->rows - 1][this->cols - 1];
        for (int i = 0, int j = 0; i < this->rows, j < this->cols; ++i, ++j)
        {
            if (this->arr[i][j] < min)
                min = this->arr[i][j];
            if (this->arr[i][j] > max)
                max = this->arr[i][j];
        }

        cout << "Max: " << max << " " << "Min: " << min << endl;
    }

    Matrix operator() + (Matrix mtx)
    {
        Matrix tmp{};

        if (mtx.rows == rows && mtx.cols == cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    tmp.arr[i][j] = mtx.arr[i][j] + arr[i][j];
                }
            }
        }

        else
        {
            cout << "ERROR";
        }

        tmp.rows = rows;
        tmp.cols = cols;

        return tmp;
    }

    Matrix operator() - (Matrix mtx)
    {
        Matrix tmp{};

        if (mtx.rows == rows && mtx.cols == cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    tmp.arr[i][j] = mtx.arr[i][j] - arr[i][j];
                }
            }
        }

        else
        {
            cout << "ERROR";
        }

        tmp.rows = rows;
        tmp.cols = cols;

        return tmp;
    }

    Matrix operator() * (Matrix mtx)
    {
        Matrix tmp{};

        if (mtx.rows == rows && mtx.cols == cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    tmp.arr[i][j] = mtx.arr[i][j] * arr[i][j];
                }
            }
        }

        else
        {
            cout << "ERROR";
        }

        tmp.rows = rows;
        tmp.cols = cols;

        return tmp;
    }

    Matrix operator() / (Matrix mtx)
    {
        Matrix tmp{};

        if (mtx.rows == rows && mtx.cols == cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    tmp.arr[i][j] = mtx.arr[i][j] / arr[i][j];
                }
            }
        }

        else
        {
            cout << "ERROR";
        }

        tmp.rows = rows;
        tmp.cols = cols;

        return tmp;
    }

private:
    int rows{};
    int cols{};
    T** arr = new T * [rows] {};
};

template <typename T>
class Queue
{
public:
    Queue() = default;
    Queue(uint16_t length)
    {
        this->length = length;
    }
    Queue(initializer_list<T> list)
    {
        this->length = list.size();
        this->arr = new T[this->length]{};

        int j = 0;
        for (auto i = list.begin(); i < list.end(); ++i, ++j)
        {
            arr[j] = *i;
        }
    }

    uint16_t get_len()
    {
        return  this->length;
    }
    void print_queue()
    {
        for (int i = 0; i < this->length; ++i)
        {
            cout << arr[i] << ' ';
        }
        cout << endl;
    }
    T pop_back()
    {
        if (this->length >= 1)
        {

            uint16_t new_length = this->length - 1;

            T result = this->arr[new_length];

            T* tmp = new T[new_length];

            for (int i = 0; i < new_length; ++i)
            {
                tmp[i] = this->arr[i];
            }

            delete[]this->arr;

            this->arr = new int[new_length] {};

            for (int i = 0; i < new_length; ++i)
            {
                this->arr[i] = tmp[i];
            }

            delete[] tmp;
            this->length = new_length;

            return result;
        }
        return  0;
    }

    T append(T item = 0)
    {
        uint16_t new_length = this->length + 1;

        T* tmp = new T[new_length];

        for (int i = 0; i < this->length; ++i)
        {
            tmp[i] = this->arr[i];
        }

        for (int i = 0; i < new_length; i++)
        {
            if (i == new_length - 1)
            {
                tmp[i] = item;
                break;
            }
        }

        delete[]this->arr;

        this->arr = new int[new_length] {};

        for (int i = 0; i < new_length; ++i)
        {
            this->arr[i] = tmp[i];
        }

        delete[] tmp;
        this->length = new_length;

        return item;
    }
private:
    uint16_t length{ 5 };
    T* arr = new T[length]{};
};

int main()
{


    return EXIT_SUCCESS;
}
