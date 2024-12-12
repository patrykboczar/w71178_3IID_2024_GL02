using System;
using System.Collections.Generic;
using System.Linq;

namespace lab6
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
        void Add(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        T GetById(TEntity id);
        void Remove(TEntity id);
    }
    public interface IBookRepository : IBaseRepository<Book, int>
    {
        IEnumerable<Book> FindByAuthor(string author);
        IEnumerable<Book> FindByYear(int year);
    }
    public interface IPersonRepository : IBaseRepository<Person, int>
    {
        IEnumerable<Book> GetBorrowedBooks(int personId);
        void AddBorrowedBook(int personId, Book book);
    }
    public class BookRepository : IBookRepository
    {
        private List<Book> books = new List<Book>();
        public void Add(Book book)
        {
            books.Add(book);
        }

        public void Update(Book book)
        {
            var existingBook = GetById(book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Year = book.Year;
                existingBook.CreationDate = book.CreationDate;
            }
        }
        public IEnumerable<Book> GetAll()
        {
            return books;
        }

        public Book GetById(int id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }
        public void Remove(int id)
        {
            var book = GetById(id);
            if (book != null)
            {
                books.Remove(book);
            }
        }
        public IEnumerable<Book> FindByAuthor(string author)
        {
            return books.Where(b => b.Author == author);
        }
        public IEnumerable<Book> FindByYear(int year)
        {
            return books.Where(b => b.Year == year);
        }
    }
    public class PersonRepository : IPersonRepository
    {
        private List<Person> people = new List<Person>();

        public void Add(Person person)
        {
            people.Add(person);
        }
        public void Update(Person person)
        {
            var existingPerson = GetById(person.Id);
            if (existingPerson != null)
            {
                existingPerson.FirstName = person.FirstName;
                existingPerson.LastName = person.LastName;
                existingPerson.Age = person.Age;
                existingPerson.BorrowedBooks = person.BorrowedBooks;
                existingPerson.CreationDate = person.CreationDate;
            }
        }
        public IEnumerable<Person> GetAll()
        {
            return people;
        }
        public Person GetById(int id)
        {
            return people.FirstOrDefault(p => p.Id == id);
        }
        public void Remove(int id)
        {
            var person = GetById(id);
            if (person != null)
            {
                people.Remove(person);
            }
        }
        public IEnumerable<Book> GetBorrowedBooks(int personId)
        {
            var person = GetById(personId);
            return person?.BorrowedBooks ?? Enumerable.Empty<Book>();
        }
        public void AddBorrowedBook(int personId, Book book)
        {
            var person = GetById(personId);
            if (person != null)
            {
                person.BorrowedBooks.Add(book);
            }
        }
    }
    public class zad1
    {
        public static void Wykonaj()
        {
            IBookRepository bookRepo = new BookRepository();
            IPersonRepository personRepo = new PersonRepository();

            Book book1 = new Book { Id = 1, Title = "C# Programming", Author = "John Doe", Year = 2021, CreationDate = DateTime.Now };
            Book book2 = new Book { Id = 2, Title = "Advanced C#", Author = "Jane Doe", Year = 2022, CreationDate = DateTime.Now };

            bookRepo.Add(book1);
            bookRepo.Add(book2);

            Person person = new Person { Id = 1, FirstName = "Anna", LastName = "Kowalska", Age = 22, CreationDate = DateTime.Now };
            personRepo.Add(person);

            personRepo.AddBorrowedBook(person.Id, book1);

            Console.WriteLine($"Książki autorstwa John Doe: {string.Join(", ", bookRepo.FindByAuthor("John Doe").Select(b => b.Title))}");
            Console.WriteLine($"Książki wydane w 2021 roku: {string.Join(", ", bookRepo.FindByYear(2021).Select(b => b.Title))}");
            Console.WriteLine($"Książki wypożyczone przez {person.FirstName} {person.LastName}: {string.Join(", ", personRepo.GetBorrowedBooks(person.Id).Select(b => b.Title))}");
        }
    }
}
