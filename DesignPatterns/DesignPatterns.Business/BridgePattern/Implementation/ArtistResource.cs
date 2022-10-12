using DesignPatterns.Business.BridgePattern.Contracts;
using DesignPatterns.Business.BridgePattern.Models;

namespace DesignPatterns.Business.BridgePattern.Implementation
{
    public class ArtistResource : Artist, IResource
    {
        public ArtistResource(Artist artist) => this.artist = artist;

        public string Snippet() => artist.GetBio();

        //

        private readonly Artist artist;
    }
}
