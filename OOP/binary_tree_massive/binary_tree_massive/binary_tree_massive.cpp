#include <iostream>
using namespace std;

struct Node
{
	int length{};
	int* value = new int[length]{};
	Node* right;
	Node* left;

	Node() = default;
	Node(int length) { this->value = new int[length]{}; this->right = nullptr; this->left = nullptr; }
};

class Binary_Tree
{
public:

	Binary_Tree() = default;
	Binary_Tree(uint16_t size) { this->size = size + 1; }


	void add(int length)
	{
		Node* tmp_comp = this->root;
		Node* new_item = new Node(length);

		if (this->root == 0)
		{
			this->root = new_item;
		}

		else
		{
			if (new_item->length > this->root->length && new_item->length != this->root->length)
			{
				tmp_comp = tmp_comp->right;

				while (new_item->length > tmp_comp->length && new_item->length != tmp_comp->length)
				{
					tmp_comp = tmp_comp->right;
				}

				new_item->right = tmp_comp;
				new_item->left = tmp_comp->left;
			}

			else if (new_item->length < this->root->length && new_item->length != this->root->length)
			{
				tmp_comp = tmp_comp->left;

				while (new_item->length < tmp_comp->length && new_item->length != tmp_comp->length)
				{
					tmp_comp = tmp_comp->left;
				}

				new_item->right = tmp_comp;
				new_item->left = tmp_comp->left;
			}

			else if (length == this->root->length)
			{
				cout << "Repeatition" << endl;
			}

			else
			{
				cout << "ERROR" << endl;
			}
		}
	}

	Node* get_ptr_search(int* value)
	{
		Node* current = this->root;
		Node* tmp = new Node{};

		if (value == this->root->value)
		{
			return this->root;
		}

		else
		{
			if (sizeof(value) > this->root->length)
			{
				current = current->right;

				while (value != current->value && current->right != nullptr)
				{
					current = current->right;
				}

				if (value == current->value)
				{
					return current;
				}

				else
				{
					cout << "There are no value like that.";
					return 0;
				}

			}

			else if (sizeof(value) > this->root->length)
			{
				current = current->left;

				while (value != current->value && current->left != nullptr)
				{
					current = current->left;
				}

				if (value == current->value)
				{
					return current;
				}

				else
				{
					cout << "There are no value like that.";
					return nullptr;
				}

			}
		}
	}

	void remove(int* value)
	{
		Node* tmp = nullptr;

		tmp = get_ptr_search(value);

		tmp->left = tmp->left->left;
		tmp->right = tmp->right->right;

		tmp->right = nullptr;
		tmp->left = nullptr;

		cout << "Successfuly deleted" << endl;
	}

	uint16_t size{};
	Node* root{};
};

int main()
{


	return 0;
}
