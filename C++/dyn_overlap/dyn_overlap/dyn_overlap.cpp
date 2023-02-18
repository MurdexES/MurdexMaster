#include <iostream>
#include <time.h>

using namespace std;



template <typename T>
void unique(T* A, T* B, T*& arr_res)
{
	int len1 = sizeof(A);
	int len2 = sizeof(B);

	int* tmp_arr = new int[len1]{};

	int count = 0;
	bool key{};

	for (size_t i = 0; i < len1; i++)
	{
		for (size_t j = 0; j < len2; j++)
		{
			if (*(A + i) == *(B + j))
			{
				key = true;
			}
		}

		if (!key)
		{
			*(tmp_arr + i) = *(A + i);
		}
	}

	for (size_t i = 0; i < len1; i++)
	{
		*(arr_res + i) = *(tmp_arr + i);
	}

	for (size_t i = 0; i < len1; i++)
	{
		cout << *(arr_res + i) << " ";
	}

	cout << endl;
}


template <typename T>
void unique_for_all(T* A, T* B, T*& arr_res)
{
	int len1 = sizeof(A);
	int len2 = sizeof(B);

	int* tmp_arr = new int[len1];

	int count = 0;

	size_t keypoint = 0;

	for (size_t i = 0, keypoint = 0; i < len1; i++, keypoint++)
	{
		for (size_t j = 0; j < len2; j++)
		{
			if (*(A + i) != *(B + j))
			{
				++count;
			}
		}

		if (count >= len2)
		{
			*(tmp_arr + keypoint) = *(A + i);
		}
	}

	for (size_t i = 0; i < len2; i++, keypoint++)
	{
		for (size_t j = 0; j < len1; j++)
		{
			if (*(B + i) != *(A + j))
			{
				++count;
			}
		}

		if (count >= len1)
		{
			*(tmp_arr + keypoint) = *(B + i);
		}
	}

	for (size_t i = 0; i < len1; i++)
	{
		*(arr_res + i) = *(tmp_arr + i);
	}
	
	for (size_t i = 0; i < len1; i++)
	{
		cout << *(arr_res + i) << " ";
	}

	cout << endl;
}

int main()
{
	srand(time(0));

	int M{};
	int N{};

	cout << "Enter M - length of first array, N - length of second array: ";
	cin >> M;
	cin >> N;

	int* A = new int[M]{};
	int* B = new int[N]{};
	int* arr_res = new int[M]{};
	int* arr_res2 = new int[M + N]{};


	for (size_t i = 0; i < M; i++)
	{
		*(A + i) = rand() % 10;
		cout << *(A + i) << ' ';
	}

	cout << endl;

	for (size_t i = 0; i < N; i++)
	{
		*(B + i) = rand() % 10;
		cout << *(B + i) << ' ';
	}

	cout << endl;


	unique(A, B, arr_res);
	unique_for_all(A, B, arr_res2);

	return 0;
}
