#include <iostream>
using namespace std;

int main()
{
    FILE* file{};
    FILE* file_words{};


    char* text_origin = new char[150]{};
    char* text_new = new char[150]{};
    char* text_words = new char[100]{};

    char* path_origin = new char[50]{};
    char* path_words = new char[50]{};

    char** word_list = new char*[50]{};


    cout << "Enter path to file with txt: ";
    cin.getline(path_origin, 50);

    cout << "Enter path to file with restricted words: ";
    cin.getline(path_words, 50);


    fopen_s(&file, path_origin, "r");
    fopen_s(&file_words, path_words, "r");



    if (file_words)
    {
        fgets(text_words, 100, file_words);
    }

    if (file)
    {
        fgets(text_origin, 150, file);
    }


    size_t idx{};

    for (size_t i = 0, j = 0; i < 100; i++, j++)
    {
        if(text_words[i] != ' ')
        {
            word_list[idx][j] = text_words[i];
        }

        j = 0;
        idx++;
    }

    if (file_words)
    {
        fclose(file_words);
    }

    if (file)
    {
        fclose(file);
    }


    int count{};
    for (size_t index = 0; index < 50; index++)
    {
        for (size_t i = 0; i < 150; i++)
        {
            if (text_origin != );
        }
    }

    return EXIT_SUCCESS;
}
