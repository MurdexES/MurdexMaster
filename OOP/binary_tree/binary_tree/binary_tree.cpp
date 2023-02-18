#include <iostream>
using namespace std;

struct Node
{
	int value;
	Node* right;
	Node* left;

	Node() = default;
	Node(int value) { this->value = value; this->right = nullptr; this->left = nullptr; }
};

class Binary_Tree
{
public:

	Binary_Tree() = default;
	Binary_Tree(uint16_t size) { this->size = size + 1; }

	
	void add(int value)
	{
		Node* tmp_comp = this->root;
		Node* new_item = new Node(value);

		if (this->root == 0)
		{
			this->root->value = value;
		}

		else
		{
			if (new_item->value > this->root->value && new_item->value != this->root->value)
			{
				tmp_comp = tmp_comp->right;

				while (new_item->value > tmp_comp->value && new_item->value != tmp_comp->value)
				{
					tmp_comp = tmp_comp->right;
				}

				new_item->right = tmp_comp;
				new_item->left = tmp_comp->left;
			}

			else if (new_item->value < this->root->value && new_item->value != this->root->value)
			{
				tmp_comp = tmp_comp->left;

				while (new_item->value < tmp_comp->value && new_item->value != tmp_comp->value)
				{
					tmp_comp = tmp_comp->left;
				}

				new_item->right = tmp_comp;
				new_item->left = tmp_comp->left;
			}

			else if (value == this->root->value)
			{
				cout << "Repeatition" << endl;
			}

			else
			{
				cout << "ERROR" << endl;
			}
		}
	}

	int search(int value)
	{
		Node* current = this->root;
		Node* tmp = new Node{};

		if (value == this->root->value)
		{
			return value;
		}

		else
		{
			if (value > this->root->value)
			{
				current = current->right;

				while (value != current->value && current->right != nullptr)
				{
					current = current->right;
				}

				if (value == current->value)
				{
					return value;
				}

				else
				{
					cout << "There are no value like that.";
					return 0;
				}
				
			}

			else if (value > this->root->value)
			{
				current = current->left;

				while (value != current->value && current->left != nullptr)
				{
					current = current->left;
				}

				if (value == current->value)
				{
					return value;
				}

				else
				{
					cout << "There are no value like that.";
					return 0;
				}

			}
		}
	}

	Node* get_ptr_search(int value)
	{
		Node* current = this->root;
		Node* tmp = new Node{};

		if (value == this->root->value)
		{
			return this->root;
		}

		else
		{
			if (value > this->root->value)
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

			else if (value > this->root->value)
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

	void remove(int value)
	{
		Node* tmp = nullptr;

		tmp = get_ptr_search(value);

		tmp->left = tmp->left->left;
		tmp->right = tmp->right->right;

		tmp->right = nullptr;
		tmp->left = nullptr;

		cout << "Successfuly deleted" << endl;
	}

	void edit()
	{
		int value{};
		int value_src{};
		Node* old_place = nullptr;

		cout << "Enter value you want to find: " << endl;
		cin >> value_src;

		old_place = get_ptr_search(value_src);

		cout << "Enter value that will change old one: " << endl;
		cin >> value;

		old_place->left = old_place->left->left;
		old_place->right = old_place->right->right;

		old_place->right = nullptr;
		old_place->left = nullptr;

		add(value);
	}


	uint16_t size{};
	Node* root{};
};

int main()
{


    return 0;
}
