/*
    NAPS2 (Not Another PDF Scanner 2)
    http://sourceforge.net/projects/naps2/
    
    Copyright (C) 2009       Pavel Sorejs
    Copyright (C) 2012       Michael Adams
    Copyright (C) 2013       Peter De Leeuw
    Copyright (C) 2012-2013  Ben Olden-Cooligan

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace digital_imaging
{
    public partial class ThumbnailList : ListView
    {
        public ThumbnailList()
        {
            InitializeComponent();
            LargeImageList = ilThumbnailList;
        }

        public void UpdateImages(List<Image> images)
        {
            ilThumbnailList.Images.Clear();
            Clear();
            foreach (Image img in images)
            {
                Image thumb = img.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                ilThumbnailList.Images.Add(thumb);
                Items.Add("", ilThumbnailList.Images.Count - 1);
            }
        }

        public void UpdateView(List<Image> images)
        {
            ilThumbnailList.Images.Clear();
            foreach (Image img in images)
            {
                Image thumb = img.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                ilThumbnailList.Images.Add(thumb);
            }
        }

        public void ClearItems()
        {
            Clear();
            ilThumbnailList.Images.Clear();
        }
    }
}
