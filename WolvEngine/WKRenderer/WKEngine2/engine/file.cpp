#include "file.h"
//#include <stdio.h>
//#include <stdlib.h>
#include <iostream>
#include <fstream>

namespace WolvenEngine
{
    File::~File()
    {
        if (m_buffer)
        {
            free(m_buffer);
            m_buffer = nullptr;
        }
    }

    bool File::open(const char* filename, const char* mode)
    {
        std::ifstream file(filename, std::ios::ate | std::ios::binary);
        if (!file.is_open())
        {
            return false;
        }

        //find what the size of the file is by looking up the location of the cursor
        //because the cursor is at the end, it gives the size directly in bytes
        m_size = (size_t)file.tellg();

        m_buffer = (uint8_t*)malloc(m_size);

        //put file cursor at beggining
        file.seekg(0);

        //load the entire file into the buffer
        file.read((char*)m_buffer, m_size);

        //now that the file is loaded into the buffer, we can close it
        file.close();

        m_position = m_buffer;
        return true;
    }

    void File::seek(long numBytes, int origin)
    {
        if (origin == SEEK_CUR)
            m_position += numBytes;
        else if (origin == SEEK_SET)
            m_position = m_buffer + numBytes;
    }

    size_t File::read(void* buffer, size_t size)
    {
        memcpy(buffer, m_position, size);
        m_position += size;
        return size;
    }

    long File::tell()
    {
        return (long)(m_position - m_buffer);
    }
}