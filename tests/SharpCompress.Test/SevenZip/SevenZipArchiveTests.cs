using System;
using SharpCompress.Common;
using SharpCompress.Readers;
using Xunit;

namespace SharpCompress.Test.SevenZip
{
    public class SevenZipArchiveTests : ArchiveTests
    {
        [Fact]
        public void SevenZipArchive_Solid_StreamRead()
        {
            ArchiveStreamRead("7Zip.solid.7z");
        }
        [Fact]
        public void SevenZipArchive_NonSolid_StreamRead()
        {
            ArchiveStreamRead("7Zip.nonsolid.7z");
        }
        [Fact]
        public void SevenZipArchive_LZMA_StreamRead()
        {
            ArchiveStreamRead("7Zip.LZMA.7z");
        }

        [Fact]
        public void SevenZipArchive_LZMA_PathRead()
        {
            ArchiveFileRead("7Zip.LZMA.7z");
        }

        [Fact]
        public void SevenZipArchive_LZMAAES_StreamRead()
        {
            ArchiveStreamRead("7Zip.LZMA.Aes.7z", new ReaderOptions() { Password = "testpassword" });
        }

        [Fact]
        public void SevenZipArchive_LZMAAES_PathRead()
        {
            ArchiveFileRead("7Zip.LZMA.Aes.7z", new ReaderOptions() { Password = "testpassword" });
        }
        [Fact]
        public void SevenZipArchive_LZMAAES_NoPasswordExceptionTest()
        {
            Assert.Throws(typeof(CryptographicException), () => ArchiveFileRead("7Zip.LZMA.Aes.7z", new ReaderOptions() { Password = null })); //was failing with ArgumentNullException not CryptographicException like rar
        }
        [Fact]
        public void SevenZipArchive_PPMd_StreamRead()
        {
            ArchiveStreamRead("7Zip.PPMd.7z");
        }

        [Fact]
        public void SevenZipArchive_PPMd_StreamRead_Extract_All()
        {
            ArchiveStreamReadExtractAll("7Zip.PPMd.7z", CompressionType.PPMd);
        }

        [Fact]
        public void SevenZipArchive_PPMd_PathRead()
        {
            ArchiveFileRead("7Zip.PPMd.7z");
        }

        [Fact]
        public void SevenZipArchive_LZMA2_StreamRead()
        {
            ArchiveStreamRead("7Zip.LZMA2.7z");
        }

        [Fact]
        public void SevenZipArchive_LZMA2_PathRead()
        {
            ArchiveFileRead("7Zip.LZMA2.7z");
        }

        [Fact]
        public void SevenZipArchive_LZMA2AES_StreamRead()
        {
            ArchiveStreamRead("7Zip.LZMA2.Aes.7z", new ReaderOptions { Password = "testpassword" });
        }

        [Fact]
        public void SevenZipArchive_LZMA2AES_PathRead()
        {
            ArchiveFileRead("7Zip.LZMA2.Aes.7z", new ReaderOptions { Password = "testpassword" });
        }

        [Fact]
        public void SevenZipArchive_BZip2_StreamRead()
        {
            ArchiveStreamRead("7Zip.BZip2.7z");
        }

        [Fact]
        public void SevenZipArchive_BZip2_PathRead()
        {
            ArchiveFileRead("7Zip.BZip2.7z");
        }

        [Fact]
        public void SevenZipArchive_LZMA_Time_Attributes_PathRead()
        {
            ArchiveFileReadEx("7Zip.LZMA.7z");
        }

        [Fact]
        public void SevenZipArchive_BZip2_Split()
        {
            Assert.Throws<InvalidOperationException>(() => ArchiveStreamRead(null, "Original.7z.001",
                                                                             "Original.7z.002",
                                                                             "Original.7z.003",
                                                                             "Original.7z.004",
                                                                             "Original.7z.005",
                                                                             "Original.7z.006",
                                                                             "Original.7z.007"));
        }

        //Same as archive as Original.7z.001 ... 007 files without the root directory 'Original\' in the archive - this caused the verify to fail
        [Fact]
        public void SevenZipArchive_BZip2_Split_Working()
        {
            ArchiveStreamMultiRead(null, "7Zip.BZip2.split.001",
                                        "7Zip.BZip2.split.002",
                                        "7Zip.BZip2.split.003",
                                        "7Zip.BZip2.split.004",
                                        "7Zip.BZip2.split.005",
                                        "7Zip.BZip2.split.006",
                                        "7Zip.BZip2.split.007");
        }

        //will detect and load other files
        [Fact]
        public void SevenZipArchive_BZip2_Split_FirstFileRead()
        {
            ArchiveFileRead("7Zip.BZip2.split.001");
                                        //"7Zip.BZip2.split.002",
                                        //"7Zip.BZip2.split.003",
                                        //"7Zip.BZip2.split.004",
                                        //"7Zip.BZip2.split.005",
                                        //"7Zip.BZip2.split.006",
                                        //"7Zip.BZip2.split.007"
        }


    }
}
