#pragma once

#include <stdint.h>

namespace WolvenEngine
{
#ifdef USE_POOL
    class FilePool
    {
    public:
        static FilePool* instance();

        uint8_t* getBuffer(size_t sz);

    private:
        FilePool();
        ~FilePool();

        size_t m_size;
        uint8_t* m_buffer;

        static FilePool* s_instance;
    };
#endif

    class File
    {
    public:
        File() :m_size(0),m_buffer(nullptr), m_position(nullptr), m_shared(false){}
        ~File();

        enum class Compression
        {
            NONE,
            ZLIB,
            SNAPPY,
            DOBOZ,
            LZ4
        };

        bool open(const char* filename, const char* mode);
        bool open(uint8_t* data, uint32_t compressedSize, uint32_t uncompressedSize, Compression compression);
        void seek(long numBytes, int origin);
        size_t read(void* buffer, size_t size);
        long tell();
        size_t size() { return m_size; }

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
        bool m_shared;
    };
}