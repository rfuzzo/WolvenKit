#include "cr2w.h"

// byte-align structures
#if defined(_MSC_VER) || defined(__BORLANDC__) || defined (__BCPLUSPLUS__)
#	pragma warning(disable: 4103)
#	pragma pack( push, packing )
#	pragma pack( 1 )
#	define PACK_STRUCT
#endif

namespace WolvenEngine
{
    const int32_t WITCHER_3 = 162;
    struct CR2WTable
    {
        uint32_t offset;
        uint32_t itemCount;
        uint32_t crc32;
    };

    struct contentInfo
    {
        uint16_t dataType;
        uint16_t objectFlags;
        uint32_t parentID;
        int32_t contentSize;
        int32_t contentAddress;
        uint32_t utemplate;
        uint32_t crc32;
    };

    //bool hasEnding(std::string const& fullString, std::string const& ending)
    //{
    //    if (fullString.length() >= ending.length()) {
    //        return (0 == fullString.compare(fullString.length() - ending.length(), ending.length(), ending));
    //    }
    //    else {
    //        return false;
    //    }
    //}

    bool readCR2W(File& fp, std::vector<std::string>& labels, std::vector<std::string>& fileNames, std::vector<ContentInfo>& contents)
    {
        fp.seek(4, SEEK_SET); // CR2W
        if (fp.read<uint32_t>() < WITCHER_3)
        {
            return false;
        }

        fp.seek(32, SEEK_CUR);

        CR2WTable* tables = fp.read<CR2WTable>(10);

        const char* p = fp.getBuffer<const char *>();

        for (uint32_t i = 0; i < tables[1].itemCount; ++i)
        {
            labels.emplace_back(p);
            p += labels.back().size() + 1;
        }

        for (uint32_t i = 0; i < tables[2].itemCount; ++i)
        {
            fileNames.emplace_back(p);
            p += fileNames.back().size() + 1;
        }

        // now read in the content
        fp.seek(tables[4].offset, SEEK_SET);

        contentInfo* ci = fp.getBuffer<contentInfo*>();

        for (uint32_t i = 0; i < tables[4].itemCount; ++i, ++ci)
        {
            ContentInfo content;
            content.address = ci->contentAddress;
            content.type = (uint32_t)ci->dataType;
            content.end = ci->contentAddress + ci->contentSize;

            contents.emplace_back(content);
        }

        fp.seek(sizeof(contentInfo) * tables[4].itemCount, SEEK_CUR);
        return true;
    }

    bool readCR2W(File& fp, std::vector<std::string>& labels, std::vector<std::string>& fileNames, std::vector<std::string>& tileNames, std::vector<ContentInfo>& contents)
    {
        fp.seek(4, SEEK_SET); // CR2W
        if (fp.read<uint32_t>() < WITCHER_3)
        {
            return false;
        }

        fp.seek(32, SEEK_CUR);

        CR2WTable* tables = fp.read<CR2WTable>(10);

        const char* p = fp.getBuffer<const char*>();
        uint32_t terrainTileLabel = 0;

        for (uint32_t i = 0; i < tables[1].itemCount; ++i)
        {
            if (strcmp(p, "CTerrainTile") == 0)
            {
                terrainTileLabel = i;
            }
            labels.emplace_back(p);
            p += labels.back().size() + 1;
        }

        for (uint32_t i = 0; i < tables[2].itemCount; ++i)
        {
            fileNames.emplace_back(p);
            p += fileNames.back().size() + 1;
        }

        // find the type for the files and just get the terrain ones
        fp.seek(tables[2].offset, SEEK_SET);
        for (uint32_t i = 0; i < tables[2].itemCount; ++i)
        {
            fp.seek(sizeof(uint32_t), SEEK_CUR);

            if (fp.read<uint16_t>() == terrainTileLabel)
            {
                tileNames.push_back(fileNames[i]);
            }

            fp.seek(sizeof(uint16_t), SEEK_CUR);
        }

        // now read in the content

        fp.seek(tables[4].offset, SEEK_SET);

        contentInfo* ci = fp.getBuffer<contentInfo*>();

        for (uint32_t i = 0; i < tables[4].itemCount; ++i, ++ci)
        {
            ContentInfo content;
            content.address = ci->contentAddress;
            content.type = (uint32_t)ci->dataType;
            content.end = ci->contentAddress + ci->contentSize;

            contents.emplace_back(content);
        }

        fp.seek(sizeof(contentInfo)* tables[4].itemCount, SEEK_CUR);
        return true;
    }

