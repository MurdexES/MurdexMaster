#include <iostream>
#include <vector>
using namespace std;

template <typename T>
class Dequeue
{
public:
	Dequeue() = default;
	Dequeue(uint16_t length)
	{
		this->length = length;
	}
	Dequeue(initializer_list<T> list)
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
	void print_dequeue()
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

	T pop_front()
	{
		if (this->length >= 1)
		{

			uint16_t new_length = this->length - 1;

			T first_result = this->arr[length];

			T* tmp = new T[new_length];

			for (int i = 0; i < new_length; ++i)
			{
				tmp[i] = this->arr[i + 1];
			}

			T second_result = this->arr[new_length];

			delete[]this->arr;

			this->arr = new int[new_length] {};

			for (int i = 0; i < new_length; ++i)
			{
				this->arr[i] = tmp[i];
			}

			delete[] tmp;
			this->length = new_length;

			return second_result;
		}
		return  0;
	}

	T prepend(T item = 0)
	{
		uint16_t new_length = this->length + 1;

		T* tmp = new T[new_length];
	
		for (int i = 1; i < new_length; ++i)
		{
			tmp[i] = this->arr[i - 1];
		}

		tmp[0] = item;
				 
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
	Dequeue<int> my_dequeue{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

	my_dequeue.print_dequeue();


	cout << my_dequeue.pop_back() << endl;
	cout << my_dequeue.get_len() << endl;

	cout << my_dequeue.pop_front() << endl;
	cout << my_dequeue.get_len() << endl;

	cout << my_dequeue.prepend(9) << endl;
	cout << my_dequeue.get_len() << endl;

	cout << my_dequeue.append(9) << endl;
	cout << my_dequeue.get_len() << endl;

	my_dequeue.print_dequeue();

	return EXIT_SUCCESS;
}
