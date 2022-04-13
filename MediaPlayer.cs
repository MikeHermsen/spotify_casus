using System;  
using System.Collections.Generic;


namespace spotify {

    class MediaController {  

        public List<int> song_list;
        public int current_song;
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



        public int currentSongPlaying() 
        {
            return this.current_song;
        }


    }
}