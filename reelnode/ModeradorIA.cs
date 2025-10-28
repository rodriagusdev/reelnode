using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Reelnode
{
    public class Moderador
    {
        private readonly HashSet<string> _malasPalabras;

        public Moderador(string modelDirectory)
        {
            string badWordsPath = Path.Combine(modelDirectory, "malaspalabras.txt");
            _malasPalabras = new HashSet<string>(File.Exists(badWordsPath)
                ? File.ReadAllLines(badWordsPath).Select(w => w.Trim().ToLower())
                : new[] { "" });
        }

        public bool ComentarioEsToxico(string comment)
        {
            if (string.IsNullOrWhiteSpace(comment)) return false;

            try
            {
                string[] words = comment.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return words.Any(word => _malasPalabras.Contains(word));
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.Message", "Error en comentario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception($"Error al procesar comentario: {ex.Message}");
            }
        }
    }

}
