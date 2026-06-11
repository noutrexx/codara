using System;
using System.IO;
using Codara.Application;
using UnityEngine;

namespace Codara.Infrastructure
{
    public sealed class FileLocalSaveService : ILocalSaveService
    {
        private readonly string rootPath;

        public FileLocalSaveService(string rootPath = null)
        {
            this.rootPath = rootPath ?? Path.Combine(UnityEngine.Application.persistentDataPath, "Saves");
            Directory.CreateDirectory(this.rootPath);
        }

        public bool Exists(string key)
        {
            return File.Exists(GetPath(key));
        }

        public string Load(string key)
        {
            var path = GetPath(key);
            var temporaryPath = path + ".tmp";
            if (!File.Exists(path) && File.Exists(temporaryPath))
            {
                File.Move(temporaryPath, path);
            }

            if (!File.Exists(path))
            {
                return null;
            }

            return File.ReadAllText(path);
        }

        public void Save(string key, string content)
        {
            var path = GetPath(key);
            var temporaryPath = path + ".tmp";
            File.WriteAllText(temporaryPath, content ?? string.Empty);

            if (File.Exists(path))
            {
                try
                {
                    File.Replace(temporaryPath, path, null);
                }
                catch (PlatformNotSupportedException)
                {
                    File.Copy(temporaryPath, path, true);
                    File.Delete(temporaryPath);
                }
            }
            else
            {
                File.Move(temporaryPath, path);
            }
        }

        public void Delete(string key)
        {
            var path = GetPath(key);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        private string GetPath(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("A save key is required.", nameof(key));
            }

            foreach (var character in Path.GetInvalidFileNameChars())
            {
                if (key.IndexOf(character) >= 0)
                {
                    throw new ArgumentException("Save key contains invalid characters.", nameof(key));
                }
            }

            return Path.Combine(rootPath, key + ".json");
        }
    }
}
