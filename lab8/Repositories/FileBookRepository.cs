using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using lab6;

namespace lab8.Repositories
{
    public class FileBookRepository : IBookRepository
    {
        private readonly string _filePath;

        public FileBookRepository(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<Book> GetAll()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Book>();
            }

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
        }

        public Book GetById(int id)
        {
            return GetAll().FirstOrDefault(b => b.Id == id);
        }

        public void Add(Book book)
        {
            var books = GetAll().ToList();
            books.Add(book);
            SaveToFile(books);
        }

        public void Update(Book book)
        {
            var books = GetAll().ToList();
            var existingBook = books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                SaveToFile(books);
            }
        }

        public void Remove(int id)
        {
            var books = GetAll().ToList();
            var bookToRemove = books.FirstOrDefault(b => b.Id == id);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                SaveToFile(books);
            }
        }

        private void SaveToFile(IEnumerable<Book> books)
        {
            var json = JsonSerializer.Serialize(books);
            File.WriteAllText(_filePath, json);
        }

        public IEnumerable<Book> FindByAuthor(string author)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> FindByYear(int year)
        {
            throw new NotImplementedException();
        }
    }
}
