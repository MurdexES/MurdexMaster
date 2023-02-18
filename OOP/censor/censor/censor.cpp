#include <iostream>
#include <stdio.h>
#include <stdlib.h>

int main()
{
    int num = 0;

    cout << "Enter number: ";
    cin >> num;

    char const* name{};

    cout << "Enter name of : " << endl;
    cin >> name;

    if (3 != num)
    {
        fprintf(stderr, "Usage: ./a.out in-file out-reverse-file\n");
        return -1;
    }

    FILE* fp_in = fopen(name[1], "r");
    if (NULL == fp_in) return -2;

    FILE* fp_out = fopen(name[2], "w");
    if (NULL == fp_out) return -2;

    if (fseek(fp_in, 0, SEEK_END)) return -3;
    long int outpos = ftell(fp_in);
    if (fseek(fp_in, 0, SEEK_SET)) return -3;

    size_t line_size;

    char* line = NULL;

    size_t strcap;

    while ((line_size = getline(&line, &strcap, fp_in)) > 0)
    {
        outpos -= line_size;
        if (fseek(fp_out, outpos, SEEK_SET) != 0 || fputs(line, fp_out) == EOF)
            return -4;
    }

    free(line);

    return 0;
}