    bool readWTER(File& fp, uint32_t lod, uint32_t& tileLOD, uint32_t& tileResolution)
    {
        bool rc = false;

        fp.seek(4, SEEK_SET); // CR2W
        if (fp.read<uint32_t>() < WITCHER_3)
        {
            return rc;
        }

        fp.seek(32, SEEK_CUR);

        std::vector<std::string> labels;
        CR2WTable* tables = fp.read<CR2WTable>(10);

        const char* p = fp.getBuffer<const char*>();

        for (uint32_t i = 0; i < tables[1].itemCount; ++i)
        {
            labels.emplace_back(p);
            p += labels.back().size() + 1;
        }

        // now read in the content

        fp.seek(tables[4].offset, SEEK_SET);

        contentInfo* pci = fp.getBuffer<contentInfo*>();
        std::vector<ContentInfo> contents;

        for (uint32_t i = 0; i < tables[4].itemCount; ++i, ++pci)
        {
            ContentInfo content;
            content.address = pci->contentAddress;
            content.type = (uint32_t)pci->dataType;
            content.end = pci->contentAddress + pci->contentSize;

            contents.emplace_back(content);
        }

        fp.seek(sizeof(contentInfo) * tables[4].itemCount, SEEK_CUR);

        for (size_t i = 0; i < contents.size(); ++i)
        {
            ContentInfo& ci = contents[i];

            if (labels[ci.type] == "CTerrainTile")
            {
                fp.seek(ci.address + 1, SEEK_SET);

                //TODO: better way to skip all this data
                Variable var;
                while (readVariable(fp, var))
                {
                    // tileFileVersion
                    // collisionType
                    // maxHeightValue
                    // minHeightValue
                    fp.seek(var.end, SEEK_SET);
                }

                uint32_t nbProperties = tables[3].itemCount;

                for (uint32_t j = 0; j < nbProperties; ++j)
                {
                    struct GroupInfo
                    {
                        uint16_t lod1;
                        uint16_t lod2;
                        uint16_t lod3;
                        uint32_t resolution;
                    };

                    std::vector<GroupInfo> groupInfo;

                    uint32_t elementCount = fp.read<uint32_t>();

                    for (uint32_t k = 0; k < elementCount; ++k)
                    {
                        GroupInfo gi;
                        gi.lod1 = fp.read<uint16_t>();
                        gi.lod2 = fp.read<uint16_t>();
                        gi.lod3 = fp.read<uint16_t>();
                        gi.resolution = fp.read<uint32_t>();

                        groupInfo.emplace_back(gi);
                    }

                    if (lod < (uint32_t)groupInfo.size())
                    {
                        tileLOD = groupInfo[lod].lod1;
                        tileResolution = groupInfo[lod].resolution;
                        rc = true;
                    }
                }
            }
        }

        return rc;
    }

    bool readW2MI(File& fp, std::string& diffuseTexture, std::string& normalTexture)
    {
        fp.seek(4, SEEK_SET); // CR2W
        if (fp.read<uint32_t>() < WITCHER_3)
        {
            return false;
        }

        std::vector<std::string> labels;
        std::vector<std::string> fileNames;
        std::vector<ContentInfo> contents;
        fp.seek(32, SEEK_CUR);

        CR2WTable* tables = fp.read<CR2WTable>(10);

        const char* p = fp.getBuffer<const char*>();

        for (uint32_t i = 0; i < tables[1].itemCount; ++i)
        {
            labels.emplace_back(p);
            p += labels.back().size() + 1;
        }

        for (uint32_t i = 0; i < tables[2].itemCount; ++i)
        {
            fileNames.emplace_back(p);
            p += fileNames.back().size() + 1;
        }

        // now read in the content
        fp.seek(tables[4].offset, SEEK_SET);

        contentInfo* pci = fp.getBuffer<contentInfo*>();

        for (uint32_t i = 0; i < tables[4].itemCount; ++i, ++pci)
        {
            ContentInfo content;
            content.address = pci->contentAddress;
            content.type = (uint32_t)pci->dataType;
            content.end = pci->contentAddress + pci->contentSize;

            contents.emplace_back(content);
        }

        fp.seek(sizeof(contentInfo) * tables[4].itemCount, SEEK_CUR);

        for (size_t i = 0; i < contents.size(); ++i)
        {
            ContentInfo& ci = contents[i];

            if (labels[ci.type] == "CMaterialInstance")
            {
                fp.seek(ci.address + 1, SEEK_SET);

                while (fp.tell() < (long)ci.end)
                {
                    Variable matVar;
                    readVariable(fp, matVar);

                    if (labels[matVar.name] == "baseMaterial")
                    {
                        fp.seek(matVar.end, SEEK_SET);
                    }
                    else if (labels[matVar.name] == "enableMask")
                    {
                        fp.seek(matVar.end, SEEK_SET);
                    }
                    else
                    {
                        uint32_t nbProperties = fp.read<uint32_t>();

                        if (nbProperties > 0)
                        {
                            for (uint32_t j = 0; j < nbProperties; ++j)
                            {
                                long back = fp.tell();
                                uint32_t propSize = fp.read<uint32_t>();

                                uint16_t propId = fp.read<uint16_t>();
                                //uint16_t propTypeId = fp.read<uint16_t>();
                                fp.seek(sizeof(uint16_t), SEEK_CUR);

                                if (propId >= labels.size())
                                    break;

                                // texture type
                                int32_t textureLayer = -1;
                                if (labels[propId] == "Diffuse")
                                    textureLayer = 0;
                                else if (labels[propId] == "Normal")
                                    textureLayer = 1;

                                if (textureLayer != -1)
                                {
                                    uint8_t texId = fp.read<uint8_t>();
                                    texId = 255 - texId;

                                    if ((size_t)texId < fileNames.size())
                                    {
                                        if (textureLayer == 0)
                                            diffuseTexture = fileNames[texId];
                                        else
                                            normalTexture = fileNames[texId];
                                    }
                                }
                                fp.seek(back + propSize, SEEK_SET);
                            }
                        }
                    }
                }
            }
        }
        return true;
    }

