using iTunesLib;

namespace iTunes_RPC
{
    internal class iTunesInfo
    {
        public static string getSongName()
        {
            var iTunes = new iTunesApp();
            return iTunes.CurrentTrack.Name;
        }

        public static string getSongArtist()
        {
            var iTunes = new iTunesApp();
            return iTunes.CurrentTrack.Artist;
        }

        public static int getSongCurrentTime()
        {
            var iTunes = new iTunesApp();
            return iTunes.PlayerPosition;
        }

        public static int getSongEndTime()
        {
            var iTunes = new iTunesApp();
            return iTunes.CurrentTrack.Duration;
        }

        public void pauseSong()
        {
            var iTunes = new iTunesApp();
            iTunes.Pause();
        }

        public void playSong()
        {
            var iTunes = new iTunesApp();
            iTunes.Play();
        }

        public void nextSong()
        {
            var iTunes = new iTunesApp();
            iTunes.NextTrack();
        }

        public void previousSong()
        {
            var iTunes = new iTunesApp();
            iTunes.PreviousTrack();
        }
    }
}