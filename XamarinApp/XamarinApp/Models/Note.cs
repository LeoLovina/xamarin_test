﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace XamarinApp.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public  int ID { get; set; }
        public string Text { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
    }
}
