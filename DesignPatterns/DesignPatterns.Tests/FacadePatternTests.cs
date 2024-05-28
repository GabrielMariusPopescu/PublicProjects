using System.Diagnostics.CodeAnalysis;
using DesignPatterns.Business.FacadePattern;
using NUnit.Framework;

namespace DesignPatterns.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class FacadePatternTests
    {
        [SetUp]
        public void Init()
        {
            facade = new Converter();
        }

        [Test]
        public void FacadeIsCalledForAudioMixer()
        {
            facade.Convert<AudioMixer>();

            Assert.Equals("AudioMixer", facade.Format);
            Assert.Equals("AudioMixer has been converted with the filename AudioMixer", facade.Name);
        }

        [Test]
        public void FacadeIsCalledForBitrateMixer()
        {
            facade.Convert<BitrateReader>();

            Assert.Equals("BitrateReader", facade.Format);
            Assert.Equals("BitrateReader has been converted with the filename BitrateReader", facade.Name);
        }

        [Test]
        public void FacadeIsCalledForCodecFactory()
        {
            facade.Convert<CodecFactory>();

            Assert.Equals("CodecFactory", facade.Format);
            Assert.Equals("CodecFactory has been converted with the filename CodecFactory", facade.Name);
        }

        [Test]
        public void FacadeIsCalledForMpeg4CompressionCodec()
        {
            facade.Convert<Mpeg4CompressionCodec>();

            Assert.Equals("Mpeg4CompressionCodec", facade.Format);
            Assert.Equals("Mpeg4CompressionCodec has been converted with the filename Mpeg4CompressionCodec", facade.Name);
        }

        [Test]
        public void FacadeIsCalledForOggCompressionCodec()
        {
            facade.Convert<OggCompressionCodec>();

            Assert.Equals("OggCompressionCodec", facade.Format);
            Assert.Equals("OggCompressionCodec has been converted with the filename OggCompressionCodec", facade.Name);
        }

        [Test]
        public void FacadeIsCalledForVideoFile()
        {
            facade.Convert<VideoFile>();

            Assert.Equals("VideoFile", facade.Format);
            Assert.Equals("VideoFile has been converted with the filename VideoFile", facade.Name);
        }

        //

        private Converter facade;
    }
}
