using System;  
using System.Collections.Generic;


namespace spotify {

    class MediaController {  

        public List<int> song_list;
        public int current_song = 0;
        private DateTime src_time = DateTime.Now;

        public MediaController()
        {
        }

        private int convertTimeToSeconds(int given_hour, int given_minute, int given_second)
        {
            
            int hour        = given_hour * 360; 
            int minutes     = given_minute * 60;
        
            return given_second + minutes + hour;
        }
        
        private void resetRunTime()
        {
            this.src_time = DateTime.Now;
        }
            
        public int getRunTime()
        {

            DateTime time_holder = DateTime.Now;
            int start_run_time = convertTimeToSeconds(this.src_time.Hour, this.src_time.Minute, this.src_time.Second);
            int current_run_time = convertTimeToSeconds(time_holder.Hour, time_holder.Minute, time_holder.Second);
            return current_run_time - start_run_time;
        }
        
        public void importSongsFromList(List<int> new_list)
        {

        }

        public void updateSongLogic(AuthModel auth_model)
        {

            if (this.current_song == 0) 
            {
                return;
            }

            SongModel song_model = auth_model.getCurrentSongByID(this.current_song);

            int time_playing = getRunTime() - song_model.duration;
            int time_left = song_model.duration - getRunTime();

            if (time_left > 0) {
                goToNextSong(auth_model);
            }
            
        }


        public void goToNextSong(AuthModel auth_model) 
        {
            song_list.Remove(this.current_song);
            if (song_list.Count == 0) {
                Console.WriteLine("Play random song from auth");
            }
        }

        public void playSongWithID(int song_id)
        {
            resetRunTime();
            this.current_song = song_id;
            song_list.Add(song_id);
        }

        public int currentSongPlaying() 
        { 
            return this.current_song;
        }


    }
}