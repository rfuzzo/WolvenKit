#include "file.h"
#include <iostream>
#include <fstream>
//#include <zlib/zlib.h>
#include <libdeflate/libdeflate.h>
#include <lz4/lib/lz4.h>
#include <doboz/Decompressor.h>

namespace WolvenEngine
{
#ifdef USE_POOL
    FilePool* FilePool::s_instance = nullptr;

    FilePool* FilePool::instance()
    {
        if (!s_instance)
            s_instance = new FilePool();

        return s_instance;
    }

    FilePool::FilePool() 
    :m_size(1024*1024*50)
    {
        m_buffer = (uint8_t*)malloc(m_size);
    }

    FilePool::~FilePool()
    {
        m_size = 0;
        if (m_buffer)
        {
            free(m_buffer);
            m_buffer = nullptr;
        }
    }

    uint8_t* FilePool::getBuffer(size_t sz)
    {
        if (sz <= m_size)
            return m_buffer;

        // else resize!
        m_size = sz;
        uint8_t* newBuffer = (uint8_t*)realloc(m_buffer, m_size);
        if (newBuffer != nullptr)
        {
            m_buffer = newBuffer;
        }
        return m_buffer;
    }
#endif

    File::~File()
    {
#ifndef USE_POOL
        if (!m_shared && m_buffer)
        {
            free(m_buffer);
            m_buffer = nullptr;
        }
#endif
    }

    bool File::open(const char* filename, const char* /*mode*/)
    {
        std::ifstream file(filename, std::ios::ate | std::ios::binary);
        if (!file.is_open())
        {
            return false;
        }

        //find what the size of the file is by looking up the location of the cursor
        //because the cursor is at the end, it gives the size directly in bytes
        m_size = (size_t)file.tellg();

#ifdef USE_POOL
        m_buffer = FilePool::instance()->getBuffer(m_size);
#else
        m_buffer = (uint8_t*)malloc(m_size);
#endif

        //put file cursor at beginning
        file.seekg(0);

        //load the entire file into the buffer
        file.read((char*)m_buffer, m_size);

        //now that the file is loaded into the buffer, we can close it
        file.close();

        m_position = m_buffer;
        return true;
    }

    bool File::open(uint8_t* data, uint32_t compressedSize, uint32_t uncompressedSize, Compression compression)
    {
        m_size = uncompressedSize;
        if (uncompressedSize == compressedSize)
            compression = Compression::NONE;

        // uncompress the data!
        switch (compression)
        {
        case Compression::LZ4:
            {
#ifdef USE_POOL
                m_buffer = FilePool::instance()->getBuffer(m_size);
#else
                m_buffer = (uint8_t*)malloc(m_size);
#endif
                LZ4_decompress_safe((const char*)data, (char *)m_buffer, compressedSize, uncompressedSize);
                break;
            }
        case Compression::DOBOZ:
            {
#ifdef USE_POOL
                m_buffer = FilePool::instance()->getBuffer(m_size);
#else
                m_buffer = (uint8_t*)malloc(m_size);
#endif
                doboz::Decompressor decompressor;
                decompressor.decompress(data, compressedSize, m_buffer, uncompressedSize);
                break;
            }
        case Compression::ZLIB:
            {
#ifdef USE_POOL
                m_buffer = FilePool::instance()->getBuffer(m_size);
#else
                m_buffer = (uint8_t*)malloc(m_size);
#endif
                //unsigned long destSize = uncompressedSize;
                //uncompress(m_buffer, &destSize, data, compressedSize);
                struct libdeflate_decompressor* d = libdeflate_alloc_decompressor();

                size_t destSize = 0;
                libdeflate_zlib_decompress(d, data, compressedSize, m_buffer, uncompressedSize, &destSize);

                libdeflate_free_decompressor(d);
                break;
            }
        case Compression::NONE:
        default:
            m_buffer = data;
            m_shared = true;
            break;
        }

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