using System.IO.MemoryMappedFiles;

namespace DocumentStorage.Application.Common.Interfaces;

public interface IFileSystem
{
    MemoryStream GetFileAsMemoryStream(string path);
    void CreateFile(MemoryStream memoryStream, string path);
    void DeleteFile(string path);
}