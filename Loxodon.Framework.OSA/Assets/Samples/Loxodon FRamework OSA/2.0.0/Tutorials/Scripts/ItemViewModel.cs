﻿/*
 * MIT License
 *
 * Copyright (c) 2018 Clark Yang
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of 
 * this software and associated documentation files (the "Software"), to deal in 
 * the Software without restriction, including without limitation the rights to 
 * use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies 
 * of the Software, and to permit persons to whom the Software is furnished to do so, 
 * subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all 
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE 
 * SOFTWARE.
 */

using Loxodon.Framework.Observables;
using UnityEngine;

namespace Loxodon.Framework.Tutorials.OSA
{
    public class ItemViewModel : ObservableObject
    {
        private ObservableList<ItemViewModel> items;
        private string title;
        private Color color;
        private bool selected = false;

        public ItemViewModel()
        {
            this.color = GetRandomColor();
        }

        public ItemViewModel(ObservableList<ItemViewModel> items)
        {
            this.items = items;
            this.color = GetRandomColor();
        }

        public string Title
        {
            get { return this.title; }
            set { this.Set<string>(ref title, value); }
        }

        public Color Color
        {
            get { return this.color; }
            set { this.Set<Color>(ref color, value); }
        }

        public bool Selected
        {
            get { return this.selected; }
            set { this.Set(ref selected, value); }
        }

        public void Select()
        {
            this.Selected = !selected;
            if (items != null && this.Selected)
            {
                foreach (var item in items)
                {
                    if (item == this)
                        continue;
                    item.Selected = false;
                }
            }
        }

        public static Color GetRandomColor(bool fullAlpha = false)
        {
            return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), fullAlpha ? 1f : Random.Range(0f, 1f));
        }
    }
}