    uint8_t* readXBM(File& fp, uint32_t& height, uint32_t& width, uint32_t& imageSize, uint32_t& mips, Format& format)
    {
        constexpr uint32_t MAGIC = 0x57325243; // "W2RC"
        if (fp.read<uint32_t>() != MAGIC)
            return nullptr;

        fp.seek(36, SEEK_CUR);

        std::vector<std::string> labels;
        CR2WTable* tables = fp.read<CR2WTable>(10);

        const char* p = fp.getBuffer<const char*>();

        for (uint32_t i = 0; i < tables[1].itemCount; ++i)
        {
            labels.emplace_back(p);
            p += labels.back().size() + 1;
        }

        fp.seek(tables[4].offset, SEEK_SET);
        contentInfo* ci = fp.getBuffer<contentInfo*>();

        fp.seek(ci->contentAddress + 1, SEEK_SET);

        // read variables
        const uint32_t texWidth = readVariable<uint32_t>(fp);
        const uint32_t texHeight = readVariable<uint32_t>(fp);
        const uint16_t compression = readVariable<uint16_t>(fp);
        const uint16_t textureGroup = readVariable<uint16_t>(fp);
        
        // could be a residentMipIndex or the textureCacheKey
        uint8_t residentMipIndex = 0;
        uint32_t textureCacheKey = 0;

        //uint16_t nameId = fp.read<uint16_t>();
        //uint16_t typeId = fp.read<uint16_t>();
        fp.seek(4, SEEK_CUR);
        uint32_t size = fp.read<uint32_t>();
        size -= 4;

        // textureCacheKey is at the end of the list of variables so either it IS the end or the residentMipIndex is before it
        if (size == 4)
        {
            textureCacheKey = fp.read<uint32_t>();
        }
        else if (size == 1)
        {
            residentMipIndex = fp.read<uint8_t>();
            textureCacheKey = readVariable<uint32_t>(fp);
        }

        fp.seek(6, SEEK_CUR);

        uint32_t mipsCount = fp.read<uint32_t>();

        struct MipData
        {
            uint32_t width;
            uint32_t height;
            uint32_t blocksize;
        } PACK_STRUCT;

        MipData* mipData = fp.getBuffer<MipData*>(); // max image size is 2048 x 2048 I hope...
        fp.seek(sizeof(MipData) * mipsCount, SEEK_CUR);

        uint32_t residentMipSize = fp.read<uint32_t>();
        fp.seek(4, SEEK_CUR); // skip unknown fields

        format = Format::DXT1;

        if (labels[compression] == "TCM_DXTAlpha")
        {
            format = Format::DXT5;
        }
        else if (labels[compression] == "TCM_NormalsGloss")
        {
            format = Format::DXT5;
        }

        height = mipData[residentMipIndex].height;
        width = mipData[residentMipIndex].width;

        imageSize = residentMipSize;
        mips = mipsCount - residentMipIndex;
        uint8_t* image = new uint8_t[residentMipSize];
        fp.read(image, residentMipSize);

        // caller must call delete on the image when done
        return image;
    }

    bool readVariable(File& fp, Variable& var)
    {
        var.name = fp.read<uint16_t>();
        if (var.name == 0)
            return false;

        var.type = fp.read<uint16_t>();

        long pos = fp.tell();
        uint32_t size = fp.read<uint32_t>();
        var.end = pos + size;
        return true;
    }

    template <class T>
    T readVariable(File& fp)
    {
        fp.seek(sizeof(uint16_t), SEEK_CUR); // nameId
        fp.seek(sizeof(uint16_t), SEEK_CUR); // typeId

#ifdef _DEBUG
        uint32_t size = fp.read<uint32_t>();
        assert(size - 4 == sizeof(T));
#else
        fp.seek(sizeof(uint32_t), SEEK_CUR);
#endif
        return fp.read<T>();
    }

    int32_t readVLQInt32(File& fp)
    {
        uint8_t b1 = fp.read<uint8_t>();

        bool sign = (b1 & 128) == 128;
        bool next = (b1 & 64) == 64;
        int size = b1 % 128 % 64;
        int offset = 6;

        while (next)
        {
            b1 = fp.read<uint8_t>();
            size = (b1 % 128) << offset | size;
            next = (b1 & 128) == 128;
            offset += 7;
        }

        return sign ? size * -1 : size;
    }
}
