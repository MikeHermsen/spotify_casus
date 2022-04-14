using System;  
using System.Collections.Generic;


namespace spotify {

    class MediaController {  

        public List<int> song_list = new List<int> {};  

        private int current_song = 0;
        private DateTime src_time = DateTime.Now;
        private bool shuffle    = false;
        private bool replay    = false;

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
            this.current_song = new_list[0];
            this.song_list = new_list;
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
            
            if (time_left < 0) {
                goToNextSong(auth_model);
            }
            
        }


        public void goToNextSong(AuthModel auth_model) 
        {

            resetRunTime();


            if (this.replay)
            {
                return;
            }
            
            else if (this.shuffle) 
            {
                Random rnd = new Random();
                int random_track  = rnd.Next(0, this.song_list.Count);
                this.current_song = this.song_list[random_track];
                return;
            } 
            else 
            {
                
                if (this.song_list.Count != 0)
                {
                    this.song_list.Remove(this.current_song);
                    if (this.song_list.Count != 0)
                    {
                        this.current_song = this.song_list[0];
                        return;
                    }
                }
            }

            Console.WriteLine("No songs queue!");
            this.current_song = 0;

        }

        public void playSongWithID(int song_id)
        {
            resetRunTime();
            this.current_song = song_id;
            this.song_list.Add(song_id);
        }

        public void currentSongPlaying(AuthModel Auth) 
        { 
            updateSongLogic(Auth);

            Console.WriteLine("");
            Console.WriteLine("----------------------");
            Console.WriteLine("");
            
            if (this.current_song == 0) 
            {
                Console.WriteLine($"No songs are playing");
                return;
            }

            SongModel song_model = Auth.getCurrentSongByID(this.current_song);
            
            int time_left = song_model.duration - getRunTime();
            
            Console.WriteLine($"id:       {this.current_song}     ");
            Console.WriteLine($"title:      {song_model.title}     ");
            Console.WriteLine($"duration:   {song_model.duration}  ");
            Console.WriteLine($"artist:     {song_model.artist}-{Auth.getUsername(song_model.artist)}    ");
            Console.WriteLine($"time left:  {time_left}             ");
            Console.WriteLine($"genre:      {song_model.genre}     ");

            Console.WriteLine();

            if (this.song_list.Count-1 != 0) 
            {
                Console.WriteLine($"==== Songs in Qeueu ====");
                foreach (int song_id in this.song_list)
                {
                    
                    if (song_id == this.current_song ) continue;

                    SongModel queue_song_model = Auth.getCurrentSongByID(song_id);
                    Console.WriteLine();
                    
                    Console.WriteLine($"id:       {song_id}     ");
                    Console.WriteLine($"title:      {queue_song_model.title}     ");
                    Console.WriteLine($"duration:   {queue_song_model.duration}  ");
                    Console.WriteLine($"artist:     {queue_song_model.artist}-{Auth.getUsername(queue_song_model.artist)}    ");
                    Console.WriteLine($"genre:      {queue_song_model.genre}     ");

                    Console.WriteLine();

                }
            }

        }


    }
}