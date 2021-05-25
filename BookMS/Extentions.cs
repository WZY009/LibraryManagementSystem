using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using BookMS.Models;

namespace BookMS {
    public static class Extentions {
        public static string[] ToStringArray(this Book book) => new string[] {
            book.Id,
            book.Name,
            book.Author,
            book.Press,
            book.Number.ToString()
        };
        public static Bitmap ScaleImage(this Image image, int maxWidth, int maxHeight) {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);
            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            Bitmap bmp = new Bitmap(newImage);
            return bmp;
        }
    }
}
