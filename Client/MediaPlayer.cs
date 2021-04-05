using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using LumenWorks.Framework.IO.Csv;
using CsvReader = LumenWorks.Framework.IO.Csv.CsvReader;
/*
Carl Haricombe 30019812
You have been hired as the new programmer by the Jupiter Mining Corporation to produce a test
program for the company, this program will be fully documented and tested.
With this project you are coming up with a program to show your range of skills and abilities to
your new boss.
You have been given an example of what your boss is expecting to see
the example they have given is an advanced music player that allows the ability to sort and search
the songs stored in a binary tree (any sort and search algorithm you select will have to be
approved if it is not merge sort and binary search), the GUI should display the sorted track list and
highlight and play the searched track, it should save the track list to a csv using a 3rd party library.
The music player must load and play files and met the requirements laid out in Question 3.
If you choose not to implement this proje
*/



namespace Client
{
    public partial class MediaPlayer : Form
    {
        public MediaPlayer()
        {
            InitializeComponent();
            PopulateListBox();
            PopulateLinkedList();
        }

        //creating a linked list for all songs in the system
        LinkedList<string> songlist = new LinkedList<string>();

        string song;

        //button to play the first song in the listbox
        private void Firstbtn_Click(object sender, EventArgs e)
        {
            try
            {
                song = songlist.First();
                DisplayCurrentSongTitle();
                PlaySound(song);
            }

            catch
            {
                MessageBox.Show("Error there is no first song");
            }
        }

        //button to play the next song in the listbox
        private void Nextbtn_Click(object sender, EventArgs e)
        {
            string songPlay = axWindowsMediaPlayer.URL;
            try
            {
                song = songlist.Find(songPlay).Next.Value;
                DisplayCurrentSongTitle();
                PlaySound(song);
            }

            catch
            {
                MessageBox.Show("Error there is no next song");
            }
        }

        //button to play the previous song in the listbox
        private void Previousbtn_Click(object sender, EventArgs e)
        {
            string songPlay = axWindowsMediaPlayer.URL;
            try
            {
                song = songlist.Find(songPlay).Previous.Value;
                DisplayCurrentSongTitle();
                PlaySound(song);
            }

            catch
            {
                MessageBox.Show("Error there is no previous song");
            }
        }

        //button to play the last song in the listbox
        private void Lastbtn_Click(object sender, EventArgs e)
        {
            try
            {
                song = songlist.Last();
                DisplayCurrentSongTitle();
                PlaySound(song);
            }

            catch
            {
                MessageBox.Show("Error there is no last song");
            }
        }

        //button to find a song in the listbox and play it
        private void findbtn_Click(object sender, EventArgs e)
        {
            List<string> list = songlist.ToList();
            string search = findsongtb.Text;
            bool found = false;
            foreach(string item in list)
            {
                if (item.ToLower().Contains(search.ToLower()))
                {
                    PlaySound(item);
                    found = true;
                }
            }
            if (found == false)
            {
                MessageBox.Show("song doesn't exist in this list");
            }

        }

        //button to save the songs in the listbox to a csv file using 3rd party library
        private void Savebtn_Click(object sender, EventArgs e)
        {
            SaveCsv();
        }

        //button to sort the songs in the listbox using merge sort
        private void Sortbtn_Click(object sender, EventArgs e)
        {
            List<string> sortedList = MergeSort(songlist.ToList());
            songlist.Clear();
            foreach (string file in sortedList)
            {
                songlist.AddLast(file);
            }
            PopulateListBox();
        }
        //populates the list into the listbox from the csv file
        private void PopulateLinkedList()
        {
            string songPath = @"C:\Carl C# tafe\Client\Client\Songs";
            string[] songFiles = Directory.GetFiles(songPath);
            foreach (string file in songFiles)
            {
                song = file.ToString();
                songlist.AddLast(song);
            }
        }


        //method to merge sort the list
        private static List<string> MergeSort(List<string> copy)
        {
            if (copy.Count <= 1)
            {
                return copy;
            }

            List<string> left = new List<string>();
            List<string> right = new List<string>();

            int middle = copy.Count / 2;

            for (int b = 0; b < middle; b++)
            {
                left.Add(copy[b]);
            }
            for (int c = middle; c < copy.Count; c++)
            {
                right.Add(copy[c]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<string> Merge(List<string> left, List<string> right)
        {
            List<string> results = new List<string>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First().CompareTo(right.First()) <= 0)
                    {
                        results.Add(left.First());
                        left.Remove(left.First());
                    }
                    else
                    {
                        results.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    results.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    results.Add(right.First());
                    right.Remove(right.First());
                }
            }
            return results;
        }


        DataGrid dataGrid = new DataGrid();
        //button to load the songs from the csv file using a 3rd party library
        private void Loadbtn_Click(object sender, EventArgs e)
        {
            ReadCsv();
        }

        //populates the listbox with the linked list contents
        private void PopulateListBox()
        {
            // clear input boxes and list box
            songlistlb.Items.Clear();
            currentsongtb.Clear();
            // display linked list in the listBox
            foreach (var song in songlist)
            {
                songlistlb.Items.Add(song);
            }
                
        }

       
        //the code to select the sound in the system
        private void PlaySound(string playsong)
        {
            try
            {
                axWindowsMediaPlayer.URL = playsong;
                axWindowsMediaPlayer.Ctlcontrols.play();
            }

            catch
            {
                MessageBox.Show("Error cannot play sound");
            }
        }

        //method to display the song that is being played
        private void DisplayCurrentSongTitle()
        {
            currentsongtb.Clear();
            currentsongtb.Text = song;
        }

        //creating class for songs
        public class Song
        {
            [Name("songname")]
            public string Songname { get; set; }

        }
        public class SongMap : ClassMap<Song>
        {
            public SongMap()
            {
                Map(m => m.Songname).Name("songname");
            }
        }


        public class NewSongs
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }


        //using csvReader 3rd party to load music and populate in the listbox 
        public void ReadCsv()
        {
            using (CsvReader csv = new CsvReader(new StreamReader("songs1.csv"), true))
            {
                songlistlb.Items.Clear();

                int fieldCount = csv.FieldCount;

                string[] headers = csv.GetFieldHeaders();
                while (csv.ReadNextRecord())
                {
                    for (int i = 0; i < fieldCount; i++)
                        songlistlb.Items.Add(string.Format(csv[i]));
                    
                }
            }

        }
        //using StreamWriter to save the listbox to a csv file
        public void SaveCsv()
        {
            System.IO.StreamWriter save = new System.IO.StreamWriter("NewSongs.csv");
            foreach (var item in songlistlb.Items)
            {
                save.WriteLine(item.ToString());
            }
            save.Close();
            songlistlb.Items.Clear();
        }

    }
}
