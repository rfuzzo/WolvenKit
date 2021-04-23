#pragma once

#include <stdint.h>

namespace WolvenEngine
{
    class File
    {
    public:
        File() :m_size(0),m_buffer(nullptr), m_position(nullptr) {}
        ~File();

        bool open(const char* filename, const char* mode);
        void seek(long numBytes, int origin);
        size_t read(void* buffer, size_t size);
        long tell();

        template <class T>
        T read() { T* p = (T*)m_position; m_position += sizeof(T); return *p; }

        template <class T>
        T* read(size_t size) { T* p = (T*)m_position; m_position += sizeof(T) * size; return p; }

        template <class T>
        T getBuffer() { return (T)m_position; }

    private:
        size_t m_size;
        uint8_t* m_buffer;
        uint8_t* m_position;
    };
}