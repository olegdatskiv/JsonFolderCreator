﻿using System;
using System.Collections.Generic;

namespace jsonCreate
{
    public class Folder
    {
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public List<File> Files { get; set; }
        public List<Folder> Children { get; set; }
    }
}
