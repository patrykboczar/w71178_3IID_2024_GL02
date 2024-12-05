using System;
using System.Collections.Generic;

namespace lab5
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
    public interface IHasCreationDate
    {
        DateTime CreationDate { get; set; }
    }
    public class Book : IEntity<int>, IHasCreationDate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public DateTime CreationDate { get; set; }
    }
    public class Person : IEntity<int>, IHasCreationDate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
        public DateTime CreationDate { get; set; }
    }
    public interface IBaseRepository<T, TEntity> where T : IEntity<TEntity>
    {
        void Create(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        T Get(TEntity id);
        void Delete(TEntity id);
    }
    public interface IBookRepository : IBaseRepository<Book, int>
    {
    }
    public interface IPersonRepository : IBaseRepository<Person, int>
    {
    }
    public class zadanie3
    {
        public static void Wykonaj()
        {
            Book book = new Book
            {
                Id = 1,
                Title = "C# Programming",
                Author = "John Doe",
                Year = 2021,
                CreationDate = DateTime.Now
            };

            Person person = new Person
            {
                Id = 1,
                FirstName = "Jane",
                LastName = "Smith",
                Age = 30,
                CreationDate = DateTime.Now
            };

            person.BorrowedBooks.Add(book);

            Console.WriteLine($"Book: {book.Title}, Author: {book.Author}, Year: {book.Year}");
            Console.WriteLine($"Person: {person.FirstName} {person.LastName}, Age: {person.Age}");
            Console.WriteLine($"Borrowed Books: {string.Join(", ", person.BorrowedBooks.Select(b => b.Title))}");
        }
    }
}


