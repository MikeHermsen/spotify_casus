using System;  
using System.Collections.Generic;


namespace spotify {

    class MediaController {  

        public List<int> song_list = new List<int> {};  

        private int current_song = 0;
        private DateTime src_time = DateTime.Now;
        // Maak functie die shuffled toggled bool
        private bool shuffle    = false;
        // Maak functie die replay toggled bool
        private bool replay    = false;
        private bool isPaused    = false;
        private int pause_minus_time = 0;
        private int total_pause_time = 0;
        private int pause_on_time   = 0;

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
            this.pause_on_time = 0;
            this.total_pause_time = 0;
        }
            

        public int refreshPauseLogic()
        {
            if (isPaused)
            {
                this.pause_minus_time = getRunTime() - this.pause_on_time;  
                return this.pause_minus_time;
            }
            return 0;
        }

        public void togglePauseSong() 
        {
            isPaused        = !isPaused;
            if (isPaused) {
                this.pause_on_time = getRunTime(); 
                return;
            }   

            this.pause_minus_time = getRunTime() - this.pause_on_time;  
            this.total_pause_time = this.total_pause_time + this.pause_minus_time;

            Console.WriteLine($"pause_on_time : {this.pause_on_time} , pause_minus_time : {this.pause_minus_time}");

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

            int time_left = (song_model.duration - getRunTime()) + (this.total_pause_time + refreshPauseLogic());
            
            
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

        public void playSongWithID(int song_id, AuthModel Auth)
        {
            resetRunTime();
            if (Auth.songExistInDict(song_id)) this.current_song = song_id;
            Console.WriteLine("Liedje bestaat niet");
        
        }
        public void addSongWithID(int song_id, AuthModel Auth)
        {
            if (this.song_list.Contains(song_id)) return;
            if (Auth.songExistInDict(song_id)) this.song_list.Add(song_id);
            Console.WriteLine("Liedje bestaat niet");

        }


        public void removePlaySongWithID(int song_id)
        {
            if (this.song_list.Contains(song_id)) {
                this.song_list.Remove(song_id);
                return;
            }
        }

        public void currentSongPlaying(AuthModel Auth) 
        { 
            updateSongLogic(Auth);

            Console.WriteLine("");
            if (this.isPaused) 
            {
                Console.WriteLine("--------[PAUSED]-------");
            } else {
                Console.WriteLine("--------[PLAYING]-------");
            }
            Console.WriteLine("");
            
            if (this.current_song == 0) 
            {
                Console.WriteLine($"No songs are playing");
                return;
            }

            SongModel song_model = Auth.getCurrentSongByID(this.current_song);
            
            int time_left = (song_model.duration - getRunTime()) + (this.total_pause_time + refreshPauseLogic());
            
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