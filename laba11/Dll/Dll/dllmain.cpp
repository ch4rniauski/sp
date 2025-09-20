#include <string.h>
#include "pch.h"

extern "C" __declspec(dllexport) int __cdecl CountVowels(const char* str)
{
    if (!str)
    {
        return 0;
    }

    const char* vowels = "aeiouyAEIOUY";
    int count = 0;

    for (const char* p = str; *p; ++p)
    {
        if (strchr(vowels, *p))
        {
            count++;
        }
    }

    return count;
}
