using System.Runtime.InteropServices;
using System.Security.Cryptography;
using static хеши.Programm;

namespace хеши
{
    class Programm
    {
        public class Track
        {
            public string Departure { get; set; }
            public string Destination { get; set; }
            public int TrackNumber { get; set; }

        }
        static void Main()
        {
            List<string> Track_List = new List<string> { "Russia", "USA", "China", "Germany", "Ausrtia", "Australia", "Canada", "Iran", "Iraq", "France", "Italy", "Poland", "Ukraine", "Spain", "Great Britain", "Ireland", "Mexico", "Brazil", "Denmark", "Japan" };
            List<Track> Tracks = new List<Track>();
            Track[] trackArray = new Track[20];
            List<Track>[] hash = new List<Track>[41];
            for (int h = 0;  h < hash.Length; h++) 
            {
                hash[h] = new List<Track>();
            }
            int i = 0;
            int m = 0;
            int c = 0;
            Random random = new Random();
            
            do
            {
                Console.Clear();
                Console.WriteLine("Choose option:");
                Console.WriteLine("1. Create array");
                Console.WriteLine("2. Print array");
                Console.WriteLine("3. Create Hash table");
                Console.WriteLine("4. Print Hash table");
                Console.WriteLine("5. Find track by track number");
                Console.WriteLine("6. Add track");
                Console.WriteLine("7. Delete track by track number");
                int.TryParse(Console.ReadLine(), out int sw);
                switch (sw)
                {
                    case 1:
                        Console.Clear();
                        for (i = 0; i < 20; i++)
                        {
                            Track track = new Track
                            {
                                Departure = Track_List[random.Next(Track_List.Count)],
                                Destination = Track_List[random.Next(Track_List.Count)],
                                TrackNumber = random.Next(1000, 10000)
                            };
                            Tracks.Add(track);
                        }
                        Console.WriteLine("Массив записей создан");
                        Console.WriteLine(new string('-', 20 + 20 + 20 + 4));
                        Console.WriteLine("|{0,20}|{1,20}|{2,20}|", "Departure", "Destination", "Track Number");
                        Console.WriteLine(new string('-', 20 + 20 + 20 + 4));
                        foreach (var track in Tracks)
                        {
                            Console.WriteLine("|{0,20}|{1,20}|{2,20}|", track.Departure, track.Destination, track.TrackNumber);
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(new string('-', 20 + 20 + 20 + 4));
                        Console.WriteLine("|{0,20}|{1,20}|{2,20}|", "Departure", "Destination", "Track Number");
                        Console.WriteLine(new string('-', 20 + 20 + 20 + 4));
                        foreach (var track in Tracks)
                        {
                            Console.WriteLine("|{0,20}|{1,20}|{2,20}|", track.Departure, track.Destination, track.TrackNumber);
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Choose method:\n0. Division\n1. Mid-squares");
                        int.TryParse(Console.ReadLine(), out m);
                        Console.Clear();
                        Console.WriteLine("Choose colision reduction method:\n0. Open indexing\n1. Chain method");
                        int.TryParse(Console.ReadLine(), out c);

                        if (c == 0)
                        {
                           hash = Open_Indexing(Tracks, m);
                        }
                        else
                        {
                           hash = Chain_Method(Tracks, m);
                        }
                        Console.Clear();
                        Console.WriteLine("Hash table was created");
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine(new string('-',5 + 10 + 40));
                        Console.WriteLine("{0,5}|{1,3}", "index", "keys");
                        Console.WriteLine(new string('-', 5 + 10 + 40));
                        i = 0;
                        foreach(var trackList in hash)
                        {
                            
                            if (trackList.Count!=0)
                            {
                                Console.Write("{0,5}:",i);
                                foreach (var track in trackList)
                                {
                                    Console.Write($"{track.TrackNumber} -> ");
                                }
                                Console.WriteLine();
                            }
                            i++;
                        }
                        break;
                        
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Enter track number:");
                        int.TryParse(Console.ReadLine(), out int trackToFind);
                        Console.Clear();
                        var t = 0;
                        var flag = false;
                        if(m == 0)
                        {
                            int index = Division(trackToFind);
                            while (t < hash[index].Count && !flag)
                            {
                                if (trackToFind == hash[index][t].TrackNumber)
                                {
                                    flag = true;
                                    Console.WriteLine(new string('-', 5 + 20 + 20 + 20 + 4));
                                    Console.WriteLine("{0,5}|{1,20}|{2,20}|{3,20}|", "Index", "Departure", "Destination", "Track Number");
                                    Console.WriteLine(new string('-',5 + 20 + 20 + 20 + 4));
                                    Console.WriteLine("{0,5}|{1,20}|{2,20}|{3,20}|", index, hash[index][t].Departure, hash[index][t].Destination, hash[index][t].TrackNumber);
                                }
                                else t++;
                            }
                            if (!flag)
                            {
                                Console.WriteLine("Track number not found!");
                            }
                        }
                        else
                        {
                            int index = Mid_squares(trackToFind);
                            while (t < hash[index].Count && !flag)
                            {
                                if (trackToFind == hash[index][t].TrackNumber)
                                {
                                    flag = true;
                                    Console.WriteLine(new string('-', 5 + 20 + 20 + 20 + 4));
                                    Console.WriteLine("{0,5}|{1,20}|{2,20}|{3,20}|", "Index", "Departure", "Destination", "Track Number");
                                    Console.WriteLine(new string('-',5 + 20 + 20 + 20 + 4));
                                    Console.WriteLine("{0,5}|{1,20}|{2,20}|{3,20}|", index, hash[index][t].Departure, hash[index][t].Destination, hash[index][t].TrackNumber);
                                }
                                else t++;
                            }
                            if (!flag)
                            {
                                Console.WriteLine("Track number not found!");
                            }
                        }
                        break;
                    case 6:
                        Console.Clear();
                        Track tempTrack = new Track();
                        Console.WriteLine("Departure:");
                        tempTrack.Departure = Console.ReadLine();
                        Console.WriteLine("Destination:");
                        tempTrack.Destination = Console.ReadLine();
                        Console.WriteLine("Track Number:");
                        int.TryParse(Console.ReadLine(), out int tempNumber);
                        tempTrack.TrackNumber = tempNumber;
                        Tracks.Add(tempTrack);
                        if(c == 0)
                        {
                            hash = Open_Indexing(Tracks, m);
                            Console.WriteLine("Track was added");
                        }
                        else
                        {
                            hash = Chain_Method(Tracks, m);
                            Console.WriteLine("Track was added");
                        }
                        break;
                        
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Enter track number");
                        int.TryParse(Console.ReadLine(), out trackToFind);
                        Console.Clear();
                        t = 0;
                        flag = false;
                        
                        if (m == 0)
                        {
                            int index = Division(trackToFind);
                            while (t < hash[index].Count && !flag)
                            {
                                if (trackToFind == hash[index][t].TrackNumber)
                                {
                                    flag = true;
                                    var item = hash[index][t];
                                    hash[index].RemoveAt(t);
                                    Tracks.Remove(item);
                                    Console.WriteLine("Track was deleted!");
                                }
                                else t++;
                            }
                            if (!flag)
                            {
                                Console.WriteLine("Track number not found!");
                            }
                        }
                        else
                        {
                            int index = Mid_squares(trackToFind);
                            while (t < hash[index].Count && !flag)
                            {
                                if (trackToFind == hash[index][t].TrackNumber)
                                {
                                    flag = true;
                                    var item = hash[index][t];
                                    hash[index].RemoveAt(t);
                                    Tracks.Remove(item);
                                    Console.WriteLine("Track was deleted!");
                                }
                                else t++;
                            }
                            if (!flag)
                            {
                                Console.WriteLine("Track number not found!");
                            }
                        }
                        break;

                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        static int Division(int trackNumber)
        {
            int key = trackNumber;
            int i = (key % 23) + 1;
            return i;
        }
        static int Mid_squares(int trackNumber)
        {
            int key = trackNumber;
            string temp = Convert.ToString(key * key);
            int i = Convert.ToInt32(temp.Substring(temp.Length / 2, 2));
            double h = (i * 0.4);
            i = (int)Math.Round(h);
            return i;
        }
        static List<Track>[] Open_Indexing(List<Track> trackArray, int m)
        {
            List<Track>[] hash = new List<Track>[41];
            for (int h = 0; h < hash.Length; h++)
            {
                hash[h] = new List<Track>();
            }
            int i = 0;
            if (m == 0)
            {
                foreach (var track in trackArray)
                {
                    i = Division(track.TrackNumber);
                    if (hash[i].Count() == 0)
                    {
                        hash[i].Add(track);
                    }
                    else
                    {
                        while (i < hash.Length && hash[i].Count() != 0)
                        {
                            i++;
                            if (i >= hash.Length)
                            {
                                i = 0;
                            }
                        }
                        hash[i].Add(track);
                    }
                }
            }
            else
            {
                foreach (var track in trackArray)
                {
                    i = Mid_squares(track.TrackNumber);
                    if (hash[i].Count()==0)
                    {
                        hash[i].Add(track);
                    }
                    else
                    {
                        while (i < hash.Length && hash[i].Count!=0)
                        {
                            i++;
                            if (i >= hash.Length)
                            {
                                i = 0;
                            }
                        }
                        hash[i].Add(track);
                    }
                }
            }
            return hash;
        }
        static List<Track>[] Chain_Method(List<Track> trackArray, int m)
        {
            List<Track>[] hash = new List<Track>[41];
            for (int h = 0; h < hash.Length; h++)
            {
                hash[h] = new List<Track>();
            }
            
            if (m == 0)
            {
                foreach (var track in trackArray)
                {
                    hash[Division(track.TrackNumber)].Add(track);
                }
            }
            else
            {
                foreach (var track in trackArray)
                {
                    hash[Mid_squares(track.TrackNumber)].Add(track);
                }
            }
            return hash;
        }
    }
}