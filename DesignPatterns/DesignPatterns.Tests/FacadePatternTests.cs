using DesignPatterns.Business.FacadePattern;
using NUnit.Framework;

namespace DesignPatterns.Tests
{
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

            Assert.AreEqual("AudioMixer", facade.Format);
            Assert.AreEqual("AudioMixer has been converted with the filename AudioMixer", facade.Name);
        }

        [Test]
        public void FacadeIsCalledForBitrateMixer()
        {
            facade.Convert<BitrateReader>();

            Assert.AreEqual("BitrateReader", facade.Format);
            Assert.AreEqual("BitrateReader has been converted with the filename BitrateReader", facade.Name);
        }

        [Test]
        public void FacadeIsCalledForCodecFactory()
        {
            facade.Convert<CodecFactory>();

            Assert.AreEqual("CodecFactory", facade.Format);
            Assert.AreEqual("CodecFactory has been converted with the filename CodecFactory", facade.Name);
        }

        [Test]
        public void FacadeIsCalledForMpeg4CompressionCodec()
        {
            facade.Convert<Mpeg4CompressionCodec>();

            Assert.AreEqual("Mpeg4CompressionCodec", facade.Format);
            Assert.AreEqual("Mpeg4CompressionCodec has been converted with the filename Mpeg4CompressionCodec", facade.Name);
        }

        [Test]
        public void FacadeIsCalledForOggCompressionCodec()
        {
            facade.Convert<OggCompressionCodec>();

            Assert.AreEqual("OggCompressionCodec", facade.Format);
            Assert.AreEqual("OggCompressionCodec has been converted with the filename OggCompressionCodec", facade.Name);
        }

        [Test]
        public void FacadeIsCalledForVideoFile()
        {
            facade.Convert<VideoFile>();

            Assert.AreEqual("VideoFile", facade.Format);
            Assert.AreEqual("VideoFile has been converted with the filename VideoFile", facade.Name);
        }

        //

        private Converter facade;
    }
}
