using iTunesLib;

namespace iTunes_RPC
{
    internal class iTunesInfo
    {
        public static string getSongName()
        {
            var iTunes = new iTunesApp();
            var tr = iTunes.CurrentTrack;
            if (tr != null)
            {
                return tr.Name;
            }
            return "No Song Playing";
        }

        public static string getSongArtist()
        {
            var iTunes = new iTunesApp();
            var tr = iTunes.CurrentTrack;
            if (tr != null)
            {
                return tr.Artist;
            }
            return "";
        }

        public static int getSongCurrentTime()
        {
            var iTunes = new iTunesApp();
            var tr = iTunes.CurrentTrack;
            if (tr != null)
            {
                return iTunes.PlayerPosition;
            }
            return 0;
        }

        public static int getSongEndTime()
        {
            var iTunes = new iTunesApp();
            var tr = iTunes.CurrentTrack;
            if (tr != null)
            {
                return tr.Duration;
            }
            return 0;
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

        public static bool isPlaying()
        {
            var iTunes = new iTunesApp();
            return iTunes.PlayerState == ITPlayerState.ITPlayerStatePlaying;
        }

        public static bool isPaused()
        {
            return !isPlaying();
        }
    }
}