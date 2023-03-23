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
using System.Drawing;
using System.Linq;

namespace digital_imaging.Images
{
    public class ScannedImageList
    {
        public ScannedImageList()
        {
            Images = new List<Image>();
        }

        public List<Image> Images { get; private set; }

        public IEnumerable<int> MoveUp(IEnumerable<int> selection)
        {
            var newSelection = new int[selection.Count()];
            int lowerBound = 0;
            int j = 0;
            foreach (int i in selection.OrderBy(x => x))
            {
                if (i != lowerBound++)
                {
                    Image img = Images[i];
                    Images.RemoveAt(i);
                    Images.Insert(i - 1, img);
                    newSelection[j++] = i - 1;
                }
                else
                {
                    newSelection[j++] = i;
                }
            }
            return newSelection;
        }

        public IEnumerable<int> MoveDown(IEnumerable<int> selection)
        {
            var newSelection = new int[selection.Count()];
            int upperBound = Images.Count - 1;
            int j = 0;
            foreach (int i in selection.OrderByDescending(x => x))
            {
                if (i != upperBound--)
                {
                    Image img = Images[i];
                    Images.RemoveAt(i);
                    Images.Insert(i + 1, img);
                   // img.MovedTo(i + 1);
                    newSelection[j++] = i + 1;
                }
                else
                {
                    newSelection[j++] = i;
                }
            }
            return newSelection;
        }

        public IEnumerable<int> RotateFlip(IEnumerable<int> selection, RotateFlipType rotateFlipType)
        {
            foreach (int i in selection)
            {
                Images[i].RotateFlip(rotateFlipType);
            }
            return selection.ToList();
        }

        public void Delete(IEnumerable<int> selection)
        {
            foreach (Image img in Images.ElementsAt(selection))
            {
                img.Dispose();
            }
            Images.RemoveAll(selection);
        }

    }
}
